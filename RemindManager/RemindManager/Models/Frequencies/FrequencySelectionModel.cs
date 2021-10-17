using RemindManager.Enums;
using RemindManager.Resources.StringResourcs;
using System;
using System.Collections.Generic;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.CommunityToolkit.ObjectModel;

namespace RemindManager.Models.Frequencies
{
    public sealed class FrequencySelectionModel : ObservableObject
    {
        public FrequenciesEnum Id { get; }
        public LocalizedString Name { get; }
        public string Key { get; }

        /// <summary>
        /// Один раз
        /// </summary>
        public static FrequencySelectionModel OneTime { get; } = new FrequencySelectionModel(FrequenciesEnum.OneTime, new LocalizedString(() => AppResources.FreqOneTime), "OneTime");
        /// <summary>
        /// Дни в году
        /// </summary>
        public static FrequencySelectionModel DaysOnYear { get; } = new FrequencySelectionModel(FrequenciesEnum.DaysOnYear, new LocalizedString(() => AppResources.FreqDaysOnYear), "DaysOnYear");
        /// <summary>
        /// Дни в месяце
        /// </summary>
        public static FrequencySelectionModel DaysOnMonth { get; } = new FrequencySelectionModel(FrequenciesEnum.DaysOnMonth, new LocalizedString(() => AppResources.FreqDaysOnMonth), "DaysOnMonth");
        /// <summary>
        /// Дни в неделе
        /// </summary>
        public static FrequencySelectionModel DaysOnWeek { get; } = new FrequencySelectionModel(FrequenciesEnum.DaysOnWeek, new LocalizedString(() => AppResources.FreqDaysOnWeek), "DaysOnWeek");
        /// <summary>
        /// Каждый день
        /// </summary>
        public static FrequencySelectionModel Everyday { get; } = new FrequencySelectionModel(FrequenciesEnum.Everyday, new LocalizedString(() => AppResources.FreqEveryday), "Everyday");

        private FrequencySelectionModel(FrequenciesEnum id, LocalizedString name, string key)
        {
            Id = id;
            Name = name;
            Key = key;
        }
        
        public static List<FrequencySelectionModel> GetList()
        {
            return new List<FrequencySelectionModel>()
            {
                OneTime,
                DaysOnYear,
                DaysOnMonth,
                DaysOnWeek,
                Everyday
            };
        }
    }
}
