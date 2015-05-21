using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace simple.Templates
{
    public class HostelTemplateCell : ViewCell
    {
        public HostelTemplateCell()
        {
            var titleLabel = new Label();
            var titleBinding = new Binding("Name");
            titleLabel.FontAttributes = Xamarin.Forms.FontAttributes.Bold;
            titleLabel.FontSize = 20;
            titleLabel.TextColor = Color.Red;
            titleLabel.SetBinding(Label.TextProperty, titleBinding);

            var valueEntry = new Label();
            var valueBinding = new Binding("Address");
            valueEntry.FontSize = 10;
            titleLabel.TextColor = Color.Gray;
            valueEntry.SetBinding(Label.TextProperty, valueBinding);

            //var accessoryImage = new Image();
            //accessoryImage.Source = "ic_action_new.png";

            var stackLayout = new StackLayout();
            stackLayout.Children.Add(titleLabel);
            stackLayout.Children.Add(valueEntry);

            var grid = new Grid
            {

                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,

                ColumnDefinitions = {
                                new ColumnDefinition{ Width = new GridLength(80 ,GridUnitType.Star) },
                                //new ColumnDefinition{ Width = new GridLength(20,GridUnitType.Star ) }
                        },
               Padding = 10
            };

            grid.Children.Add(stackLayout, 0, 0);
            Grid.SetColumnSpan(stackLayout, 1);
            //grid.Children.Add(accessoryImage, 1, 0);

            View = grid;
        }

    }
}
