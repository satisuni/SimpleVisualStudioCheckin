using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using simple.Pages;
using simple.iOS.Renderers;
using Xamarin.Auth;

   [assembly: ExportRenderer (typeof (LoginPage), typeof (LoginPageRenderer))]

namespace simple.iOS.Renderers
{
    public class LoginPageRenderer : PageRenderer
    {
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            var auth = new OAuth2Authenticator(
                clientId: "", // your OAuth2 client id
                scope: "", // the scopes for the particular API you're accessing, delimited by "+" symbols
                authorizeUrl: new Uri(""), // the auth URL for the service
                redirectUrl: new Uri("")); // the redirect URL for the service

            auth.Completed += (sender, eventArgs) =>
            {
                // We presented the UI, so it's up to us to dimiss it on iOS.
                //App.SuccessfulLoginAction.Invoke();
                App.Current.MainPage = new ToDoPage();
                if (eventArgs.IsAuthenticated)
                {
                    // Use eventArgs.Account to do wonderful things
                    App.Current.Properties["access_token"] = eventArgs.Account.Properties["access_token"].ToString();
                    App.Current.Properties["userName"] = eventArgs.Account.Username;
                }
                else
                {
                    // The user cancelled
                }
            };

            PresentViewController(auth.GetUI(), true, null);
        }
    }
}
