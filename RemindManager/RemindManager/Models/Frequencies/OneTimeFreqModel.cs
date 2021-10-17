using RemindManager.Models.Interfaces;
using System;
using Xamarin.Forms;

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

        /// <summary>
        /// Шаблон контрола для данных об одноразовом напоминании
        /// </summary>
        public ControlTemplate Template => Application.Current.Resources["OneTimeFreqDataTemplate"] as ControlTemplate;
    }
}
