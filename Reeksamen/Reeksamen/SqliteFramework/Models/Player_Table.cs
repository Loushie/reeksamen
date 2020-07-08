using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reeksamen.SqliteFramework.Models
{
    class Player_Table
    {
        public int ID { get; set; }
        public int MaxHealth { get; set; }
        public int MoveSpeed { get; set; }

        public Player_Table()
        {

        }

        public Player_Table(int MaxHealth, int MoveSpeed)
        {
            this.MaxHealth = MaxHealth;
            this.MoveSpeed = MoveSpeed;
        }
    }
}
