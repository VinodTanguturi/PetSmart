using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSmart.Entities.Internal
{
    public class MySQLConnString
    {
        public string Server { get; set; }
        public string Port { get; set; }
        public string Uid { get; set; }
        public string Pwd { get; set; }
    }
}
