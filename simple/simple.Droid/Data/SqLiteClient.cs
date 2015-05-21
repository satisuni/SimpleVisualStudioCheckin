using Xamarin.Forms;
using simple.Droid.Data;

[assembly: Dependency(typeof(SQLiteClient))]
namespace simple.Droid.Data
{
    using System;
    using simple.Data;
    using SQLite.Net.Async;
    using System.IO;
    using SQLite.Net.Platform.XamarinAndroid;
    using SQLite.Net;

    public class SQLiteClient : ISQLite
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var sqliteFilename = "Hotels.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            var path = Path.Combine(documentsPath, sqliteFilename);

            var platform = new SQLitePlatformAndroid();

            var connectionWithLock = new SQLiteConnectionWithLock(
                                         platform,
                                         new SQLiteConnectionString(path, true));

            var connection = new SQLiteAsyncConnection(() => connectionWithLock);

            return connection;
        }
    }
}