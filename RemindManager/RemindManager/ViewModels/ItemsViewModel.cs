using RemindManager.Models;
using RemindManager.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Forms;

namespace RemindManager.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private ReminderModel _selectedItem;

        public ObservableCollection<ReminderModel> Items { get; }
        //public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<ReminderModel> ItemTapped { get; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<ReminderModel>();
           // LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<ReminderModel>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);

        }

        //async Task ExecuteLoadItemsCommand()
        //{
        //    IsBusy = true;

        //    try
        //    {
        //        Items.Clear();
        //        var items = await DataStore.GetItemsAsync(true);
        //        foreach (var item in items)
        //        {
        //            Items.Add(item);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public ReminderModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {

            string newLang = "ru";
            LocalizationResourceManager.Current.CurrentCulture =
                new CultureInfo(newLang);
            //await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(ReminderModel item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the
            // navigation stack
            await Shell.Current.GoToAsync(
                $"{nameof(ItemDetailPage)}?" +
                $"{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}