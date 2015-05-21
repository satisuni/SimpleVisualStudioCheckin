using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace simple.Pages
{
    public class StartPage : ContentPage
    {
        Button customFacebookButton;
        Button customGoogleButton;
        public StartPage()
        {
            RenderContent();
            customFacebookButton.Clicked += (object sender, EventArgs e) =>
            {

                try
                {
                    if (App.Current.Properties.Any(a=>a.Key.Equals("clientId")))
                    {
                        App.Current.Properties["clientId"]= "1403574013300580";
                    }
                    else
                    {
                        App.Current.Properties.Add("clientId", "1403574013300580");
                    }
                    if (App.Current.Properties.Any(a => a.Key.Equals("scope")))
                    {
                        App.Current.Properties["scope"] = "";
                    }
                    else
                    {
                        App.Current.Properties.Add("scope", "");
                    }
                    if (App.Current.Properties.Any(a => a.Key.Equals("authorizeUrl")))
                    {
                        App.Current.Properties["authorizeUrl"] = "https://m.facebook.com/dialog/oauth/";
                    }
                    else
                    {
                        App.Current.Properties.Add("authorizeUrl", "https://m.facebook.com/dialog/oauth/");
                    }
                    if (App.Current.Properties.Any(a => a.Key.Equals("redirectUrl")))
                    {
                        App.Current.Properties["redirectUrl"] = "http://www.facebook.com/connect/login_success.html";
                    }
                    else
                    {
                        App.Current.Properties.Add("redirectUrl", "http://www.facebook.com/connect/login_success.html");
                    }

                }
                catch(Exception ex)
                {
                }

                try
                {
                    Navigation.PushAsync(new LoginPage());
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }

            };


            customGoogleButton.Clicked += (object sender, EventArgs e) =>
            {
                try
                {
                    try
                    {
                        if (App.Current.Properties.Any(a=>a.Key.Equals("clientId")))
                        {
                            App.Current.Properties["clientId"] = "730990345527-h7r23gcdmdllgke4iud4di76b0bmpnbb.apps.googleusercontent.com";
                        }
                        else
                        {
                            App.Current.Properties.Add("clientId", "730990345527-h7r23gcdmdllgke4iud4di76b0bmpnbb.apps.googleusercontent.com");
                        }
                        if (App.Current.Properties.Any(a => a.Key.Equals("scope")))
                        {
                            App.Current.Properties["scope"] = "https://www.googleapis.com/auth/userinfo.email";
                        }
                        else
                        {
                            App.Current.Properties.Add("scope", "https://www.googleapis.com/auth/userinfo.email");
                        }
                        if (App.Current.Properties.Any(a => a.Key.Equals("authorizeUrl")))
                        {
                            App.Current.Properties["authorizeUrl"] = "https://accounts.google.com/o/oauth2/auth";
                        }
                        else
                        {
                            App.Current.Properties.Add("authorizeUrl", "https://accounts.google.com/o/oauth2/auth");
                        }
                        if (App.Current.Properties.Any(a => a.Key.Equals("redirectUrl")))
                        {
                            App.Current.Properties["redirectUrl"] = "https://www.googleapis.com/plus/v1/people/me";
                        }
                        else
                        {
                            App.Current.Properties.Add("redirectUrl", "https://www.googleapis.com/plus/v1/people/me");
                        }

                    }
                    catch
                    {
                    }

                    Navigation.PushAsync(new LoginPage());
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }

            };
        }

        private void RenderContent()
        {

            ScrollView scrollview = new ScrollView() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            var rootLayout = new StackLayout() { BackgroundColor = Color.White, Spacing = 15, Orientation = StackOrientation.Vertical, HorizontalOptions = LayoutOptions.FillAndExpand, Padding = new Thickness(0, 0, 0, 10) }; // Padding = new Thickness(45, 15, 45, 15),


            ContentView header = new ContentView() { BackgroundColor = Color.White, HorizontalOptions = LayoutOptions.FillAndExpand, Padding = new Thickness(0, 80, 0, 0) };
            rootLayout.Children.Add(header);


            customGoogleButton = new Button()
            {
                Text = " LOG IN WITH GOOGLE ",
                FontAttributes = FontAttributes.Bold,
                BackgroundColor = Color.FromRgb(459,89,152),
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Center
            };

            customFacebookButton = new Button()
            {
                Text = " LOG IN WITH FACEBOOK ",
                FontAttributes = FontAttributes.Bold,
                BackgroundColor = Color.Aqua,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Center
            };

            rootLayout.Children.Add(customFacebookButton);
            rootLayout.Children.Add(customGoogleButton);
            scrollview.Content = rootLayout;

            if (Device.OS == TargetPlatform.Android)
            {
                scrollview.IsClippedToBounds = true;
            }

            Content = scrollview;

        }
    }
}
