using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlennsHotrods2.Models
{
    public class WorkOrder
    {
        
        public int WorkOrderId { get; set; }
        public string AssignedTo { get; set; }
        [MaxLength(250)]
        public string WorkDescription { get; set; }
        
        public DateTime OrderDate { get; set; }
        public bool Completed { get; set; }
        public string PhoneNumber { get; set; }

        public int CustomerId { get; set; }
        public Customer customer { get; set; }

    }
}
