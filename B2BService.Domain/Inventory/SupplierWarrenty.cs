using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain.Inventory
{
    public class SupplierWarrenty:BaseClass
    {
        public int Id { get; set; }
        public int WarrentyID { get; set; }
        public int SupplierID { get; set; }
        public int ProductId { get; set; }
        /// <summary>
        /// Duration in months
        /// </summary>
        public int Duration { get; set; }
        public decimal PriceForadditionalYear { get; set; }

        

    }
}
