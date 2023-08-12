using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IManageMenu Menu = MenuFactory.CreateMenu("main");
            string menuType;
            do
            {
                Console.Clear();
                Menu.PrintMenu();
                menuType = Menu.SelectMenu();
                Menu = MenuFactory.CreateMenu(menuType);
            }while (menuType != "");
        }
    }
}
