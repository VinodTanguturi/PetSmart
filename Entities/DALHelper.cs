using MySql.Data.MySqlClient;
using System;
using Dapper;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace PetSmart.Entities
{
    public static class DALHelper
    {
        public static List<T> Query<T>(string sql = null, DynamicParameters parameters = null, CommandType commandType = CommandType.StoredProcedure, int timeOut = 30, string database = null)
        {
            DateTime start_time = DateTime.Now;
            TimeSpan duration;
            try
            {
                using (var conn = new MySqlConnection(Helper.GetConnectionString(database)))
                {
                    return conn.Query<T>(sql, parameters, commandTimeout: timeOut, commandType: commandType).ToList();
                }
            }
            finally
            {
                duration = (DateTime.Now - start_time);
                //TODO: Log the connection duration
            }
        }

        //TODO: Check to see if multiple datasets is possible (again)
    }
}
