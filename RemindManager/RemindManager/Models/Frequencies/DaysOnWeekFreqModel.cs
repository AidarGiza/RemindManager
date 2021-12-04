using RemindManager.Enums;
using RemindManager.Models.Interfaces;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace RemindManager.Models.Frequencies
{
    /// <summary>
    /// Данные о напоминании в указанные дни в неделе
    /// </summary>
    public class DaysOnWeekFreqModel : ObservableObject, IFrequencyData
    {
        /// <summary>
        /// Битовая маска дней в неделе (1-127). Пример - 44 (0010 1100)
        /// </summary>
        public DaysOfWeekEnum WeekDays { get; set; }

        /// <summary>
        /// Выбран понедельник
        /// </summary>
        public bool IsMondayChecked
        {
            get => WeekDays.HasFlag(DaysOfWeekEnum.Monday);
            set 
            {
                if (value)
                    WeekDays |= DaysOfWeekEnum.Monday;
                else
                    WeekDays ^= DaysOfWeekEnum.Monday;
                SetProperty(ref isMondayChecked, value);
            }
        }
        public bool isMondayChecked;

        /// <summary>
        /// Выбран вторник
        /// </summary>
        public bool IsTuesdayChecked
        {
            get => WeekDays.HasFlag(DaysOfWeekEnum.Tuesday);
            set 
            {
                if (value)
                    WeekDays |= DaysOfWeekEnum.Tuesday;
                else
                    WeekDays ^= DaysOfWeekEnum.Tuesday;
                SetProperty(ref isTuesdayChecked, value);
            }
        }
        public bool isTuesdayChecked;

        /// <summary>
        /// Выбрана среда
        /// </summary>
        public bool IsWednesdayChecked
        {
            get => WeekDays.HasFlag(DaysOfWeekEnum.Wednesday);
            set 
            {
                if (value)
                    WeekDays |= DaysOfWeekEnum.Wednesday;
                else
                    WeekDays ^= DaysOfWeekEnum.Wednesday;
                SetProperty(ref isWednesdayChecked, value);
            }
        }
        public bool isWednesdayChecked;

        /// <summary>
        /// Выбран четверг
        /// </summary>
        public bool IsThursdayChecked
        {
            get => WeekDays.HasFlag(DaysOfWeekEnum.Thursday);
            set 
            {
                if (value)
                    WeekDays |= DaysOfWeekEnum.Thursday;
                else
                    WeekDays ^= DaysOfWeekEnum.Thursday;
                SetProperty(ref isThursdayChecked, value);
            }
        }
        public bool isThursdayChecked;

        /// <summary>
        /// Выбрана пятница
        /// </summary>
        public bool IsFridayChecked
        {
            get => WeekDays.HasFlag(DaysOfWeekEnum.Friday);
            set 
            {
                if (value)
                    WeekDays |= DaysOfWeekEnum.Friday;
                else
                    WeekDays ^= DaysOfWeekEnum.Friday;
                SetProperty(ref isFridayChecked, value);
            }
        }
        public bool isFridayChecked;

        /// <summary>
        /// Выбрана суббота
        /// </summary>
        public bool IsSaturdayChecked
        {
            get => WeekDays.HasFlag(DaysOfWeekEnum.Saturday);
            set 
            {
                if (value)
                    WeekDays |= DaysOfWeekEnum.Saturday;
                else
                    WeekDays ^= DaysOfWeekEnum.Saturday;
                SetProperty(ref isSaturdayChecked, value);
            }
        }
        public bool isSaturdayChecked;

        /// <summary>
        /// Выбрано воскресенье
        /// </summary>
        public bool IsSundayChecked
        {
            get => WeekDays.HasFlag(DaysOfWeekEnum.Sunday);
            set 
            {
                if (value)
                    WeekDays |= DaysOfWeekEnum.Sunday;
                else
                    WeekDays ^= DaysOfWeekEnum.Sunday;
                SetProperty(ref isSundayChecked, value);
            }
        }
        public bool isSundayChecked;

        /// <summary>
        /// Шаблон контрола для выбора дней в неделе
        /// </summary>
        public ControlTemplate Template =>
            Application.Current.Resources["DaysOnWeekFreqDataTemplate"]
            as ControlTemplate;
    }
}
