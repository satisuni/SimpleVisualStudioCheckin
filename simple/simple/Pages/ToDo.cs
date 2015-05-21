using simple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using simple.ViewModels;
using simple.Templates;


namespace simple
{
    public class ToDoPage : ContentPage
    {
        //Label resultsLabel;
        ListView listView;
        List<HotelInfo> hotelInformation = new List<HotelInfo>();
        HotelsViewModel viewModel = null;
        public ToDoPage()
        {
            this.Content = new Label
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Loading"
            };

            Init();

        }

        private async Task Init()
        {
            var search = new SearchBar
            {
                Placeholder = "Search the hotel",
            };

            search.SearchButtonPressed += search_SearchButtonPressed;
            search.TextChanged += search_SearchButtonPressed;

          


            Label header = new Label
            {
                Text = "SearchBar",
                FontAttributes = Xamarin.Forms.FontAttributes.Bold,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Center
            };

            listView = new ListView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                
            };

            listView.ItemSelected += async (sender, e) =>
            {
                //label.Text = e.SelectedItem.ToString();
                await Navigation.PushAsync(new DetailView((HotelInfo)e.SelectedItem));
            };
          //  listView.ItemTapped += async (sender, e) =>
          //{
          //    //label.Text = e.SelectedItem.ToString();
          //    await Navigation.PushAsync(new DetailView((HotelInfo)e.Item));
          //};
            listView.BackgroundColor = Color.White;
            listView.RowHeight = 60;
           


            var cell = new DataTemplate(typeof(HostelTemplateCell));

            //cell.SetBinding(TextCell.TextProperty, "Name");
            //cell.SetBinding(TextCell.DetailProperty, "Description");//new Binding(path: "Start", stringFormat: "{0:MM/dd/yyyy}")
            //cell.SetBinding(TextCell.DetailColorProperty, "Red");
            //cell.SetBinding(TextCell.TextColorProperty, "White");
            listView.ItemTemplate = cell;

            viewModel = new HotelsViewModel();
            await viewModel.GetHotels();

            //hotelInformation.Add(new HotelInfo { Name = "Satish", Address = "Sr Software"});
            //hotelInformation.Add(new HotelInfo { Name = "Prabhat", Address = "PM" });
            //hotelInformation.Add(new HotelInfo { Name = "Srinu", Address = "Artitect" });
            //hotelInformation.Add(new HotelInfo { Name = "Shravan", Address = "CEO" });

            //listView.ItemsSource = hotelInformation;//viewModel.Hotels;

           listView.ItemsSource = viewModel.Hotels;
            this.Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(
                    left: 0,
                    right: 0,
                    bottom: 0,
                    top: Device.OnPlatform(iOS: 20, Android: 0, WinPhone: 0)),
                Children = { 
					header,
                    search,
                      new Label {
						XAlign = Xamarin.Forms.TextAlignment.Center,
						Text = string.Format ("Welcome to User: {0}", App.Current.Properties["userName"])
					},
                    //new Label {
                    //    XAlign = Xamarin.Forms.TextAlignment.Center,
                    //    Text = string.Format ("user id: {0}", id)
                    //},
					new Label {
						XAlign = Xamarin.Forms.TextAlignment.Center,
						Text = string.Format ("access token: {0}",  App.Current.Properties["access_token"])
					},
                    new ScrollView
                    {
                        Content = listView                       
                    } 
				}
            };
        }

        void search_SearchButtonPressed(object sender, EventArgs args)
        {
            // Get the search text.
            SearchBar searchBar = (SearchBar)sender;
            string searchText = searchBar.Text;
            //   DisplayAlert("message", searchText, "Ok");
            listView.ItemsSource = viewModel.Hotels.Where(a => a.Name.ToLower().Contains(searchText.ToLower()));
        }

    }
}
