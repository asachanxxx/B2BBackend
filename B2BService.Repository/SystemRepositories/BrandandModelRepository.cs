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

     

        public async Task<int> AddBrand(Brand modelVM)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<Brand>(GlobalSPNames.AddBrandSPName, modelVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddModel(Model modelVM)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<Model>(GlobalSPNames.AddModelSPName, modelVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
