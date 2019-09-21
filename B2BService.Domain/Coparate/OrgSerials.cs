using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain.Coparate
{
    public class OrgSerials
    {
        public int Id { get; set; }
        /// <summary>
        /// 1- Qutation
        /// 2- PO
        /// </summary>
        public int TypeId { get; set; }
        public int OrgId { get; set; }
        public int Serial { get; set; }
        

    
    }
}
