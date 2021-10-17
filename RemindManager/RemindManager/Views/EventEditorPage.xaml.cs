using RemindManager.Models.Frequencies;
using RemindManager.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RemindManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventEditorPage : ContentPage
    {
        //private Dictionary<FrequenciesEnum, ControlTemplate> FrequencyDataTemplatesDictionary = new Dictionary<FrequenciesEnum, ControlTemplate>();
        
        public EventEditorPage()
        {
            InitializeComponent();
            //(BindingContext as EventEditorViewModel).FrequencyDataTemplatesDictionary = new Dictionary<FrequencySelectionModel, ControlTemplate>();
            //FindTemplates();
        }

        //private void FindTemplates()
        //{
        //    foreach (var res in this.Resources)
        //    {
        //        if (res.Key.Contains("FreqDataTemplate"))
        //        {
        //            (BindingContext as EventEditorViewModel).FrequencyDataTemplatesDictionary.Add(FrequencySelectionModel.GetList().FirstOrDefault(f => res.Key.Contains(f.Key)), res.Value as ControlTemplate);
        //        }
        //    }
        //}
    }
}