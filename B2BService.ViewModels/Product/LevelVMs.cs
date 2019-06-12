using B2BService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.ViewModels.Product
{
    public class Level1VM: BaseClass
    {
        public string Code { get; set; }
        public string Level1Name { get; set; }
    }
    public class Level2VM : BaseClass
    {
        public int Level1Id { get; set; }
        public string Code { get; set; }
        public string Level2Name { get; set; }
        public int SpecMasterId { get; set; }
    }
    public class Level3VM : BaseClass
    {
        public int Level1Id { get; set; }
        public int Level12d { get; set; }
        public string Code { get; set; }
        public string Level3Name { get; set; }
    }
}
