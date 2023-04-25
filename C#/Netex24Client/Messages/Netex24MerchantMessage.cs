namespace Netex24Clients.Messages;

/// <inheritdoc cref="INetex24MerchantMessage"/>
public class Netex24MerchantMessage : INetex24MerchantMessage
{
    /// <summary>
    /// Код ошибки.
    /// </summary>
    public int? ErrorCode { get; set; }
    /// <summary>
    /// Текст ошибки.
    /// </summary>
    public string Error { get; set; }
}