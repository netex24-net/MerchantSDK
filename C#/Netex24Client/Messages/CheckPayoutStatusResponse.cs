using Netex24Clients.DataModels;

namespace Netex24Clients.Messages;

/// <summary>
/// Данные ответа проверки статуса выплаты.
/// </summary>
public class CheckPayoutStatusResponse : Netex24MerchantMessage
{
    /// <summary>
    /// Идентификатор выплаты.
    /// </summary>
    public string PayoutId { get; set; }

    /// <summary>
    /// Статус.
    /// </summary>
    public PayoutStatuses StatusCode { get; set; }
}