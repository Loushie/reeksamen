using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reeksamen.SqliteFramework
{
    public static class Conn
    {


        public static SQLiteConnection GetCon()
        {
            string DatabaseName = "Stats";

            SQLiteConnection con = new SQLiteConnection($"Data Source={DatabaseName}.db; Version=3;New=True;");
            return con;
        }

        public static SQLiteConnection CreateConnection()
        {
            SQLiteConnection cn = GetCon();
            cn.Open();
            return cn;
        }
    }
}
