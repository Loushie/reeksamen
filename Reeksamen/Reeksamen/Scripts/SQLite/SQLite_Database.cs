using Reeksamen.Scripts.Enums;
using Reeksamen.Scripts.PlayerComponents;
using Reeksamen.Scripts.SQLiteFrameWork;
using Reeksamen.Scripts.SQLiteFrameWork.Factories;
using Reeksamen.Scripts.SQLiteFrameWork.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reeksamen.Scripts.SQLlite
{
    public class SQLite_Database
    {
        private static SQLite_Database instance;

        private PlayerStats_Factory pf = new PlayerStats_Factory();
        //Singleton Pattern for SQLite_Database
        public static SQLite_Database Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SQLite_Database();
                }

                return instance;
            }
        }
        public void RunSQLite()
        {
            //Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US"); //used incase we want floats to work properly in the database since . gets converted to , otherwise
            //DataBaseSetup();
            //PlayerStatsDatabase();
        }

        /*private void DataBaseSetup()
        {
            string name = "DatabaseName";
            SQLiteConnection databaseCon = new SQLiteConnection($"Data Source={name}.db;Version=3;New=true"); //sets up the database if it dosent already exsist
            databaseCon.Open();

            SQLiteCommand databaseCmd = new SQLiteCommand("CREATE TABLE IF NOT EXISTS PlayerStats (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name VARCHAR, NumberInt INTEGER, NumberFloat REAL)", databaseCon);
            databaseCmd.ExecuteNonQuery();

            //SPEED,MAXHP
            databaseCmd = new SQLiteCommand($"INSERT INTO PlayerStats (NumberFloat,NumberFloat) VALUES ({100.0f},{100.0f})", databaseCon);
            databaseCmd.ExecuteNonQuery();

            databaseCmd = new SQLiteCommand("SELECT * FROM PlayerStats", databaseCon);
            var data = databaseCmd.ExecuteReader();

            while (data.Read())
            {
                var _id = data.GetInt32(0);
                //var _string = data.GetString(1);
                //var _int = data.GetInt32(2);
                var _float = data.GetFloat(3);

                Console.WriteLine(_id);
                //Console.WriteLine(_string);
                //Console.WriteLine(_int);
                Console.WriteLine(_float);

            }


            databaseCon.Close();
        }*/

        public void GetPlayerData(ref float health, ref float speed)
        {
            //Since we never know what ID the player has and there only is 1 player anyway we use GetAll
            List<PlayerStats_Table> Listpt = pf.GetAll();
            PlayerStats_Table pt = Listpt[0];

            health = pt.Health;
            speed = pt.Speed;
        }
        public void SetupPlayerInDatabase()
        {
            AutoTable<PlayerStats_Table> autoTable = new AutoTable<PlayerStats_Table>();
            autoTable.MakeTable();

            List<PlayerStats_Table> Listpt = pf.GetAll();

            if (!(Listpt.Count > 0)) //if a player exsists
            {
                PlayerStats_Table pt = new PlayerStats_Table(100f, 100f);
                pf.Insert(pt);
            }
        }
    }
}
