namespace Netex24Clients.Messages;

/// <summary>
/// Данные запроса проверки статуса депозита.
/// </summary>
public class CheckDepositStatusRequest : INetex24MerchantMessage
{
    /// <summary>
    /// Идентификатор депозита.
    /// </summary>
    public string DepositUid { get; set; }
}