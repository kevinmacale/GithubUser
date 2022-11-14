using System.Collections.Generic;

namespace Github.Mobile.Dtos
{
    public class GetGithubUsersResponse
    {
        /// <summary>
        /// Users of github
        /// </summary>
        public IEnumerable<GithubUserProfileTransport> GithubUserProfileTransports { get; set; }
    }
}
