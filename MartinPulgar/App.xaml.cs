using MartinPulgar.Styles;
using MartinPulgar.Views.Pages;
using Xamarin.Forms;

[assembly: ExportFont("fa-brands.ttf", Alias = "FontAwesomeBrands")]
[assembly: ExportFont("fa-solid.ttf", Alias = "FontAwesomeSolid")]
[assembly: ExportFont("fa-regular.ttf", Alias = "FontAwesomeRegular")]
[assembly: ExportFont("fa-light.ttf", Alias = "FontAwesomeLight")]
[assembly: ExportFont("lato-regular.ttf", Alias = "LatoRegular")]
[assembly: ExportFont("lato-bold.ttf", Alias = "LatoBold")]
namespace MartinPulgar
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            // Get App Theme
            ThemeHelper.ChangeToLightTheme();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
