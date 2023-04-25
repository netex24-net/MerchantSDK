using Netex24Clients.DataModels;

namespace Netex24Clients.Messages;

/// <summary>
/// Данные запроса получения лимитов.
/// </summary>
public abstract class GetLimitsRequest : INetex24MerchantMessage
{
    /// <summary>
    /// Тип лимитов.
    /// </summary>
    public Netex24TransferTypes Type { get; set; }
}