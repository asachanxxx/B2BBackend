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
        public string type { get; set; } = "checkbox";
        public int count { get; set; }
        public bool checked_def { get; set; } = false;
        public bool disabled { get; set; } = false;

    }


}
