using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rivenditore.Models;

namespace Rivenditore.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        protected static Dictionary<string, string> Errors = new Dictionary<string, string>();
        

        public string Error => throw new NotImplementedException();
        public string this[string columnName]
        {
            get
            {
                
                string ErrorMsg = "";

                ValidationContext valContext = new ValidationContext(new CustomerExtension()) { MemberName = columnName };
                List<ValidationResult> ListaErrori = new List<ValidationResult>();

                if (!Validator.TryValidateProperty(

                    GetType().GetProperty(columnName).GetValue(this),
                    valContext,
                    ListaErrori
                    )) ErrorMsg = ListaErrori.First().ErrorMessage;

                /*Errors = new Dictionary<string, string>();*/

                if (!Errors.ContainsKey(columnName))
                    Errors.Add(columnName, ErrorMsg);
                else
                    Errors[columnName] = ErrorMsg;

                if (ErrorMsg != "")
                    return ErrorMsg;
                
                return "";
                    
                 
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropretyChanged(string p)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
        }


        
    }
}
