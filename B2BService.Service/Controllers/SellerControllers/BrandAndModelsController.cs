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
    [RoutePrefix("brandandmodels")]
    [Authorize]
    public class BrandAndModelsController : ApiController
    {


        BrandandModelRepository corepo;

        public BrandAndModelsController()
        {
            corepo = new BrandandModelRepository();
        }
       


        [Route("AddBrand")]
        [HttpPost]
        public async Task<HttpResponseMessage> AddBrand(Brand modelVM,int action)
        {
            RepoBase<Brand> specmaster;

            try
            {
                specmaster = new RepoBase<Brand>("Brands");

                //if update command passing to the controller check if exists
                if (modelVM != null)
                {
                    if (await specmaster.FindExistance("Name", modelVM.Name.Trim())) {
                        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "This Brand already exists!");
                    }
                }

                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.AddBrand(modelVM));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("AddModel")]
        [HttpPost]
        public async Task<HttpResponseMessage> AddModel(Model modelVM, int action)
        {
            RepoBase<Model> specmaster;

            try
            {
                specmaster= new RepoBase<Model>("Models");
                //if update command passing to the controller check if exists
                if (modelVM != null) {
                    if ( await specmaster.FindExistance("Name", modelVM.Name)){
                        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "This Model already exists!");
                    }
                }

                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.AddModel(modelVM));
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



    }
}
