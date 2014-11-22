using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ThingsOfInternet.ViewModels;

namespace ThingsOfInternet.Views
{	
    public partial class LightSwitchDetailsPage : ContentPageBase<ThingViewModel>
	{	
        public LightSwitchDetailsPage(ThingViewModel model) : base(model)
        {
            InitializeComponent();
        }
	}
}