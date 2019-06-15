using B2BService.Domain;
using B2BService.Domain.Inventory;
using B2BService.Repository;
using B2BService.Unitilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Repository.SystemRepositories
{

    public class SpecRepository
    {
        public readonly StandAloneRepository StdRepo;

        public SpecRepository()
        {
            StdRepo = new StandAloneRepository();

        }


        public async Task<int> SaveSpecMaster(SpecMaster modelVM)
        {
            try
            {

                return await StdRepo.ExcuteStoredProcedureToSave<SpecMaster>(GlobalSPNames.SaveSpecMasterSPName, modelVM);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> SaveSpecItem(SpecItem modelVM)
        {
            try
            {

                return await StdRepo.ExcuteStoredProcedureToSave<SpecItem>(GlobalSPNames.SaveSpecItemSPName, modelVM);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> SaveSpecItem(List<SpecItem> modelVM)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<List<SpecItem>>(GlobalSPNames.SaveSpecItemSPNameBulk, modelVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<int> SaveSpecDetails(List<SpecDetail> modelVM)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<List<SpecDetail>>(GlobalSPNames.SaveSpecDetails, modelVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<int> SaveProductSpecDetails(List<SpecProductDetails> modelVM)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<List<SpecProductDetails>>(GlobalSPNames.SaveSpecProductDetails, modelVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<IEnumerable<SpecMaster>> GetAllSpecMaster()
        {
            try
            {
                var repo = new RepoBase<SpecMaster>("SpecMasters");
                return await repo.FindALL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<SpecItem>> GetAllSpecItems()
        {
            try
            {
                var repo = new RepoBase<SpecItem>("SpecItems");
                return await repo.FindALL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<SpecDetail>> GetAllSpecDetailsForMAster(int MasterId)
        {
            try
            {
                var repo = new RepoBase<SpecDetail>("SpecItems");
                return await repo.FindExistanceMulti("SpecMasterId", MasterId.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<SpecProductDetails>> GetAllSpecProductDetails(int ProductId)
        {
            try
            {
                var repo = new RepoBase<SpecProductDetails>("SpecProductDetails");
                return await repo.FindExistanceMulti("SpecMasterId", ProductId.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
  

    }
}
