using RemindManager.Enums;
using RemindManager.Models.DateDataModels;
using RemindManager.Models.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace RemindManager.Models.Frequencies
{
    /// <summary>
    /// Данные о напоминании в указанные дни в году
    /// </summary>
    public class DaysOnYearFreqModel : ObservableObject, IFrequencyData
    {
        /// <summary>
        /// Список дней в году вида <see cref="DayAndMonth"/>
        /// </summary>
        public ObservableCollection<DayAndMonth> DaysOnYear { get; set; }

        /// <summary>
        /// Команда для добавления дня
        /// </summary>
        public Command AddDayCommand { get; set; }

        /// <summary>
        /// Команда для удаления дня
        /// </summary>
        public Command RemoveDayCommand { get; set; }

        /// <summary>
        /// Шаблон контрола для выбора дней в году
        /// </summary>
        public ControlTemplate Template =>
            Application.Current.Resources["DaysOnYearFreqDataTemplate"]
            as ControlTemplate;

        /// <summary>
        /// Возможность добавить день
        /// </summary>
        public bool CanAddDay => DaysOnYear?.Count < 366;

        /// <summary>
        /// Конструктор модели
        /// </summary>
        public DaysOnYearFreqModel()
        {
            DaysOnYear = new ObservableCollection<DayAndMonth>();
            AddDayCommand = new Command(AddDay);
            RemoveDayCommand = new Command<DayAndMonth>(RemoveDay);
            AddDay();
        }

        /// <summary>
        /// Добавить день
        /// </summary>
        private void AddDay()
        {
            if (DaysOnYear.Count < 366)
            {
                DayAndMonth newDay =
                    new DayAndMonth(1, MonthsEnum.January);
                while (DaysOnYear.Any(d => d.Day == newDay.Day && 
                                           d.Month == newDay.Month))
                    newDay.Inc();
                DaysOnYear.Add(newDay);
                OnPropertyChanged(nameof(CanRemoveDay));
                OnPropertyChanged(nameof(CanAddDay));
            }
        }

        /// <summary>
        /// Удалить день
        /// </summary>
        /// <param name="day">День для удаления</param>
        private void RemoveDay(DayAndMonth day)
        {
            _ = DaysOnYear.Remove(day);
            if (DaysOnYear.Count == 1)
                OnPropertyChanged(nameof(CanRemoveDay));
            OnPropertyChanged(nameof(CanAddDay));
        }

        /// <summary>
        /// Условие для удаления дня
        /// </summary>
        public bool CanRemoveDay => DaysOnYear.Count > 1;

    }
}
