using System;
using GalaSoft.MvvmLight;

namespace ThingsOfInternet.ViewModels
{
    public class PageViewModelBase : ViewModelBase
    {
        protected string navigationTitle;

        public string NavigationTitle
        {
            get { return navigationTitle; }
            set { Set(() => NavigationTitle, ref navigationTitle, value); }
        }

        public PageViewModelBase()
        {

        }

        public virtual void Initialize()
        {

        }
    }
}

