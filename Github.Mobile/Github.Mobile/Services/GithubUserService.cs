using Github.Mobile.Models;
using Github.Mobile.Services.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Github.Mobile.Services
{
    public interface IGithubUserService
    {
        /// <summary>
        /// This will get the user profiles
        /// </summary>
        Task<IEnumerable<GithubUserProfileModel>> GetGithubUserProfiles(CancellationToken cancellationToken = default);
    }

    public class GithubUserService : IGithubUserService
    {
        private readonly IGithubUserApiClient _githubUserApiClient;
        private readonly IObjectMapperService _objectMapperService;

        public GithubUserService(IGithubUserApiClient githubUserApiClient,
            IObjectMapperService objectMapperService)
        {
            _githubUserApiClient = githubUserApiClient;
            _objectMapperService = objectMapperService;
        }

        public async Task<IEnumerable<GithubUserProfileModel>> GetGithubUserProfiles(CancellationToken cancellationToken = default)
        {
            var getGithubUsersResponse = await _githubUserApiClient.GetUsers(cancellationToken);
            if (getGithubUsersResponse == null)
                throw new NullReferenceException(nameof(getGithubUsersResponse));

            if (getGithubUsersResponse.GithubUserProfileTransports == null)
                throw new NullReferenceException(nameof(getGithubUsersResponse.GithubUserProfileTransports));

            return getGithubUsersResponse.GithubUserProfileTransports.Select(x => _objectMapperService.Map<GithubUserProfileModel>(x));
        }
    }
}
