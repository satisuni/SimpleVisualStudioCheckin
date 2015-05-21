using simple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Xamarin.Forms;

namespace simple
{
    public class DetailView : ContentPage
    {
        public DetailView() { }

        public DetailView(HotelInfo currentListItem)
        {
            Content = new StackLayout
            {
                Children = {
					new Label { Text = currentListItem.Name}
                 
				}
            };
        }
    }
}
