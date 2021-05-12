using MartinPulgar.Utils;
using MartinPulgar.Views.Pages;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MartinPulgar.ViewModels
{
    public class HomeViewModel
    {

        public HomeViewModel()
        {
            ConnectivityUtility.ListenForConnectionChanges();
        }

        private async Task NavigateToploadPage()
        {
            await Shell.Current.Navigation.PushModalAsync(new UploadPage());
        }

        /// <summary>
        /// Command to navigate to UploadPage
        /// </summary>
        ICommand _uploadDataCommand = null;

        public ICommand UploadDataCommand
        {
            get
            {
                return _uploadDataCommand ?? (_uploadDataCommand =
                                          new Command( async () => await NavigateToploadPage()));
            }
        }
    }
}
