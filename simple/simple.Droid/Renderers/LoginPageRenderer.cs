using System; 
using Android.App;
using simple;
using simple.Droid;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using simple.Pages;
using simple.Common;

[assembly: ExportRenderer (typeof (LoginPage), typeof (LoginPageRenderer))]
namespace simple.Droid
{
	public class LoginPageRenderer : PageRenderer
	{
		bool done = false;

		protected override void OnElementChanged (ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged(e);

            try
            {
                if (!done)
                {

                    // this is a ViewGroup - so should be able to load an AXML file and FindView<>
                    var activity = this.Context as Activity;
                    
                    var auth = new OAuth2Authenticator(
                        clientId: App.Current.Properties["clientId"].ToString(),
                        scope: App.Current.Properties["scope"].ToString(),
                        authorizeUrl: new Uri(App.Current.Properties["authorizeUrl"].ToString()),
                        redirectUrl: new Uri(App.Current.Properties["redirectUrl"].ToString()));

                    auth.Completed += (sender, eventArgs) =>
                    {
                        if (eventArgs.IsAuthenticated)
                        {
                            App.Current.MainPage = new ToDoPage();

                            //var request = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me"), null, eventArgs.Account);
                            var request = new OAuth2Request("GET", new Uri(" https://graph.facebook.com/me/photos"), null, eventArgs.Account);
                            // for google https://www.googleapis.com/oauth2/v1/userinfo?access_token=" + authToken
                            request.GetResponseAsync().ContinueWith(t =>
                            {
                                if (t.IsFaulted)
                                    Console.WriteLine("Error: " + t.Exception.InnerException.Message);
                                else
                                {
                                    string json = t.Result.GetResponseText();
                                    //Console.WriteLine(json);
                                    UtilMethods.GetValueFromJson(json, "name");
                                }
                            });
                          

                            App.Current.Properties["access_token"] = eventArgs.Account.Properties["access_token"].ToString();
                            App.Current.Properties["userName"] = eventArgs.Account.Username;
                            //AccountStore.Create(this).Save(eventArgs.Account, "Google");
                        }
                        else
                        {
                            // Auth failed - The only way to get to this branch on Google is to hit the 'Cancel' button.
                            App.Current.MainPage = new LoginPage();
                            App.Current.Properties["access_token"] = "";
                        }
                    };

                    //auth.AllowCancel = false;
                    activity.StartActivity(auth.GetUI(activity));
                    done = true;
                }
            }
            catch (Exception ex)
            {

            }
		}

        
	}
}
