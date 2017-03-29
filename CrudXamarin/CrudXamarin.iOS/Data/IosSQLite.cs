using SQLite.Net;
using System.IO;
using SQLite.Net.Platform.XamarinIOS;
using Xamarin.Forms;
using CrudXamarin.iOS.Data;
using CrudXamarin.Data.DataService;

[assembly: Dependency(typeof(IosSQLite))]
namespace CrudXamarin.iOS.Data
{
    public class IosSQLite : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var dataBaseName = "DBPESSOA.db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var combinePath = Path.Combine(documentsPath, "..", "Library");
            var resultPath = Path.Combine(combinePath, dataBaseName);

            var connection = new SQLiteConnection(new SQLitePlatformIOS(), resultPath);

            return connection;
        }
    }
}
