using System.Text;
using Netex24Clients.Messages;
using Netex24Clients.Services;

namespace Netex24Clients;

/// <summary>
/// Протокол Netex24 Merchant.
/// </summary>
public class Netex24Client : INetex24Client
{
    private const string HttpClientName = "netex24client";

    private readonly Netex24ClientSettings _settings;
    private readonly INetex24ClientUriProvider _uriProvider;
    private readonly INetex24ClientMessageConverter _messageConverter;
    private readonly INetex24ClientSignatureService _signatureService;
    private readonly IHttpClientFactory _httpClientFactory;

    public Netex24Client(
        Netex24ClientSettings settings,
        INetex24ClientUriProvider uriProvider,
        INetex24ClientMessageConverter messageConverter,
        INetex24ClientSignatureService signatureService,
        IHttpClientFactory httpClientFactory)
    {
        _settings = settings;
        _uriProvider = uriProvider;
        _messageConverter = messageConverter;
        _signatureService = signatureService;
        _httpClientFactory = httpClientFactory;
    }

    public Netex24Client(
        INetex24ClientSettingsProvider settingsProvider,
        INetex24ClientUriProvider uriProvider,
        INetex24ClientMessageConverter messageConverter,
        INetex24ClientSignatureService signatureService,
        IHttpClientFactory httpClientFactory)
    {
        _settings = settingsProvider
            .GetSettingsAsync()
            .ConfigureAwait(true)
            .GetAwaiter()
            .GetResult()!;
        _uriProvider = uriProvider;
        _messageConverter = messageConverter;
        _signatureService = signatureService;
        _httpClientFactory = httpClientFactory;
    }
    
    /// <inheritdoc cref="INetex24Client.SendAsync(GetDepositLimitsRequest)"/>
    public Task<GetLimitsResponse> SendAsync(GetDepositLimitsRequest request)
    {
        var uri = _uriProvider.GetDepositLimitsUri();
        var requestText = _messageConverter.ConvertToText(request);
        return SignAndSendRequestAsync<GetLimitsResponse>(uri, requestText);
    }

    /// <inheritdoc cref="INetex24Client.SendAsync(GetPayoutLimitsRequest)"/>
    public Task<GetLimitsResponse> SendAsync(GetPayoutLimitsRequest request)
    {
        var uri = _uriProvider.GetPayoutLimitsUri();
        var requestText = _messageConverter.ConvertToText(request);
        return SignAndSendRequestAsync<GetLimitsResponse>(uri, requestText);
    }

    /// <inheritdoc cref="INetex24Client.SendAsync(SendPayoutRequest)"/>
    public Task<SendPayoutResponse> SendAsync(SendPayoutRequest request)
    {
        var uri = _uriProvider.GetPayoutRequestUri();
        var requestText = _messageConverter.ConvertToText(request);
        return SignAndSendRequestAsync<SendPayoutResponse>(uri, requestText);
    }

    /// <inheritdoc cref="INetex24Client.SendAsync(CheckPayoutStatusRequest)"/>
    public Task<CheckPayoutStatusResponse> SendAsync(CheckPayoutStatusRequest request)
    {
        var uri = _uriProvider.GetPayoutStatusRequestUri();
        var requestText = _messageConverter.ConvertToText(request);
        return SignAndSendRequestAsync<CheckPayoutStatusResponse>(uri, requestText);
    }

    /// <inheritdoc cref="INetex24Client.SendAsync(CreateDepositRequest)"/>
    public Task<CreateDepositResponse> SendAsync(CreateDepositRequest request)
    {
        var uri = _uriProvider.GetDepositRequestUri();
        var requestText = _messageConverter.ConvertToText(request);
        return SignAndSendRequestAsync<CreateDepositResponse>(uri, requestText);
    }

    /// <inheritdoc cref="INetex24Client.SendAsync(CheckDepositStatusRequest)"/>
    public Task<CheckDepositStatusResponse> SendAsync(CheckDepositStatusRequest request)
    {
        var uri = _uriProvider.GetDepositStatusRequestUri();
        var requestText = _messageConverter.ConvertToText(request);
        return SignAndSendRequestAsync<CheckDepositStatusResponse>(uri, requestText);
    }
    
    /// <inheritdoc cref="INetex24Client.SendAsync(HoldMoneyRequest)"/>
    public Task<SendPayoutResponse> SendAsync(HoldMoneyRequest request)
    {
        var uri = _uriProvider.GetHoldUri();
        var requestText = _messageConverter.ConvertToText(request);
        return SignAndSendRequestAsync<SendPayoutResponse>(uri, requestText);
    }

    /// <inheritdoc cref="INetex24Client.SendAsync(ConfirmPayoutRequest)"/>
    public Task<SendPayoutResponse> SendAsync(ConfirmPayoutRequest request)
    {
        var uri = _uriProvider.GetConfirmationUri();
        var requestText = _messageConverter.ConvertToText(request);
        return SignAndSendRequestAsync<SendPayoutResponse>(uri, requestText);
    }

    private async Task<T> SignAndSendRequestAsync<T>(Uri uri, string message, string requestType = "POST") where T : INetex24MerchantMessage
    {
        using var httpClient = _httpClientFactory.CreateClient(HttpClientName);
        var nonce = DateTimeOffset.Now.Ticks.ToString();
        var signature = _signatureService.GetRequestSignature(message, _settings.MerchantId, nonce, _settings.ApiKey);
        httpClient.DefaultRequestHeaders.Remove("ECDSA");
        httpClient.DefaultRequestHeaders.Add("ECDSA", signature);

        var stringContent = new StringContent(message, Encoding.UTF8, "application/json");
        var response = requestType switch
        {
            "POST" => await httpClient.PostAsync(uri, stringContent),
            "GET" => await httpClient.GetAsync(uri),
            _ => throw new InvalidOperationException()
        };
        var responseText = await response.Content.ReadAsStringAsync();

        return _messageConverter.ConvertToMessage<T>(responseText);
    }
}