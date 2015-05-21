using simple.Common;
using simple.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin;
using Xamarin.Forms;

namespace simple
{
    public class App : Application
    {
        public App()
        {
            object token;
            Constants.LoggedIn = false;

           // Xamarin.Insights.Initialize(Insights.DebugModeKey);

            if (App.Current.Properties.TryGetValue("access_token", out token))
            {
                if (Constants.AccessToken.ToString().Length > 0)
                {
                   // Constants.LoggedIn = true;
                    Constants.AccessToken = token;
                }
            }

            if (!Constants.LoggedIn)
            {
                // If we aren't logged in, then this may be the first time we're starting the app, in which case we want to
                // jam some settings in for our auth that we can retrieve later.  
                // But MAYBE, we are re-launching an app that was not logged in, in which case jamming these values in would 
                // cause a crash.  So we wrap them up in an empty try-catch, which is not elegant but is effective.

                //App.Current.Properties.Add("clientId", "");
                //App.Current.Properties.Add("scope", "");
                //App.Current.Properties.Add("authorizeUrl", "");
                //App.Current.Properties.Add("redirectUrl", "");

                // The root page of your application before login.
                MainPage = GetMainPage("StartPage");

            }
            else
            {
                // If we ARE logged in, then fire up the root page of your application after login.
                MainPage = GetMainPage("ToDo");
            }
          
        }
        public static Page GetMainPage(string page)
        {
            if (page == "ToDo")
            {
                return new NavigationPage(new ToDoPage());
            }
            return new NavigationPage(new StartPage());            
           
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
