using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.ViewModels.Product
{
    public class SpecLevelMasterVM 
    {
        public int SpecId { get; set; }
        public string SpecItemName { get; set; }
        public List<SpecLevelDetailsVM> Details { get; set; }
    }

    public class SpecLevelDetailsVM
    {
        public string SpecValue { get; set; }
    }
}
