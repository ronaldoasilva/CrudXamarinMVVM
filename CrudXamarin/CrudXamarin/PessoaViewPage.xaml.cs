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
    public partial class PessoaViewPage : ContentPage, IMessage
    {
        
        public PessoaViewPage()
        {
            InitializeComponent();
            var viewModel = new PessoaListViewModel();
            viewModel.Message = this;
            viewModel.Navigation = this.Navigation;

            BindingContext = viewModel;
        }
        
    }
}
