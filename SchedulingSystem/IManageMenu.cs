using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal interface IManageMenu
    {
        void PrintMenu();
        bool SelectMenu();
        bool Confirm(string message);
    }
}
