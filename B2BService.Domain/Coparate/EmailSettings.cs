using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain.Coparate
{
    public class EmailSettings
    {
        public int Id { get; set; }
        public string InfoEmail { get; set; }
        public string FromPassword { get; set; }
        public string Subject { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public bool EnableSsl { get; set; }
        public bool UseDefaultCredentials { get; set; }
        
    }
}
