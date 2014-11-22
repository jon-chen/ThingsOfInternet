using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ThingsOfInternet.ViewModels;

namespace ThingsOfInternet.Views
{	
    public partial class BlindSwitchDetailsPage : ContentPageBase<ThingViewModel>
	{	
        public BlindSwitchDetailsPage(ThingViewModel model) : base(model)
        {
            InitializeComponent();
        }
	}
}