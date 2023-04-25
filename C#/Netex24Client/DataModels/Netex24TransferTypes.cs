namespace Netex24Clients.DataModels;

/// <summary>
/// Типы переводов.
/// </summary>
public enum Netex24TransferTypes
{
    /// <summary>
    /// Прямой перевод.
    /// </summary>
    BankCards = 1,
    /// <summary>
    /// Перевод через qiwi.
    /// </summary>
    QiwiWallet = 2,
}