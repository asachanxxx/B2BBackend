using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain.Inventory
{
    public class SpecialProducts:BaseClass
    {

        public int Id { get; set; }
        public int ItemId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public int NoOfReviews { get; set; }
        public decimal Price { get; set; }
        public int SpecialType { get; set; }

    }
}
