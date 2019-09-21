using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain.Sales
{
    public class QuotationMaster : BaseClass
    {
        public int Id { get; set; }
        public string QNumber { get; set; }
        public string CustomerId { get; set; }
        public string SupplierId { get; set; }
        public decimal Subtotal { get; set; }
        public decimal ShippingCharges { get; set; }
        public decimal Tax { get; set; }
        public decimal Additions { get; set; }
        public decimal Deductions { get; set; }
        public decimal NetTotal { get; set; }
        public DateTime Date { get; set; }
        /// <summary>
        /// 1- Active
        /// 2- ApprovedBySupplier
        /// 3- Order Created
        /// 4- close
       
        /// </summary>
        public int Status { get; set; }

        public string Remarks { get; set; }
        public int OrgId { get; set; }


    }
}
