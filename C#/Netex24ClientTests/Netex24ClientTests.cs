using System.Net.Security;
using Netex24Clients;
using Netex24Clients.Messages;
using Netex24Clients.Services;
using NSubstitute;
using NUnit.Framework;

namespace Netex24ClientTests;

public class Tests
{
    private INetex24Client _target;
    private string privateKey = "***";
    private INetex24ClientSettingsProvider settingsProvider;

    [SetUp]
    public void Setup()
    {
        settingsProvider = Substitute.For<INetex24ClientSettingsProvider>();
        settingsProvider
            .GetSettingsAsync()
            .Returns(new Netex24ClientSettings
        {
            BaseUri = "https://netex24.net/api/",
            ApiKey = privateKey,
            MerchantId = "440a41f7-8267-4509-9338-7b99aee364a8"
        });
        
        var _httpClientFactory = Substitute.For<IHttpClientFactory>();
        var _httpClient = new HttpClient(new HttpClientHandler
        {

            MaxConnectionsPerServer = 1,
            ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                if (sslPolicyErrors == SslPolicyErrors.None)
                {
                    return true;
                }

                return false;
            },
            AllowAutoRedirect = true
        });
        var uri = new Netex24ClientUriProvider(settingsProvider);
        _httpClientFactory.CreateClient(Arg.Any<string>()).Returns(_httpClient);
        _target = new Netex24Client(
            settingsProvider,
             uri,
            new Netex24ClientMessageConverter(),
            new Netex24ClientSignatureService(),
            _httpClientFactory);
    }

    [Test]
    public async Task CanGetDepositLimitsAsync()
    {
        var response = await _target.SendAsync(new GetDepositLimitsRequest());
        Assert.That(response.Min, Is.EqualTo(5));
    }
    
    [Test]
    public async Task CanCreateDepositAsync()
    {
        var r = new CreateDepositRequest
        {
            Amount = 10,
        };
        var response = await _target.SendAsync(r);
        Assert.NotNull(response.Account);
    }
    
    [Test]
    public async Task CanHoldMoneyAsync()
    {
        var r = new HoldMoneyRequest
        {
            Amount = 5,
            PhoneNumber = "+79080000000",
            Type = 2,
            ReceivingAccount = "+79080000000",
        };
        
        var response = await _target.SendAsync(r);
        Assert.NotNull(response.PayoutId);
    }
    
    [Test]
    public async Task CanConfirmPayoutAsync()
    {
        var r = new ConfirmPayoutRequest
        {
            PayoutId = Guid.Parse("e1a864ff-3cfb-4b7e-86c3-2df4a0492a6c"),
        };
        
        var response = await _target.SendAsync(r);
        Assert.NotNull(response.PayoutId);
    }
}