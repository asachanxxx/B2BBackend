using B2BService.Domain;
using B2BService.Domain.Inventory;
using B2BService.Repository;
using B2BService.Repository.SellerRepositories;
using B2BService.Repository.SystemRepositories;
using B2BService.Service.HelperClasses;
using B2BService.ViewModels;
using B2BService.ViewModels.Product;
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

        ProductRepository corepo;
        
        public ProductController()
        {
            corepo = new ProductRepository();
        }



        [Route("SaveCatelog")]
        [HttpPost]
        public async Task<HttpResponseMessage> SaveCatelog(CateglogProducts modelVM, int action)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.SaveCatelog(modelVM));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }



        [Route("SaveProduct")]
        [HttpPost]
        public async Task<HttpResponseMessage> SaveProduct(ProductSaveVM modelVM, int action)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.AddProduct(modelVM));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }


        [Route("GetAllCatelogItems")]
        [HttpGet]
        public async Task<HttpResponseMessage> SearchCatelogItems()
        {
            RepoBase<CateglogProducts> repo;
            try
            {
                repo = new RepoBase<CateglogProducts>("CateglogProducts");
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await repo.FindALL());
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("SearchCatelogItems")]
        [HttpGet]
        public async Task<HttpResponseMessage> SearchCatelogItems(SearchVM modelVM)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.SearchCatelogItems(modelVM));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("GetCatelogDataFeed")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetCatelogDataFeed()
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.GetCatelogDataFeed());
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("GetCatelogDataFeed")]
        [HttpGet]
        public async Task<HttpResponseMessage> SearchCatelogItems(CatelogDataFeedVM Model)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.GetCatelogDataFeed());
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("GetProductForCatelogSerachResult")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetProductForCatelogSerachResult(int CatelogId)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.GetProductForCatelogSerachResult(CatelogId));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("GetAllWarrentyTypes")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllWarrentyTypes()
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.GetAllWarrentyTypes());
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("AddSupplierPriceForProduct")]
        [HttpPost]
        public async Task<HttpResponseMessage> AddSupplierPriceForProduct(SupplierBundleVM Model)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.AddSupplierPriceForProduct(Model));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("SearchExistingProduct")]
        [HttpGet]
        public async Task<HttpResponseMessage> SearchExistingProduct(ProductSearchVM Model)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.SearchExistingProduct(Model));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("DuplicateProduct")]
        [HttpGet]
        public async Task<HttpResponseMessage> DuplicateProduct(int ProductId)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.DuplicateProduct(ProductId));
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



    }
}
