using System.Collections.Concurrent;
using Test2.Entities.Interfaces;
using Test2.Repositories.Interfaces;
using Test2.Senders.Interfaces;

namespace Test2.Services;

public class Postman
{
    private readonly IUserRepository _userRepository;
    private readonly IDictionary<int, ISender> _senders;
    private readonly int _maxTotalThreads;
    private readonly IDictionary<int, int> _maxThreadsPerMethod;

    public ConcurrentBag<IMessage> FailedMessages { get; } = new ConcurrentBag<IMessage>();

    public Postman(IUserRepository userRepository, IDictionary<int, ISender> senders, int maxTotalThreads, IDictionary<int, int> maxThreadsPerMethod)
    {
        _userRepository = userRepository;
        _senders = senders;
        _maxTotalThreads = maxTotalThreads;
        _maxThreadsPerMethod = maxThreadsPerMethod;
    }

    public async Task SendAsync(IEnumerable<IMessage> messages)
    {
        var semaphore = new SemaphoreSlim(_maxTotalThreads);
        var methodSemaphores = new Dictionary<int, SemaphoreSlim>();

        foreach (var method in _maxThreadsPerMethod.Keys)
        {
            methodSemaphores[method] = new SemaphoreSlim(_maxThreadsPerMethod[method]);
        }

        var tasks = messages.Select(async message =>
        {
            await semaphore.WaitAsync();
            try
            {
                var user = _userRepository.Get(message.UserId);
                if (user == null)
                {
                    FailedMessages.Add(message);
                    return;
                }

                if (!_senders.TryGetValue(user.DeliveryMethod, out var sender))
                {
                    FailedMessages.Add(message);
                    return;
                }

                await methodSemaphores[user.DeliveryMethod].WaitAsync();
                try
                {
                    var success = sender.Send(message.MessageText, user.Address);
                    if (!success)
                    {
                        FailedMessages.Add(message);
                    }
                }
                finally
                {
                    methodSemaphores[user.DeliveryMethod].Release();
                }
            }
            catch (Exception)
            {
                FailedMessages.Add(message);
            }
            finally
            {
                semaphore.Release();
            }
        });

        await Task.WhenAll(tasks);
    }
}
