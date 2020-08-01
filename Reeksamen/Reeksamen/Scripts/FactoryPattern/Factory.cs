using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//This Is What The Other Factory Patterns Are Gonna Inherit From
namespace Reeksamen.Scripts.FactoryPattern
{
    public abstract class Factory
    {
        public abstract GameObject Create(string type);
    }
}
