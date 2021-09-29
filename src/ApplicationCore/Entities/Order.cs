using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Order : BaseEntity
    {
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
