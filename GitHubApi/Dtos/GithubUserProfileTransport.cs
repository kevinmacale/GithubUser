using Newtonsoft.Json;

namespace GitHubApi.Dtos
{
    public class GithubUserProfileTransport
    {
        /// <summary>
        /// Identification of the github user
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// login of the user
        /// </summary>
        [JsonProperty("login")]
        public string Login { get; set; } 
        
        /// <summary>
        /// Name of the user
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Avatar of the user
        /// </summary>
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        /// <summary>
        /// Company of the user
        /// </summary>
        [JsonProperty("company")]
        public string Company { get; set; }

        /// <summary>
        /// Number of followers of the user
        /// </summary>
        [JsonProperty("followers")]
        public int NumberOfFollowers { get; set; }

        /// <summary>
        /// Number of public repositories
        /// </summary>
        [JsonProperty("public_repos")]
        public int NumberOfPublicRepositories { get; set; }

        /// <summary>
        /// Number of avg followers per repositories
        /// </summary>
        public double AverageNumberOfFollowersPerRepository { get => NumberOfFollowers / NumberOfPublicRepositories; }
    }
}
