using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain.Sales
{
    public class QuotationWarranty:BaseClass
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public int WarrentyID { get; set; }
        public string Description { get; set; }
        public int SupplierID { get; set; }
        public int ProductId { get; set; }
        /// <summary>
        /// Duration in months
        /// </summary>
        public int Duration { get; set; }
        public decimal PriceForadditionalYear { get; set; }

    }
}
