namespace Test2.Entities.Interfaces;

public interface IUser
{
    /// <summary>
    /// Уникальный идентификатор
    /// </summary>
    string Id { get; }

    /// <summary>
    /// Метод доставки сообщения, напаример: 
    /// 0 -не нужна доставка, 1 - Телеграмм, 2 - СМС, 3 - e-mail, 4 - WhatsApp и тд и тп
    /// </summary>
    int DeliveryMethod { get; }

    /// <summary>
    /// Адресс, по которму будут отправляться сообщения. Зависит от метода доставки:
    /// аккаунт Телеграмм, номер телефона, e-mail и тд
    /// </summary>
    string Address { get; }
}
