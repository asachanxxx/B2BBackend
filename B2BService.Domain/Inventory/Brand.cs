using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain.Inventory
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsApproved { get; set; }
    }
}
