
using MartinPulgar.ViewModels;
using TinyIoC;

namespace MartinPulgar.Services.Dependency
{
    public class IOCService
    {
        public HomeViewModel HomeViewModel
        {
            get
            {
                return TinyIoCContainer.Current.Resolve<HomeViewModel>();
            }
        }

        public UploadViewModel UploadViewModel
        {
            get
            {
                return TinyIoCContainer.Current.Resolve<UploadViewModel>();
            }
        }

        public SettingsViewModel SettingsViewModel
        {
            get
            {
                return TinyIoCContainer.Current.Resolve<SettingsViewModel>();
            }
        }

        public IOCService()
        {
            ConfigureDependencyInjection();
        }

        private void ConfigureDependencyInjection()
        {
            // Register Interfaces before ViewModels
            RegisterInterfaces();
            RegisterViewModels();
        }

        private void RegisterInterfaces()
        {
            // Register Interfaces Here
        }

        void RegisterViewModels()
        {
            // RegisterViewModels Here
            TinyIoCContainer.Current.Register<HomeViewModel>();
            TinyIoCContainer.Current.Register<UploadViewModel>();
            TinyIoCContainer.Current.Register<SettingsViewModel>();
            //        .Register<ViewModel>(() => new ViewModel(
            //TinyIoC.TinyIoCContainer.Current.Resolve<IService>(),
            //model));
        }
    }
}
