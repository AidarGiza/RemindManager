using RemindManager.Models.Interfaces;
using System.Collections.ObjectModel;
using System.Linq;
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
        /// Команда для удаления дня
        /// </summary>
        public Command RemoveDayCommand { get; set; }

        /// <summary>
        /// Шаблон контрола для выбора дней в месяце
        /// </summary>
        public ControlTemplate Template =>
            Application.Current.Resources["DaysOnMonthFreqDataTemplate"]
            as ControlTemplate;

        /// <summary>
        /// Возможность добавить день
        /// </summary>
        public bool CanAddDay => Days?.Count < 31;

        /// <summary>
        /// Конструктор модели
        /// </summary>
        public DaysOnMonthFreqModel()
        {
            Days = new ObservableCollection<DayEntry>();
            AddDayCommand = new Command(AddDay);
            RemoveDayCommand = new Command<DayEntry>(RemoveDay);
            AddDay();
        }

        /// <summary>
        /// Добавить день
        /// </summary>
        private void AddDay()
        {
            if (Days.Count < 31)
            {
                byte n = 1;
                while (Days.Any(d => d.Day == n)) n++;
                Days.Add(new DayEntry(n));
                OnPropertyChanged(nameof(CanRemoveDay));
                OnPropertyChanged(nameof(CanAddDay));
            }
        }

        /// <summary>
        /// Удалить день
        /// </summary>
        /// <param name="day">День для удаления</param>
        private void RemoveDay(DayEntry day)
        {
            _ = Days.Remove(day);
            if (Days.Count == 1) 
                OnPropertyChanged(nameof(CanRemoveDay));
            OnPropertyChanged(nameof(CanAddDay));
        }

        /// <summary>
        /// Условие для удаления дня
        /// </summary>
        public bool CanRemoveDay => Days.Count > 1;
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
        private byte day;

        /// <summary>
        /// Конструктор модели дня
        /// </summary>
        /// <param name="day">Число</param>
        public DayEntry(byte day) => Day = day;
    }
}
