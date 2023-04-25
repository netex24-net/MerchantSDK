namespace Netex24Clients.DataModels;

/// <summary>
/// Статусы инвойса депозита.
/// </summary>
public enum DepositInvoiceStatuses
{
    /// <summary>
    /// Не определен.
    /// </summary>
    Undefined = 0,
        
    /// <summary>
    /// Новый.
    /// </summary>
    New = 1,
        
    /// <summary>
    /// Ожидается.
    /// </summary>
    Pending = 2,
        
    /// <summary>
    /// Подтвержден.
    /// </summary>
    Confirmed = 3,
        
    /// <summary>
    /// Отменен.
    /// </summary>
    Cancelled = 4,
        
    /// <summary>
    /// Начат клиринг.
    /// </summary>
    ClearingStarted = 5,
        
    /// <summary>
    /// Клиринг завершен.
    /// </summary>
    ClearingCompleted = 6,
}