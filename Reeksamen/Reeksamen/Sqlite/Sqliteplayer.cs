using Reeksamen.Scripts.PlayerComponents;
using Reeksamen.SqliteFramework;
using Reeksamen.SqliteFramework.Factories;
using Reeksamen.SqliteFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reeksamen.Sqlite
{
    public class Sqliteplayer
    {
        public void RunSQlite()
        {
            Stats();
        }

        private void Stats()
        {
            AutoTable<Player_Table> autoTable = new AutoTable<Player_Table>();
            autoTable.MakeTable();

            Player_Factory pf = new Player_Factory();

            Player_Table pt = new Player_Table(100, 250);
            pf.Insert(pt);

            List<Player_Table> Listpt = pf.GetAll();

            foreach (Player_Table item in Listpt)
            {
                Console.WriteLine(item.MoveSpeed);
                Console.WriteLine(item.MaxHealth);
            }


        }

    }
}
