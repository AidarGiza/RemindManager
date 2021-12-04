using RemindManager.Models.Frequencies;
using System.Collections.Generic;
using Xamarin.Forms;

namespace RemindManager.Models.Interfaces
{
    /// <summary>
    /// Интерфейс напоминания
    /// </summary>
    public interface IReminder
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        uint Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Частота события вида <see cref="FrequencySelectionModel"/>
        /// </summary>
        FrequencySelectionModel Frequency { get; set; }

        /// <summary>
        /// Данные частоты напоминания
        /// </summary>
        IFrequencyData FrequencyData { get; set; }

        /// <summary>
        /// Список чисел, которые указывают, 
        /// за сколько минут нужно напомнить
        /// </summary>
        List<byte> RemindBefore { get; set; }

        /// <summary>
        /// Шаблон контрола выбора времени
        /// </summary>
        public ControlTemplate TimePickerTemplate { get; }
    }
}
