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
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public int SeriesId { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public string CategoryId { get; set; }

    }
}
