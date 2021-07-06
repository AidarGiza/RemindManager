using RemindManager.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace RemindManager.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}