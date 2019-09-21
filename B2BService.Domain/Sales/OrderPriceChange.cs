using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain.Sales
{
    public class OrderPriceChange:BaseClass
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public int DetailtId { get; set; }
        public string Remark { get; set; }
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }


    }
}
