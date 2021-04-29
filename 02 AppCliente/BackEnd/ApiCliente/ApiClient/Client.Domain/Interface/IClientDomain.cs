using Client.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Domain.Interface
{
   public interface IClientDomain
    {
        List<ClientEntity> GetAll(ClientEntity objEntity);
        ClientEntity InsertClient(ClientEntity objEntity);

    }
}
