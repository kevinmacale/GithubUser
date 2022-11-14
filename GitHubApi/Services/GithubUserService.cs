using GitHubApi.Dtos;

namespace GitHubApi.Services
{
    public interface IGithubUserService
    {
        /// <summary>
        /// This will get the github users
        /// </summary>
        Task<GetGithubUsersResponse> GetUsers(string userAgent, CancellationToken cancellationToken = default);
    }

    public class GithubUserService : IGithubUserService
    {
        private readonly ILogger<GithubUserService> _logger;
        private readonly IGithubUserApiClient _githubUserApiClient;

        public GithubUserService(ILogger<GithubUserService> logger,
            IGithubUserApiClient githubUserApiClient)
        {
            _logger = logger;
            _githubUserApiClient = githubUserApiClient;
        }

        public async Task<GetGithubUsersResponse> GetUsers(string userAgent, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"{nameof(GithubUserService)} -- Get all users was called");

            try
            {
                var githubUserProfileTransports = await _githubUserApiClient.GetUsers(userAgent, cancellationToken);
                return new GetGithubUsersResponse()
                {
                    GithubUserProfileTransports = githubUserProfileTransports.OrderBy(x => x.Name)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(GithubUserService)} -- Error on getting Github users", ex.Message);
                throw;
            }
        }
    }
}
