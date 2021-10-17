using RemindManager.Models.Frequencies;
using RemindManager.Resources.StringResourcs;
using RemindManager.Services;
using System;
using System.IO;
using System.Linq;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Forms;

namespace RemindManager
{
    public partial class App : Application
    {

        public const string DB_NAME = "Reminder_DB.db";
        public static DatabaseService DatabaseService;

        public App()
        {
            InitializeComponent();

            LocalizationResourceManager.Current.PropertyChanged += CurrentCulture_PropertyChanged;
            LocalizationResourceManager.Current.Init(AppResources.ResourceManager);

            DatabaseService = new DatabaseService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DB_NAME));

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        private void CurrentCulture_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            AppResources.Culture = LocalizationResourceManager.Current.CurrentCulture;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private void DayEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                if (e.NewTextValue.Contains('.') || e.NewTextValue.Contains(',')) ((Entry)sender).Text = e.OldTextValue;
                if (byte.TryParse(e.NewTextValue, out byte val))
                {
                    if (val < 1 || val > 31) ((Entry)sender).Text = e.OldTextValue;
                }
                else ((Entry)sender).Text = e.OldTextValue;
            }
        }

        private void DayEntry_Unfocused(object sender, FocusEventArgs e)
        {
            if (((Entry)sender).Text == "") ((Entry)sender).Text = (((Entry)sender).BindingContext as DayEntry).Day.ToString();
        }
    }
}
