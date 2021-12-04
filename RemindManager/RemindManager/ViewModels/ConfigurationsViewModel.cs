using System.Collections.Generic;
using System.Globalization;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace RemindManager.ViewModels
{
    public class ConfigurationsViewModel : ObservableObject
    {
        /// <summary>
        /// Список доступных языков интерфейса
        /// </summary>
        public List<string> AvailableLangages { get; }

        /// <summary>
        /// Команда 
        /// </summary>
        public ICommand ChangeLanguageCommand { get; }

        /// <summary>
        /// Конструктор конфигуратор
        /// </summary>
        public ConfigurationsViewModel()
        {
            ChangeLanguageCommand = new Command(ChangeLanguage);
        }


        /// <summary>
        /// Изменить язык
        /// </summary>
        public void ChangeLanguage()
        {
            string newLang = "ru";
            LocalizationResourceManager.Current.CurrentCulture = 
                new CultureInfo(newLang);
        }
    }
}
