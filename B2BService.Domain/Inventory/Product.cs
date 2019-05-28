using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain.Inventory
{
    public class Product:BaseClass
    {
        public int Id { get; set; }
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
        public int Rating { get; set; }
        public decimal PriceValidityPeriod { get; set; }
        public decimal SupplierPrice { get; set; }
        public decimal ProductPrice { get; set; }
        public string DefaultImagePath { get; set; }
        public bool IsApproved { get; set; }
        public decimal ConversionRate { get; set; }
        public int CurrencyId { get; set; }
    }
}
