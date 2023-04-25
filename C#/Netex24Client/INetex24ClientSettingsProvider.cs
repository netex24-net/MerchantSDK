namespace Netex24Clients;

public interface INetex24ClientSettingsProvider
{
    Task<Netex24ClientSettings> GetSettingsAsync();
}