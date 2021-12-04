using RemindManager.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RemindManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
    }
}