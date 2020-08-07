using Reeksamen.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reeksamen.Scripts.SQLiteFrameWork.Models
{
    public class PlayerStats_Table
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool YesNo { get; set; } //might wanna change the name depending of useaged
        public int NumberInt { get; set; }
        public float NumberFloat { get; set; }
        public DateTime dateTime { get; set; }
        public DatabaseEnums enums { get; set; }

        public PlayerStats_Table()
        {

        }

        public PlayerStats_Table(string Name, bool YesNo, int NumberInt, float NumberFloat, DateTime dateTime, DatabaseEnums enums)
        {
            this.Name = Name;
            this.YesNo = YesNo;
            this.NumberInt = NumberInt;
            this.NumberFloat = NumberFloat;
            this.dateTime = dateTime;
            this.enums = enums;

        }
    }
}