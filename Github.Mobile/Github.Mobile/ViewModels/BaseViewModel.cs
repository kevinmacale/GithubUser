using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;

namespace Github.Mobile.ViewModels
{
    public abstract class BaseViewModel : ObservableObject
    { 
        /// <summary>
        /// Handles onload of the view
        /// </summary>
        public abstract Task OnAppearing();

        /// <summary>
        /// Handle unload of the view
        /// </summary>
        public abstract Task OnDisappearing();
    }
}
