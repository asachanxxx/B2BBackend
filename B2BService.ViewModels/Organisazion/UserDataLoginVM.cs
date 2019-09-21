using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.ViewModels.Organisazion
{
    public class UserDataLoginVM
    {
        public int OrgId { get; set; }
        public string OrgName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserIdString { get; set; }
        public bool IsSupperUser { get; set; }

    }
    public class UserStatus
    {
        public bool Activated { get; set; }
        public bool Approved { get; set; }
        public bool IsSeller { get; set; }

    }
}
