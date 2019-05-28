using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain
{
    public class Level2 : BaseClass
    {
        public int Id { get; set; }
        public int Level1Id { get; set; }
        public string Code { get; set; }
        public string Level2Name { get; set; }
        public int SpecMasterId { get; set; }
        
    }
}
