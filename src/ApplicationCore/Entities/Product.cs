using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string DescriptionShort { get; set; }
        public string DescriptionLong { get; set; }
        public decimal Price { get; set; }
        public string ProductSKU { get; set; }
        public int ProductStock { get; set; }
        public string PictureUri { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
