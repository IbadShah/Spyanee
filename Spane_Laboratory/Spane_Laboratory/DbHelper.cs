using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spane_Laboratory
{
   public class DbHelper
    {
        private readonly SqlConnection _connection = new SqlConnection();

        public DbHelper()
        {
            _connection.ConnectionString = Connection.ConnectionString;
        }

        public void OpenConnection()
        {
            if (_connection.State != ConnectionState.Closed) return;
            _connection.Open();
        }

        public void CloseConnection()
        {
            if (_connection == null) return;
            _connection.Close();
        }

        private SqlCommand CreateCommand(string procedureName, params SqlParameter[] param)
        {
            var cmd = new SqlCommand(procedureName, _connection)
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 500
            };
            // add proc parameters
            cmd.Parameters.Clear();
            if (param != null)
            {
                cmd.Parameters.AddRange(param);
            }
            // return param
            cmd.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false,
                0, 0, string.Empty, DataRowVersion.Default, null));

            return cmd;
        }

        public List<T> GenericSqlDataReader<T>(string procedureName, params SqlParameter[] sqlParameters)
        {
            List<T> list;
            try
            {
                var cmd = CreateCommand(procedureName, sqlParameters);
                OpenConnection();
                var reader = cmd.ExecuteReader();
                list = DataReaderMapToList<T>(reader);
            }
            finally
            {
                CloseConnection();
            }
            return list;
        }

        private static List<T> DataReaderMapToList<T>(IDataReader dr)
        {
            var list = new List<T>();
            while (dr.Read())
            {
                var obj = Activator.CreateInstance<T>();
                foreach (var prop in obj.GetType().GetProperties())
                {
                    if (!Equals(dr[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, dr[prop.Name], null);
                    }
                }
                list.Add(obj);
            }
            return list;
        }

        public T GetField<T>(SqlDataReader dr, string fieldName)
        {
            var value = dr.GetValue(dr.GetOrdinal(fieldName));
            return value is DBNull ? default(T) : (T)value;
        }

        public long ExecuteScalar(string procedureName, params SqlParameter[] param)
        {
            try
            {
                var cmd = CreateCommand(procedureName, param);
                OpenConnection();
                return Convert.ToInt64(cmd.ExecuteScalar());
            }
            finally
            {
                CloseConnection();
            }
        }

        public object ExecuteScalarOutPram(string procName, string outParamName, params SqlParameter[] param)
        {
            try
            {
                var cmd = CreateCommand(procName, param);
                OpenConnection();
                cmd.ExecuteScalar();
                return cmd.Parameters[outParamName].Value;
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Used to execute the Stored Procedure.
        /// </summary>
        /// <param name="procedureName">Stored Procedure name</param>
        /// <param name="param">SqlParameters, can contain single or full array. it can be null also</param>
        public void ExecuteProcedure(string procedureName, params SqlParameter[] param)
        {
            try
            {
                var cmd = CreateCommand(procedureName, param);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                CloseConnection();
            }
        }

        public DataSet GetDataSet(string procedureName, params SqlParameter[] param)
        {
            try
            {
                OpenConnection();
                var cmd = CreateCommand(procedureName, param);
                cmd.CommandTimeout = 1000;
                var adapter = new SqlDataAdapter(cmd);
                var dataset = new DataSet();
                adapter.Fill(dataset);
                return dataset;
            }
            finally
            {
                CloseConnection();
            }
        }

        public DataTable GetDataTable(string procedureName, params SqlParameter[] param)
        {
            try
            {
                OpenConnection();
                var cmd = CreateCommand(procedureName, param);
                cmd.CommandTimeout = 1000;
                var adapter = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            finally
            {
                CloseConnection();
            }
        }




        #region SQL Parameters

        public SqlParameter InParam(string paramName, SqlDbType dbType, int size, object value)
        {
            return MakeParam(paramName, dbType, size, ParameterDirection.Input, value);
        }
        public SqlParameter InOutParam(string paramName, SqlDbType dbType, int size, object value)
        {
            return MakeParam(paramName, dbType, size, ParameterDirection.InputOutput, value);
        }
        public SqlParameter OutParam(string paramName, SqlDbType dbType, int size)
        {
            return MakeParam(paramName, dbType, size, ParameterDirection.Output, null);
        }

        private static SqlParameter MakeParam(string paramName, SqlDbType dbType, int size, ParameterDirection direction, object value)
        {
            var param = size > 0 ? new SqlParameter(paramName, dbType, size)
                                 : new SqlParameter(paramName, dbType);

            param.Direction = direction;
            if (!(direction == ParameterDirection.Output && value == null))
                param.Value = value;

            return param;
        }

        #endregion

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
