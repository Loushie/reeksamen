using Microsoft.Xna.Framework;
using Reeksamen.Scripts.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reeksamen.Scripts.ObserverPattern
{
    public interface IGameListener
    {
        void Notify(GameEvent gameEvent, Component component);
    }
}
