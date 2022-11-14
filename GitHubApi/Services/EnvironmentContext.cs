namespace GitHubApi.Services
{
    public interface IEnvironmentContext
    {
        /// <summary>
        /// Returns the github base url 
        /// </summary>
        string GetGithubUrl();

        /// <summary>
        /// Get the github users url
        /// </summary>
        string GetUsersUrl();
    }

    public class EnvironmentContext : IEnvironmentContext
    {
        private const string GITHUB_URL = "https://api.github.com/";

        public string GetGithubUrl()
        {
            return GITHUB_URL;
        }

        public string GetUsersUrl()
        {
            return $"{GITHUB_URL}users";
        }
    }
}
