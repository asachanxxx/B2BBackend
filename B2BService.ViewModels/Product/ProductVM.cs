using B2BService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.ViewModels.Product
{

    public class ProductSaveVM : BaseClass
    {
        public ProductVM Product { get; set; }
        public IEnumerable<SpecItemsVM> SpecItems { get; set; }
        public SupplierBundleVM SupplierWarrenty { get; set; }
    }

    public class ProductVM
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public string ShortName { get; set; }
        public string DisplayName { get; set; }
        public string PartNumber { get; set; }
        public string Series { get; set; }
        public string Name { get; set; }
        public string ItemNo { get; set; }
        public string UNSPSC { get; set; }
        public int Level1Id { get; set; }
        public int Level2Id { get; set; }
        public int Level3Id { get; set; }
        public decimal PriceValidityPeriod { get; set; }
        public decimal SupplierPrice { get; set; }
        public decimal ProductPrice { get; set; }
        public string DefaultImagePath { get; set; }
        public bool AddedByASeller { get; set; }
        public string AddedSellerID { get; set; }
    }

    public class SpecItemsVM {
        public int SpecItemId { get; set; }
        public string SpecItemName { get; set; }
        public string SpecItemDisplayName { get; set; }
        public string DataType { get; set; }
        public string Value { get; set; }
    }
}
