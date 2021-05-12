using MartinPulgar.Services.Dependency.Interfaces;
using MartinPulgar.Styles;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MartinPulgar.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UploadPage : ContentPage
    {
        public UploadPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DependencyService.Get<IStatusBar>().ChangeStatusBarColorToBlack();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ThemeHelper.GetAppTheme();
        }
    }
}