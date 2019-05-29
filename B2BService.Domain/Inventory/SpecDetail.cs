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
        public string SpecItemName { get; set; }
        public string DataType { get; set; }
    }
}
