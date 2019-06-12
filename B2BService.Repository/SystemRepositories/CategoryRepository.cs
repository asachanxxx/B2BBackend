using B2BService.Domain;
using B2BService.Unitilities;
using B2BService.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Repository.SystemRepositories
{
    public class CategoryRepository
    {
        public readonly StandAloneRepository StdRepo;

        public CategoryRepository()
        {
            StdRepo = new StandAloneRepository();
        }


        public async Task<int> AddLevel1(Level1VM modelVM)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<Level1VM>(GlobalSPNames.AddLevel1SPName, modelVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<int> AddLevel2(Level2VM modelVM)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<Level2VM>(GlobalSPNames.AddLevel2SPName, modelVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddLevel3(Level3VM modelVM)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<Level3VM>(GlobalSPNames.AddLevel3SPName, modelVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
