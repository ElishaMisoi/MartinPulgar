using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MartinPulgar.Services.Dependency
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewModelLocator : ResourceDictionary
    {
        public ViewModelLocator()
        {
            InitializeComponent();
        }
    }
}