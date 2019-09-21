using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain.Sales
{
    public class QuotationRevision : BaseClass
    {

        public int Id { get; set; }
        public int QHid { get; set; }
        public int QDId { get; set; }
        public decimal OriginalAmount { get; set; }
        public decimal RevAmount { get; set; }
        public decimal OriginalQty { get; set; }
        public decimal RevQty { get; set; }
        /// <summary>
        /// indicate if Qty or Price Revised
        /// </summary>
        public decimal ISQtyOrPrice { get; set; }


        
        
        
        
        

    }
}
