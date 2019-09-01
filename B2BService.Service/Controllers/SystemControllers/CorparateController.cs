using B2BService.Domain.Coparate;
using B2BService.Repository.BuyerRepositories;
using B2BService.Repository.SellerRepositories;
using B2BService.Service.HelperClasses;
using B2BService.ViewModels;
using B2BService.ViewModels.Organisazion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace B2BService.Service.Controllers.SystemControllers
{
    /// <summary>
    /// This controller is for to deal with the organization and the users mainly. and it has a space for futher developing entities 
    /// related to the organization
    /// </summary>
    [RoutePrefix("Corparate")]
    public class CorparateController : ApiController
    {
        CorparateRepository corepo;
        /// <summary>
        /// constructor of the controller
        /// </summary>
        public CorparateController()
        {
            corepo = new CorparateRepository();
        }

        //[Route("AddOrganization")]
        //[HttpGet]
        //public async Task<HttpResponseMessage> AddOrganization(UserOrganisazionVM modelVM)
        //{
        //    try
        //    {
        //        string username = RequestContext.Principal.Identity.Name;
        //        string clientAddress = HttpContext.Current.Request.UserHostAddress;
        //        return Request.CreateResponse(HttpStatusCode.OK, await corepo.AddOrganization(modelVM));
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                
        //    }
        //}

  



        [Route("GetUserDetails")]
        [HttpGet]
        [Authorize]
        public async Task<HttpResponseMessage> GetUserDetails(string UserID)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.GetUserDetails(UserID));

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

            }
        }

        [Route("EditUserDetails")]
        [HttpPost]
        [Authorize]
        public async Task<HttpResponseMessage> EditUserDetails(User obj)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.EditUserDetails(obj));

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

            }
        }

        [Route("EditOrgDetails")]
        [HttpPost]
        [Authorize]
        public async Task<HttpResponseMessage> EditOrgDetails(Organization obj)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.EditOrgDetails(obj));

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

            }
        }

        [Route("ChangeSupperUser")]
        [HttpPost]
        [Authorize]
        public async Task<HttpResponseMessage> ChangeSupperUser(ChangeSupperUserVM obj)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.ChangeSupperUser(obj));

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

            }
        }

        [Route("ApproveQutations")]
        [HttpPost]
        [Authorize]
        public async Task<HttpResponseMessage> ApproveQutations(ApproveQutationsVM obj)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.ApproveQutations(obj));

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

            }
        }

        [Route("CreateOrganizationOnly")]
        [HttpPost]
        [Authorize]
        public async Task<HttpResponseMessage> CreateOrganizationOnly(Organization obj)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.CreateOrganizationOnly(obj));

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

            }
        }
        

        [Route("ApproveUser")]
        [HttpPost]
        [Authorize]
        public async Task<HttpResponseMessage> ApproveUser(ApproveUserVM obj)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.ApproveUser(obj));

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

            }
        }


        [Route("GetAllusersForApproval")]
        [HttpGet]
        [Authorize]
        public async Task<HttpResponseMessage> GetAllusersForApproval(GetAllusersForApprovalVM obj)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.GetAllusersForApproval(obj));

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

            }
        }


        [Route("GetAllDistricts")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllDistricts()
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.GetAllDistricts());

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

            }
        }


        [Route("GetAllCities")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllCities(int Did)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.GetAllCities(Did));

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

            }
        }


        [Route("GetAllBussinessTypes")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllBussinessTypes()
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.GetAllBussinessTypes());

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

            }
        }

        [Route("GetAllOrganisaztions")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllOrganisaztions()
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                var itemsz = await corepo.GetAllOrganisaztions();
                return Request.CreateResponse(HttpStatusCode.OK, itemsz);

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

            }
        }

        [Route("SendMail")]
        [HttpGet]
        public async Task<HttpResponseMessage> SendMail(EmailVM obj)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                var itemsz = await corepo.SendMail(obj);
                return Request.CreateResponse(HttpStatusCode.OK, itemsz);

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns>
        /// 1- Status Active , 2 - Status not active , 3 - USer Not found
        /// </returns>
        [Route("CheckUserActiveStatus")]
        [HttpGet]
        public async Task<HttpResponseMessage> CheckUserActiveStatus(string UserId)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;

                return Request.CreateResponse(HttpStatusCode.OK, await corepo.CheckUserActiveStatus(UserId));

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

            }
        }

        [Route("SubscribeUser")]
        [HttpGet]
        public async Task<HttpResponseMessage> SubscribeUser(string UserId)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.SubscribeUser(UserId));

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

            }
        }


        



    }
}
