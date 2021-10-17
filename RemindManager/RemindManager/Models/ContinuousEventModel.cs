using RemindManager.Models.Interfaces;
using System;

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
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Время окончания события
        /// </summary>
        public DateTime EndTime { get; set; }
    }
}
