using B2BService.Domain.Inventory;
using B2BService.Repository;
using B2BService.Repository.SystemRepositories;
using B2BService.Service.HelperClasses;
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
    [RoutePrefix("BrandAndModels")]
    [Authorize]
    public class BrandAndModelsController : ApiController
    {


        BrandandModelRepository corepo;

        public BrandAndModelsController()
        {
            corepo = new BrandandModelRepository();
        }
       


        [Route("SaveBrand")]
        [HttpPost]
        public async Task<HttpResponseMessage> SaveBrand(Brand modelVM,[FromUri]int action)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;

                //for (int i = 0; i < 1000; i++)
                //{
                //    modelVM.Name = "Brand " + i.ToString();
                //    await corepo.SaveBrand(modelVM, action);
                //}

                modelVM.IpAddress = clientAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.SaveBrand(modelVM, action));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("SaveModel")]
        [HttpPost]
        public async Task<HttpResponseMessage> SaveModel(Model modelVM, [FromUri] int action)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                modelVM.IpAddress = clientAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.SaveModel(modelVM, action));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }


        [Route("SaveSeries")]
        [HttpPost]
        public async Task<HttpResponseMessage> SaveSeries(Series modelVM, [FromUri] int action)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                modelVM.IpAddress = clientAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.SaveSeries(modelVM, action));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }


        [Route("GetAllBrands")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllBrands()
        {
            RepoBase<Brand> specmaster;
            try
            {

                specmaster = new RepoBase<Brand>("Brands");
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse<IEnumerable<Brand>>(HttpStatusCode.OK, await specmaster.FindALL());
            }
            catch (Exception ex)
            {
                specmaster = null;
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("GetAllModels")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllModels()
        {
            RepoBase<Model> specmaster;
            try
            {
                specmaster = new RepoBase<Model>("Models");
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse<IEnumerable<Model>>(HttpStatusCode.OK, await specmaster.FindALL());
            }
            catch (Exception ex)
            {
                specmaster = null;
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("GetAllSeries")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllSeries()
        {
            RepoBase<Series> specmaster;
            try
            {
                specmaster = new RepoBase<Series>("Series");
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse<IEnumerable<Series>>(HttpStatusCode.OK, await specmaster.FindALL());
            }
            catch (Exception ex)
            {
                specmaster = null;
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

    }
}
