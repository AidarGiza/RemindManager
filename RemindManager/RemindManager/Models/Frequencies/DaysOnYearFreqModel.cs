﻿using RemindManager.Models.DateDataModels;
using RemindManager.Models.Interfaces;
using System.Collections.Generic;
using Xamarin.Forms;

namespace RemindManager.Models.Frequencies
{
    /// <summary>
    /// Данные о напоминании в указанные дни в году
    /// </summary>
    public class DaysOnYearFreqModel : IFrequencyData
    {
        /// <summary>
        /// Список дней в году вида <see cref="DayAndMonth"/>
        /// </summary>
        public List<DayAndMonth> DayAndMonth { get; set; }

        /// <summary>
        /// Шаблон контрола для выбора дней в году
        /// </summary>
        public ControlTemplate Template =>
            Application.Current.Resources["DaysOnYearFreqDataTemplate"]
            as ControlTemplate;
    }
}
