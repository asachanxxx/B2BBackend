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
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.SaveCatelog(modelVM , action));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("AddSpecMaster")]
        [HttpPost]
        public async Task<HttpResponseMessage> AddSpecMaster(SpecMaster modelVM, [FromUri] int type)
        {
            RepoBase<SpecMaster> specmaster;

            try
            {
               
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                if (modelVM != null)
                {
                    modelVM.IpAddress = clientAddress;
                }
                if (type == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, await corepo.AddSpecMaster(modelVM, type));
                }
                else if (type == 2) {
                    specmaster = new RepoBase<SpecMaster>("SpecMasters");
                    return Request.CreateResponse(HttpStatusCode.OK, await specmaster.Save(modelVM,2));
                }
                else
                {
                    specmaster = new RepoBase<SpecMaster>("SpecMasters");
                    return Request.CreateResponse(HttpStatusCode.OK, await specmaster.Delete(modelVM) ? 1 : 0);
                }
                
            }
            catch (Exception ex)
            {
                specmaster = null;
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }


        [Route("AddSpecDetails")]
        [HttpPost]
        public async Task<HttpResponseMessage> AddSpecDetails(List<SpecDetail> modelVM)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                if (modelVM != null)
                {
                    modelVM.ForEach(x=>x.IpAddress = clientAddress);
                }

                return Request.CreateResponse(HttpStatusCode.OK, await corepo.AddSpecDetails(modelVM));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }


        [Route("AddProductSpecDetails")]
        [HttpPost]
        public async Task<HttpResponseMessage> AddProductSpecDetails(List<ProductSpecDetail> modelVM)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.AddProductSpecDetails(modelVM));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }






        /*
         *************************************************************************************************************************************************
         
         ALL Get reauests 
         
         *************************************************************************************************************************************************
         */


        [Route("GetSpecMaster")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetSpecMaster()
        {
            RepoBase<SpecMaster> specmaster;
            try
            {
                specmaster = new RepoBase<SpecMaster>("SpecMasters");
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse<IEnumerable<SpecMaster>>(HttpStatusCode.OK, await specmaster.FindALL());
            }
            catch (Exception ex)
            {
                specmaster = null;
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }



        [Route("GetSpecDetails")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetSpecDetails(int Id)
        {
            RepoBase<SpecDetail> specmaster;
            try
            {
                specmaster = new RepoBase<SpecDetail>("SpecDetails");
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse<IEnumerable<SpecDetail>>(HttpStatusCode.OK, await specmaster.FindExistanceMulti("SpecMasterId" , Id.ToString()));
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
