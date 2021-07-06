using RemindManager.Models.Interfaces;
using System;

namespace RemindManager.Models.Frequencies
{
    /// <summary>
    /// Данные об одноразовом напоминании
    /// </summary>
    public class OneTimeFreqModel : IFrequencyData
    {
        /// <summary>
        /// Дата напоминаиния
        /// </summary>
        public DateTime Date { get; set; }
    }
}
