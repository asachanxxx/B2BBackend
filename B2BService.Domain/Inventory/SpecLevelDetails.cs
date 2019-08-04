using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain.Inventory
{
    public class SpecLevelDetails:BaseClass
    {
        /*
         ID	Level3name	Id	SpecItemName	ValueX
            619	Computer Cases	126	Type	ATX Cube Case
         */

        public int Id { get; set; }
        public int Level3Id { get; set; }
        public string Level3name { get; set; }
        public int SpecId { get; set; }
        public string SpecItemName { get; set; }
        public string SpecValue { get; set; }
    }




}
