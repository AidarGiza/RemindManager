using RemindManager.Enums;

namespace RemindManager.Models.Interfaces
{
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
        /// Частота события вида <see cref="FrequenciesEnum"/>
        /// </summary>
        FrequenciesEnum Frequency { get; set; }

        /// <summary>
        /// Данные частоты напоминания
        /// </summary>
        IFrequencyData FrequencyData { get; set; }
    }
}
