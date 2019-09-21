using B2BService.Domain.Coparate;
using B2BService.Repository.BuyerRepositories;
using B2BService.Service.HelperClasses;
using B2BService.ViewModels.Sales;
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
    [RoutePrefix("Quotation")]
    public class QuotationController : ApiController
    {
        QuotationRepository corepo;

        public QuotationController()
        {
            corepo = new QuotationRepository();
        }

        [Route("SaveQuotation")]
        [HttpPost]
        [Authorize]
        public async Task<HttpResponseMessage> SaveQuotation(QutationVM obj)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.SaveQuotation(obj));

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

            }
        }

        [Route("ApproveQuotationBySupperUser")]
        [HttpPost]
        [Authorize]
        public async Task<HttpResponseMessage> ApproveQuotationBySupperUser(QutationUserVM obj)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.ApproveQuotationBySupperUser(obj));

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

            }
        }

        [Route("ApprovePO")]
        [HttpPost]
        [Authorize]
        public async Task<HttpResponseMessage> ApprovePO(SupplierUserVM obj)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.ApprovePO(obj));

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

            }
        }

        [Route("UpdatePOStatus")]
        [HttpPost]
        [Authorize]
        public async Task<HttpResponseMessage> UpdatePOStatus(UpdatePOS obj)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.UpdatePOStatus(obj));

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

            }
        }

        [Route("DeletePOItem")]
        [HttpPost]
        [Authorize]
        public async Task<HttpResponseMessage> DeletePOItem(int POItemID)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.DeletePOItem(POItemID));

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

            }
        }

        [Route("ApprovePOByCustomer")]
        [HttpPost]
        [Authorize]
        public async Task<HttpResponseMessage> ApprovePOByCustomer(SupplierUserVM obj)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.ApprovePOByCustomer(obj));

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

            }
        }

        [Route("GetQuotationMasters")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetQuotationMasters(int OrgId)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.GetQuotationMasters(OrgId));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("GetQuotationDetails")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetQuotationDetails(int QuoteId)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.GetQuotationDetails(QuoteId));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("GetQuotationWarranty")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetQuotationWarranty(int ProductId, int DocumentId)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.GetQuotationWarranty(ProductId, DocumentId));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }



        

    }
}
