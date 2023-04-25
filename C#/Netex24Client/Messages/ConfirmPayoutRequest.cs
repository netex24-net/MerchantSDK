using System.ComponentModel.DataAnnotations;

namespace Netex24Clients.Messages;

public class ConfirmPayoutRequest : INetex24MerchantMessage
{
    /// <summary>
    /// Идентификатор выплаты.
    /// </summary>
    [Required]
    public Guid PayoutId { get; set; }
}