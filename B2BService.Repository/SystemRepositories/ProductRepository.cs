﻿using B2BService.Domain;
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
        public async Task<IEnumerable<CateglogProducts>> SearchCatelogItems(SearchVM modelVM)
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


        public async Task<int> SaveCatelog(CateglogProducts modelVM)
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


        /// <summary>
        /// Add a produt to the system
        /// </summary>
        /// <param name="modelVM"></param>
        /// <returns>type of int with the newly inserted produt ID</returns>
        public async Task<int> AddProduct(ProductSaveVM modelVM)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<ProductSaveVM>(GlobalSPNames.AddProductSPName, modelVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<CatelogDataFeedVM> GetCatelogDataFeed()
        {
            try
            {
                return await StdRepo.QueryStoredProcedure<CatelogDataFeedVM>(GlobalSPNames.GetCatelogDataFeedSP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<IEnumerable<ProductsForCatelogVM>> GetProductForCatelogSerachResult(int CatelogId)
        {
            try
            {

                return await StdRepo.ExcuteStoredProcedureToSave<ProductsForCatelogVM>(GlobalSPNames.GetProductForCatelogSerachResultSP, CatelogId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<WarrentyType>> GetAllWarrentyTypes()
        {
            try
            {
                var repo = new RepoBase<WarrentyType>("WarrentyType");
                return await repo.FindALL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddSupplierPriceForProduct(SupplierBundleVM modelVM)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<SupplierBundleVM>(GlobalSPNames.AddSupplierPriceForProductSPName, modelVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //public async Task<int> AddSupplierPriceForProduct(SupplierBundleVM modelVM)
        //{
        //    try
        //    {
        //        return await StdRepo.ExcuteStoredProcedureToSave<SupplierBundleVM>(GlobalSPNames.AddSupplierPriceForProductSPName, modelVM);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        public async Task<int> SearchExistingProduct(ProductSearchVM modelVM)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<ProductSearchVM>(GlobalSPNames.SearchExistingProductSPName, modelVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductSaveVM> DuplicateProduct(int ProductId)
        {
            try
            {

                return await StdRepo.QueryStoredProcedure<ProductSaveVM>(GlobalSPNames.DuplicateProductSPName, ProductId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}