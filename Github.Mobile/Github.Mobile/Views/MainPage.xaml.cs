using Github.Mobile.ViewModels;
using Github.Mobile.Views;

namespace Github.Mobile
{
    public partial class MainPage : BaseContentPage
    {
        public MainPage(MainViewModel mainViewModel)
        {
            BindingContext = mainViewModel;
            InitializeComponent();
        }
    }
}
