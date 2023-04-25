using Netex24Clients.DataModels;

namespace Netex24Clients.Messages;

/// <summary>
/// Данные запроса создания выплаты.
/// </summary>
public class SendPayoutRequest : INetex24MerchantMessage
{
    /// <summary>
    /// Клиент.
    /// </summary>
    public string ReceivingAccount { get; set; }
        
    /// <summary>
    /// Сумма.
    /// </summary>
    public decimal Amount { get; set; }
        
    /// <summary>
    /// Тип выплаты.
    /// </summary>
    public Netex24TransferTypes Type { get; set; }
        
    /// <summary>
    /// Внешний идентификатор.
    /// </summary>
    public string ExternalId { get; set; }
        
    /// <summary>
    /// Email клиента.
    /// </summary>
    public string Email { get; set; }
        
    /// <summary>
    /// Телефон клиента.
    /// </summary>
    public string PhoneNumber { get; set; }
}