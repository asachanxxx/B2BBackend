using B2BService.Domain.Coparate;
using B2BService.Unitilities;
using B2BService.ViewModels.Organisazion;
using B2BService.ViewModels.Product;
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
    public class CorparateRepository
    {
        public readonly StandAloneRepository StdRepo;
        public readonly IDbConnection Conn;

        public CorparateRepository()
        {
            StdRepo = new StandAloneRepository();
            Conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SysConn"].ConnectionString);
        }


        public async Task<OrgUserVM> GetUserDetails(string UserID)
        {
            try
            {
                try
                {
                    OrgUserVM pObj = new OrgUserVM();

                    using (IDbConnection db = Conn)
                    {
                        DynamicParameters parameter = new DynamicParameters();
                        parameter.Add("@Status", dbType: DbType.Int32, direction: ParameterDirection.Output);
                        parameter.Add("@UserID", UserID, dbType: DbType.Int32, direction: ParameterDirection.Input);


                        using (var multi = await db.QueryMultipleAsync(GlobalSPNames.GetUserDetailsSPName, param: parameter , commandType: CommandType.StoredProcedure))
                        {
                            pObj.UserDet = multi.Read<UserVM>().FirstOrDefault();
                            pObj.OrganisazionDet = multi.Read<OrgVM>().FirstOrDefault();
                        }
                    }

                    return pObj;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> EditUserDetails(User obj)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<User>(GlobalSPNames.EditUserDetailsSPName, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> EditOrgDetails(Organization obj)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<Organization>(GlobalSPNames.EditOrgDetailsSPName, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> ChangeSupperUser(ChangeSupperUserVM obj)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<ChangeSupperUserVM>(GlobalSPNames.ChangeSupperUserSPName, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> ApproveQutations(ApproveQutationsVM obj)
        {
            try
            {
                // --First check the UserID is A moderator or SupperUser

                //--If User Valid then Approve the qutation
                return await StdRepo.ExcuteStoredProcedureToSave<ApproveQutationsVM>(GlobalSPNames.ApproveQutationsSPName, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> CreateUserWithOrganisation(OrgUserFullVM obj)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<OrgUserFullVM>(GlobalSPNames.AddOrganizationSPName, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> CreateOrganizationOnly(Organization obj)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<Organization>(GlobalSPNames.CreateOrganizationOnlySPName, obj);
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> CreateUserOnly(User obj)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<User>(GlobalSPNames.AddOUserOnlySPName, obj);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> CheckOrganizationExits(int OrgId)
        {
            try
            {
                using (IDbConnection db = Conn)
                {

                    var returnval=  await db.QuerySingleAsync<int>("SELECT count(*) FROM Organizations where id = @id", new { id = OrgId });
                    if (returnval > 0)
                    {
                        return true;
                    }
                    else {
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<int> ApproveUser(ApproveUserVM obj)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<ApproveUserVM>(GlobalSPNames.ApproveUserSPName, obj);
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<IEnumerable<ShortUserVM>> GetAllusersForApproval(GetAllusersForApprovalVM obj)
        {
            try
            {
                return await StdRepo.QueryStoredProcedure<GetAllusersForApprovalVM,ShortUserVM>(GlobalSPNames.GetAllusersForApprovalSPName, obj);
               

               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<DistrictJsonVM>> GetAllDistricts()
        {
            try
            {
                return await StdRepo.QueryStoredProcedureSQLString<DistrictJsonVM>("select id,dname as 'Name' from DistrictJsons");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<CityJsonVM>> GetAllCities(int pDId)
        {
            try
            {

                using (IDbConnection db = Conn)
                {
                    return await db.QueryAsync<CityJsonVM>("select Id , DName as 'Name' ,postcode as 'PostCode'  from CityJsons where DId =@DId", new { DId = pDId });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<IEnumerable<BussinessTypesJsonVM>> GetAllBussinessTypes()
        {
            try
            {
                return await StdRepo.QueryStoredProcedureSQLString<BussinessTypesJsonVM>("select id, Name from BussinessTypesJsons");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<OrgDropDownVM>> GetAllOrganisaztions()
        {
            try
            {
                return await StdRepo.QueryStoredProcedureSQLString<OrgDropDownVM>("select Id, OrganizationName as 'Name' from Organizations order by OrganizationName desc");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> SendMail(EmailVM obj)
        {
            try
            {
                var mail = GetEmailSettings();
                MessagingService.SendMailAsync(mail , obj);
                return await Task.FromResult<int>(1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EmailSettings GetEmailSettings()
        {
            try
            {
                using (IDbConnection db = Conn)
                {
                    var returnval =  db.QuerySingle<EmailSettings>("select * from EmailSettings");
                    return returnval;
                }

            }
            catch (Exception ex)
            {
                return new EmailSettings() {EnableSsl = true,FromPassword = "asdqwe123#" , Host= "smtp.gmail.com", Id=1, InfoEmail= "mr.hk.hunter@gmail.com" , Port = "587", Subject = "Welcome to Techthrong",UseDefaultCredentials = false };
            }
        }

        public async Task<int> SaveConfirmationMail(EmailConfirmations obj)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<EmailConfirmations>(GlobalSPNames.EmailConfirmationsSPName, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> CheckUserActiveStatus(string UserId)
        {
            try
            {
                using (IDbConnection db = Conn)
                {
                    var returnval = await db.QuerySingleAsync<bool>("select Activated from Users where UserId = '"+UserId.Trim()+"'");
                    if (returnval)
                    {
                        return 1;
                    }
                    else {
                        return 2;
                    }
                }

            }
            catch (Exception ex)
            {
                return 3;
            }
        }

        public async Task<int> SubscribeUser(string UserId)
        {
            try
            {
                using (IDbConnection db = Conn)
                {
                    var returnval = await db.ExecuteAsync("update Users set IsSubscribed =1 where UserId = '" + UserId.Trim() + "'");
                    return returnval;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("User is not active");
            }
        }

    }
}
