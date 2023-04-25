using Netex24Clients.Messages;

namespace Netex24Clients;

/// <summary>
/// Интерфейс протокола Netex24 Merchant.
/// </summary>
public interface INetex24Client 
{
    /// <summary>
    /// Запрос на получение лимитов депозита.
    /// </summary>
    /// <param name="request">Данные запроса.</param>
    /// <returns>Лимиты депозита.</returns>
    Task<GetLimitsResponse> SendAsync(GetDepositLimitsRequest request);
        
    /// <summary>
    /// Запрос на получение лимитов выплаты.
    /// </summary>
    /// <param name="request">Данные запроса.</param>
    /// <returns>Лимиты выплаты.</returns>
    Task<GetLimitsResponse> SendAsync(GetPayoutLimitsRequest request);
        
    /// <summary>
    /// Запрос на создание выплаты.
    /// </summary>
    /// <param name="request">Данные запроса.</param>
    /// <returns>Информация о созданной выплате.</returns>
    Task<SendPayoutResponse> SendAsync(SendPayoutRequest request);
        
    /// <summary>
    /// Запрос на проверку статуса выплаты.
    /// </summary>
    /// <param name="request">Данные запроса.</param>
    /// <returns>Информация о выплате.</returns>
    Task<CheckPayoutStatusResponse> SendAsync(CheckPayoutStatusRequest request);
        
    /// <summary>
    /// Запрос на создание депозита.
    /// </summary>
    /// <param name="request">Данные запроса.</param>
    /// <returns>Информация о созданном депозите.</returns>
    Task<CreateDepositResponse> SendAsync(CreateDepositRequest request);
        
    /// <summary>
    /// Запрос на проверку статуса депозита.
    /// </summary>
    /// <param name="request">Данные запроса.</param>
    /// <returns>Информация о депозите.</returns>
    Task<CheckDepositStatusResponse> SendAsync(CheckDepositStatusRequest request);
    
    
    /// <summary>
    /// Запрос на резервирование средств для выплаты.
    /// </summary>
    /// <param name="request">Данные запроса.</param>
    /// <returns>Информация о депозите.</returns>
    Task<SendPayoutResponse> SendAsync(HoldMoneyRequest request);
    
    /// <summary>
    /// Запрос на подтверждение выплаты.
    /// </summary>
    /// <param name="request">Данные запроса.</param>
    /// <returns>Информация о депозите.</returns>
    Task<SendPayoutResponse> SendAsync(ConfirmPayoutRequest request);
}