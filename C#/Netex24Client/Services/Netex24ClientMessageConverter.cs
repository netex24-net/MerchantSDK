using Netex24Clients.Messages;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Netex24Clients.Services;

/// <inheritdoc cref="INetex24ClientMessageConverter"/>
public class Netex24ClientMessageConverter : INetex24ClientMessageConverter
{
    /// <inheritdoc cref="INetex24ClientMessageConverter.ConvertToMessage{T}"/>
    public T ConvertToMessage<T>(string messageText)
        where T : INetex24MerchantMessage
    {
        if (!typeof(INetex24MerchantMessage).IsAssignableFrom(typeof(T)))
        {
            throw new InvalidOperationException("Тип не поддерживается.");
        }
        return JsonConvert.DeserializeObject<T>(messageText, new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        });
    }

    /// <inheritdoc cref="INetex24ClientMessageConverter.ConvertToText{T}"/>
    public string ConvertToText<T>(T message) where T : INetex24MerchantMessage
    {
        if (!typeof(INetex24MerchantMessage).IsAssignableFrom(typeof(T)))
        {
            throw new InvalidOperationException("Тип не поддерживается.");
        }
        return JsonConvert.SerializeObject(message, new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        });
    }
}