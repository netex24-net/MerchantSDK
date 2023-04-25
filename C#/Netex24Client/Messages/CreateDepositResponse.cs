namespace Netex24Clients.Messages;

/// <summary>
/// Данные ответа создания депозита.
/// </summary>
public class CreateDepositResponse : Netex24MerchantMessage
{
    /// <summary>
    /// Клиент.
    /// </summary>
    public string Account { get; set; }
        
    /// <summary>
    /// Идентификатор депозита.
    /// </summary>
    public string DepositUid { get; set; }
        
    /// <summary>
    /// Лимиты депозитов.
    /// </summary>
    public GetLimitsResponse Limit { get; set; }
        
    /// <summary>
    /// Время ожидания оплаты.
    /// </summary>
    public TimeSpan? PaymentWaitingTime { get; set; }
}