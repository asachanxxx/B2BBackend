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


    }
}
