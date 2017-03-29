using SQLite.Net;

namespace CrudXamarin.Data.DataService
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
