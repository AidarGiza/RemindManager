using RemindManager.Models.Interfaces;
using System;
using Xamarin.Forms;

namespace RemindManager.Models
{
    /// <summary>
    /// Обычное напоминание
    /// </summary>
    public class InstantEventModel : ReminderModel, IReminder
    {
        /// <summary>
        /// Время события
        /// </summary>
        public TimeSpan EventTime
        {
            get => eventTime;
            set => SetProperty(ref eventTime, value);
        }
        private TimeSpan eventTime;

        /// <summary>
        /// Шаблон контрола выбора времени мгновенного события
        /// </summary>
        public override ControlTemplate TimePickerTemplate => Application.Current.Resources["InstantEventTimeDataTemplate"] as ControlTemplate;
    }
}
