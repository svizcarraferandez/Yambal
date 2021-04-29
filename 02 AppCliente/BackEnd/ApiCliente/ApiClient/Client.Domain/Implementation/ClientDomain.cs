using Client.Domain.Interface;
using Client.Entities;
using Client.Infraestructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Domain.Implementation
{
    public class ClientDomain : IClientDomain
    {
        ClientInfraestructure clientInfraestructure;

        public ClientDomain()
        {
            clientInfraestructure = new ClientInfraestructure();
        }

        public List<ClientEntity> GetAll(ClientEntity objEntity)
        {
            return clientInfraestructure.Get_All(objEntity);
        }

        public ClientEntity InsertClient(ClientEntity objEntity)
        {
            if (!String.IsNullOrEmpty(objEntity.FechaNacimientoString))
            {
                objEntity.FechaNacimiento = Convert.ToDateTime(objEntity.FechaNacimientoString);
            }
            return clientInfraestructure.InsertClient(objEntity);
        }

    }
}
