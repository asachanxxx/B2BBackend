using B2BService.Domain;
using B2BService.Domain.Coparate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.ViewModels.Organisazion
{
    public class OrgUserFullVM
    {
        public Organization OrganisazionDet { get; set; }
        public User UserDet { get; set; }
    }

    public class OrgUserVM
    {
        public OrgVM OrganisazionDet { get; set; }
        public UserVM UserDet { get; set; }
    }


    public class OrgVM
    {
        public int Id { get; set; }
        public string BusinessType { get; set; }
        public string OrganizationName { get; set; }
        public string MainPhone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public bool IsSeller { get; set; }
    }

    public class OrgDropDownVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

        public class UserVM
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
    }

    public class ApproveUserVM {
        public string UserIdToApprove { get; set; }
        public int OrgId { get; set; }
        public string ApprovalUserId { get; set; }

    }

    public class GetAllusersForApprovalVM
    {
        public string UserId { get; set; }
        public int OrgId { get; set; }

    }

    public class ShortUserVM
    {
        public string UserId { get; set; }
        public string DisplayName { get; set; }
        public bool IsApproved { get; set; }

    }

    public class ChangeSupperUserVM
    {
        public string CurrentId { get; set; }
        public string ChangeToId { get; set; }
    }

    public class ApproveQutationsVM
    {
        public int QutationId { get; set; }
        public string UserId { get; set; }
    }

    


    //string CurrentId, string ChangeToId
}
