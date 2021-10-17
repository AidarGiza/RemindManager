using RemindManager.Models.Interfaces;
using Xamarin.Forms;

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

        /// <summary>
        /// Шаблон контрола для выбора дней в неделе
        /// </summary>
        public ControlTemplate Template => Application.Current.Resources["DaysOnWeekFreqDataTemplate"] as ControlTemplate;
    }
}
