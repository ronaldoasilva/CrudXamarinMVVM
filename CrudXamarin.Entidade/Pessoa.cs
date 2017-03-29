using CrudXamarin.Entidade.Base;
using CrudXamarin.Entidade.Exceptions;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudXamarin.Entidade 
{
    [Table("TBPESSOA")]
    public class Pessoa : EntidadeBase
    {
        private string _nome;
        private string _email;
        private string _endereco;
        private string _telefone;


        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        [MaxLength(150)]
        public string Nome
        {
            get { return _nome; }
            set {
                _nome = value;
                RaisedPropertyChanged(() => Nome);
            }
        }

        [MaxLength(100)]
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                RaisedPropertyChanged(() => Email);
            }
        }

        [MaxLength(200)]
        public string Endereco
        {
            get { return _endereco; }
            set
            {
                _endereco = value;
                RaisedPropertyChanged(() => Endereco);
            }
        }

        [MaxLength(20)]
        public string Telefone
        {
            get { return _telefone; }
            set
            {
                _telefone = value;
                RaisedPropertyChanged(() => Telefone);
            }
        }

        public override void Validate()
        {
            if(string.IsNullOrEmpty(Nome))
            {
                throw new ObrigatorioException("Campo nome deve ser preenchido.");
            }

            if (string.IsNullOrEmpty(Email))
            {
                throw new ObrigatorioException("Campo email deve ser preenchido.");
            }

            if (string.IsNullOrEmpty(Endereco))
            {
                throw new ObrigatorioException("Campo endereço deve ser preenchido.");
            }
        }
    }
}
