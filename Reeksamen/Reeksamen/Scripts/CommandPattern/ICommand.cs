using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reeksamen.Scripts.CommandPattern
{
    interface ICommand
    {
        void Execute(Player player);
    }
}