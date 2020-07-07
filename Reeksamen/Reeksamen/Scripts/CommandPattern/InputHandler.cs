using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Reeksamen.Scripts;
using Reeksamen.Scripts.Components;
using Reeksamen.Scripts.PlayerComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Reeksamen.Scripts.CommandPattern
{

    class InputHandler
    {
         private Dictionary<Keys, ICommand> keybinds = new Dictionary<Keys, ICommand>();

         public InputHandler()
         {
             keybinds.Add(Keys.D, new MoveCommand(new Vector2(1, 0)));
             keybinds.Add(Keys.A, new MoveCommand(new Vector2(-1, 0)));
             keybinds.Add(Keys.W, new MoveCommand(new Vector2(0, -1)));
             keybinds.Add(Keys.S, new MoveCommand(new Vector2(0, 1)));
         }

         public void Execute(Player player)
         {
             KeyboardState keyState = Keyboard.GetState();

             foreach (Keys key in keybinds.Keys)
             {
                 if (keyState.IsKeyDown(key))
                 {
                     keybinds[key].Execute(player);
                 }
             }
         }
    }
}