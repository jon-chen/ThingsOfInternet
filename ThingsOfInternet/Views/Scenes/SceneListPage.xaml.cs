using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ThingsOfInternet.ViewModels;

namespace ThingsOfInternet.Views
{	
	public partial class SceneListPage : ContentPageBase<SceneListViewModel>
	{	
        public SceneListPage (SceneListViewModel model) : base(model)
		{
			InitializeComponent();
		}

        protected override void OnInitializing()
        {
            base.OnInitializing();

            foreach (var vm in ViewModel.Items)
            {
                vm.Initialize();
            }
        }
	}
}

