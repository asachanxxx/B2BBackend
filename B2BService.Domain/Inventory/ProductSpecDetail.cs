using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain
{
    public class ProductSpecDetail: BaseClass
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string SpecMasterId { get; set; }
        public string SpecDetailId { get; set; }
        public object SpecValue { get; set; }
    }
}
