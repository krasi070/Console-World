using ConsoleWorld.GameLogic.Menus;

namespace ConsoleWorld.GameLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class Startup
    {
        static void Main()
        {
            Console.CursorVisible = false;
           StartMenu Menu= new StartMenu();
            Menu.Draw();
            Menu.ChooseOption();

        }
    }
}
