using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain.Inventory
{
    public class CateglogProducts:BaseClass
    {

        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string PartNumber { get; set; }
        public string Series { get; set; }
        public string Name { get; set; }
        public string ItemNo { get; set; }
        public string UNSPSC { get; set; }
        public string Level1Id { get; set; }


    }
}
