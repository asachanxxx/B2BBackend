using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain.Coparate
{
    public class CityJson
    {
        public int Id { get; set; }
        public int DId { get; set; }
        public string DName { get; set; }
        public string PostCode { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }


    }
}
