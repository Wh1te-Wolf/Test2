namespace Test2.Entities.Interfaces;

public interface IMessage
{
    /// <summary>
    /// Идентификатор пользователя, которому надо доставить сообщение
    /// </summary>
    int UserId { get; }

    /// <summary>
    /// Текст сообщения
    /// </summary>
    string MessageText { get; }
}
