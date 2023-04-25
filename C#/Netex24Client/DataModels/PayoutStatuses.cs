namespace Netex24Clients.DataModels;

/// <summary>
/// Статусы выплаты.
/// </summary>
public enum PayoutStatuses
{
    /// <summary>
    /// Не определен.
    /// </summary>
    Undefined = 0,
        
    /// <summary>
    /// Захолдирован.
    /// </summary>
    Hold = 1,
        
    /// <summary>
    /// Подтвержден.
    /// </summary>
    Confirmed = 2,
        
    /// <summary>
    /// Отправляется.
    /// </summary>
    Sending = 3,
        
    /// <summary>
    /// Отправлен.
    /// </summary>
    Sent = 4,
        
    /// <summary>
    /// Отменен.
    /// </summary>
    Cancelled = 5
}