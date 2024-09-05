namespace Test2.Senders.Interfaces;

public interface ISender
{
    /// <summary>
    /// Отправляет сообщение по указанному адресу, возвращает True в случае успешной доставки
    /// </summary>
    /// <param name="message"> текст сообщения </param>
    /// <param name="address"> адрес доставки, в зависимости от реализации может содержать 
    /// имя аккаунта, телефон, e-mail и тд и тп</param>
    /// <returns>Результат доставки, True, если сообщение успешно доставлено</returns>
    bool Send(string message, string address);
}
