using Netex24Clients.Messages;

namespace Netex24Clients.DataModels;

/// <summary>
/// Направление торговли.
/// </summary>
public class MerchantTradingDirection
{
    /// <summary>
    /// Базовая валюта.
    /// </summary>
    public PaymentCurrencyCode SourceCurrency { get; set; }
    /// <summary>
    /// Котируемая валюта.
    /// </summary>
    public PaymentCurrencyCode TargetCurrency { get; set; }
    /// <summary>
    /// Коэффициент.
    /// </summary>
    public decimal TradingCoefficient { get; set; }
    /// <summary>
    /// Базовая стоимость.
    /// </summary>
    public decimal BaseRate { get; set; }
}