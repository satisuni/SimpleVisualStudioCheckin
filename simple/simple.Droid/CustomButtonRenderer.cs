using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using simple.Pages;
using simple.Droid;

[assembly:ExportRenderer (typeof(CustomButton), typeof(CustomButtonRenderer))]
namespace simple.Droid
{
	public class CustomButtonRenderer : ButtonRenderer
	{
		public CustomButtonRenderer ()
		{

		}

		protected override void OnElementChanged (ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged (e);

			var button = e.NewElement as CustomButton;
			button.Clicked += (object sender, EventArgs ee) => {
				Console.WriteLine ("Android Button Press");
				global::Xamarin.Forms.Forms.Context.StartActivity (typeof(FacebookLoginNativeActivity));
			};
		}
	}
}

