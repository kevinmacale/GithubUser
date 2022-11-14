namespace Github.Mobile.Dtos
{
    public class GithubUserProfileTransport
    {
        /// <summary>
        /// Identification of the github user
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Avatar of the user
        /// </summary>
        public string AvatarUrl { get; set; }

        /// <summary>
        /// Company of the user
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Number of followers of the user
        /// </summary>
        public int NumberOfFollowers { get; set; }

        /// <summary>
        /// Number of public repositories
        /// </summary>
        public int NumberOfPublicRepositories { get; set; }

        /// <summary>
        /// Number of avg followers per repositories
        /// </summary>
        public double AverageNumberOfFollowersPerRepository { get; set; }
    }
}
