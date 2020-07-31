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
        public Player entity { get; set; }

        private static InputHandler instance;
        //Singleton Pattern for InputHandler
        public static InputHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InputHandler();
                }

                return instance;
            }
        }
        //Dictionary With all ketbind and Commands
         private Dictionary<Keys, ICommand> keybinds = new Dictionary<Keys, ICommand>();


        //Creating Keybinds
         public InputHandler()
         {
             keybinds.Add(Keys.D, new MoveCommand(new Vector2(1, 0)));
             keybinds.Add(Keys.A, new MoveCommand(new Vector2(-1, 0)));
             keybinds.Add(Keys.W, new MoveCommand(new Vector2(0, -1)));
             keybinds.Add(Keys.S, new MoveCommand(new Vector2(0, 1)));
             //keybinds.Add(Keys.K, new ShootCommand());
         }
        //Check if player Presses any of the keybinds
         public void Execute()
         {
             KeyboardState keyState = Keyboard.GetState();

             foreach (Keys key in keybinds.Keys)
             {
                 if (keyState.IsKeyDown(key))
                 {
                     keybinds[key].Execute(entity);
                 }
             }
         }
    }
}