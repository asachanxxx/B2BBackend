using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain.Coparate
{
    public class ProductRating:BaseClass
    {
        public int Id { get; set; }
        public int BuyerID { get; set; }
        public int ProductId { get; set; }
        public int Value { get; set; }
    }
}
