using Netex24Clients.DataModels;

namespace Netex24Clients.Messages;

/// <summary>
/// Данные запроса создания депозита.
/// </summary>
public class CreateDepositRequest : INetex24MerchantMessage
{
    /// <summary>
    /// Тип депозита.
    /// </summary>
    public Netex24TransferTypes Type { get; set; }
        
    /// <summary>
    /// Клиент.
    /// </summary>
    public string Account { get; set; }
        
    /// <summary>
    /// Сумма.
    /// </summary>
    public decimal Amount { get; set; }
        
    /// <summary>
    /// Email клиента.
    /// </summary>
    public string Email { get; set; }
        
    /// <summary>
    /// Телефон клиента.
    /// </summary>
    public string PhoneNumber { get; set; }
        
    /// <summary>
    /// Uri для переадресации после оплаты.
    /// </summary>
    public string ReturnUri { get; set; }
}