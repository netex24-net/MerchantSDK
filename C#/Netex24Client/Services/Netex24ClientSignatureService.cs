using System.Security.Cryptography;
using System.Text;

namespace Netex24Clients.Services;

/// <inheritdoc cref="INetex24ClientSignatureService"/>
public class Netex24ClientSignatureService : INetex24ClientSignatureService
{
    /// <inheritdoc cref="INetex24ClientSignatureService.GetRequestSignature"/>
    public string GetRequestSignature(string request, string id, string nonce, string privateKey)
    {
        var signatureRawData = $"{request}{id}{nonce}".ToLowerInvariant().Replace("{}", "");
        var signatureRawDataBytes = Encoding.UTF8.GetBytes(signatureRawData);
        using var sha512 = new SHA512Managed();
        var signatureRawDataHash = sha512.ComputeHash(signatureRawDataBytes);
        var secretKeyByteArray = Convert.FromBase64String(privateKey);

        using var ecdsa = ECDsa.Create();
        ecdsa.ImportECPrivateKey(secretKeyByteArray, out _);
        var signatureBytes = ecdsa.SignHash(signatureRawDataHash);

        var signatureHex = BitConverter.ToString(signatureBytes).Replace("-", "");

        return $"{signatureHex}:{id}:{nonce}";
    }
}