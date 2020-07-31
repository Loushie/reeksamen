using Microsoft.Xna.Framework;
using Reeksamen.Scripts.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reeksamen.Scripts.ObserverPattern
{
    public class GameEvent
    {
        private List<IGameListener> listners = new List<IGameListener>();

        public string Title { get; private set; }

        public GameEvent(string title)
        {
            this.Title = title;
        }

        public void Attach(IGameListener listner)
        {
            listners.Add(listner);
        }

        public void Detach(IGameListener listener)
        {
            listners.Remove(listener);
        }

        public void Notify(Component other)
        {
            foreach (IGameListener listner in listners)
            {
                listner.Notify(this, other);
            }
        }
    }
}
