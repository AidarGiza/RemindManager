using RemindManager.Enums;
using RemindManager.Models.Interfaces;

namespace RemindManager.Models
{
    /// <summary>
    /// Основной абстрактный класс напоминания
    /// </summary>
    public abstract class ReminderModel : IReminder
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Частота события вида <see cref="FrequenciesEnum"/>
        /// </summary>
        public FrequenciesEnum Frequency { get; set; }

        /// <summary>
        /// Данные частоты напоминания
        /// </summary>
        public IFrequencyData FrequencyData { get; set; }
    }
}
