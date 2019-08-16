using B2BService.Domain.Coparate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain.Inventory
{
    public class ProductReview:BaseClass
    {
        public int Id { get; set; }
        public int BuyerID { get; set; }
        public DateTime DateCreated { get; set; }
        public int ProductId { get; set; }
        public string ReviewText { get; set; }

    }

//    export interface ProductReview
//    {
//        avatar: string;
//    author: string;
//    rating: number;
//    date: string;
//    text: string;
//}
}
