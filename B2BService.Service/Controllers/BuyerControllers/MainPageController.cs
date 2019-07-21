using B2BService.Domain;
using B2BService.Domain.Inventory;
using B2BService.Repository;
using B2BService.Repository.SystemRepositories;
using B2BService.Service.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace B2BService.Service.Controllers.BuyerControllers
{
    [RoutePrefix("MainPage")]
    [Authorize]
    public class MainPageController : ApiController
    {

        ProductRepository corepo;

        public MainPageController()
        {
            corepo = new ProductRepository();
        }

        [Route("GetNewArrivalProduct")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetNewArrivalProduct()
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.GetNewArrivalProduct());
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("GetBestSellProducts")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetBestSellProducts()
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.GetBestSellProducts());
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }


        [Route("GetFeatureProducts")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetFeatureProducts()
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.GetFeatureProducts());
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("GetSingleProduct")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetSingleProduct(int Id)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.GetSingleProduct(Id));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

    }
}
