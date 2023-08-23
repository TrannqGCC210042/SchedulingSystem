using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal class MainMenu : IManageMenu
    {
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

        public bool Confirm(string message)
        {
            Console.Write($"Are you sure to {message}? [y/n]: ");
            string isExit = Console.ReadLine();
            if (isExit.Equals("y") || isExit.Equals("n"))
            {
                return isExit.Equals("y");
            }
            Console.WriteLine("Input must be \"y\" or \"n\".");
            return Confirm(message);
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
    }
}
