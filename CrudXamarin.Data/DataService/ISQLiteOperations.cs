using CrudXamarin.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudXamarin.Data.DataService
{
    public interface ISQLiteOperations
    {
        void Salvar(Pessoa pessoa);
        void Excluir(Pessoa pessoa);
        void Atualizar(Pessoa pessoa);
        IList<Pessoa> Select(Pessoa pessoa);
    }
}
