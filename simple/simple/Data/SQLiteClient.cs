namespace simple.Data
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using SQLite.Net.Async;
	using Xamarin.Forms;
    using simple.Data;
    using simple.Models;

	public class SQLiteClient
	{
		private static readonly AsyncLock Mutex = new AsyncLock ();
		private readonly SQLiteAsyncConnection _connection;

		public SQLiteClient ()
		{
			_connection = DependencyService.Get<ISQLite> ().GetConnection ();
			CreateDatabaseAsync();
		}

		public async Task CreateDatabaseAsync ()
		{
			using (await Mutex.LockAsync ().ConfigureAwait (false)) {
				await _connection.CreateTableAsync<HotelInfo> ().ConfigureAwait (false);
			}
		}

        public async Task<List<HotelInfo>> GetHotelsAsync()
		{
            List<HotelInfo> hotels = new List<HotelInfo>();
			using (await Mutex.LockAsync ().ConfigureAwait (false)) {
                hotels = await _connection.Table<HotelInfo>().ToListAsync().ConfigureAwait(false);
			}

            return hotels;
		}

        public async Task Save(HotelInfo hotel)
		{
			using (await Mutex.LockAsync ().ConfigureAwait (false)) {
				// Because our conference model is being mapped from the dto,
				// we need to check the database by name, not id
                var existingHotel = await _connection.Table<HotelInfo>()
                        .Where(x => x.Name == hotel.Name)
						.FirstOrDefaultAsync ();

                if (existingHotel == null)
                {
                    await _connection.InsertAsync(hotel).ConfigureAwait(false);
				} else {
                    hotel.Id = existingHotel.Id;
                    await _connection.UpdateAsync(hotel).ConfigureAwait(false);
				}
			}
		}

        public async Task SaveAll(IEnumerable<HotelInfo> hotels)
		{
            foreach (var hotel in hotels)
            {
                await Save(hotel);
			}
		}

	}
}

