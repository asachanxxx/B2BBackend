using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain
{
    public class Level3 : BaseClass
    {
        public int Id { get; set; }
        public int Level1Id { get; set; }
        public int Level12d { get; set; }
        public string Code { get; set; }
        public string Level3Name { get; set; }
        public int NoOfClicks { get; set; }
        public int NoOfImpressions { get; set; }
        public int SpecMasterId { get; set; }
        public string Url { get; set; }
        public string External { get; set; }
        public string Target { get; set; }
    }
}
