using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spane_Laboratory
{
    public class Connection
    {
       
        private static string _connection = "Data Source= .; Initial Catalog=LabDatabase ;  Integrated Security=true";
        
        public static string ConnectionString
        {
            get { return _connection; }
            set { _connection = value; }
        }
    }
}
