using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain.Inventory
{

    public class SpecProductDetails : BaseClass
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SpecGroupId { get; set; }
        public int SpecItemId { get; set; }
        public string SpecItemName { get; set; }
        public string SpecItemDisplayName { get; set; }
        public string DataType { get; set; }
        public string Value { get; set; }
        public bool IsApproved { get; set; }
    }
}
