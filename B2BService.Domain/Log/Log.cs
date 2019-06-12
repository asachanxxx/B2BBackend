using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Domain.Log
{
    public class Log
    {

        [System.ComponentModel.DataAnnotations.Key]
        [Computed]
        public int LOG_ID { get; set; }
        public DateTime LOG_DATE { get; set; }
        /// <summary>
        /// 1-Error
        /// 2-Information
        /// 3-Warning
        /// </summary>
        public string USER_ID { get; set; }
        public string MESSAGE { get; set; }
        public string STACK_TRACE { get; set; }
        public string PysicalMethod { get; set; }
        public string Controllername { get; set; }
        public string UserAgent { get; set; }
        public string CLIENT_IP { get; set; }
        public string CLIENT_PORT { get; set; }
        public DateTime CPU_TIME { get; set; }
     

    }
}
