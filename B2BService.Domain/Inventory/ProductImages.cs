using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain.Inventory
{
    /// <summary>
    /// This is for storing the images on a logical term.  NoOFImages indicates the no of image count currently apply for the product
    /// if this count =2 then imagepath1 and imagepath2 are contain only valid images and so forth .
    /// Standered is get 5 images for product. so we've make 6 columns for easy access of the imange. so one only one row must be taken out to get the images for
    /// a given item
    /// </summary>
    public class ProductImages:BaseClass
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string ProductCode { get; set; }
        /// <summary>
        /// This indicates the no of images for given one product
        /// </summary>
        public string NoOFImages { get; set; }
        /// <summary>
        /// Path for the images 1,2,3,4,5,6
        /// </summary>
        public string imagepath1 { get; set; }
        public string imagepath2 { get; set; }
        public string imagepath3 { get; set; }
        public string imagepath4 { get; set; }
        public string imagepath5 { get; set; }
        public string imagepath6 { get; set; }
        /// <summary>
        /// If image count more than 6 then the name of the images can be stored here.
        /// </summary>
        public string ImagePathAdditional { get; set; }



    }
}
