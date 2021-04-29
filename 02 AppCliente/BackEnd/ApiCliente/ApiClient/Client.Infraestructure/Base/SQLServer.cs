
using Client.Infraestructure.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace Client.Infraestructure.Implementation
{
    public class SQLServer
    {
        Settings oSettings;
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;

        public SQLServer()
        {
            oSettings = new Settings();
            try
            {

                oSettings.Load();
            }
            catch (Exception eXception)
            {
                throw new Exception("No se pudo cargar la información del archivo de configuración.", eXception);
            }
        }
        public SQLServer(string ConnectionString)
        {
            oSettings = new Settings();
            //oSettings.ConnectionString = ConnectionString;
            try
            {
                oSettings.Save();
            }
            catch (Exception eXception)
            {
                throw new Exception("No se pudo guardar la información del archivo de configuración.", eXception);
            }
        }
        public string ReadOneValue(string Command)
        {
            return ReadOneValue(Command, null);
        }

        public string ReadOneValue(string Command, SqlParameterCollection sqlParameterCollection)
        {
            if (sqlConnection == null)
                sqlConnection = new SqlConnection(oSettings.ConnectionString);
            try
            {
                using (sqlCommand = new SqlCommand(Command, sqlConnection))
                {
                    if (sqlParameterCollection != null)
                        sqlCommand.Parameters.Add(sqlParameterCollection);
                    string sReturnValue = null;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        sqlDataReader.Read();
                        sReturnValue = sqlDataReader.GetValue(0).ToString();
                    }
                    if (sqlDataReader != null && !sqlDataReader.IsClosed)
                        sqlDataReader.Close();
                    return sReturnValue;
                }
            }
            catch (Exception eXception)
            {
                throw new Exception("No se pudo leer la información de la base de datos.", eXception);
            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State != System.Data.ConnectionState.Closed)
                    sqlConnection.Close();
            }
        }


        public List<T> ReadValueSP<T>(string Command, List<SqlParameter> sqlParameterCollection)
        {
            DataTable dtLista = new DataTable();
            DataSet dtsLista = new DataSet();
            List<T> listValues;

            if (sqlConnection == null)
                sqlConnection = new SqlConnection(oSettings.ConnectionString);
            try
            {
                using (sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = Command;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    if (sqlParameterCollection != null)
                        sqlCommand.Parameters.AddRange(sqlParameterCollection.ToArray());
                    sqlConnection.Open();

                    listValues = new List<T>();

                    SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCommand);
                    sqlDA.Fill(dtsLista, "valores");
                    dtLista = dtsLista.Tables[0];

                    listValues = ConvertDataTable<T>(dtLista);
                    return listValues;
                }
            }
            catch (Exception eXception)
            {
                throw new Exception("No se pudo leer la información de la base de datos.", eXception);
            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State != System.Data.ConnectionState.Closed)
                    sqlConnection.Close();
            }
        }

        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                    {

                        var d = dr[column.ColumnName].ToString() == "" ? null : dr[column.ColumnName].ToString();
                        var f = obj;
                        var g = pro.PropertyType;
                        //pro.SetValue(obj, Convert.ChangeType(dr[column.ColumnName], pro.PropertyType), null);

                        Type t = Nullable.GetUnderlyingType(pro.PropertyType) ?? pro.PropertyType;
                        object safeValue = (d == null) ? null : Convert.ChangeType(dr[column.ColumnName], t);
                        pro.SetValue(obj, safeValue, null);

                    }
                    else
                        continue;
                }
            }
            return obj;
        }


        public string InsertOne(string Command, List<SqlParameter> sqlParameterCollection)
        {
            if (sqlConnection == null)
                sqlConnection = new SqlConnection(oSettings.ConnectionString);
            try
            {
                using (sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = Command;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    if (sqlParameterCollection != null)
                        sqlCommand.Parameters.AddRange(sqlParameterCollection.ToArray());
                    sqlConnection.Open();
                    return Convert.ToString(sqlCommand.ExecuteScalar());
                }
            }
            catch (Exception eXception)
            {
                throw new Exception("No se pudo leer la información de la base de datos.", eXception);
            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State != System.Data.ConnectionState.Closed)
                    sqlConnection.Close();
            }
        }

        public int InsertReturnOne(string Command, List<SqlParameter> sqlParameterCollection)
        {
            int sValores = 0;

            if (sqlConnection == null)
                sqlConnection = new SqlConnection(oSettings.ConnectionString);
            try
            {
                sqlConnection.Open();
                using (sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = Command;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    if (sqlParameterCollection != null)
                        sqlCommand.Parameters.AddRange(sqlParameterCollection.ToArray());

                    sqlCommand.ExecuteNonQuery();

                    sValores = Convert.ToInt32(sqlCommand.Parameters["@IdRef"].Value);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo leer la información de la base de datos.", ex);
                //  sValores = "X" + "No se pudo leer la información de la base de datos." + "\n" + eXception.ToString();
            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State != System.Data.ConnectionState.Closed)
                    sqlConnection.Close();
            }
            return sValores;
        }

        public BaseEntity InsertReturnOutPut(string Command, List<SqlParameter> sqlParameterCollection)
        {
            BaseEntity obj = new BaseEntity();

            if (sqlConnection == null)
                sqlConnection = new SqlConnection(oSettings.ConnectionString);
            try
            {
                sqlConnection.Open();
                using (sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = Command;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    if (sqlParameterCollection != null)
                        sqlCommand.Parameters.AddRange(sqlParameterCollection.ToArray());

                    sqlCommand.ExecuteNonQuery();

                    obj.IdRef = Convert.ToInt32(sqlCommand.Parameters["@IdRef"].Value);

                    if (sqlCommand.Parameters["@IdRef_A"].Value != null)
                    {
                        obj.IdRef_ = Convert.ToInt32(sqlCommand.Parameters["@IdRef_A"].Value);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo leer la información de la base de datos.", ex);
                //  sValores = "X" + "No se pudo leer la información de la base de datos." + "\n" + eXception.ToString();
            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State != System.Data.ConnectionState.Closed)
                    sqlConnection.Close();
            }
            return obj;
        }

        public string DeleteOne(string Command, List<SqlParameter> sqlParameterCollection)
        {
            string strResultado;

            if (sqlConnection == null)
                sqlConnection = new SqlConnection(oSettings.ConnectionString);
            try
            {
                using (sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = Command;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    if (sqlParameterCollection != null)
                        sqlCommand.Parameters.AddRange(sqlParameterCollection.ToArray());
                    sqlConnection.Open();
                    strResultado = "A" + Convert.ToString(sqlCommand.ExecuteNonQuery());
                }
            }
            catch (Exception eXception)
            {
                //throw new Exception("No se pudo eliminar de la base de datos.", eXception);
                strResultado = "X" + "No se pudo eliminar el registro." + "\n" + eXception.ToString();
            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State != System.Data.ConnectionState.Closed)
                    sqlConnection.Close();
            }
            return strResultado;
        }

        /*FIN MODELO TURNOS*/
    }
}