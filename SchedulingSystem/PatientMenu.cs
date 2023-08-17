using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal class PatientMenu : IManageMenu
    {
        public void PrintMenu()
        {
            Console.WriteLine("========= Manage Patients =========");
            Console.WriteLine("0. [Return menu]");
            Console.WriteLine("1. Add Patients");
            Console.WriteLine("2. Update Patients");
            Console.WriteLine("3. Delete Patients");
            Console.WriteLine("4. Show All Patients");
            Console.WriteLine("5. Search Patients");
        }
        public string SelectMenu()
        {
            Console.Write("Please enter your choice: ");
            string choice = Console.ReadLine();
            string checkExit = "managepatient";

            switch (choice)
            {
                case "0":
                    if (Confirm("return")) checkExit = "main";
                    break;
                case "1":
                    Console.Clear();
                    ManagePatient.Instance.Add();
                    break;
                case "2":
                    Console.Clear();
                    ManagePatient.Instance.Update();
                    break;
                case "3":
                    Console.Clear();
                    ManagePatient.Instance.Delete();
                    break;
                case "4":
                    Console.Clear();
                    ManagePatient.Instance.DisplayInfor();
                    break;
                case "5":
                    Console.Clear();
                    ManagePatient.Instance.Search();
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
            Console.Write($"Are you sure to {message}? [y/n]: ");
            string isExit = Console.ReadLine();
            if (isExit.Equals("y") || isExit.Equals("n"))
            {
                return isExit.Equals("y") ? true : false;
            }
            Console.WriteLine("Input must be \"y\" or \"n\".");
            return Confirm(message);
        }
    }
}
