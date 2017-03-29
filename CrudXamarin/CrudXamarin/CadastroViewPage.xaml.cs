using CrudXamarin.Data;
using CrudXamarin.Entidade;
using CrudXamarin.Interfaces;
using CrudXamarin.ViewModel;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrudXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroViewPage : ContentPage, IMessage
    {
        private Pessoa pessoa;
        //private PessoaDataService pessoaDataService;
        public CadastroViewPage()
        {
            InitializeComponent();
            var viewModel = new PessoaCadastroViewModel();
            viewModel.Navigation = this.Navigation;
            viewModel.Message = this;

            BindingContext = viewModel;
        }

        public CadastroViewPage(Pessoa pessoa)
        {
            InitializeComponent();
            var viewModel = new PessoaCadastroViewModel(pessoa);
            viewModel.Navigation = this.Navigation;
            viewModel.Message = this;

            BindingContext = viewModel;
        }
    }
}
