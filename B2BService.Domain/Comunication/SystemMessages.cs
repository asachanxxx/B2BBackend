using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain.Comunication
{
    public class SystemMessages:BaseClass
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public int fromUserID { get; set; }
        public int ToUserId { get; set; }
        public bool Isdiscard { get; set; }
        /// <summary>
        /// When a message genarated in some cases system users must know. so this is the group who needed to be sent the messages when they have created
        /// </summary>
        public bool SystemUserGroupToNotify { get; set; }

            

    }
}
