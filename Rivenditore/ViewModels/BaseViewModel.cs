using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rivenditore.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropretyChanged(string p)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
        }

        public string this[string columnName] => throw new NotImplementedException();

        public string Error { get 
            {
                ValidationContext ValCon = new ValidationContext(this) { MemberName = columnName };
                List<ValidationResult> ListaErrori = new List<ValidationResult>();

                if (Validator.TryValidateProperty(
                    GetType().GetProperty(columnName).GetValue(this),
                    ValCon,
                    ListaErrori
                    ))
                    return "";
                return ListaErrori.First().ErrorMessage;
                
            } 
        }
    }
}
