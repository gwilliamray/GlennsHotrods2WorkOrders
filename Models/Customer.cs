using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlennsHotrods2.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [DisplayName("Customer Name") ]
        public string CustomerName { get; set; }
        public string Contact { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        [DisplayName("Customer Since")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime CreateDate { get; set; }
        public string Email { get; set; }
       
        public int ServiceWriterId { get; set; }
        [DisplayName("Service Writer")]
        public ServiceWriter ServiceWriter { get; set; }

    }

   
}
