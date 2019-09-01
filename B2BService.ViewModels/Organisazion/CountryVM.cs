using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.ViewModels.Organisazion
{
    public class DistrictJsonVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CityJsonVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PostCode { get; set; }
    }

    public class BussinessTypesJsonVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    
}
