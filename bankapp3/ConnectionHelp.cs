using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace bankapp3
{
    class ConnectionHelp
    {
        public static SqlConnection GetConnection()
        {
            string str = ConfigurationManager.ConnectionStrings["bankcon"].ConnectionString;
            SqlConnection con = new SqlConnection(str);
            return con;
        }
    }
}
