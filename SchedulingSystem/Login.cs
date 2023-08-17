using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal class Login : IManageMenu
    {
        public Login() { }

        public bool Confirm(string message)
        {
            throw new NotImplementedException();
        }

        public void PrintMenu()
        {
            Console.WriteLine("========= LOGIN =========");
        }

        public string SelectMenu()
        {
        Check:
            try
            {
                Console.Write("Username: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();

                if (username == "admin" && password == "1")
                    return "main";
                Console.WriteLine("Invalid username or password!\n");
                goto Check;
            }
            catch (Exception e) {             
                Console.Write(e.Message);
                goto Check;
            }
        }
    }
}
