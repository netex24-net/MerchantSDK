using System.ComponentModel.DataAnnotations;

namespace Netex24Clients.Messages;

public class HoldMoneyRequest : INetex24MerchantMessage
{
    /// <summary>
    /// Кошелек/карта получателя.
    /// </summary>
    [Required]
    public string ReceivingAccount { get; set; }

    /// <summary>
    /// Сумма выплаты.
    /// </summary>
    [Required]
    public decimal Amount { get; set; }

    /// <summary>
    /// Email получателя.<br/>
    /// <i>Обязательно при выплате в рублях.</i>.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Номер телефона получателя.<br/>
    /// <i>Обязательно при выплате в рублях.</i>.
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Внешний идентификатор выплаты.
    /// </summary>
    public string ExternalId { get; set; }

    /// <summary>
    /// Тип выплаты:<br/>
    /// 1 - На карту (default)<br/>
    /// 2 - На кошелёк<br/>
    /// <i>Используется только для выплат в рублях.</i>
    /// </summary>
    public int? Type { get; set; }

}