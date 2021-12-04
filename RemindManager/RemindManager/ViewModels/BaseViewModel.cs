using RemindManager.Models;
using RemindManager.Services;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace RemindManager.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        public IDataStore<ReminderModel> DataStore => 
            DependencyService.Get<IDataStore<ReminderModel>>();

        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }
        bool isBusy = false;

        public string Title
        {
            get  => title;
            set => SetProperty(ref title, value);
        }
        string title = string.Empty;
    }
}
