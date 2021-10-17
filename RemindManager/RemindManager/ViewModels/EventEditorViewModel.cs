using RemindManager.Enums;
using RemindManager.Models;
using RemindManager.Models.Frequencies;
using RemindManager.Models.Interfaces;
using RemindManager.Resources.StringResourcs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Forms;

namespace RemindManager.ViewModels
{
    /// <summary>
    /// Страница с полями для заполнения и изменения информации выбранного события
    /// </summary>
    public class EventEditorViewModel : BaseViewModel
    {
        #region locolized strings

        

        #endregion

        /// <summary>
        /// Название страницы
        /// </summary>
        public string PageName { get; set; }

        /// <summary>
        /// Редактируемое событие
        /// </summary>
        public IReminder Reminder { get; set; }

        /// <summary>
        /// Флаг того, что редактируется моментальное событие
        /// </summary>
        public bool IsInstantEvent
        {
            get => isInstantEvent;
            set
            {
                SetProperty(ref isInstantEvent, value);
                ChangeType();
            }
        }
        private bool isInstantEvent;

        /// <summary>
        /// Флаг того, что редактируется моментальное событие
        /// </summary>
        public bool IsContinuousEvent
        {
            get => isContinuousEvent;
            set
            {
                SetProperty(ref isContinuousEvent, value);
                ChangeType();
            }
        }
        private bool isContinuousEvent;

        /// <summary>
        /// Команда сохранения объекта
        /// </summary>
        public Command SaveCommand { get; }

        /// <summary>
        /// Список возможных частот
        /// </summary>
        public List<FrequencySelectionModel> Frequencies => FrequencySelectionModel.GetList();

        /// <summary>
        /// Список шаблонов для напоминаний с определеннымы частотами
        /// </summary>
        //public Dictionary<FrequencySelectionModel, ControlTemplate> FrequencyDataTemplatesDictionary { get; set; }

        /// <summary>
        /// Выбранная модель частоты
        /// </summary>
        public FrequencySelectionModel SelectedFrequencyModel
        {
            get => selectedFrequencyModel;
            set
            {
                //if (FrequencyDataTemplatesDictionary.TryGetValue(value, out ControlTemplate template)) FrequencyDataTemplate = template;
                switch (value.Id)
                {
                    case FrequenciesEnum.OneTime: Reminder.FrequencyData = new OneTimeFreqModel(); break;
                    case FrequenciesEnum.DaysOnYear: Reminder.FrequencyData = new DaysOnYearFreqModel(); break;
                    case FrequenciesEnum.DaysOnMonth: Reminder.FrequencyData = new DaysOnMonthFreqModel(); break;
                    case FrequenciesEnum.DaysOnWeek: Reminder.FrequencyData = new DaysOnWeekFreqModel(); break;
                    case FrequenciesEnum.Everyday: Reminder.FrequencyData = null; break;
                }
                SetProperty(ref selectedFrequencyModel, value);
            }
        }
        private FrequencySelectionModel selectedFrequencyModel;

        /// <summary>
        /// Control для выбранной частоты
        /// </summary>
        //public ControlTemplate FrequencyDataTemplate
        //{
        //    get => frequencyDataTemplate;
        //    set => SetProperty(ref frequencyDataTemplate, value);
        //}
        //private ControlTemplate frequencyDataTemplate;


        /// <summary>
        /// Конструктор редактора для создания нового события-0
        /// </summary>
        /// <param name="reminderToEdit">Редактируемое событие</param>
        public EventEditorViewModel(IReminder reminderToEdit = null)
        {
            // Создание команды сохранения

            SaveCommand = new Command(OnSave);


            // Если в параметр передан null, то инициализируется создание нового события
            // Иначе - редактирование выбранного

            if (reminderToEdit == null) InitNewEvent();
            else
            {
                Reminder = reminderToEdit;
                PageName = Reminder.Name;

                if (reminderToEdit is InstantEventModel) isInstantEvent = true;             // Если редактируемое событие - моментальное
                else if (reminderToEdit is ContinuousEventModel) isContinuousEvent = true;  // Если редактируемое событие - длительное
                else InitNewEvent();                                                        // Если переданный объект неизвестен создается новое
            }

            LocalizationResourceManager.Current.PropertyChanged += CurrentCulture_PropertyChanged;
        }

        /// <summary>
        /// При изменении языка приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentCulture_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            this.OnPropertyChanged(nameof(Frequencies));
        }

        /// <summary>
        /// Пустой конструктор редактора 
        /// </summary>
        public EventEditorViewModel() : this(null)
        {
            
        }

        /// <summary>
        /// Создать новое событие
        /// </summary>
        private void InitNewEvent()
        {
            isInstantEvent = true;
            Reminder = new InstantEventModel();
            PageName = AppResources.NewReminder;
        }

        /// <summary>
        /// Функция сохранения изменений события
        /// </summary>
        private async void OnSave()
        {
            string newLang = "en";
            LocalizationResourceManager.Current.CurrentCulture = new CultureInfo(newLang);
            //Reminder.Name = "Name";
            //SelectedFrequency = "asdfawe";
            //ReminderModel newItem = new ReminderModel()
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    Text = Text,
            //    Description = Description
            //};

            //await DataStore.AddItemAsync(newItem);

            //// This will pop the current page off the navigation stack
            //await Shell.Current.GoToAsync("..");
        }

        /// <summary>
        /// Изменить тип редактируемого события, сохранив при этом его главные свойства
        /// </summary>
        private void ChangeType()
        {
            IReminder newReminder;

            if (Reminder is ContinuousEventModel) newReminder = new InstantEventModel();
            else if (Reminder is InstantEventModel) newReminder = new ContinuousEventModel();
            else newReminder = new InstantEventModel();

            newReminder.Id = Reminder.Id;
            newReminder.Name = Reminder.Name;
            newReminder.Frequency = Reminder.Frequency;
            newReminder.Description = Reminder.Description;
            newReminder.FrequencyData = Reminder.FrequencyData;

            Reminder = newReminder;
        }

        public LocalizedString Text { get; } = new LocalizedString(() => AppResources.RemInstant);

    }
}
