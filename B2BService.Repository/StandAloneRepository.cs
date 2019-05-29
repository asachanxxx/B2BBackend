using B2BService.Unitilities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace B2BService.Repository
{
    public class StandAloneRepository : IStandAloneRepository
    {
        public readonly IDbConnection Conn;
        public StandAloneRepository()
        {
            Conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SysConn"].ConnectionString);
        }

        public async Task<int> ExcuteStoredProcedureTo(string SPName) 
        {
            try
            {
                using (IDbConnection db = Conn)
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await db.ExecuteAsync(SPName, parameter, commandType: CommandType.StoredProcedure);
                    int rowCount = parameter.Get<int>("@RowCount");
                    return rowCount;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> ExcuteStoredProcedureToSave<T>(string SPName,T Object) where T : class
        {
            try
            {
                var xmlperson = XMLTools.ObjectToXMLGeneric<T>(Object);
                using (IDbConnection db = Conn)
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@XMLSQL", xmlperson, DbType.String, ParameterDirection.Input);
                    parameter.Add("@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await db.ExecuteAsync(SPName, parameter,commandType: CommandType.StoredProcedure);
                    int rowCount = parameter.Get<int>("@RowCount");
                    return rowCount;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
