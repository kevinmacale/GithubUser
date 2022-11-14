namespace GitHubApi.Dtos
{
    public class GetGithubUsersResponse
    {
        /// <summary>
        /// Users of github
        /// </summary>
        public IEnumerable<GithubUserProfileTransport> GithubUserProfileTransports { get; set; }
    }
}
