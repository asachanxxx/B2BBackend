using B2BService.Repository.SellerRepositories;
using B2BService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace B2BService.Service.Controllers.SellerControllers
{
    /// <summary>
    /// This controller is for to deal with the organization and the users mainly. and it has a space for futher developing entities 
    /// related to the organization
    /// </summary>
    [RoutePrefix("Corparate")]
    [Authorize]
    public class CorparateController : ApiController
    {
        CoparateReporitory corepo;
        /// <summary>
        /// constructor of the controller
        /// </summary>
        public CorparateController()
        {
            corepo = new CoparateReporitory();
        }

        [Route("AddOrganization")]
        [HttpGet]
        public async Task<HttpResponseMessage> AddOrganization(UserOrganisazionVM modelVM)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.AddOrganization(modelVM));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                
            }
        }

        [Route("TestLogMethods")]
        [HttpGet]
        public async Task<HttpResponseMessage> TestLogMethods()
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                var xxx = HttpContext.Current.Request.Path;
                var xxy = HttpContext.Current.Request.PhysicalPath;
                var Port = HttpContext.Current.Request.RequestContext.HttpContext;

                return Request.CreateResponse(HttpStatusCode.OK, "Success");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

            }
        }
    }
}
