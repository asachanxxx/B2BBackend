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

        public async Task<IEnumerable<SubCatVM>> GetDataForSubCategoryView(int CategoryId) {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<SubCatVM>(GlobalSPNames.GetDataForSubCategoryView, CategoryId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Level2>> GetSubcategoryForSideMenu( int CategoryId) {
            try
            {
                RepoBase<Level2> repo = new RepoBase<Level2>("Level1");
                return await repo.FindExistanceMulti("Level1Id", CategoryId.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
