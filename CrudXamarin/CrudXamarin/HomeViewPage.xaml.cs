using CrudXamarin.Interfaces;
using CrudXamarin.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrudXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeViewPage : ContentPage, IMessage
    {
        public HomeViewPage()
        {
            InitializeComponent();

            var viewModel = new HomeViewModel();
            viewModel.Message = this;
            BindingContext = viewModel;
            viewModel.Navigation = this.Navigation;
        }

        //void OnCadastro(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new CadastroViewPage());
        //}

        //void OnListagem(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new PessoaViewPage());
        //}
    }
}
