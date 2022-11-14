namespace Github.Mobile.Dtos
{
    public class GithubUserTransport
    {
        /// <summary>
        /// Identification of the github user
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// url of the main profile
        /// </summary>
        public string ProfileUrl { get; set; }
    }
}
