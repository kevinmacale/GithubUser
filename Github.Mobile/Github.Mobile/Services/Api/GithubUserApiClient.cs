using Github.Mobile.Dtos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Github.Mobile.Services.Api
{
    public interface IGithubUserApiClient
    {
        /// <summary>
        /// this will get github users
        /// </summary>
        Task<GetGithubUsersResponse> GetUsers(CancellationToken cancellationToken = default);
    }

    public class GithubUserApiClient : BaseApiClient, IGithubUserApiClient
    {
        private readonly string _getUsersUrl = "https://192.168.100.2:7019/GithubUser";

        public async Task<GetGithubUsersResponse> GetUsers(CancellationToken cancellationToken = default)
        {
            var getGithubUsersResponse = await GetAsync<GetGithubUsersResponse>(_getUsersUrl, cancellationToken);

            return getGithubUsersResponse;
        }
    }
}
