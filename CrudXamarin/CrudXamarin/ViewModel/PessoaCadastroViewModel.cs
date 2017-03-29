using CrudXamarin.Data;
using CrudXamarin.Data.DataService;
using CrudXamarin.Entidade;
using CrudXamarin.Entidade.Exceptions;
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
    public class PessoaCadastroViewModel : ViewModelBase<Pessoa>
    {
        private ICommand _salvarCommand;
        private ICommand _excluirCommand;
        private ICommand _atualizarCommand;
        private PessoaDataService _dataService;
        private bool _salvarVisibilidade;
        private bool _excluirVisibilidade;
        private bool _atualizarVisibilidade;

        public bool SalvarVisibilidade
        {
            get { return _salvarVisibilidade; }
            set
            {
                _salvarVisibilidade = value;
                RaisedPropertyChanged(() => SalvarVisibilidade);
            }
        }

        public bool ExcluirVisibilidade
        {
            get { return _excluirVisibilidade; }
            set
            {
                _excluirVisibilidade = value;
                RaisedPropertyChanged(() => ExcluirVisibilidade);
            }
        }

        public bool AtualizarVisibilidade
        {
            get { return _atualizarVisibilidade; }
            set
            {
                _atualizarVisibilidade = value;
                RaisedPropertyChanged(() => AtualizarVisibilidade);
            }
        }

        public PessoaCadastroViewModel()
        {
            _dataService = new PessoaDataService(DependencyService.Get<ISQLite>().GetConnection());
            SetVisibility(EntidadeAtual.Id == 0);
        }

        public PessoaCadastroViewModel(Pessoa pessoa)
            : this()
        {
            EntidadeAtual = pessoa;
            SetVisibility(EntidadeAtual.Id == 0);
        }

        private void SetVisibility(bool isnew)
        {
            SalvarVisibilidade = isnew;
            AtualizarVisibilidade = !isnew;
            ExcluirVisibilidade = !isnew;
        }

        public ICommand SalvarCommand
        {
            get
            {
                return _salvarCommand ?? (_salvarCommand = new Command(() =>
                {
                    try
                    {
                        EntidadeAtual.Validate();
                        _dataService.Salvar(EntidadeAtual);
                        Message.DisplayAlert("Sucesso", "Pessoa cadastrado com sucesso!", "Ok");
                        Navigation.PushAsync(new PessoaViewPage());
                    }
                    catch (ObrigatorioException obrigatorio)
                    {
                        Message.DisplayAlert("Error", obrigatorio.Message, "Ok");
                    }
                    catch (Exception ex)
                    {
                        Message.DisplayAlert("Error", "Erro ao salvar registro!", "Ok");
                    }
                }));
            }
        }

        public ICommand ExcluirCommand
        {
            get
            {
                return _excluirCommand ?? (_excluirCommand = new Command(async () =>
                {
                    try
                    {
                        var action = await Message.DisplayActionSheet("Deseja exlcuir esta pessoa?", "Canncel", null, "Sim", "Não");

                        switch (action)
                        {
                            case "Sim":
                                _dataService.Excluir(EntidadeAtual);
                                await Message.DisplayAlert("Sucesso", "Pessoa excluida com sucesso!", "Ok");
                                await Navigation.PushAsync(new PessoaViewPage());
                                break;
                            case "Não":
                            default:
                                break;
                        }
                    }
                    catch (Exception)
                    {
                        await Message.DisplayAlert("Error", "Erro ao excluir registro!", "Ok");
                    }
                }));
            }
        }

        public ICommand AtualizarCommand
        {
            get
            {
                return _atualizarCommand ?? (_atualizarCommand = new Command(() =>
                {
                    try
                    {
                        EntidadeAtual.Validate();
                        _dataService.Atualizar(EntidadeAtual);
                        Message.DisplayAlert("Sucesso", "Pessoa atualizada com sucesso!", "Ok");
                        Navigation.PushAsync(new PessoaViewPage());
                    }
                    catch (ObrigatorioException obrigatorio)
                    {
                        Message.DisplayAlert("Error", obrigatorio.Message, "Ok");
                    }
                    catch (Exception)
                    {
                        Message.DisplayAlert("Error", "Erro ao atualizar registro!", "Ok");
                    }
                }));
            }
        }
    }
}
