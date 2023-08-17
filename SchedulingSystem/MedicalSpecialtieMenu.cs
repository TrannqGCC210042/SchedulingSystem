using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal class MedicalSpecialtieMenu : IManageMenu
    {        
        public void PrintMenu()
        {
            Console.WriteLine("========= Manage Medical Specialty =========");
            Console.WriteLine("0. [Return menu]");
            Console.WriteLine("1. Add Medical Specialty");
            Console.WriteLine("2. Update Medical Specialty");
            Console.WriteLine("3. Delete Medical Specialty");
            Console.WriteLine("4. Show All Medical Specialties");
            Console.WriteLine("5. Search Medical Specialty");
        }
        public string SelectMenu()
        {
            Console.Write("Please enter your choice: ");
            string choice = Console.ReadLine();
            string checkExit = "managemedical";
            switch (choice)
            {
                case "0":
                    if (Confirm("return")) checkExit = "main";
                    break;
                case "1":
                    Console.Clear();
                    ManageMedicalSpecialty.Instance.Add();
                    break;
                case "2":
                    Console.Clear();
                    ManageMedicalSpecialty.Instance.Update();
                    break;
                case "3":
                    Console.Clear();
                    ManageMedicalSpecialty.Instance.Delete();
                    break;
                case "4":
                    Console.Clear();
                    ManageMedicalSpecialty.Instance.DisplayInfor();
                    break;
                case "5":
                    Console.Clear();
                    ManageMedicalSpecialty.Instance.Search();
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
