using B2BService.Domain;
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
    [RoutePrefix("Category")]
    [Authorize]
    public class CategoryController : ApiController
    {


        CategoryRepository corepo;

        public CategoryController()
        {
            corepo = new CategoryRepository();
        }



        [Route("AddLevel1")]
        [HttpPost]
        public async Task<HttpResponseMessage> AddLevel1(Level1VM modelVM)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.AddLevel1(modelVM));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        [Route("AddLevel2")]
        [HttpPost]
        public async Task<HttpResponseMessage> AddLevel2(Level2VM modelVM)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.AddLevel2(modelVM));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        [Route("AddLevel3")]
        [HttpPost]
        public async Task<HttpResponseMessage> AddLevel3(Level3VM modelVM)
        {
            try
            {
                string username = RequestContext.Principal.Identity.Name;
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse(HttpStatusCode.OK, await corepo.AddLevel3(modelVM));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }



        [Route("GetAllCategories")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetSpecMaster()
        {
            RepoBase<Level1> specmaster;
            try
            {
                specmaster = new RepoBase<Level1>("Level1");
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse<IEnumerable<Level1>>(HttpStatusCode.OK, await specmaster.FindALL());
            }
            catch (Exception ex)
            {
                specmaster = null;
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("GetAllSubCategories")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllSubCategories(int CatId)
        {
            RepoBase<Level2> specmaster;
            try
            {
                specmaster = new RepoBase<Level2>("Level2");
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse<IEnumerable<Level2>>(HttpStatusCode.OK, await specmaster.FindExistanceMulti("Level1Id", CatId.ToString()));
            }
            catch (Exception ex)
            {
                specmaster = null;
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("GetAllSubCategor2s")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllSubCategor2s(int CatId, int SubCatId)
        {
            RepoBase<Level3> specmaster;
            try
            {
                specmaster = new RepoBase<Level3>("Level2");
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                var SQL = "SELECT * FROM  Level3 WHERE Level1Id = " + CatId + " AND Level12d = " + SubCatId + " ORDER BY Level3Name";
                return Request.CreateResponse<IEnumerable<Level3>>(HttpStatusCode.OK, await specmaster.FindExistanceMulti(SQL));
            }
            catch (Exception ex)
            {
                specmaster = null;
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("GetAllSubCategoriesForMegaView")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllSubCategoriesForMegaView(int categoryId)
        { 
            try
            {
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse<IEnumerable<SubCatVM>>(HttpStatusCode.OK, await corepo.GetAllSubCategoriesForMegaView(categoryId));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("GetAllSubCategor2sUsingID")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllSubCategor2s(int SubCat2Id)
        {
            RepoBase<Level3> specmaster;
            try
            {
                specmaster = new RepoBase<Level3>("Level3");
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse<Level3>(HttpStatusCode.OK, await specmaster.Find(SubCat2Id));
            }
            catch (Exception ex)
            {
                specmaster = null;
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }


        [Route("GetAllSubCategorsUsingID")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllSubCategorsUsingID(int SubCatId)
        {
            RepoBase<Level2> specmaster;
            try
            {
                specmaster = new RepoBase<Level2>("Level2");
                string clientAddress = HttpContext.Current.Request.UserHostAddress;
                return Request.CreateResponse<Level2>(HttpStatusCode.OK, await specmaster.Find(SubCatId));
            }
            catch (Exception ex)
            {
                specmaster = null;
                LogHelper.WriteLog(HttpContext.Current.Request, ex, RequestContext.Principal.Identity.Name);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }


        /*
         List of all the Routes
         FindExistanceMulti
        GetAllCategories()
        SaveCategory(object,int action) // check if name exists
        GetAllSubCategories(int categoryId)
        SaveSubCategories(object,int action) // check if name exists
        GetAllSubCategor2s(int categoryId)
        SaveSubCategory2s(object,int action) // check if name exists

         */


    }

}
