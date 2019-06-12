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
        public int SpecMasterId { get; set; }
        public int SpecDetailId { get; set; }
        public string SpecValue { get; set; }
        public string DataType { get; set; }
        
    }
}
