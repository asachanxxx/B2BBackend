using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain
{
    public class Level1: BaseClass
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Level1Name { get; set; }
        public int NoOfClicks { get; set; }
        public int NoOfImpressions { get; set; }
    }
}
