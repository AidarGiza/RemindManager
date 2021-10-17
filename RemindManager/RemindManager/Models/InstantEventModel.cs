using RemindManager.Models.Interfaces;
using System;

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
        public DateTime EventTime { get; set; }
    }
}
