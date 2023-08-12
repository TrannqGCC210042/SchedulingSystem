using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal class MainMenu : IManageMenu
    {
        public MainMenu() { }
        public void PrintMenu()
        {
            Console.WriteLine("Appointment Booking System Menu");
            Console.WriteLine("===============================");
            Console.WriteLine("0. [Exit]");
            Console.WriteLine("1. Manage Doctors");
            Console.WriteLine("2. Manage Patients");
            Console.WriteLine("3. Manage Appointment Records");
            Console.WriteLine("4. Manage Medical Specialties");
        }

        public string SelectMenu()
        {
            Console.Write("Please enter your choice: ");
            string choice = Console.ReadLine();
            string checkExit = "main";
            switch (choice)
            {
                case "0":
                    if (Confirm("return")) Environment.Exit(0);
                    break;
                case "1":
                    return "managedoctor";
                case "2":
                    return "managepatient";
                case "3":
                    return "manageappointment";
                case "4":
                    return "managemedical";
                default:
                    Console.WriteLine("Input must be from 0 to 4!");
                    Console.WriteLine("[Press any key input again.]");
                    Console.ReadKey();
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
