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


namespace B2BService.Service.Controllers
{
    [RoutePrefix("SiteTest")]
    public class SiteTestController : ApiController
    {
        CorparateRepository corepo;

        public SiteTestController()
        {
            corepo = new CorparateRepository();
        }


        [Route("GetUserDetails")]
        [HttpGet]
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
    }
}
