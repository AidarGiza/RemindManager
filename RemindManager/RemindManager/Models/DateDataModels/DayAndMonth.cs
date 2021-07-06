using RemindManager.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemindManager.Models.DateDataModels
{
    /// <summary>
    /// День в году
    /// </summary>
    public class DayAndMonth
    {
        /// <summary>
        /// День (0-31)
        /// </summary>
        public byte Day { get; set; }
        /// <summary>
        /// Месяц вида <see cref="MonthsEnum"/>
        /// </summary>
        public MonthsEnum Month { get; set; }
    }
}
