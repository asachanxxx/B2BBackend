using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain.Sales
{
    public class SupplierOrderHeader : BaseClass
    {
        public int Id { get; set; }
        public int QHid { get; set; }
        public string OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public int SupplierId { get; set; }
        public decimal Subtotal { get; set; }
        public decimal ShippingCharges { get; set; }
        public decimal Tax { get; set; }
        public decimal Additions { get; set; }
        public decimal Deductions { get; set; }
        public decimal NetTotal { get; set; }
        public DateTime Date { get; set; }
        /// <summary>
        ///  1-Active
        ///  2-Approvedbysupplier
        ///  3-ReadyToDeliver
        ///  4-IdDispaced
        ///  5-IsDeliveredToCus
        /// </summary>
        public int Status { get; set; }
    }
}
