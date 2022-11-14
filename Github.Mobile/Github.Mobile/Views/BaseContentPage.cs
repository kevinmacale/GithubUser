using Github.Mobile.ViewModels;
using Xamarin.Forms;

namespace Github.Mobile.Views
{
    public abstract class BaseContentPage : ContentPage
    {
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var vm = GetViewModel<BaseViewModel>();
            if (vm != null)
                await vm.OnAppearing();
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            var vm = GetViewModel<BaseViewModel>();
            if (vm != null)
                await vm.OnDisappearing();
        }

        protected T GetViewModel<T>() where T : BaseViewModel
        {
            return BindingContext as T;
        }
    }
}
