using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            Title = "Au sujet de l'app...";
            AppName.Text = AppInfo.Name;
            AppVersion.Text = AppInfo.VersionString;
        }
    }
}