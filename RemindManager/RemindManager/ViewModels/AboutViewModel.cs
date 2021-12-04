using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RemindManager.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            string aboutSite = "https://aka.ms/xamarin-quickstart";
            OpenWebCommand = new Command(
                async () => await Browser.OpenAsync(aboutSite));
        }

        public ICommand OpenWebCommand { get; }
    }
}