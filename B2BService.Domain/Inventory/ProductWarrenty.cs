using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain.Inventory
{
    public class ProductWarrenty
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string PartWarrenty { get; set; }
        public string PartWarrentyType { get; set; }
        public string LaborWarrenty { get; set; }
        public string LaborWarrentyType { get; set; }
        public string WarrantySummary { get; set; }
        public string ReturnPolicies { get; set; }
        public string ReturnPoliciesDocPath { get; set; }
        public string Website { get; set; }
        public string SupportPhone { get; set; }
        public string SupportEmail { get; set; }

    }
}
