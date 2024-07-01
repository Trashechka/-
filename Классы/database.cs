using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Спортивный_клуб
{
    public class database
    {
        static string serverName = @"DESKTOP-2F416IT";
        static string dbName = "Club";

        public SqlConnection con = new SqlConnection($@"Data Source={serverName}; Initial Catalog={dbName};Integrated Security = True");
    }
}
