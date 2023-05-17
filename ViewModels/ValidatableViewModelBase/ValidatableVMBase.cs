using Cataloguer.ViewModels.ViewModel_Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cataloguer.ViewModels.ValidatableViewModelBase
{
    internal abstract class ValidatableVMBase : BaseViewModel, IDataErrorInfo
    {
        private string _error;

        public string Error
        {
            get => _error;
            private set => Set(ref _error, value);
        }

        public string this[string columnName] => Error = Validate(columnName);
        protected abstract string Validate(string columnName);
    }
}
