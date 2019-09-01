using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain.Coparate
{
    public class EmailConfirmations
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public bool Activated { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
