using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace test
{
    class DbConnection
    {
        public static MySqlConnection conn;

        public static MySqlConnection getCon()
        {

            conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
            conn.Open();
            return conn;
        }

        public static void closeConn()
        {
            conn.Close();
        }
    }
}
