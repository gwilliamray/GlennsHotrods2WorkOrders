using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlennsHotrods2.Models
{
    public class WorkOrderImage
    {
        public int WorkOrderImageId { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }


        // I will need to add the Id manually if I want to keep them
        public int CustomerId { get; set; }
       // public Customer customer { get; set; }

        public int WorkOrderId { get; set; }
      //  public WorkOrder workOrder { get; set; }

    }
}
