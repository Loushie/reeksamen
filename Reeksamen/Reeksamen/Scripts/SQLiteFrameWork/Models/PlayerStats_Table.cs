﻿using Reeksamen.Scripts.Enums;
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
        public float Speed { get; set; }
        public float Health { get; set; }

        public PlayerStats_Table()
        {

        }

        public PlayerStats_Table(float Health, float Speed)
        {
            this.Health = Health;
            this.Speed = Speed;
        }
    }
}