using SQLite.Net;
using System.IO;
using SQLite.Net.Platform.XamarinAndroid;
using Xamarin.Forms;
using CrudXamarin.Droid.Data;
using CrudXamarin.Data.DataService;

[assembly: Dependency(typeof(AndroidSQLite))]
namespace CrudXamarin.Droid.Data
{
    public class AndroidSQLite : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var dataBaseName = "DBPESSOA.db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var combinePath = Path.Combine(documentsPath, dataBaseName);

            var connection = new SQLiteConnection(new SQLitePlatformAndroid(), combinePath);

            return connection;
        }
    }
}