using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Facebook;
using Xamarin.Forms;
using simple.Pages;

namespace simple.Droid
{
	[Activity (Label = "FacebookLoginNativeActivity")]			
	public class FacebookLoginNativeActivity : Activity, Session.IStatusCallback, Request.IGraphUserCallback
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			// Open a FB Session and show login if necessary
			Session.OpenActiveSession (this, true, this);
		}

		protected override void OnActivityResult (int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult (requestCode, resultCode, data);

			// Relay the result to our FB Session
			Session.ActiveSession.OnActivityResult (this, requestCode, (int)resultCode, data);
		}

		public void Call (Session session, SessionState state, Java.Lang.Exception exception)
		{

			// Make a request for 'Me' information about the current user
			if (session.IsOpened) {
				Request.ExecuteMeRequestAsync (session, this);
			}
		}

		public void OnCompleted (Xamarin.Facebook.Model.IGraphUser user, Response response)
		{
			// 'Me' request callback
			if (user != null) {
				Console.WriteLine ("Got user: " + user.Name);
				Console.WriteLine ("You should save the user details....");
				var token = Session.ActiveSession.AccessToken;
				App.Current.MainPage = new FacebookAuthenticatedPage (user.Name, user.Id, token);
				this.Finish ();
			} else {
				Console.WriteLine ("Failed to get 'me'!");
			}
		}
	}
}