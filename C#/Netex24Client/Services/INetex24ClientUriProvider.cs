namespace Netex24Clients.Services;

/// <summary>
/// Провайдер URI для Netex24 Merchant.
/// </summary>
public interface INetex24ClientUriProvider
{
    /// <summary>
    /// Получить URI для запроса лимитов депозита.
    /// </summary>
    Uri GetDepositLimitsUri();
    /// <summary>
    /// Получить URI для запроса лимитов выплаты.
    /// </summary>
    Uri GetPayoutLimitsUri();
    /// <summary>
    /// Получить URI для запроса создания выплаты.
    /// </summary>
    Uri GetPayoutRequestUri();
    /// <summary>
    /// Получить URI для запроса получения статуса выплаты.
    /// </summary>
    Uri GetPayoutStatusRequestUri();
    /// <summary>
    /// Получить URI для запроса создания депозита.
    /// </summary>
    Uri GetDepositRequestUri();
    /// <summary>
    /// Получить URI для запроса получения статуса депозита.
    /// </summary>
    Uri GetDepositStatusRequestUri();

    /// <summary>
    /// Получить URI для резервирования средств выплаты.
    /// </summary>
    /// <returns></returns>
    Uri GetHoldUri();
    
    /// <summary>
    /// Получить URI для подтвержения выплаты.
    /// </summary>
    /// <returns></returns>
    Uri GetConfirmationUri();
}