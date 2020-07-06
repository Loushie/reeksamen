using Reeksamen.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reeksamen.CommandPattern
{
    interface ICommand
    {
        void Execute(Player player);
    }
}
