
namespace Netex24Clients.Services;

/// <inheritdoc cref="INetex24ClientUriProvider"/>
public class Netex24ClientUriProvider : INetex24ClientUriProvider
{
    private readonly Netex24ClientSettings? _settings;
    
    /// <summary>
    /// Конструктор провайдера URI для Netex24 Merchant.
    /// </summary>
    /// <param name="settings">Настройки.</param>
    public Netex24ClientUriProvider(Netex24ClientSettings? settings)
    {
        _settings = settings;
    }
    
    /// <summary>
    /// Конструктор провайдера URI для Netex24 Merchant.
    /// </summary>
    public Netex24ClientUriProvider(INetex24ClientSettingsProvider settingsProvider)
    {
        _settings = settingsProvider!
            .GetSettingsAsync()
            .ConfigureAwait(true)
            .GetAwaiter()
            .GetResult();
    }

    /// <inheritdoc cref="INetex24ClientUriProvider.GetDepositLimitsUri"/>
    public Uri GetDepositLimitsUri()
    {
        return new Uri($"{_settings.BaseUri?.Trim('/').Trim('\\')}/Merchants/GetDepositLimits");
    }

    /// <inheritdoc cref="INetex24ClientUriProvider.GetPayoutLimitsUri"/>
    public Uri GetPayoutLimitsUri()
    {
        return new Uri($"{_settings.BaseUri?.Trim('/').Trim('\\')}/Merchants/GetPayoutLimits");
    }

    /// <inheritdoc cref="INetex24ClientUriProvider.GetPayoutRequestUri"/>
    public Uri GetPayoutRequestUri()
    {
        return new Uri($"{_settings.BaseUri?.Trim('/').Trim('\\')}/Merchants/SendPayout");
    }

    /// <inheritdoc cref="INetex24ClientUriProvider.GetPayoutStatusRequestUri"/>
    public Uri GetPayoutStatusRequestUri()
    {
        return new Uri($"{_settings.BaseUri?.Trim('/').Trim('\\')}/Merchants/CheckPayoutStatus");
    }

    /// <inheritdoc cref="INetex24ClientUriProvider.GetDepositRequestUri"/>
    public Uri GetDepositRequestUri()
    {
        return new Uri($"{_settings.BaseUri?.Trim('/').Trim('\\')}/Merchants/CreateDeposit");
    }

    /// <inheritdoc cref="INetex24ClientUriProvider.GetDepositStatusRequestUri"/>
    public Uri GetDepositStatusRequestUri()
    {
        return new Uri($"{_settings.BaseUri?.Trim('/').Trim('\\')}/Merchants/CheckDepositStatus");
    }

    /// <inheritdoc cref="INetex24ClientUriProvider.GetHoldUri"/>
    public Uri GetHoldUri()
    {
        return new Uri($"{_settings.BaseUri?.Trim('/').Trim('\\')}/Merchants/HoldPayout");

    }

    /// <inheritdoc cref="INetex24ClientUriProvider.GetConfirmationUri"/>
    public Uri GetConfirmationUri()
    {
        return new Uri($"{_settings.BaseUri?.Trim('/').Trim('\\')}/Merchants/ConfirmPayout");
    }
}