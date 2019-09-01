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

        public async Task<int> ExcuteStoredProcedureToSave<T>(string SPName,T Object,int action) where T : class
        {
            try
            {
                var xmlperson = XMLTools.ObjectToXMLGeneric<T>(Object);
                using (IDbConnection db = Conn)
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@XMLSQL", xmlperson, DbType.String, ParameterDirection.Input);
                    parameter.Add("@Action", action, DbType.Int32, ParameterDirection.Input);
                    parameter.Add("@Status", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    await db.ExecuteAsync(SPName, parameter,commandType: CommandType.StoredProcedure);
                    int rowCount = parameter.Get<int>("@Status");
                    return rowCount;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<IEnumerable<T>> ExcuteStoredProcedureToSave<T>(string SPName, int obj) where T : class
        {
            try
            {
                using (IDbConnection db = Conn)
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@Obj", obj, DbType.Int32, ParameterDirection.Input);
                    parameter.Add("@Status", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    return await db.QueryAsync<T>(SPName, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> ExcuteStoredProcedureToSave<T>(string SPName, string obj) where T : class
        {
            try
            {
                using (IDbConnection db = Conn)
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@Obj", obj, DbType.String, ParameterDirection.Input);
                    parameter.Add("@Status", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    return await db.QueryAsync<T>(SPName, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// To excite a given sp and return single instance of the object of type T. without passing any parameters
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="SPName">Stored Procedure to exute</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> QueryStoredProcedureSQLString<T>(string SQL) where T : class
        {
            try
            {
                using (IDbConnection db = Conn)
                {
                    return await db.QueryAsync<T>(SQL);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        /// <summary>
        /// To excite a given sp and return single instance of the object of type T. without passing any parameters
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="SPName">Stored Procedure to exute</param>
        /// <returns></returns>
        public async Task<T> QueryStoredProcedure<T>(string SPName) where T : class
        {
            try
            {
                using (IDbConnection db = Conn)
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@Status", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    return await db.QuerySingleOrDefaultAsync<T>(SPName, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // <summary>
        /// To excite a given sp and return single instance of the object of type T. with passign parameters
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="SPName">Stored Procedure to exute</param>
        /// <returns></returns>
        public async Task<T> QueryStoredProcedure<T>(string SPName ,int obj) where T : class
        {
            try
            {
                using (IDbConnection db = Conn)
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@Obj", obj, DbType.Int32, ParameterDirection.Input);
                    parameter.Add("@Status", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    return await db.QuerySingleOrDefaultAsync<T>(SPName, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal Task<int> ExcuteStoredProcedureToSave<T>(object approveUserSPName, T obj)
        {
            throw new NotImplementedException();
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
                    parameter.Add("@Status", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    return await db.QueryAsync<TOut>(SPName, parameter, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> ExcuteStoredProcedureToSave<T>(string SPName, T Object) where T : class
        {
            try
            {
                var xmlperson = XMLTools.ObjectToXMLGeneric<T>(Object);
                using (IDbConnection db = Conn)
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@XMLSQL", xmlperson, DbType.String, ParameterDirection.Input);
                    parameter.Add("@Status", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    await db.ExecuteAsync(SPName, parameter, commandType: CommandType.StoredProcedure);
                    int rowCount = parameter.Get<int>("@Status");
                    return rowCount;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<List<T>> ReadTextAsync<T>(string filePath) where T : class
        {
            try
            {
                JsonEngine jengine = new JsonEngine();

                using (FileStream sourceStream = new FileStream(filePath,
                    FileMode.Open, FileAccess.Read, FileShare.Read,
                    bufferSize: 4096, useAsync: true))
                {
                    StringBuilder sb = new StringBuilder();

                    byte[] buffer = new byte[0x1000];
                    int numRead;
                    while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                    {
                        string text = Encoding.ASCII.GetString(buffer, 0, numRead);
                        sb.Append(text);
                    }

                    var listback = jengine.ConvertFromJson<T>(sb.ToString());

                    return listback;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
