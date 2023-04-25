namespace Netex24Clients.Services;

/// <summary>
/// Сервис подписи сообщений для Netex24 Merchant.
/// </summary>
public interface INetex24ClientSignatureService
{
    /// <summary>
    /// Получить подпись запроса.
    /// </summary>
    /// <param name="request">Текст запроса.</param>
    /// <param name="id">Id мерчанта.</param>
    /// <param name="nonce">Номер.</param>
    /// <param name="privateKey">Ключ для подписи.</param>
    /// <returns>Подпись.</returns>
    string GetRequestSignature(string request, string id, string nonce, string privateKey);
}