using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Entities
{
    public class ClientEntity : BaseEntity
    {

        public int Id { set; get; }
       
        public string Nombres { set; get; }
        public string Apellidos { set; get; }
        public string Correo { set; get; }
        public DateTime? FechaNacimiento { set; get; }
        public string FechaNacimientoString { set; get; }
        public string Direccion { set; get; }

    }
}
