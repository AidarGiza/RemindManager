using RemindManager.Enums;
using RemindManager.Models;
using RemindManager.Models.Frequencies;
using RemindManager.Models.Interfaces;
using RemindManager.Resources.StringResourcs;
using System;
using System.Collections.Generic;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Forms;

namespace RemindManager.ViewModels
{
    /// <summary>
    /// Страница с полями для заполнения и изменения информации 
    /// выбранного события
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
        public IReminder Reminder
        {
            get => reminder;
            set => SetProperty(ref reminder, value);
        }
        private IReminder reminder;

        /// <summary>
        /// Флаг того, что редактируется моментальное событие
        /// </summary>
        public bool IsInstantEvent
        {
            get => isInstantEvent;
            set
            {
                SetProperty(ref isInstantEvent, value);
                if (value)
                    SetType(EventTypesEnum.InstantEvent);
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
                if (value)
                    SetType(EventTypesEnum.ContinuousEvent);
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
        public List<FrequencySelectionModel> Frequencies =>
            FrequencySelectionModel.GetList();

        /// <summary>
        /// Конструктор редактора для создания нового события-0
        /// </summary>
        /// <param name="reminderToEdit">Редактируемое событие</param>
        public EventEditorViewModel(IReminder reminderToEdit = null)
        {
            // Создание команды сохранения

            SaveCommand = new Command(OnSave);

            // Если в параметр передан null, то инициализируется
            // создание нового события
            // Иначе - редактирование выбранного
            if (reminderToEdit == null)
                InitNewEvent();
            else
            {
                Reminder = reminderToEdit;
                PageName = Reminder.Name;

                // Если редактируемое событие - моментальное
                if (reminderToEdit is InstantEventModel)
                    isInstantEvent = true;
                // Если редактируемое событие - длительное
                else if (reminderToEdit is ContinuousEventModel)
                    isContinuousEvent = true;
                else
                    InitNewEvent();                                                        // Если переданный объект неизвестен создается новое
            }

            LocalizationResourceManager.Current.PropertyChanged +=
                CurrentCulture_PropertyChanged;
        }

        /// <summary>
        /// При изменении языка приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentCulture_PropertyChanged(object sender,
            System.ComponentModel.PropertyChangedEventArgs e)
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
            IsInstantEvent = true;
            PageName = AppResources.NewReminder;
        }

        /// <summary>
        /// Функция сохранения изменений события
        /// </summary>
        private async void OnSave()
        {
            string newLang = "en";
            //LocalizationResourceManager.Current.CurrentCulture = new CultureInfo(newLang);
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
        /// Задать тип редактируемого события,
        /// сохранив при этом его главные свойства
        /// </summary>
        private void SetType(EventTypesEnum type)
        {
            IReminder newReminder;

            if (type == EventTypesEnum.InstantEvent)
                newReminder = new InstantEventModel();
            else if (type == EventTypesEnum.ContinuousEvent)
                newReminder = new ContinuousEventModel();
            else 
                newReminder = new InstantEventModel();
            if (Reminder != null)
            {
                newReminder.Id = Reminder.Id;
                newReminder.Name = Reminder.Name;
                newReminder.Frequency = Reminder.Frequency;
                newReminder.Description = Reminder.Description;
                newReminder.FrequencyData = Reminder.FrequencyData;
            }
            int hours =
                DateTime.Now.Minute < 30 ?
                DateTime.Now.Hour :
                DateTime.Now.AddHours(1).Hour;
            if (newReminder is InstantEventModel instantEvent) 
                instantEvent.EventTime = new TimeSpan(hours, 0, 0);
            if (newReminder is ContinuousEventModel continuousEvent)
            {
                continuousEvent.StartTime = new TimeSpan(hours, 0, 0);
                continuousEvent.EndTime =
                    continuousEvent.StartTime.Add(new TimeSpan(1, 0, 0));
            }
            Reminder = newReminder;
        }

        public LocalizedString Text { get; } =
            new LocalizedString(() => AppResources.RemInstant);

    }
}
