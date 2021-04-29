using Client.Entities;
using Client.Infraestructure.Implementation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Client.Infraestructure
{
    public class ClientInfraestructure
    {
        private SQLServer sqlServer;
        public ClientInfraestructure()
        {
            sqlServer = new SQLServer();
            
        }
        
        public List<ClientEntity> Get_All(ClientEntity obj)
        {
            try
            {
                List<SqlParameter> sp = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName = "@Id",  Value= obj.Id }
                };

                var miLista = (sqlServer.ReadValueSP<ClientEntity>("[GetCliente]", sp));
                return miLista;
            }
            catch (Exception eXception)
            {
                throw new Exception("No se pudo cargar la información del objeto ServiceCode.", eXception);
            }
        }


        public ClientEntity InsertClient(ClientEntity obj)
        {
            try
            {
                List<SqlParameter> sp = new List<SqlParameter>()
                {
                        new SqlParameter() {ParameterName = "@Nombres", Value= (object)obj.Nombres ?? DBNull.Value },
                        new SqlParameter() {ParameterName = "@Apellidos", Value= (object)obj.Apellidos?? DBNull.Value },
                        new SqlParameter() {ParameterName = "@Correo", Value= (object)obj.Correo?? DBNull.Value },
                        new SqlParameter() {ParameterName = "@FechaNacimiento", Value= (object)obj.FechaNacimiento?? DBNull.Value },
                        new SqlParameter() {ParameterName = "@Direccion", Value= (object)obj.Direccion?? DBNull.Value },
                           new SqlParameter() {ParameterName = "@IdRef", SqlDbType = SqlDbType.Int,  Direction = ParameterDirection.Output }
                };
                var validar = sqlServer.InsertReturnOne("[InsCliente]", sp);
                obj.Correo = validar.ToString();
                return obj;
            }
            catch (Exception eXception)
            {
                throw new Exception("No se pudo cargar la información del objeto ServiceCode.", eXception);
            }
        }

    }
}
