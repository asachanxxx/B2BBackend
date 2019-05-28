using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain
{
    public class BaseClass
    {
        public string IpAddress { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime CreatedWhen { get; set; }
        public DateTime ModifiedWhen { get; set; }
    }
}
