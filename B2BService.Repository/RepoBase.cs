using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2BService.Data;
using B2BService.Domain;

namespace B2BService.Repository
{

    /// <summary>
    /// This repository is used for dealing with entities specific data task. 
    /// all the transaction on this repository is based on the passing entity
    /// </summary>
    /// <typeparam name="T">Entity witch would pass to the repository</typeparam>
    public class RepoBase<T> : IRepoBase<T> where T : class 
    {
        private string _TableName;


        public IDbConnection Conn;// = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SysConn"].ConnectionString);

      


        public RepoBase(string TableName)
        {
            _TableName = TableName;
            Conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SysConn"].ConnectionString);
        }

        public async Task<bool> Delete(int Id)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SysConn"].ConnectionString))
                {
                    var selectedT = await Find(Id);
                    var val = await db.DeleteAsync<T>(selectedT);
                    return val;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(T Entity)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SysConn"].ConnectionString))
                {
                    var val = await db.DeleteAsync<T>(Entity);
                    return val;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> FindALL()
        {
            try
            {
                string sql = "select * from " + _TableName;
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SysConn"].ConnectionString))
                {
                    var val = await db.QueryAsync<T>(sql);
                    return val;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> FindALLSortedBy(string SortColumn)
        {
            try
            {
                string sql = "select * from " + _TableName + " order by " + SortColumn.Trim();
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SysConn"].ConnectionString))
                {
                    var val = await db.QueryAsync<T>(sql);
                    return val;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> FindALLViaStorePrcedure(string spname)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SysConn"].ConnectionString))
                {
                    var val = await db.QueryAsync<T>(spname, commandType:CommandType.StoredProcedure);
                    return val;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Save(T Entity, int Action)
        {
            try
            {
                int returnval = -1;
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SysConn"].ConnectionString))
                {
                   

                    if (Action == 1)
                    {
                        returnval = await db.InsertAsync<T>(Entity);
                        returnval = 1;
                    }
                    else
                    {
                        bool resultx = await db.UpdateAsync<T>(Entity);
                        if (resultx)
                        {
                            returnval = 2;
                        }
                    }
                }
                return returnval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> Find(int Id)
        {
            try
            {
                string sql = "select * from " + _TableName + " where id = @id";
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SysConn"].ConnectionString))
                {
                    var val = await db.QueryFirstAsync<T>(sql, new { id = Id });
                    return val;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> FindExistance(string valueField , string Value)
        {
            try
            {
                string sql = "select * from Users where "+ valueField + " = '"+ Value + "' ";
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SysConn"].ConnectionString))
                {
                    var val = await db.QueryFirstOrDefaultAsync<T>(sql);
                    if (val == null)
                    {
                        return false;
                    }
                    else {
                        return true;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T FindExistance_ReturnObject(string valueField, string Value)
        {
            try
            {
                string sql = "select * from Users where " + valueField + " = '" + Value + "' ";
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SysConn"].ConnectionString))
                {
                    var val =  db.QueryFirstOrDefault<T>(sql);
                    return val;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<KeyValuePear>> ReturnKeyValue(string _IdField, string _ValueFIeld)
        {
            try
            {
                string sql = "select "+ _IdField + " as Value , " + _ValueFIeld  + " as Text from " + _TableName + " order by " + _ValueFIeld;
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SysConn"].ConnectionString))
                {
                    var val = await db.QueryAsync<KeyValuePear>(sql);
                    return val;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<IEnumerable<KeyValuePearWithbool>> ReturnKeyValueWithBool(string _IdField, string _ValueFIeld)
        {
            try
            {
                string sql = "select " + _IdField + " as Value , " + _ValueFIeld + " as Text , 0 as Options from " + _TableName + " order by " + _ValueFIeld;
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SysConn"].ConnectionString))
                {
                    var val = await db.QueryAsync<KeyValuePearWithbool>(sql);
                    return val;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<IEnumerable<KeyValuePear>> ReturnKeyValue(string _IdField, string _ValueFIeld, string _OrderBY ,bool desc)
        {
            try
            {
                string sql = "select " + _IdField + " as Value , " + _ValueFIeld + " as Text from " + _TableName + " order by " + _OrderBY;
                if (desc)
                {
                     sql = "select " + _IdField + " as Value , " + _ValueFIeld + " as Text from " + _TableName + " order by " + _OrderBY + " desc ";
                }
                else {
                     sql = "select " + _IdField + " as Value , " + _ValueFIeld + " as Text from " + _TableName + " order by " + _OrderBY + " asc ";
                }
                
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SysConn"].ConnectionString))
                {
                    var val = await db.QueryAsync<KeyValuePear>(sql);
                    return val;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Key2ValuePear>> ReturnKey2Value(string _IdField, string _ValueFIeld1, string _ValueFIeld2, string _OrderBY, bool desc)
        {
            try
            {
                string sql = "select " + _IdField + " as Value , " + _ValueFIeld1 + " as Text , " + _ValueFIeld2 + " as Options from " + _TableName + " order by " + _OrderBY;
                if (desc)
                {
                    sql = "select " + _IdField + " as Value , " + _ValueFIeld1 + " as Text , " + _ValueFIeld2 + " as Options from " + _TableName + " order by " + _OrderBY + " desc ";
                }
                else
                {
                    sql = "select " + _IdField + " as Value , " + _ValueFIeld1 + " as Text , " + _ValueFIeld2 + " as Options from " + _TableName + " order by " + _OrderBY + " asc ";
                }

                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SysConn"].ConnectionString))
                {
                    var val = await db.QueryAsync<Key2ValuePear>(sql);
                    return val;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<KeyValuePear>> ReturnKeyValueWithFK(string _IdField, string _ValueFIeld,string FK, string FKValue)
        {
            try
            {
                string sql = "select " + _IdField + " as Value , " + _ValueFIeld + " as Text from " + _TableName + "  where "+FK+" = "+ FKValue + " order by " + _ValueFIeld;
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SysConn"].ConnectionString))
                {
                    var val = await db.QueryAsync<KeyValuePear>(sql);
                    return val;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int SaveNonAsync(T Entity, int Action)
        {
            try
            {
                int returnval = -1;
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SysConn"].ConnectionString))
                {


                    if (Action == 1)
                    {
                        returnval = int.Parse(db.Insert<T>(Entity).ToString());
                        returnval = 1;
                    }
                    else
                    {
                        bool resultx =  db.Update<T>(Entity);
                        if (resultx)
                        {
                            returnval = 2;
                        }
                    }
                }
                return returnval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
