using RemindManager.Enums;
using RemindManager.Resources.StringResourcs;
using System;
using System.Collections.Generic;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.CommunityToolkit.ObjectModel;

namespace RemindManager.Models.DateDataModels
{
    /// <summary>
    /// День в году
    /// </summary>
    public class DayAndMonth : ObservableObject
    {
        /// <summary>
        /// День (0-31)
        /// </summary>
        public byte Day
        {
            get => day;
            set => SetProperty(ref day, value);
        }
        private byte day;

        /// <summary>
        /// Месяц вида <see cref="MonthsEnum"/>
        /// </summary>
        public MonthsEnum Month
        {
            get => month;
            set => SetProperty(ref month, value);
        }
        private MonthsEnum month;

        public int MonthId
        {
            get => monthId;
            set => SetProperty(ref monthId, value);
        }
        private int monthId;

        /// <summary>
        /// Список месяцев
        /// </summary>
        public List<LocalizedString> Months =>
            new List<LocalizedString>()
            {
                new LocalizedString(() => AppResources.MonJan),
                new LocalizedString(() => AppResources.MonFeb),
                new LocalizedString(() => AppResources.MonMar),
                new LocalizedString(() => AppResources.MonApr),
                new LocalizedString(() => AppResources.MonMay),
                new LocalizedString(() => AppResources.MonJun),
                new LocalizedString(() => AppResources.MonJul),
                new LocalizedString(() => AppResources.MonAug),
                new LocalizedString(() => AppResources.MonSep),
                new LocalizedString(() => AppResources.MonOct),
                new LocalizedString(() => AppResources.MonNov),
                new LocalizedString(() => AppResources.MonDec)
            };

        /// <summary>
        /// Конструктор модели дня в году
        /// </summary>
        /// <param name="day">Число</param>
        /// <param name="month">Месяц</param>
        public DayAndMonth(byte day, MonthsEnum month)
        {
            Day = day;
            Month = month;
        }

        public void Inc()
        {
            switch (Month)
            {
                case MonthsEnum.January:
                case MonthsEnum.March:
                case MonthsEnum.May:
                case MonthsEnum.July:
                case MonthsEnum.August:
                case MonthsEnum.October:
                case MonthsEnum.December:
                    {
                        if (Day == 31)
                            Day = 1;
                        else
                            Day++;
                    }
                    break;
                case MonthsEnum.April:
                case MonthsEnum.June:
                case MonthsEnum.September:
                case MonthsEnum.November:
                    {
                        if (Day == 30)
                            Day = 1;
                        else
                            Day++;
                    }
                    break;
                case MonthsEnum.February:
                    {
                        if (Day == 29)
                            Day = 1;
                        else
                            Day++;
                    }
                    break;
                default:
                    break;
            }


            if (Month == MonthsEnum.December)
                Month = MonthsEnum.January;
            else
                Month++;
        }

        public void Dec()
        {
            if (Day == 1)
            {
                switch (Month)
                {
                    case MonthsEnum.January:
                    case MonthsEnum.February:
                    case MonthsEnum.April:
                    case MonthsEnum.June:
                    case MonthsEnum.August:
                    case MonthsEnum.September:
                    case MonthsEnum.November:
                        {
                            Day = 31;
                        }
                        break;
                    case MonthsEnum.March:
                        {
                            Day = 29;
                        }
                        break;
                    case MonthsEnum.May:
                    case MonthsEnum.July:
                    case MonthsEnum.October:
                    case MonthsEnum.December:
                        Day = 30;
                        break;
                    default:
                        break;
                }

                if (Month == MonthsEnum.January)
                    Month = MonthsEnum.December;
                else 
                    Month--;
            }
            else
                Day--;
        }
    }
}