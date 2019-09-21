using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain.Coparate
{
    public class Approval:BaseClass
    {
        public int Id { get; set; }
        public int Docid { get; set; }
        public int OrgId { get; set; }
        /// <summary>
        ///  1-Qutation by SupperUSer
        ///  2- Qutation by Supplier
        ///  2- PO by Supplier
        /// </summary>
        public int DocType { get; set; }
        public string QNumber { get; set; }
        public int CustomerId { get; set; }
        public string ApproveRemarks { get; set; }
    }
}
