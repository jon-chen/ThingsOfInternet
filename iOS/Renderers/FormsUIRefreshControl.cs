using System;
using System.Windows.Input;
using MonoTouch.UIKit;
using Xamarin.Forms;

namespace ThingsOfInternet.iOS.Renderers
{
    public class FormsUIRefreshControl : UIRefreshControl
    {
        private bool isRefreshing;
        private string message;

        public FormsUIRefreshControl()
        {
            this.ValueChanged += (object sender, EventArgs e) =>
                {
                    var command = RefreshCommand;
                    if (command == null)
                    {
                        return;
                    }

                    command.Execute(null);
                };
        }


        /// <summary>
        /// Gets or sets the message to display
        /// </summary>
        /// <value>The message.</value>
        public string Message
        {
            get 
            { 
                return message; 
            }

            set
            {
                message = value;
                if (string.IsNullOrWhiteSpace(message))
                {
                    return;
                }

                this.AttributedTitle = new MonoTouch.Foundation.NSAttributedString(message);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is refreshing.
        /// </summary>
        /// <value><c>true</c> if this instance is refreshing; otherwise, <c>false</c>.</value>
        public bool IsRefreshing
        {
            get 
            { 
                return isRefreshing; 
            }

            set
            {
                isRefreshing = value;
                if (isRefreshing)
                {
                    BeginRefreshing();
                }
                else
                {
                    EndRefreshing();
                }
            }
        }

        /// <summary>
        /// Gets or sets the refresh command.
        /// </summary>
        /// <value>The refresh command.</value>
        public ICommand RefreshCommand { get; set; }
    }
}