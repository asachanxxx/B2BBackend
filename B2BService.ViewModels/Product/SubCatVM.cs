using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.ViewModels.Product
{
    public class SubCatVM
    {
        public int Subcategory1Id { get; set; }
        public string Subcategory1Name { get; set; }
        public string ImageUrl { get; set; }

        public IEnumerable<Subcat2View> Details { get; set; }
    }

    public class Subcat2View
    {

        public int Subcategory2Id { get; set; }
        public string Subcategory2Name { get; set; }
    }
}
