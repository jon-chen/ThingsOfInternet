using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Labs;
using ThingsOfInternet.Models;
using ThingsOfInternet.ViewModels;
using Unity = Microsoft.Practices.Unity;

namespace ThingsOfInternet.Views
{	
	public partial class ThingListPage : ContentPageBase<MainViewModel>
	{
        public ThingListPage (MainViewModel model) : base(model)
		{
			InitializeComponent ();
		}

        protected override void OnInitializing()
        {
            base.OnInitializing();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ItemsList.ItemTapped += ItemList_ItemTapped;
        }

        protected void ItemList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ICommand cmd = ViewModel.ShowDetailsCommand;
            cmd.Execute(e.Item);
            ItemsList.SelectedItem = null;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ItemsList.ItemTapped -= ItemList_ItemTapped;
        }
	}
}

