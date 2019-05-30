using B2BService.Domain.Coparate;
using B2BService.Unitilities;
using B2BService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Repository.SellerRepositories
{
    public class CoparateReporitory
    {
        public readonly StandAloneRepository StdRepo;

        public CoparateReporitory()
        {
            StdRepo = new StandAloneRepository();
        }


        public async Task<int> AddOrganization(UserOrganisazionVM modelVM)
        {
            try
            {
                return await StdRepo.ExcuteStoredProcedureToSave<UserOrganisazionVM>(GlobalSPNames.AddOrganizationSPName, modelVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
