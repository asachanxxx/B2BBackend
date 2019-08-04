using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain
{
    public class SpecDetail : BaseClass
    {
        public int Id { get; set; }
        public int SpecMasterId { get; set; }
        public int SpecItemId { get; set; }
        public string DataType { get; set; }
        public string DefaultValue { get; set; }
        public bool IsApproved { get; set; }
        public int SpecGroupId { get; set; }
    }
}
