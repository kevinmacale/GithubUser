using Flurl.Http.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Github.Mobile.Services.Api
{
    public class CustomHttpClientFactory : DefaultHttpClientFactory
    {
        /// <summary>
        /// Override to customize how HttpClient is created/configured
        /// </summary>
        public override HttpClient CreateHttpClient(HttpMessageHandler handler)
        {
            return new HttpClient(CreateMessageHandler());
        }

        /// <summary>
        /// override to customize how HttpMessageHandler is created/configured
        /// </summary>
        public override HttpMessageHandler CreateMessageHandler()
        {
            return new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
                {
#if DEBUG
                    return cert.Issuer == "CN=localhost";
#elif !DEBUG
                    return errors == System.Net.Security.SslPolicyErrors.None;
#endif
                }
            };
        }
    }
}
