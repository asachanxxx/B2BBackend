using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.ViewModels.Product
{
    public class SearchVM
    {
        public int ModelId { get; set; }
        public int BrandId { get; set; }

        public int SeriesId { get; set; }

        public string Name { get; set; }
    }
}
