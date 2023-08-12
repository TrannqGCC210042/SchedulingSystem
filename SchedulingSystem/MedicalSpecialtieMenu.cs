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
            Console.WriteLine("========= Manage Medical Specialties =========");
            Console.WriteLine("0. [Return menu]");
            Console.WriteLine("1. Add Medical Specialties");
            Console.WriteLine("2. Update Medical Specialties");
            Console.WriteLine("3. Delete Medical Specialties");
            Console.WriteLine("4. Show All Medical Specialties");
            Console.WriteLine("5. Search Medical Specialties");
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
