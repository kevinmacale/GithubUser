using Xamarin.CommunityToolkit.ObjectModel;

namespace Github.Mobile.Models
{
    public class GithubUserProfileModel : ObservableObject
    {
        private int _id;
        private string _name;
        private string _login;
        private string _avatarUrl;
        private string _company;
        private int _numberOfFollowers;
        private int _numberOfPublicRepositories;
        private double _averageNumberOfFollowersPerRepository;

        /// <summary>
        /// Identification of the github user
        /// </summary>
        public int Id { get => _id; set => SetProperty(ref _id, value); }

        /// <summary>
        /// Name of the user
        /// </summary>
        public string Name { get => _name; set => SetProperty(ref _name, value); }

        /// <summary>
        /// Login of the user
        /// </summary>
        public string Login { get => _login; set => SetProperty(ref _login, value); }

        /// <summary>
        /// Avatar of the user
        /// </summary>
        public string AvatarUrl { get => _avatarUrl; set => SetProperty(ref _avatarUrl, value); }

        /// <summary>
        /// Company of the user
        /// </summary>
        public string Company { get => _company; set => SetProperty(ref _company, value); }

        /// <summary>
        /// Number of followers of the user
        /// </summary>
        public int NumberOfFollowers { get => _numberOfFollowers; set => SetProperty(ref _numberOfFollowers, value); }

        /// <summary>
        /// Number of public repositories
        /// </summary>
        public int NumberOfPublicRepositories { get => _numberOfPublicRepositories; set => SetProperty(ref _numberOfPublicRepositories, value); }

        /// <summary>
        /// Number of avg followers per repositories
        /// </summary>
        public double AverageNumberOfFollowersPerRepository { get => _averageNumberOfFollowersPerRepository; set => SetProperty(ref _averageNumberOfFollowersPerRepository, value); }
    }
}
