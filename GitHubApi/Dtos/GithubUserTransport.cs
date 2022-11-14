using Newtonsoft.Json;

namespace GitHubApi.Dtos
{
    public class GithubUserTransport
    {
        /// <summary>
        /// Identification of the github user
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// url of the main profile
        /// </summary>
        [JsonProperty("url")]
        public string ProfileUrl { get; set; }
    }
}
