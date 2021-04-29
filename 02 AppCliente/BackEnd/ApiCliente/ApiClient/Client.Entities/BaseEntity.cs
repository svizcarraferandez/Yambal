using System;

namespace Client.Entities
{
    public class BaseEntity
    {

        public bool Activo { set; get; }
        public DateTime FechaRegistro { set; get; }
        public string CreationDateString { set; get; }
        public string CreationUser { set; get; }
        public string CreationIPTerminal { set; get; }
        public DateTime ModificationDate { set; get; }
        public string ModificationDateString { set; get; }
        public string ModificationUser { set; get; }
        public string ModificationIPTerminal { set; get; }
    }
}
