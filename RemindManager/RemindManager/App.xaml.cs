using RemindManager.Services;
using RemindManager.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RemindManager
{
    public partial class App : Application
    {

        public const string DB_NAME = "Reminder_DB.db";
        public static DatabaseService DatabaseService;

        public App()
        {
            InitializeComponent();

            DatabaseService = new DatabaseService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DB_NAME));

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
    }
}
