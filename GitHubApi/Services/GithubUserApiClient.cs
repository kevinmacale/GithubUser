using Flurl.Http;
using GitHubApi.Dtos;

namespace GitHubApi.Services
{
    public interface IGithubUserApiClient
    {
        /// <summary>
        /// This will get all the availbale users from github
        /// </summary>
        Task<IEnumerable<GithubUserProfileTransport>> GetUsers(string userAgent, CancellationToken cancellationToken = default);
    }

    public class GithubUserApiClient : IGithubUserApiClient
    {
        private readonly ILogger<GithubUserApiClient> _logger;
        private readonly IEnvironmentContext _environmentContext;

        public GithubUserApiClient(ILogger<GithubUserApiClient> logger,
            IEnvironmentContext environmentContext)
        {
            _logger = logger;
            _environmentContext = environmentContext;
        }

        public async Task<IEnumerable<GithubUserProfileTransport>> GetUsers(string userAgent, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"{nameof(GithubUserApiClient)} -- Get all users wass called");

            try
            {
                var githubUserTransports = await _environmentContext.GetUsersUrl()
                    .AllowAnyHttpStatus()
                    .WithHeaders(new { User_Agent = userAgent })
                    .GetJsonAsync<IEnumerable<GithubUserTransport>>(cancellationToken);

                var githubUserProfiles = new List<GithubUserProfileTransport>();

                await PopulateUserProfiles(userAgent, githubUserTransports, githubUserProfiles, cancellationToken);

                return githubUserProfiles;
            }
            catch (FlurlHttpException ex)
            {
                _logger.LogError($"{nameof(GithubUserApiClient)} -- Error on getting Github users", ex.Message);
                throw;
            }
        }

        private async Task PopulateUserProfiles(string userAgent, IEnumerable<GithubUserTransport> githubUserTransports, List<GithubUserProfileTransport> githubUserProfiles, CancellationToken cancellationToken)
        {
            try
            {
                foreach (var githubUserTransport in githubUserTransports)
                {
                    var githubUserProfileTransport = await githubUserTransport.ProfileUrl
                            .WithHeaders(new { User_Agent = userAgent })
                            .GetJsonAsync<GithubUserProfileTransport>(cancellationToken);

                    if (!githubUserProfiles.Any(x => x.Name == githubUserProfileTransport.Name))
                        githubUserProfiles.Add(githubUserProfileTransport);
                }
            }
            catch (Exception)
            {
                // Just let it go :) so the other profile can be populated
            }
        }
    }
}
