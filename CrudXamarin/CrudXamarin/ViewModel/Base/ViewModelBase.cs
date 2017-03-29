using CrudXamarin.Interfaces;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using Xamarin.Forms;

namespace CrudXamarin.ViewModel.Base
{
    public abstract class ViewModelBase : ViewModelBase<object>
    {

    }
    public abstract class ViewModelBase<T> : INotifyPropertyChanged 
        where T : class, new()
    {
        private T _entidade;

        public IMessage Message { get; set; }

        public INavigation Navigation { get; set; }

        public T EntidadeAtual {
            get { return _entidade; }
            set
            {
                _entidade = value;
                RaisedPropertyChanged(() => EntidadeAtual);
            }
        }

        public ViewModelBase()
        {
            EntidadeAtual = new T();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisedPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void RaisedPropertyChanged<T>(Expression<Func<T>> expression)
        {
            var member = expression.Body as MemberExpression;
            var propertyInfo = member.Member as PropertyInfo;

            if (propertyInfo != null)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyInfo.Name));
            }
        }
    }
}
