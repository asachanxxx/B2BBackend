using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain.Sales
{
    public class SupplierOrderDetails : BaseClass
    {

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int QDId { get; set; }
        public int ProductId { get; set; }

        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal Additions { get; set; }
        public decimal Deductions { get; set; }
        public decimal Total { get; set; }
        /// <summary>
        /// 1- Active
        /// 2- revised
        /// 3- Approved
        /// </summary>
        public int Status { get; set; }

    }
}
