namespace Netex24Clients.Messages;

/// <summary>
/// Данные запроса проверки статуса выплаты.
/// </summary>
public class CheckPayoutStatusRequest : INetex24MerchantMessage
{
    /// <summary>
    /// Идентификатор выплаты.
    /// </summary>
    public string PayoutId { get; set; }
}