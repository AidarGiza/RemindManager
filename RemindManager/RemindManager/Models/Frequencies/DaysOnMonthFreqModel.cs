using RemindManager.Models.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace RemindManager.Models.Frequencies
{
    /// <summary>
    /// Данные о напоминании в указанные дни в месяце
    /// </summary>
    public class DaysOnMonthFreqModel : ObservableObject, IFrequencyData
    {
        /// <summary>
        /// Список дней (1-31)
        /// </summary>
        public ObservableCollection<DayEntry> Days
        {
            get => days;
            set => SetProperty(ref days, value);
        }
        public ObservableCollection<DayEntry> days;

        /// <summary>
        /// Команда для добавления дня
        /// </summary>
        public Command AddDayCommand { get; set; }

        /// <summary>
        /// Шаблон контрола для выбора дней в месяце
        /// </summary>
        public ControlTemplate Template => Application.Current.Resources["DaysOnMonthFreqDataTemplate"] as ControlTemplate;

        /// <summary>
        /// Конструктор модели
        /// </summary>
        public DaysOnMonthFreqModel()
        {
            Days = new ObservableCollection<DayEntry>();
            AddDayCommand = new Command(AddDay);
            AddDay();
        }

        /// <summary>
        /// Добавить день
        /// </summary>
        private void AddDay() => Days.Add(new DayEntry(1));
    }

    /// <summary>
    /// Модель дня
    /// </summary>
    public class DayEntry : ObservableObject
    {
        /// <summary>
        /// Число месяца
        /// </summary>
        public byte Day
        {
            get => day;
            set => SetProperty(ref day, value);
        }
        public byte day;

        /// <summary>
        /// Конструктор модели дня
        /// </summary>
        /// <param name="day"></param>
        public DayEntry(byte day) => Day = day;
    }
}
