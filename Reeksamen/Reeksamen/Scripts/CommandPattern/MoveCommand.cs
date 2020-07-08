using Microsoft.Xna.Framework;
using Reeksamen.Scripts;
using Reeksamen.Scripts.PlayerComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reeksamen.Scripts.CommandPattern
{
    class MoveCommand : ICommand
    {
        private Vector2 playerSpeed;

        public MoveCommand(Vector2 playerSpeed)
        {
            this.playerSpeed = playerSpeed;
        }

        public void Execute(Player player)
        {
            player.Move(player playerSpeed);
        }
    }
}
