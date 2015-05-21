using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace simple.Pages
{
    /// <summary>
    /// This page is displayed after a user logs in with facebook.
    /// </summary>
    public class FacebookAuthenticatedPage : ContentPage
    {
        public FacebookAuthenticatedPage(string userName = "unknown", string id = "unknown", string accessToken = "unknown")
        {
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
					new Label {
						XAlign = Xamarin.Forms.TextAlignment.Center,
						Text = string.Format ("Welcome to Facebook User: {0}", userName)
					},
					new Label {
						XAlign = Xamarin.Forms.TextAlignment.Center,
						Text = string.Format ("Facebook user id: {0}", id)
					},
					new Label {
						XAlign = Xamarin.Forms.TextAlignment.Center,
						Text = string.Format ("Facebook access token: {0}", accessToken)
					},
				}
            };
        }
    }
}
