namespace simple.Data
{  
    using SQLite.Net.Async;

	public interface ISQLite {
		SQLiteAsyncConnection GetConnection();
	}
}