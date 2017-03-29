using System;

namespace CrudXamarin.Entidade.Exceptions
{
    public class ObrigatorioException : Exception
    {
        public ObrigatorioException(string message)
            : base(message) { }
    }
}
