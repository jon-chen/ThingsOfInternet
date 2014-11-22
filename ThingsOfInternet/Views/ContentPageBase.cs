using System;
using Xamarin.Forms;
using ThingsOfInternet.ViewModels;
using Unity = Microsoft.Practices.Unity;

namespace ThingsOfInternet.Views
{
    public class ContentPageBase<TViewModel> : ContentPage
        where TViewModel : PageViewModelBase
    {
        private bool isInitialized;

        protected TViewModel ViewModel { get; set; }

        public ContentPageBase(TViewModel model)
        {
            ViewModel = model;
            BindingContext = ViewModel;
        }

        protected override void OnAppearing()
        {
            if (!isInitialized)
            {
                OnInitializing();
                isInitialized = true;
            }

            base.OnAppearing();
        }

        protected virtual void OnInitializing()
        {
            ViewModel.Initialize();
        }
    }
}

