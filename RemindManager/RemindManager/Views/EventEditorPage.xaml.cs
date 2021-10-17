using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RemindManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventEditorPage : ContentPage
    {
        /// <summary>
        /// Главный StackLayout на странице
        /// </summary>
        StackLayout mainStackLayout;

        /// <summary>
        /// Конструктор страницы
        /// </summary>
        public EventEditorPage()
        {
            InitializeComponent();
            mainStackLayout = (StackLayout)FindByName("MainStackLayout");
        }

        /// <summary>
        /// Обновление StackLayout, потому что он не увеличивается, когда что то добавляется в TemplatedControl
        /// Нужно будет попробовать без этого после обновления Xamarin
        /// </summary>
        public void UpdateLayout()
        {
            var ds = MeasurHeightRequire(mainStackLayout.Children);
            ds += mainStackLayout.Children.Count * mainStackLayout.Spacing;
            mainStackLayout.HeightRequest = ds;
        }

        /// <summary>
        /// Измерить необходимую высоту 
        /// </summary>
        /// <param name="views">Элементы</param>
        /// <returns>Необходимая высота</returns>
        double MeasurHeightRequire(IList<View> views)
        {
            double res = 0;
            foreach (var view in views)
            {
                res += view.Bounds.Height;
                res += view.Margin.Top;
                res += view.Margin.Bottom;
            }
            return res;
        }

        /// <summary>
        /// Изменилась высота TemplatedView
        /// </summary>
        /// <param name="sender">Control</param>
        /// <param name="e">Аргументы</param>
        private void TemplatedView_SizeChanged(object sender, System.EventArgs e)
        {
            UpdateLayout();
        }
    }
}