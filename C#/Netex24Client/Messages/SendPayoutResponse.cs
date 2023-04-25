namespace Netex24Clients.Messages;

/// <summary>
/// Данные ответа создания выплаты.
/// </summary>
public class SendPayoutResponse : Netex24MerchantMessage
{
    /// <summary>
    /// Идентификатор выплаты.
    /// </summary>
    public string PayoutId { get; set; }
        
    /// <summary>
    /// Номер выплаты.
    /// </summary>
    public long PaymentNumber { get; set; }
        
    /// <summary>
    /// Захолдированная сумма.
    /// </summary>
    public decimal? HoldTargetAmount { get; set; }
        
    /// <summary>
    /// Исходная сумма.
    /// </summary>
    public decimal? SourceAmount { get; set; }
}