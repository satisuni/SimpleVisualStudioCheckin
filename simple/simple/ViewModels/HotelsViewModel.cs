using PropertyChanged;
using simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using simple.Models;
using simple.Services;

namespace simple.ViewModels
{
    [ImplementPropertyChanged]
    public class HotelsViewModel
    {
        readonly SQLiteClient _db;

        public HotelsViewModel()
        {
           _db = new SQLiteClient();
        }

        public List<HotelInfo> Hotels { get; set; }

        public async Task GetHotels()
        {
            await GetLocalHotels();
            await GetRemoteHotels();
            await GetLocalHotels();
        }

        private async Task GetLocalHotels()
        {
            var hotels = await _db.GetHotelsAsync();
            this.Hotels = hotels.OrderBy(x => x.Name).ToList();
        }

        private async Task GetRemoteHotels()
        {
            var remoteClient = new ServiceClient();
            var hotels = await remoteClient.GetHotels ().ConfigureAwait(false);
            //List<HotelInfo> hotelInformation = new List<HotelInfo>();
            //hotelInformation.Add(new HotelInfo { Name = "Satish", Address = "Sr Software" });
            //hotelInformation.Add(new HotelInfo { Name = "Prabhat", Address = "PM" });
            //hotelInformation.Add(new HotelInfo { Name = "Srinu", Address = "Artitect" });
            //hotelInformation.Add(new HotelInfo { Name = "Shravan", Address = "CEO" });
            //this.Hotels = hotelInformation;
            this.Hotels = hotels;
            await _db.SaveAll(this.Hotels).ConfigureAwait(false);
        }
    }
}
