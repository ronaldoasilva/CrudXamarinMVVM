using SQLite.Net;
using Xamarin.Forms;
using CrudXamarin.UWP.Data;
using System.IO;
using SQLite.Net.Platform.WinRT;
using CrudXamarin.Data.DataService;

[assembly: Dependency(typeof(UWPSQLitecs))]
namespace CrudXamarin.UWP.Data
{
    public class UWPSQLitecs : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var dataBaseName = "DBPESSOA.db3";
            var combinePath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, dataBaseName);

            var connection = new SQLiteConnection(new SQLitePlatformWinRT(), combinePath);

            return connection;
        }
    }
}
