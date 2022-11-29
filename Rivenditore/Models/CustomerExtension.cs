using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rivenditore.ViewModels;

namespace Rivenditore.Models
{

    //la calsse Customer avrà i suoi attributi in questa classe
    [MetadataTypeAttribute(typeof(CustomerExtension))]
    public partial class Customer : BaseViewModel
    {

    }

    class CustomerExtension
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Richiesto")]
        [StringLength(255, ErrorMessage = "il cognome deve essere minore di 255 caratteri")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Campo Richiesto")]
        [StringLength(255, ErrorMessage = "il nome deve essere minore di 255 caratteri")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo Richiesto")]
        [StringLength(16, ErrorMessage = "il codice fiscale deve essere minore di 16 caratteri")]
        public string FiscalCode { get; set; }

        [Required(ErrorMessage = "Campo Richiesto")]
        [StringLength(1000, ErrorMessage = "l'indirizzo deve essere minore di 1000 caratteri")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Campo Richiesto")]
        [StringLength(100, ErrorMessage = "il cognome deve essere minore di 255 caratteri")]
        public string City { get; set; }

        [Required(ErrorMessage = "Campo Richiesto")]
        [StringLength(5, ErrorMessage = "il CAP deve essere minore di 5 caratteri")]
        public string Cap { get; set; }

        [Required(ErrorMessage = "Campo Richiesto")]
        [StringLength(50, ErrorMessage = "la mail deve essere minore di 50 caratteri")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Campo Richiesto")]
        [StringLength(20, ErrorMessage = "il numero di telefono deve essere minore di 20 caratteri")]
        public string Phone { get; set; }
    }
}
