using RemindManager.Models.Interfaces;
using System;
using Xamarin.Forms;

namespace RemindManager.Models
{
    /// <summary>
    /// Продолжительное событие
    /// </summary>
    public class ContinuousEventModel : ReminderModel, IReminder
    {
        /// <summary>
        /// Время начала события
        /// </summary>
        public TimeSpan StartTime
        {
            get => startTime;
            set => SetProperty(ref startTime, value);
        }
        private TimeSpan startTime;

        /// <summary>
        /// Время окончания события
        /// </summary>
        public TimeSpan EndTime
        {
            get => endTime;
            set
            {
                SetProperty(ref endTime, value);
                OnPropertyChanged(nameof(IsEndNextDay));
            }
        }
        private TimeSpan endTime;

        /// <summary>
        /// Конец события только на следующий день
        /// </summary>
        public bool IsEndNextDay => EndTime.Hours < StartTime.Hours;

        /// <summary>
        /// Шаблон контрола выбора времени продолжительного события
        /// </summary>
        public override ControlTemplate TimePickerTemplate => 
            Application.Current.Resources["ContinuousEventTimeDataTemplate"]
            as ControlTemplate;
    }
}
