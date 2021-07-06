using RemindManager.Models;
using RemindManager.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RemindManager.Views
{
    public partial class NewItemPage : ContentPage
    {
        public ReminderModel Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}