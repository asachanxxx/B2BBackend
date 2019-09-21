using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain.Sales
{
    public class QuotationDetails : BaseClass
    {
        public int Id { get; set; }
        public int QHId { get; set; }
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal Additions { get; set; }
        public decimal Deductions { get; set; }
        public decimal Total { get; set; }
        /// <summary>
        ///  1-Active
        ///  2-Revised
        ///  3-Approved
        ///  4-Closed
        /// </summary>
        public int Status { get; set; }
        public string Remarks { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
