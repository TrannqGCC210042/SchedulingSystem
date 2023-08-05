using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    

    internal class DoctorMenu : IManageMenu
    {   
        ManageDoctor manageDoctor { get; set; }
        public DoctorMenu(ManageDoctor manageDoctor)
        {
            this.manageDoctor = manageDoctor;
        }

        public void PrintMenu()
        {
            bool isExit;
            do
            {
                Console.WriteLine("========= Manage Doctors =========");
                Console.WriteLine("0. [Return menu]");
                Console.WriteLine("1. Add Doctors");
                Console.WriteLine("2. Update Doctors");
                Console.WriteLine("3. Delete Doctors");
                Console.WriteLine("4. Show All Doctors");
                Console.WriteLine("5. Search Doctors");
                isExit = SelectMenu();
            }
            while (!isExit);
        }
        public bool SelectMenu()
        {
            Console.Write(">>> Input your choice: ");
            int choice = int.Parse(Console.ReadLine());
            bool checkExit = false;

            switch (choice)
            {
                case 0:
                    checkExit = Confirm("return");
                    break;
                case 1:
                    Console.Clear();
                    manageDoctor.Add();
                    break;
                case 2:
                    Console.Clear();
                    manageDoctor.Update();
                    break;
                case 3:
                    Console.Clear();
                    manageDoctor.Delete();
                    break;
                case 4:
                    Console.Clear();
                    manageDoctor.ShowAll();
                    break;
                case 5:
                    Console.Clear();
                    manageDoctor.Search();
                    break;
                default:
                    Console.WriteLine("Input must be from 0 to 5!");
                    break;
            }
            return checkExit;
        }


        public bool Confirm(string message)
        {
            bool checkContinue = false;
            string isExit = "";
            while (!isExit.Equals("y") || !isExit.Equals("y"))
            {
                Console.Write($"Are you sure to {message}? [y/n]: ");
                isExit = Console.ReadLine();

                if (isExit.Equals("y"))
                {
                    checkContinue = true;
                    break;
                }
                else if (isExit.Equals("n"))
                {
                    break;
                }
                else
                    Console.WriteLine("Input must be \"y\" or \"n\".");
            }

            Console.Clear();
            return checkContinue;
        }
    }
}
