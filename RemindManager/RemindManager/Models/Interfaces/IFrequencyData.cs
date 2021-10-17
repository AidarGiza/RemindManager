using Xamarin.Forms;

namespace RemindManager.Models.Interfaces
{
    /// <summary>
    /// Данные о частоте напоминания
    /// </summary>
    public interface IFrequencyData
    {
        /// <summary>
        /// Шаболон контрола данных частоты напоминания
        /// </summary>
        ControlTemplate Template { get; }
    }
}
