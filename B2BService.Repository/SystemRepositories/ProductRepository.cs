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
        public async Task<IEnumerable<CatelogItemsVM>> CatelogProductSearch(SearchVM modelVM)
        {
            try
            {
                return await StdRepo.QueryStoredProcedure<SearchVM, CatelogItemsVM> (GlobalSPNames.CatelogProductSearchSPName, modelVM);
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
        public async Task<int> AddProduct(ProductVM modelVM)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<ProductVM>(GlobalSPNames.CatelogProductSearchSPName, modelVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}
