using Github.Mobile.Models;
using Github.Mobile.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Github.Mobile.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IGithubUserService _githubUserService;
        private ObservableCollection<GithubUserProfileModel> _githubUserProfileModels;
        private bool _isLoading;

        public MainViewModel(IGithubUserService githubUserService)
        {
            _githubUserService = githubUserService;

            GithubUserProfileModels = new ObservableCollection<GithubUserProfileModel>();
        }

        /// <summary>
        /// Flag to know if the view is loading or not
        /// </summary>
        public bool IsLoading { get => _isLoading; set => SetProperty(ref _isLoading, value); }

        /// <summary>
        /// holds the list of github users
        /// </summary>
        public ObservableCollection<GithubUserProfileModel> GithubUserProfileModels { get => _githubUserProfileModels; set => SetProperty(ref _githubUserProfileModels, value); }

        /// <summary>
        /// handles on appearing of the view
        /// </summary>
        public override async Task OnAppearing()
        {
            try
            {
                IsLoading = true;

                var githubUserProfileModels = await _githubUserService.GetGithubUserProfiles();

                foreach (var gitHubUsers in githubUserProfileModels)
                {
                    await Task.Delay(100);
                    GithubUserProfileModels.Add(gitHubUsers);
                }

                IsLoading = false;
            }
            catch (Exception)
            {
                IsLoading = false;
                await Application.Current.MainPage.DisplayAlert("Error", "An error occured during loading of Github Users", "Ok");
            }
        }

        /// <summary>
        /// Handles disappearing of the view
        /// </summary>
        public override Task OnDisappearing()
        {
            return Task.CompletedTask;
        }
    }
}
