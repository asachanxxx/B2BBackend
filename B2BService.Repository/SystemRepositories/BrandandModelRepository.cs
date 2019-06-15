using B2BService.Domain.Inventory;
using B2BService.Unitilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Repository.SystemRepositories
{
    public class BrandandModelRepository
    {

        public readonly StandAloneRepository StdRepo;

        public BrandandModelRepository()
        {
            StdRepo = new StandAloneRepository();
        }

     

        public async Task<int> SaveBrand(Brand modelVM,int action)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<Brand>(GlobalSPNames.SaveBrand, modelVM, action);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> SaveModel(Model modelVM, int action)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<Model>(GlobalSPNames.SaveModel, modelVM, action);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> SaveSeries(Series modelVM, int action)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<Series>(GlobalSPNames.SaveSeries, modelVM, action);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
