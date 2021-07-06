using RemindManager.Models.Interfaces;

namespace RemindManager.Models.Frequencies
{
    /// <summary>
    /// Данные о напоминании в указанные дни в неделе
    /// </summary>
    public class DaysOnWeekFreqModel : IFrequencyData
    {
        /// <summary>
        /// Битовая маска дней в неделе (1-127). Пример - 44 (0010 1100)
        /// </summary>
        public byte Days { get; set; }
    }
}
