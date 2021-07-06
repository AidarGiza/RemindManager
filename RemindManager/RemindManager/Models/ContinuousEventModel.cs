using RemindManager.Models.Interfaces;
using System;
using System.Collections.Generic;

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

        /// <summary>
        /// Список чисел, которые указывают, за сколько минут нужно напомнить
        /// </summary>
        public List<byte> RemindBefore { get; set; }
    }
}
