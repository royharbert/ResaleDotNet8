using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResaleV8_ClassLibrary.DatabaseOps
{
    public static class ConnectToDB
    {
        public static MySqlConnection OpenDB()
        {
            MySqlConnection con = new MySqlConnection(GV.conString);
            con.Open();
            return con;
        }
          
    }
}
