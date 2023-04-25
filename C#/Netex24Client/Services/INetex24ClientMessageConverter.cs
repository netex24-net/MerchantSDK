using Netex24Clients.Messages;

namespace Netex24Clients.Services;

/// <summary>
/// Конвертер сообщений для Netex24 Merchant.
/// </summary>
public interface INetex24ClientMessageConverter
{
    /// <summary>
    /// Конвертирует текстовое сообщение в инстанс класса данного сообщения.
    /// </summary>
    /// <typeparam name="T">Тип сообщения.</typeparam>
    /// <param name="messageText"></param>
    /// <returns>Инстанс класса сообщения.</returns>
    T ConvertToMessage<T>(string messageText) where T : INetex24MerchantMessage;

    /// <summary>
    /// Конвертирует сообщение как инстанс класса в текстовое представление.
    /// </summary>
    /// <typeparam name="T">Тип сообщения.</typeparam>
    /// <param name="message">Инстанс класса сообщения.</param>
    /// <returns></returns>
    string ConvertToText<T>(T message) where T : INetex24MerchantMessage;
}