using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain.Sales
{
    public class WarrantyChangeLog
    {
        public int Id { get; set; }

        public int ExistingWarrentyID { get; set; }
        public int ChangedWarrentyID { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; }
        public int ExistingDuration { get; set; }
        public int ChangedDuration { get; set; }
    }
}
