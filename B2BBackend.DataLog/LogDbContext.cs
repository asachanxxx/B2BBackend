using B2BService.Domain.Log;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BBackend.DataLog
{
    public class LogDbContext:DbContext
    {
        public LogDbContext():base("SysConLOG")
        {

        }

        public DbSet<Log> Log { get; set; }
    }
}
