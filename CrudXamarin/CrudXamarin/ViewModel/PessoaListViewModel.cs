using CrudXamarin.Data;
using CrudXamarin.Data.DataService;
using CrudXamarin.Entidade;
using CrudXamarin.ViewModel.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace CrudXamarin.ViewModel
{
    public class PessoaListViewModel : ViewModelListagem<Pessoa>
    {
        private PessoaDataService _dataService;
        private ICommand _voltarCommand;
        private Pessoa _currentItem;

        public PessoaListViewModel()
        {
            LoadData();
        }

        public Pessoa CurrentItem
        {
            get { return _currentItem; }
            set
            {
                _currentItem = value;
                RaisedPropertyChanged(() => CurrentItem);

                if(_currentItem != null)
                    Navigation.PushAsync(new CadastroViewPage(_currentItem));
            }
        }
        private void LoadData()
        {
            _dataService = new PessoaDataService(DependencyService.Get<ISQLite>().GetConnection());
            Entidades = new ObservableCollection<Pessoa>(_dataService.Select(null));
        }

        public ICommand VoltarCommand
        {
            get
            {
                return _voltarCommand ?? (_voltarCommand = new Command(() =>
                {
                    Navigation.PushAsync(new HomeViewPage());
                }));
            }
        }
    }
}
