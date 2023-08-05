using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal class MedicalSpecialtieMenu : IManageMenu
    {
        ManageMedicalSpecialty manageMedicalSpecialtie { get; set; }
        public MedicalSpecialtieMenu(ManageMedicalSpecialty manageMedicalSpecialtie) {
            this.manageMedicalSpecialtie = manageMedicalSpecialtie;
        }
        public void PrintMenu()
        {
            bool isExit;
            do
            {
                Console.WriteLine("========= Manage Medical Specialties =========");
                Console.WriteLine("0. [Return menu]");
                Console.WriteLine("1. Add Medical Specialties");
                Console.WriteLine("2. Update Medical Specialties");
                Console.WriteLine("3. Delete Medical Specialties");
                Console.WriteLine("4. Show All Medical Specialties");
                Console.WriteLine("5. Search Medical Specialties");
                Console.WriteLine("[Press any key to exit the program]");
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
                    if (Confirm("return"))
                        checkExit = true;
                    break;
                case 1:
                    Console.Clear();
                    manageMedicalSpecialtie.Add();
                    break;
                case 2:
                    Console.Clear();
                    manageMedicalSpecialtie.Update();
                    break;
                case 3:
                    Console.Clear();
                    manageMedicalSpecialtie.Delete();
                    break;
                case 4:
                    Console.Clear();
                    manageMedicalSpecialtie.ShowAll();
                    break;
                case 5:
                    Console.Clear();
                    manageMedicalSpecialtie.Search();
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
