using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Repository
{
    public interface IStandAloneRepository
    {

        Task<int> ExcuteStoredProcedureToSave<T>(string SPName ,T Object) where T : class;
        Task<int> ExcuteStoredProcedureTo(string SPName);
    }
}
