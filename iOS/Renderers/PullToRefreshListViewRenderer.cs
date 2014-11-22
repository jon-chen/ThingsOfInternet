using System;
using MonoTouch.UIKit;
using ThingsOfInternet.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using ThingsOfInternet.iOS.Renderers;

[assembly: ExportRendererAttribute(typeof(PullToRefreshListView), typeof(PullToRefreshListViewRenderer))]
namespace ThingsOfInternet.iOS.Renderers
{
    public class PullToRefreshListViewRenderer : ListViewRenderer
    {
        private FormsUIRefreshControl refreshControl;

        public PullToRefreshListViewRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);

            var pullToRefreshListView = (PullToRefreshListView)e.NewElement;

            var viewController = new UITableViewController(UITableViewStyle.Plain);
            viewController.TableView = this.Control;
            SetNativeControl(viewController.TableView);

            refreshControl = new FormsUIRefreshControl
                {
                    RefreshCommand = pullToRefreshListView.RefreshCommand,
                    Message = pullToRefreshListView.Message
                };

            viewController.RefreshControl = refreshControl;
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var pullToRefreshListView = (PullToRefreshListView)this.Element;

            if (e.PropertyName == PullToRefreshListView.IsRefreshingProperty.PropertyName) 
            {
                refreshControl.IsRefreshing = pullToRefreshListView.IsRefreshing;
            } 
            else if (e.PropertyName == PullToRefreshListView.MessageProperty.PropertyName) 
            {
                refreshControl.Message = pullToRefreshListView.Message;
            } 
            else if (e.PropertyName == PullToRefreshListView.RefreshCommandProperty.PropertyName) 
            {
                refreshControl.RefreshCommand = pullToRefreshListView.RefreshCommand;
            }
        }
    }
}