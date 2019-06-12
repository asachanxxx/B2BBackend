using B2BService.Domain;
using B2BService.Domain.Inventory;
using B2BService.Unitilities;
using B2BService.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Repository.SystemRepositories
{
    public class ProductRepository
    {
        public readonly StandAloneRepository StdRepo;

        public ProductRepository()
        {
            StdRepo = new StandAloneRepository();
        }

        /// <summary>
        /// This is used to search throuh system catelog data set. sellers supposed to pic one and enter rest of the details
        /// to make it a valied system product
        /// </summary>
        /// <param name="modelVM">Search model to pass</param>
        /// <returns>Type of CatelogItemsVM</returns>
        public async Task<IEnumerable<CateglogProducts>> CatelogProductSearch(SearchVM modelVM)
        {
            try
            {
                return await StdRepo.QueryStoredProcedure<SearchVM, CateglogProducts> (GlobalSPNames.CatelogProductSearchSPName, modelVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Add a produt to the system
        /// </summary>
        /// <param name="modelVM"></param>
        /// <returns>type of int with the newly inserted produt ID</returns>
        public async Task<int> AddProduct(ProductVM modelVM , int action)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<ProductVM>(GlobalSPNames.AddProductSPName, modelVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    

        public async Task<int> SaveCatelog(CateglogProducts modelVM , int action)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<CateglogProducts>(GlobalSPNames.AddCatelogProductSPName, modelVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      

        public async Task<int> AddSpecMaster(SpecMaster modelVM,int type)
        {
            try
            {
                if (type == 1)
                {
                    return await StdRepo.ExcuteStoredProcedureToSave<SpecMaster>(GlobalSPNames.AddSpecMasterSPName, modelVM);
                }
                else {
                    return await StdRepo.ExcuteStoredProcedureToSave<SpecMaster>(GlobalSPNames.UpdateSpecMasterSPName, modelVM);
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddSpecDetails(List<SpecDetail> modelVM)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<List<SpecDetail>>(GlobalSPNames.AddSpecDetailsSPName, modelVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddProductSpecDetails(List<ProductSpecDetail> modelVM)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<List<ProductSpecDetail>>(GlobalSPNames.AddProductSpecDetailsSPName, modelVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
