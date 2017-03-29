using CrudXamarin.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CrudXamarin.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        private ICommand _cadastroCommand;
        private ICommand _listagemCommand;

        public ICommand CadastroCommand
        {
            get
            {
                return _cadastroCommand ?? (_cadastroCommand = new Command(() =>
                {
                    Navigation.PushAsync(new CadastroViewPage());
                }));
            }
        }

        public ICommand ListagemCommand
        {
            get
            {
                return _listagemCommand ?? (_listagemCommand = new Command(() =>
                {
                    Navigation.PushAsync(new PessoaViewPage());
                }));
            }
        }

    }
}
