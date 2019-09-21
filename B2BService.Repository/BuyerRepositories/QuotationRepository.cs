using B2BService.Domain.Coparate;
using B2BService.Unitilities;
using B2BService.ViewModels.Organisazion;
using B2BService.ViewModels.Sales;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Repository.BuyerRepositories
{
    public class QuotationRepository
    {

        public readonly StandAloneRepository StdRepo;
        public readonly IDbConnection Conn;

        public QuotationRepository()
        {
            StdRepo = new StandAloneRepository();
            Conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SysConn"].ConnectionString);
        }


        public async Task<int> SaveQuotation(QutationVM obj)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<QutationVM>(GlobalSPNames.SaveQuotationSPName, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


      
        public async Task<int> ApprovePO(SupplierUserVM obj)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<SupplierUserVM>(GlobalSPNames.ApproveQuotationBySupperUserSPName, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdatePOStatus(UpdatePOS obj)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<UpdatePOS>(GlobalSPNames.UpdatePOStatusSPName, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeletePOItem(int POItemID)
        {
            try
            {
                using (IDbConnection db = Conn)
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@POItemID", POItemID, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    return await db.ExecuteAsync(GlobalSPNames.DeletePOItemSPName, param: parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> ApprovePOByCustomer(SupplierUserVM obj)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<SupplierUserVM>(GlobalSPNames.ApprovePOByCustomerSPName, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> GetQuotationHistory(int QuotationId)
        {
            try
            {
                using (IDbConnection db = Conn)
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@QuotationId", QuotationId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    return await db.ExecuteAsync(GlobalSPNames.DeletePOItemSPName, param: parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<QuotationMasterVMForView>> GetQuotationMasters(int OrgId)
        {
            try
            {
                using (IDbConnection db = Conn)
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@OrgId", OrgId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    return await db.QueryAsync<QuotationMasterVMForView>(GlobalSPNames.GetQuotationMastersSPName, param: parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<QuotationDetailsVMForView>> GetQuotationDetails(int QuoteId)
        {
            try
            {
                using (IDbConnection db = Conn)
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@QuoteId", QuoteId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    return await db.QueryAsync<QuotationDetailsVMForView>(GlobalSPNames.GetQuotationDetailsSPName, param: parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<QuotationWarrantyVMForView>> GetQuotationWarranty(int ProductId , int DocumentId)
        {
            try
            {
                using (IDbConnection db = Conn)
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    parameter.Add("@DocumentId", DocumentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    return await db.QueryAsync<QuotationWarrantyVMForView>(GlobalSPNames.GetQuotationWarrantySPName, param: parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<QuotationMasterVMForView>> GetSupplierApprovedQuotations(int OrgId, string UserId)
        {
            try
            {
                using (IDbConnection db = Conn)
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@OrgId", OrgId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    parameter.Add("@UserId", UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    return await db.QueryAsync<QuotationMasterVMForView>(GlobalSPNames.GetSupplierApprovedQuotationsSPName, param: parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> ApproveQuotationBySupperUser(int QutationId, string UserId)
        {
            /*
             if all ok and done OutStatus =1
             check if supplier approved the quitation first.(cehck status =2) if not OutStatus =2
             also check if the user is a supper user if not  OutStatus =3

             */
            try
            {
                using (IDbConnection db = Conn)
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@QutationId", QutationId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    parameter.Add("@UserId", UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    parameter.Add("@OutStatus", UserId, dbType: DbType.Int32, direction: ParameterDirection.Output);
                    await db.ExecuteAsync(GlobalSPNames.ApproveQuotationBySupperUserSPName, param: parameter, commandType: CommandType.StoredProcedure);
                    var retVal = parameter.Get<int>("OutStatus");
                    return retVal;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<int> SavePo(int QutationId)
        {
            try
            {
                using (IDbConnection db = Conn)
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@QutationId", QutationId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    return await db.ExecuteAsync(GlobalSPNames.SavePoSPName, param: parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Approval of the supplier side
        /// </summary>
        /// <param name="PoId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<int> ApprovePOHeader(int PoId , string UserId)
        {
            /*
             if all ok and done OutStatus =1
             but first check if user have rights to validate the PO (check if he is a supper user) if not OutStatus =2
             In here approve all the details as well.
             */
            try
            {
                using (IDbConnection db = Conn)
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@PoId", PoId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    parameter.Add("@UserId", UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    parameter.Add("@OutStatus", UserId, dbType: DbType.Int32, direction: ParameterDirection.Output);
                    await db.ExecuteAsync(GlobalSPNames.ApprovePOHeaderSPName, param: parameter, commandType: CommandType.StoredProcedure);
                    var retVal = parameter.Get<int>("OutStatus");
                    return retVal;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Approval of the supplier side
        /// </summary>
        /// <param name="PoId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<int> ApprovePODetails(int PoDetailId, string UserId)
        {
            /*
             if all ok and done OutStatus =1
             In here first check master PO is approved or not. if it approved this is worth less.
             and then reject this one.   OutStatus =2
             If approved send 1, if master approved send 2 , if user not valid to authonticate then send 3
             */

            try
            {
                using (IDbConnection db = Conn)
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@PoDetailId", PoDetailId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    parameter.Add("@UserId", UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    parameter.Add("@OutStatus", UserId, dbType: DbType.Int32, direction: ParameterDirection.Output);
                    await db.ExecuteAsync(GlobalSPNames.PoDetailIdSPName, param: parameter, commandType: CommandType.StoredProcedure);
                    var retVal = parameter.Get<int>("OutStatus");
                    return retVal;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        /// <summary>
        /// Approval of the Buyer side
        /// </summary>
        /// <param name="PoId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<int> ApprovePOHeaderByBuyer(int PoId, string UserId)
        {
            /*
             if all ok and done OutStatus =1
             but first check if user have rights to validate the PO (check if he is a supper user) if not OutStatus =2
             In here approve all the details as well.
             Buyer approve one time. and after this it will be a valied PO
             */
            try
            {
                using (IDbConnection db = Conn)
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@PoId", PoId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    parameter.Add("@UserId", UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    parameter.Add("@OutStatus", UserId, dbType: DbType.Int32, direction: ParameterDirection.Output);
                    await db.ExecuteAsync(GlobalSPNames.ApprovePOHeaderByBuyerSPName, param: parameter, commandType: CommandType.StoredProcedure);
                    var retVal = parameter.Get<int>("OutStatus");
                    return retVal;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

     
        public async Task<int> RequestWarrentyChange(int PoId, string UserId )
        {
            /*
            only supper user can do this. buyer will do it. and he can request to change type of warrenty and the months of the period 
            If all ok OutStatus =1
            if user has no rights OutStatus =2
            
             */
            try
            {
                using (IDbConnection db = Conn)
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@PoId", PoId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    parameter.Add("@UserId", UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    parameter.Add("@OutStatus", UserId, dbType: DbType.Int32, direction: ParameterDirection.Output);
                    await db.ExecuteAsync(GlobalSPNames.ApprovePOHeaderByBuyerSPName, param: parameter, commandType: CommandType.StoredProcedure);
                    var retVal = parameter.Get<int>("OutStatus");
                    return retVal;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> ApproveQarrentyChange(int PoId, string UserId)
        {
            /*
             if all ok and done OutStatus =1
             but first check if user have rights to validate the PO (check if he is a supper user) if not OutStatus =2
             In here approve all the details as well.
             Buyer approve one time. and after this it will be a valied PO
             */
            try
            {
                using (IDbConnection db = Conn)
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@PoId", PoId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    parameter.Add("@UserId", UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    parameter.Add("@OutStatus", UserId, dbType: DbType.Int32, direction: ParameterDirection.Output);
                    await db.ExecuteAsync(GlobalSPNames.ApprovePOHeaderByBuyerSPName, param: parameter, commandType: CommandType.StoredProcedure);
                    var retVal = parameter.Get<int>("OutStatus");
                    return retVal;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> WarrantyChangeRequest(WarrantyChangeProfile obj)
        {
          
            /*
             Validate user id prior to call this method. or this method will be fired an exception
             */
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<WarrantyChangeProfile>(GlobalSPNames.WarrantyChangeRequestSPName, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

    }
}
