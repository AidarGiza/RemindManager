using RemindManager.Models.Frequencies;
using RemindManager.Resources.StringResourcs;
using RemindManager.Services;
using RemindManager.ViewModels;
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

            LocalizationResourceManager.Current.PropertyChanged +=
                CurrentCulture_PropertyChanged;
            LocalizationResourceManager.Current.Init(
                AppResources.ResourceManager);

            DatabaseService =
                new DatabaseService(Path.Combine(
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.LocalApplicationData),
                    DB_NAME));

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        private void CurrentCulture_PropertyChanged(object sender,
            System.ComponentModel.PropertyChangedEventArgs e)
        {
            AppResources.Culture =
                LocalizationResourceManager.Current.CurrentCulture;
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

        /// <summary>
        /// Действия при вводе дня месяца в поле
        /// ввода с помощью клавиатуры
        /// </summary>
        /// <param name="sender">Поле ввода</param>
        /// <param name="e">Аргументы</param>
        private void DayEntry_TextChanged(object sender,
            TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                string correctedVal = null;
                if (e.NewTextValue.Contains('.') ||
                        e.NewTextValue.Contains(','))
                    correctedVal = e.OldTextValue;
                else if (!byte.TryParse(e.NewTextValue, out byte val))
                    correctedVal = e.OldTextValue;
                else if (val < 1 || val > 31)
                    correctedVal = e.OldTextValue;
                if (correctedVal != null)
                    ((Entry)sender).Text = correctedVal;
            }
        }

        /// <summary>
        /// Действия при потери фокуса поля ввода дня в месяце
        /// </summary>
        /// <param name="sender">Поле ввода</param>
        /// <param name="e">Аргументы</param>
        private void DayEntry_Unfocused(object sender, FocusEventArgs e)
        {
            if (((Entry)sender).Text == "")
                ((Entry)sender).Text =
                    (((Entry)sender).BindingContext as DayEntry).
                    Day.ToString();
        }

        /// <summary>
        /// Действия при изменении значения дня в месяце
        /// </summary>
        /// <param name="sender">Stepper</param>
        /// <param name="e">Аргументы</param>
        private void DayStepper_ValueChanged(object sender,
            ValueChangedEventArgs e)
        {
            Element template =
                ((Stepper)sender).Parent.Parent?.Parent.Parent;
            Element parent = ((Stepper)sender).Parent;
            DayEntry dayEntry =
                ((Stepper)sender).BindingContext as DayEntry;
            if (template?.BindingContext is
                EventEditorViewModel eventEditor)
            {
                if (eventEditor.Reminder.FrequencyData is
                    DaysOnMonthFreqModel domFreq &&
                    domFreq.Days.Any(d => d.Day == e.NewValue &&
                        d != dayEntry))
                {
                    int newValue = (int)e.NewValue;
                    while (domFreq.Days.
                        Any(d => d.Day == newValue && d != dayEntry))
                    {
                        newValue += 1;
                        if (newValue <= 0)
                            newValue = 31;
                        else if (newValue >= 32)
                            newValue = 1;
                    }
                    if (e.NewValue != newValue)
                        ((Stepper)sender).Value = newValue;
                }
                else if (eventEditor.Reminder.FrequencyData is
                    DaysOnYearFreqModel doyFreq)
                {
                    var sdef = parent.FindByName("MonthPicker");
                    if (doyFreq.DaysOnYear.Any(d => d.Day == e.NewValue))
                    {
                        
                        //int n = (int)(e.NewValue - e.OldValue);
                        //int newValue = (int)e.NewValue;
                        //while (domFreq.Days.
                        //    Any(d => d.Day == newValue && d != dayEntry))
                        //{
                        //    newValue += n;
                        //    if (newValue <= 0)
                        //        newValue = 31;
                        //    else if (newValue >= 32)
                        //        newValue = 1;
                        //}
                        //if (e.NewValue != newValue)
                        //    ((Stepper)sender).Value = newValue;
                        
                    }
                }
            }
        }

        private void MonthStepper_ValueChanged(object sender,
            ValueChangedEventArgs e)
        {
            Element template = ((Stepper)sender).Parent.Parent?.Parent.Parent;
            Element parent = ((Stepper)sender).Parent;
            DayEntry dayEntry = ((Stepper)sender).BindingContext as DayEntry;
            if (template?.BindingContext is EventEditorViewModel eventEditor)
            {

            }
        }
    }
}
