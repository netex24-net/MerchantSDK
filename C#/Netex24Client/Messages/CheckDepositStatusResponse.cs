using Netex24Clients.DataModels;

namespace Netex24Clients.Messages;

/// <summary>
/// Данные ответа проверки статуса депозита.
/// </summary>
public class CheckDepositStatusResponse : Netex24MerchantMessage
{
    /// <summary>
    /// Идентификатор депозита.
    /// </summary>
    public string DepositUid { get; set; }
        
    /// <summary>
    /// Статус.
    /// </summary>
    public DepositInvoiceStatuses StatusCode { get; set; }
}