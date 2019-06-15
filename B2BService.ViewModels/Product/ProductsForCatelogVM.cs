using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.ViewModels.Product
{
    public class ProductsForCatelogVM
    {

        public int ProductId { get; set; }
        public string ShortName { get; set; }
        public string DisplayName { get; set; }
        public decimal ProductPrice { get; set; }
        public string DefaultImagePath { get; set; }
        public bool AddedByASeller { get; set; }
        public string AddedSellerID { get; set; }

    }
}
