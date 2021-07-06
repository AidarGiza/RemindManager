using RemindManager.Enums;
using RemindManager.Models;
using RemindManager.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RemindManager.ViewModels
{
    /// <summary>
    /// Страница с полями для заполнения и изменения информации выбранного события
    /// </summary>
    public class EventEditorViewModel : BaseViewModel
    {
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
        public List<string> Frequencies
        {
            get
            {
                List<string> listOfFrequencies = new List<string>();
                foreach (FrequenciesEnum frequencyName in (FrequenciesEnum[]) Enum.GetValues(typeof(FrequenciesEnum))) listOfFrequencies.Add(frequencyName.ToString());
                return listOfFrequencies;
            }
        }

        /// <summary>
        /// Выбранная частота
        /// </summary>
        public SelectedFrequency
        {
            get
            {
                List<string> listOfFrequencies = new List<string>();
                foreach (FrequenciesEnum frequencyName in (FrequenciesEnum[]) Enum.GetValues(typeof(FrequenciesEnum))) listOfFrequencies.Add(frequencyName.ToString());
                return listOfFrequencies;
            }
        }

        /// <summary>
        /// Конструктор редактора для создания нового события
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

                if (reminderToEdit is InstantEventModel) isInstantEvent = true;             // Если редактируемое событие - моментальное
                else if (reminderToEdit is ContinuousEventModel) isContinuousEvent = true;  // Если редактируемое событие - длительное
                else InitNewEvent();                                                        // Если переданный объект неизвестен создается новое
            }

        }

        /// <summary>
        /// Пустой конструктор редактора 
        /// </summary>
        public EventEditorViewModel() : this(null) { }

        /// <summary>
        /// Создать новое событие
        /// </summary>
        private void InitNewEvent()
        {
            isInstantEvent = true;
            Reminder = new InstantEventModel();
        }

        /// <summary>
        /// Функция сохранения изменений события
        /// </summary>
        private async void OnSave()
        {
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
    }
}
