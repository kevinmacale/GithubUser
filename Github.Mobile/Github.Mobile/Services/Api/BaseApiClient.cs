using Flurl.Http;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Github.Mobile.Services.Api
{
    public abstract class BaseApiClient
    {
        private readonly TimeSpan _defaultTimeout = TimeSpan.FromSeconds(60);

        /// <summary>
        /// Call Get method with the desired endpoint
        /// </summary>
        public async Task<T> GetAsync<T>(string endpoint, CancellationToken cancellationToken = default)
        {
            return await endpoint
                .WithTimeout(_defaultTimeout)
                .GetJsonAsync<T>(cancellationToken);
        }

        /// <summary>
        /// Call Post method with the desired endpoint
        /// </summary>
        public async Task<T> PostAsync<T>(string endpoint, object data = null, CancellationToken cancellationToken = default)
        {
            if (data != null)
                return await endpoint
                    .WithTimeout(_defaultTimeout)
                    .PostJsonAsync(data, cancellationToken)
                    .ReceiveJson<T>();
            else
                return await endpoint
                    .WithTimeout(_defaultTimeout)
                    .PostJsonAsync(cancellationToken)
                    .ReceiveJson<T>();
        }
    }
}
