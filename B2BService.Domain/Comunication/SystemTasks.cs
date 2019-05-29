using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain.Comunication
{
    public class SystemTasks
    {
        public int Id { get; set; }
        public int AssociatedMessageId { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public int Isdone { get; set; }
        public int IsCanDiscard { get; set; }
        public int IsNeedEscallate { get; set; }
        public int EscallationInformUser1 { get; set; }
        public int EscallationInformUser2 { get; set; }
        /// <summary>
        /// Mainley from user id is the system. but in still not known cases this may be a user.
        /// EX: if buyer wants to quickley accept the qutation by seller he can raise a task.
        /// When Qutation created a automated task will assign to the seller
        /// </summary>
        public int fromUserID { get; set; }
        public int ToUserId { get; set; }

    }
}
