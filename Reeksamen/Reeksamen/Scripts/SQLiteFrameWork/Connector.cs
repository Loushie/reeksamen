using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reeksamen.Scripts.SQLiteFrameWork
{
    public static class Connector
    {
        public static SQLiteConnection GetCon()
        {
            string DatabaseName = "PlayerStats";

            SQLiteConnection con = new SQLiteConnection($"Data Source= {DatabaseName}.db; Version=3;New=True;");
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
