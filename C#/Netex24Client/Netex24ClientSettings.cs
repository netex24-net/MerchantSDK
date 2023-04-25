namespace Netex24Clients;

/// <summary>
/// Настройки протокола Netex24 Merchant
/// </summary>
public class Netex24ClientSettings
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public string MerchantId { get; set; }
        
    /// <summary>
    /// Ключ.
    /// </summary>
    public string ApiKey { get; set; }
        
    /// <summary>
    /// Базовый URL.
    /// </summary>
    public string BaseUri { get; set; }
}