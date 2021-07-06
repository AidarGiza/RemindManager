using System;
using System.Collections.Generic;
using System.Text;

namespace RemindManager.Models.Frequencies
{
    public sealed class FrequencySelectionModel
    {
        private readonly int id;
        private readonly string name;

        /// <summary>
        /// Один раз
        /// </summary>
        public static readonly FrequencySelectionModel OneTime = new FrequencySelectionModel(0, "Один раз");
        /// <summary>
        /// Дни в году
        /// </summary>
        public static readonly FrequencySelectionModel DaysOnYear = new FrequencySelectionModel(1, "Дни в году");
        /// <summary>
        /// Дни в месяце
        /// </summary>
        public static readonly FrequencySelectionModel DaysOnMonth = new FrequencySelectionModel(2, "Дни в месяце");
        /// <summary>
        /// Дни в неделе
        /// </summary>
        public static readonly FrequencySelectionModel DaysOnWeek = new FrequencySelectionModel(3, "Дни в неделе");
        /// <summary>
        /// Каждый день
        /// </summary>
        public static readonly FrequencySelectionModel Everyday = new FrequencySelectionModel(4, "Каждый день");

        private FrequencySelectionModel(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
