using CrudXamarin.Data.DataService;
using CrudXamarin.Entidade;
using SQLite.Net;
using System.Collections.Generic;
using System.Linq;

namespace CrudXamarin.Data
{
    public class PessoaDataService : ISQLiteOperations
    {
        private SQLiteConnection _connection;

        public PessoaDataService(SQLiteConnection connection)
        {
            //_connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection = connection;
            _connection.CreateTable<Pessoa>();
        }

        public void Atualizar(Pessoa pessoa)
        {
            _connection.Update(pessoa);
        }

        public void Excluir(Pessoa pessoa)
        {
            _connection.Delete(pessoa);
        }

        public void Salvar(Pessoa pessoa)
        {
            _connection.Insert(pessoa);
        }

        public IList<Pessoa> Select(Pessoa pessoa)
        {
            if (pessoa == null)
                return _connection.Table<Pessoa>().ToList();
            else
                return _connection.Table<Pessoa>().Where(x => x.Id == pessoa.Id).ToList();
        }
    }
}
