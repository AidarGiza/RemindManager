using RemindManager.Models.Frequencies;
using RemindManager.Models.Interfaces;
using System.Collections.Generic;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace RemindManager.Models
{
    /// <summary>
    /// Основной абстрактный класс напоминания
    /// </summary>
    public abstract class ReminderModel : ObservableObject, IReminder
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        private string name;

        /// <summary>
        /// Описание
        /// </summary>
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        public string description;

        /// <summary>
        /// Частота события вида <see cref="FrequencySelectionModel"/>
        /// </summary>
        public FrequencySelectionModel Frequency { get; set; }

        /// <summary>
        /// Данные частоты напоминания
        /// </summary>
        public IFrequencyData FrequencyData
        {
            get => frequencyData;
            set => SetProperty(ref frequencyData, value);
        }
        private IFrequencyData frequencyData;

        /// <summary>
        /// Список чисел, которые указывают, за сколько минут нужно напомнить
        /// </summary>
        public List<byte> RemindBefore { get; set; }

        /// <summary>
        /// Шаблон контрола выбора времени
        /// </summary>
        public abstract ControlTemplate TimePickerTemplate { get; }
    }
}
