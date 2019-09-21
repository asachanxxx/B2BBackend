using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain.Inventory
{
    public class BestSellProduct:BaseClass
    {
        public int id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal CompareAtPrice { get; set; }
        public int Reviews { get; set; }
        public int Rating { get; set; }
        public int Availability { get; set; }
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
    }
}
