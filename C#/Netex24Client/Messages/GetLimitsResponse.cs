namespace Netex24Clients.Messages;

/// <summary>
/// Данные ответа получения лимитов.
/// </summary>
public class GetLimitsResponse : Netex24MerchantMessage
{
    /// <summary>
    /// Минимальный лимит.
    /// </summary>
    public decimal Min { get; set; }
        
    /// <summary>
    /// Максимальный лимит.
    /// </summary>
    public decimal Max { get; set; }
}