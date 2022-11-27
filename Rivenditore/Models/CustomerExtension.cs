using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rivenditore.Models
{

    //la calsse Customer avrà i suoi attributi in questa classe
    [MetadataTypeAttribute(typeof(CustomerExtension))]
    public partial class Customer
    {

    }

    class CustomerExtension
    {
        public int Id { get; set; }
        [StringLength(5, ErrorMessage = "il cognomw deve essere minore di 5")]
        public string Surname { get; set; }
        public string Name { get; set; }
        public string FiscalCode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Cap { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
    }
}
