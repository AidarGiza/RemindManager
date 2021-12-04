using RemindManager.Models.Interfaces;
using System;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace RemindManager.Models.Frequencies
{
    /// <summary>
    /// Данные об одноразовом напоминании
    /// </summary>
    public class OneTimeFreqModel : ObservableObject, IFrequencyData
    {
        /// <summary>
        /// Дата напоминаиния
        /// </summary>
        public DateTime Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }
        private DateTime date;

        /// <summary>
        /// Самый ранний день для выбора
        /// </summary>
        public DateTime MinimumDate => DateTime.Today;

        /// <summary>
        /// Шаблон контрола для данных об одноразовом напоминании
        /// </summary>
        public ControlTemplate Template =>
            Application.Current.Resources["OneTimeFreqDataTemplate"]
            as ControlTemplate;
    }
}
