using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain.Inventory
{
    public class Review:BaseClass
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string UserId { get; set; }
        public bool IsAnon { get; set; }
        public string Caption { get; set; }
        public string Pros { get; set; }
        public string Cons { get; set; }
        public string BottomLine { get; set; }
        public int Rating { get; set; }
        public DateTime Datetime { get; set; }
        public int NoOfLikes { get; set; }
        public int NoOfDislikes { get; set; }

    }
}
