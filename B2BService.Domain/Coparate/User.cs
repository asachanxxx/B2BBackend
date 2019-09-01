using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain.Coparate
{
    public class User:BaseClass
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public int TypeId { get; set; }
        public bool Activated { get; set; }
        public bool Approved { get; set; }
        public int OrganizationID { get; set; }
        public int GroupId { get; set; }
        public bool IsSupperUser { get; set; }
        public bool IsSubscribed { get; set; }
    }
}
