using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace simple.Pages
{
    public class CustomButton : Button
    {
        //this class is a placeholder for the custom renderer on android.
        public CustomButton()
        {
            this.Clicked += (object sender, EventArgs e) =>
            {
                Debug.WriteLine("Does nothing by default.");
            };
        }
    }
}
