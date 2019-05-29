using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain.Inventory
{
    public class SupplierProducts:BaseClass
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int SupplierID { get; set; }
        public decimal Price { get; set; }

    }
}
