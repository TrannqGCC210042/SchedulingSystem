using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal class AppointmentRecordMenu : IManageMenu
    {
        ManageAppointmentRecord manageAppointmentRecord { get; set; }
        public AppointmentRecordMenu(ManageAppointmentRecord manageAppointmentRecord) {
            this.manageAppointmentRecord = manageAppointmentRecord;
        }

        public void PrintMenu()
        {
            bool isExit;
            do
            {
                Console.WriteLine("========= Manage Appointment Records =========");
                Console.WriteLine("0. [Return menu]");
                Console.WriteLine("1. Add Appointment Records");
                Console.WriteLine("2. Update Appointment Records");
                Console.WriteLine("3. Delete Appointment Records");
                Console.WriteLine("4. Show All Appointment Records");
                Console.WriteLine("5. Search Appointment Records");
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
                    manageAppointmentRecord.Add();
                    break;
                case 2:
                    Console.Clear();
                    manageAppointmentRecord.Update();
                    break;
                case 3:
                    Console.Clear();
                    manageAppointmentRecord.Delete();
                    break;
                case 4:
                    Console.Clear();
                    manageAppointmentRecord.ShowAll();
                    break;
                case 5:
                    Console.Clear();
                    manageAppointmentRecord.Search();
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
