using B2BService.Repository.SellerRepositories;
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

    [RoutePrefix("Product")]
    [Authorize]
    public class ProductController : ApiController
    {

        CoparateReporitory corepo;

        public ProductController()
        {
            corepo = new CoparateReporitory();
        }



        [Route("AddOrganization")]
        [HttpGet]
        public async Task<HttpResponseMessage> CatelogProductSearch()
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

    }
}
