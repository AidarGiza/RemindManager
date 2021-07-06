using RemindManager.Models.Interfaces;
using System.Collections.Generic;

namespace RemindManager.Models.Frequencies
{
    /// <summary>
    /// Данные о напоминании в указанные дни в месяце
    /// </summary>
    public class DaysOnMonthFreqModel : IFrequencyData
    {
        /// <summary>
        /// Список дней (1-31)
        /// </summary>
        public List<byte> Days { get; set; }
    }
}
