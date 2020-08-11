using Reeksamen.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reeksamen.Scripts.SQLiteFrameWork.Models
{
    class Test_Examble_Table
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public bool YesNo { get; set; } //might wanna change the name depending of useaged
        public int NumberInt { get; set; }
        public float Speed { get; set; }
        public float Health { get; set; }
        public DateTime dateTime { get; set; }
        public DatabaseEnums enums { get; set; }

        public Test_Examble_Table()
        {

        }
    }
}
