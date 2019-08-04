using B2BService.Domain;
using B2BService.Domain.Inventory;
using B2BService.Unitilities;
using B2BService.ViewModels.Product;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Repository.SystemRepositories
{
    public class ProductRepository
    {
        public readonly StandAloneRepository StdRepo;
        public readonly IDbConnection Conn;
        public ProductRepository()
        {
            StdRepo = new StandAloneRepository();
            Conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SysConn"].ConnectionString);

        }

        /// <summary>
        /// This is used to search throuh system catelog data set. sellers supposed to pic one and enter rest of the details
        /// to make it a valied system product
        /// </summary>
        /// <param name="modelVM">Search model to pass</param>
        /// <returns>Type of CatelogItemsVM</returns>
        public async Task<IEnumerable<CateglogProducts>> SearchCatelogItems(SearchVM modelVM)
        {
            try
            {
                return await StdRepo.QueryStoredProcedure<SearchVM, CateglogProducts>(GlobalSPNames.CatelogProductSearchSPName, modelVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<int> SaveCatelog(CateglogProducts modelVM)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<CateglogProducts>(GlobalSPNames.AddCatelogProductSPName, modelVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Add a produt to the system
        /// </summary>
        /// <param name="modelVM"></param>
        /// <returns>type of int with the newly inserted produt ID</returns>
        public async Task<int> AddProduct(ProductSaveVM modelVM)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<ProductSaveVM>(GlobalSPNames.AddProductSPName, modelVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<CatelogDataFeedVM> GetCatelogDataFeed()
        {
            try
            {
                return await StdRepo.QueryStoredProcedure<CatelogDataFeedVM>(GlobalSPNames.GetCatelogDataFeedSP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<IEnumerable<ProductsForCatelogVM>> GetProductForCatelogSerachResult(int CatelogId)
        {
            try
            {

                return await StdRepo.ExcuteStoredProcedureToSave<ProductsForCatelogVM>(GlobalSPNames.GetProductForCatelogSerachResultSP, CatelogId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<WarrentyType>> GetAllWarrentyTypes()
        {
            try
            {
                var repo = new RepoBase<WarrentyType>("WarrentyType");
                return await repo.FindALL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddSupplierPriceForProduct(SupplierBundleVM modelVM)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<SupplierBundleVM>(GlobalSPNames.AddSupplierPriceForProductSPName, modelVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //public async Task<int> AddSupplierPriceForProduct(SupplierBundleVM modelVM)
        //{
        //    try
        //    {
        //        return await StdRepo.ExcuteStoredProcedureToSave<SupplierBundleVM>(GlobalSPNames.AddSupplierPriceForProductSPName, modelVM);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        public async Task<int> SearchExistingProduct(ProductSearchVM modelVM)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<ProductSearchVM>(GlobalSPNames.SearchExistingProductSPName, modelVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductSaveVM> DuplicateProduct(int ProductId)
        {
            try
            {

                return await StdRepo.QueryStoredProcedure<ProductSaveVM>(GlobalSPNames.DuplicateProductSPName, ProductId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<ProductVMNew>> GetBestSellProducts()
        {
            try
            {
                ProductVMNew outpro = new ProductVMNew();
                using (IDbConnection db = Conn)
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@Status", dbType: DbType.Int32, direction: ParameterDirection.Output);


                    var orderDictionary = new Dictionary<int, ProductVMNew>();
                    var list = db.Query<ProductVMNew, features, ProductVMNew>(
                        GlobalSPNames.BestSellProductSPName,
                        (Pro, Fe) =>
                        {
                            ProductVMNew orderEntry;

                            if (!orderDictionary.TryGetValue(Pro.id, out orderEntry))
                            {
                                orderEntry = Pro;
                                orderEntry.features = new List<features>();
                                orderDictionary.Add(orderEntry.id, orderEntry);
                            }

                            orderEntry.features.Add(Fe);
                            return orderEntry;
                        },
                        splitOn: "id", param: parameter, commandType: CommandType.StoredProcedure)
                    .Distinct()
                    .ToList();

                    list.ForEach(x => x.badges = new List<string>() { "New", "Xprice" });
                    list.ForEach(x => x.images = new List<string>() { "http://localhost/images/ProductImg_Init/" + x.id + ".jpg", "http://localhost/images/ProductImg_Init/" + x.id + ".jpg" });

                    return list;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProductVMNew>> GetFeatureProducts()
        {
            try
            {
                ProductVMNew outpro = new ProductVMNew();
                using (IDbConnection db = Conn)
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@Status", dbType: DbType.Int32, direction: ParameterDirection.Output);


                    var orderDictionary = new Dictionary<int, ProductVMNew>();
                    var list = db.Query<ProductVMNew, features, ProductVMNew>(
                        GlobalSPNames.FeatureProductsSPName,
                        (Pro, Fe) =>
                        {
                            ProductVMNew orderEntry;

                            if (!orderDictionary.TryGetValue(Pro.id, out orderEntry))
                            {
                                orderEntry = Pro;
                                orderEntry.features = new List<features>();
                                orderDictionary.Add(orderEntry.id, orderEntry);
                            }

                            orderEntry.features.Add(Fe);
                            return orderEntry;
                        },
                        splitOn: "id", param: parameter, commandType: CommandType.StoredProcedure)
                    .Distinct()
                    .ToList();

                    list.ForEach(x => x.badges = new List<string>() { "New", "Xprice" });
                    list.ForEach(x => x.images = new List<string>() { "http://localhost/images/ProductImg_Init/"+x.id +".jpg", "http://localhost/images/ProductImg_Init/" + x.id + ".jpg" });

                    return list;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProductVMNew>> GetNewArrivalProduct()
        {
            try
            {
                ProductVMNew outpro = new ProductVMNew();
                using (IDbConnection db = Conn)
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@Status", dbType: DbType.Int32, direction: ParameterDirection.Output);


                    var orderDictionary = new Dictionary<int, ProductVMNew>();
                    var list = db.Query<ProductVMNew, features, ProductVMNew>(
                        GlobalSPNames.NewArrivalProductSPName,
                        (Pro, Fe) =>
                        {
                            ProductVMNew orderEntry;

                            if (!orderDictionary.TryGetValue(Pro.id, out orderEntry))
                            {
                                orderEntry = Pro;
                                orderEntry.features = new List<features>();
                                orderDictionary.Add(orderEntry.id, orderEntry);
                            }

                            orderEntry.features.Add(Fe);
                            return orderEntry;
                        },
                        splitOn: "id", param: parameter, commandType: CommandType.StoredProcedure)
                    .Distinct()
                    .ToList();

                    list.ForEach(x => x.badges = new List<string>() { "New", "Xprice" });
                    list.ForEach(x => x.images = new List<string>() { "http://localhost/images/ProductImg_Init/" + x.id + ".jpg", "http://localhost/images/ProductImg_Init/" + x.id + ".jpg" });

                    return list;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductVMSingle> GetSingleProduct(int Id)
        {
            try
            {
                ProductVMSingle outpro = new ProductVMSingle();
                using (IDbConnection db = Conn)
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@Status", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    parameter.Add("@id", Id , dbType: DbType.Int32, direction: ParameterDirection.Input);


                    var orderDictionary = new Dictionary<int, ProductVMSingle>();
                    var list = db.Query<ProductVMSingle, features, ProductVMSingle>(
                        GlobalSPNames.NewArrivalProductSingleSPName,
                        (Pro, Fe) =>
                        {
                            ProductVMSingle orderEntry;

                            if (!orderDictionary.TryGetValue(Pro.id, out orderEntry))
                            {
                                orderEntry = Pro;
                                orderEntry.features = new List<features>();
                                orderDictionary.Add(orderEntry.id, orderEntry);
                            }

                            orderEntry.features.Add(Fe);
                            return orderEntry;
                        },
                        splitOn: "id", param: parameter, commandType: CommandType.StoredProcedure)
                    .Distinct()
                    .ToList();

                    list.ForEach(x => x.badges = new List<string>() { "New", "Xprice" });
                    list.ForEach(x => x.images = new List<string>() { "http://localhost/images/ProductImg_Init/" + x.id + ".jpg", "http://localhost/images/ProductImg_Init/" + x.id + ".jpg" });

                    return list.First();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProductSpecificationsGroups>> GetSpecificationForGivenProduct(int Id)
        {
            try
            {
                ProductSpecificationsGroups outpro = new ProductSpecificationsGroups();
                using (IDbConnection db = Conn)
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@Status", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    parameter.Add("@ProId", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);


                    var orderDictionary = new Dictionary<int, ProductSpecificationsGroups>();
                    var list = db.Query<ProductSpecificationsGroups, ProductSpecifications, ProductSpecificationsGroups>(
                        GlobalSPNames.SpecificationForGivenProductSPName,
                        (Pro, Fe) =>
                        {
                            ProductSpecificationsGroups orderEntry;

                            if (!orderDictionary.TryGetValue(Pro.GroupID, out orderEntry))
                            {
                                orderEntry = Pro;
                                orderEntry.Details = new List<ProductSpecifications>();
                                orderDictionary.Add(orderEntry.GroupID, orderEntry);
                            }

                            orderEntry.Details.Add(Fe);
                            return orderEntry;
                        },
                        splitOn: "ProductId", param: parameter, commandType: CommandType.StoredProcedure)
                    .Distinct()
                    .ToList();

                    return list;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SpecLevelMasterVM>> GetSpecGrouping(int Id , bool isproduct)
        {
            try
            {
                string SpName = "";
                SpecLevelMasterVM outpro = new SpecLevelMasterVM();
                using (IDbConnection db = Conn)
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@Status", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    if (isproduct)
                    {
                        parameter.Add("@ProId", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                        SpName = GlobalSPNames.SpecLevelDetailSPName;
                    }
                    else {
                        parameter.Add("@Level3Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                        SpName = GlobalSPNames.SpecLevelDetailByLevelSPName;
                    }

                    

                    var orderDictionary = new Dictionary<int, SpecLevelMasterVM>();
                    var list = db.Query<SpecLevelMasterVM, SpecLevelDetailsVM, SpecLevelMasterVM>(
                        SpName,
                        (Pro, Fe) =>
                        {
                            SpecLevelMasterVM orderEntry;

                            if (!orderDictionary.TryGetValue(Pro.SpecId, out orderEntry))
                            {
                                orderEntry = Pro;
                                orderEntry.Details = new List<SpecLevelDetailsVM>();
                                orderDictionary.Add(orderEntry.SpecId, orderEntry);
                            }

                            orderEntry.Details.Add(Fe);
                            return orderEntry;
                        },
                        splitOn: "SpecValue", param: parameter, commandType: CommandType.StoredProcedure)
                    .Distinct()
                    .ToList();

                    return list;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
