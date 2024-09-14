using System;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace Android.Gms.SafetyNet
{
    public static class SafetyNetApiAttestationResponseExtensions
    {
        public static string DecodeJwsResult (this SafetyNetApiAttestationResponse result, byte[] originalNonce)
        {
            return JWT.JsonWebToken.Decode (result.JwsResult, originalNonce);
        }

		public static async Task<bool> ValidateWithGoogle (this SafetyNetApiAttestationResponse result, string validationApiKey)
        {
            const string url = "https://www.googleapis.com/androidcheck/v1/attestations/verify?key=";

            var http = new HttpClient ();
            var jsonReq = "{ \"signedAttestation\": \"" + result.JwsResult + "\" }";
            var content = new StringContent (jsonReq, Encoding.Default, "application/json");

            var response = await http.PostAsync (url + validationApiKey, content);
            response.EnsureSuccessStatusCode ();

            using var stream = await response.Content.ReadAsStreamAsync();
            JsonDocument doc = await JsonDocument.ParseAsync(stream);
            JsonElement root = doc.RootElement;

            if (root.TryGetProperty ("isValidSignature", out var signature)) {
                return signature.GetBoolean ();
            } else {
                return false;
            }
        }
    }

    public static class Nonce
    {
        static readonly RNGCryptoServiceProvider rnd = new RNGCryptoServiceProvider ();

        public static byte[] Generate (int size = 16)
        {            
            var buffer = new byte[size];
            rnd.GetNonZeroBytes (buffer);
            return buffer;
        }
    }


}


