using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain.Coparate
{
    public class Organization: BaseClass
    {
        public int Id { get; set; }
        public int BusinessType { get; set; }
        public string OrganizationName { get; set; }
        public string MainPhone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int District { get; set; }
        public int City { get; set; }
        public string Email { get; set; }
        /// <summary>
        /// This is the name of top responsible person in the company
        /// </summary>
        public string FRPerson { get; set; }
        /// <summary>
        /// This is the Email of top responsible person in the company
        /// </summary>
        public string FRPEmail { get; set; }
        /// <summary>
        /// This is the name of second responsible person in the company
        /// </summary>
        public string SRPerson { get; set; }
        /// <summary>
        /// This is the Email of second responsible person in the company
        /// </summary>
        public string SRPEmail { get; set; }
        /// <summary>
        /// This is the name of the person who mainly interact with the online system
        /// </summary>
        public string HandlerName { get; set; }
        /// <summary>
        /// This is the Email of the handler
        /// </summary>
        public string HandlerEmail { get; set; }
        /// <summary>
        /// This will indicate the given company buy or sell in the online system
        /// </summary>
        public string IsBuyOrSell { get; set; }


    }
}
