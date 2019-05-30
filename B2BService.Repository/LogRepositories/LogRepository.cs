using B2BService.Domain.Log;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Repository.LogRepositories
{
    public class LogRepository
    {

        RepoBase<Log> Logrepo;
        public readonly IDbConnection Conn;
        public LogRepository()
        {
            Conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SysConLOG"].ConnectionString);
            Logrepo = new RepoBase<Log>("Logs");
        }


        public bool AddLogEntry(Log entity)
        {
            try
            {
                using (IDbConnection db = Conn)
                {
                    db.Insert<Log>(entity);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
