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

        /// <summary>
        /// This method is complicated. what it does is that it take one type of parameter as passing parameters and different types as Return type
        /// THis will enable users to genaralize the passing and retrning types 
        /// </summary>
        /// <typeparam name="TPassing">Type that need to pass as parameters</typeparam>
        /// <typeparam name="TOut">Type you want to return from the method</typeparam>
        /// <param name="SPName">Stored procudure to exute</param>
        /// <param name="Object">Passing object</param>
        /// <returns></returns>
        public async Task<IEnumerable<TOut>> QueryStoredProcedure<TPassing, TOut>(string SPName, TPassing Object) where TOut : class  where TPassing : class
        {
            try
            {
                var xmlperson = XMLTools.ObjectToXMLGeneric<TPassing>(Object);
                using (IDbConnection db = Conn)
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@XMLSQL", xmlperson, DbType.String, ParameterDirection.Input);
                    parameter.Add("@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    return await db.QueryAsync<TOut>(SPName, parameter, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
