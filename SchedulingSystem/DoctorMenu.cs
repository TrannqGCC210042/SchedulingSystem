using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    

    internal class DoctorMenu : IManageMenu
    {
        public void PrintMenu()
        {
            Console.WriteLine("========= Manage Doctors =========");
            Console.WriteLine("0. [Return menu]");
            Console.WriteLine("1. Add Doctors");
            Console.WriteLine("2. Update Doctors");
            Console.WriteLine("3. Delete Doctors");
            Console.WriteLine("4. Show All Doctors");
            Console.WriteLine("5. Search Doctors");
        }
        public string SelectMenu()
        {
            Console.Write("Please enter your choice: ");
            string choice = Console.ReadLine();
            string checkExit = "managedoctor";

            switch (choice)
            {
                case "0":
                    if (Confirm("return")) checkExit = "main";
                    break;
                case "1":
                    Console.Clear();
                    ManageDoctor.Instance.Add();
                    break;
                case "2":
                    Console.Clear();
                    ManageDoctor.Instance.Update();
                    break;
                case "3":
                    Console.Clear();
                    ManageDoctor.Instance.Delete();
                    break;
                case "4":
                    Console.Clear();
                    ManageDoctor.Instance.DisplayInfor();
                    break;
                case "5":
                    Console.Clear();
                    ManageDoctor.Instance.Search();
                    break;
                default:
                    Console.WriteLine("Input must be from 0 to 5!");
                    Console.WriteLine("[Press any key to enter again!]");
                    Console.ReadLine();
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
