using B2BService.Domain;
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
    public class CategoryRepository
    {
        public readonly StandAloneRepository StdRepo;
        public readonly IDbConnection Conn;

        public CategoryRepository()
        {
            StdRepo = new StandAloneRepository();
            Conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SysConn"].ConnectionString);
        }


        public async Task<int> AddLevel1(Level1VM modelVM)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<Level1VM>(GlobalSPNames.AddLevel1SPName, modelVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<int> AddLevel2(Level2VM modelVM)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<Level2VM>(GlobalSPNames.AddLevel2SPName, modelVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<int> AddLevel3(Level3VM modelVM)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<Level3VM>(GlobalSPNames.AddLevel3SPName, modelVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SubCatVM>> GetDataForSubCategoryView(int CategoryId)
        {
            try
            {
              
                string sql = "select l2.Id as 'Subcategory1Id',	l2.Level2Name as 'Subcategory1Name','' as ImageUrl ,l2.Id as 'Subcategory1Id', l3.Id as 'Subcategory2Id',	l3.Level3Name as 'Subcategory2Name'  from Level2 as L2 inner join Level3 as L3   on L2.Id = L3.Level12d  where l2.Level1Id = " + CategoryId.ToString();
                using (IDbConnection db = Conn)
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@CategoryId", CategoryId, DbType.Int32, ParameterDirection.Input);
                    var orderDictionary = new Dictionary<int, SubCatVM>();
                    
                    var list =  db.Query<SubCatVM, Subcat2View, SubCatVM>(
                        sql,
                        (order, orderDetail) =>
                        {
                            SubCatVM orderEntry;

                            if (!orderDictionary.TryGetValue(order.Subcategory1Id, out orderEntry))
                            {
                                orderEntry = order;
                                orderEntry.Details = new List<Subcat2View>();
                                orderDictionary.Add(orderEntry.Subcategory1Id, orderEntry);
                            }

                            orderEntry.Details.Add(orderDetail);
                            return orderEntry;
                        },
                        splitOn: "Subcategory1Id", param:parameter
                        )
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

        public async Task<IEnumerable<Level2>> GetSubcategoryForSideMenu( int CategoryId) {
            try
            {
                RepoBase<Level2> repo = new RepoBase<Level2>("Level1");
                return await repo.FindExistanceMulti("Level1Id", CategoryId.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
