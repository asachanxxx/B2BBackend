using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Unitilities
{
    public class GlobalSPNames
    {
        public static string AddOrganizationSPName { get; set; } = "SP_PRO_AddOrganization";
        public static string AddCatelogProductSPName { get; set; } = "SP_PRO_AddCatelogProduct";
        public static string AddProductSPName { get; set; } = "SP_PRO_AddProduct";
        public static string AddLevel1SPName { get; set; } = "SP_PRO_AddLevel1";
        public static string AddLevel2SPName { get; set; } = "SP_PRO_AddLevel2";
        public static string AddLevel3SPName { get; set; } = "SP_PRO_AddLevel3";
        public static string CatelogProductSearchSPName { get; set; } = "SP_PRO_CatelogProductSearch";
        public static string AddBrandSPName { get; set; } = "SP_PRO_AddBrand";
        public static string AddModelSPName { get; set; } = "SP_PRO_AddModel";
        public static string SaveSpecMasterSPName { get; set; } = "SP_PRO_AddSpecMaster";
        public static string SaveSpecItemSPName { get; set; } = "SP_PRO_AddSpecItem";
        public static string SaveSpecItemSPNameBulk { get; set; } = "SP_PRO_AddSpecItemBulk";
        public static string SaveSpecDetails{ get; set; } = "SP_PRO_SaveSpecDetails";
        public static string SaveSpecProductDetails { get; set; } = "SP_PRO_SaveSpecProductDetails";
        public static string GetDataForSubCategoryView { get; set; } = "SP_PRO_GetDataForSubCategoryView";
        public static string SaveModel { get; set; } = "SP_PRO_SaveModel";
        public static string SaveBrand { get; set; } = "SP_PRO_SaveBrand";
        public static string SaveSeries { get; set; } = "SP_PRO_SaveSeries";
        public static string GetCatelogDataFeedSP { get; set; } = "SP_PRO_GetCatelogDataFeedSP";
        public static string GetProductForCatelogSerachResultSP { get; set; } = "SP_PRO_GetProductForCatelogSerachResultSP";
        public static string AddSupplierPriceForProductSPName { get; set; } = "SP_PRO_AddSupplierPriceForProductSP";
        public static string SearchExistingProductSPName { get; set; } = "SP_PRO_SearchExistingProductSP";
        public static string DuplicateProductSPName { get; set; } = "SP_PRO_DuplicateProductSP";

        public static string FeatureProductsSPName { get; set; } = "SP_Get_FeatureProducts";
        public static string NewArrivalProductSPName { get; set; } = "SP_Get_NewArrivalProduct";
        public static string NewArrivalProductSingleSPName { get; set; } = "SP_Get_NewArrivalProductSingle";
        public static string SpecificationForGivenProductSPName { get; set; } = "SP_Get_SpecLevelDetail";

        public static string SpecLevelDetailSPName { get; set; } = "SP_Get_SpecLevelDetail";
        public static string SpecLevelDetailByLevelSPName { get; set; } = "SP_Get_SpecLevelDetailByLevel";

        
        public static string BestSellProductSPName { get; set; } = "SP_Get_BestSellProduct";

    }
}
