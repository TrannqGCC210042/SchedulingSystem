using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal class MainMenu
    {
        //ManageDoctor manageDoctor { get; set; }
        //ManagePatient managePatient { get; set; }
        //ManageAppointmentRecord manageAppointment { get; set; }
        //ManageMedicalSpecialty manageMedical { get; set;    }
        //public MainMenu(ManageDoctor manageDoctor, 
        //                ManagePatient managePatient, 
        //                ManageAppointmentRecord manageAppointment, 
        //                ManageMedicalSpecialty manageMedical) 
        //{ 
        //    this.manageDoctor = manageDoctor;
        //    this.managePatient = managePatient;
        //    this.manageAppointment = manageAppointment;
        //    this.manageMedical = manageMedical;
        //}
        public MainMenu() { }
        public void PrintMenu()
        {
            try
            {
                bool isExit;
                do
                {
                    Console.WriteLine("========= Menu =========");
                    Console.WriteLine("0. [Exit]");
                    Console.WriteLine("1. Manage Doctors");
                    Console.WriteLine("2. Manage Patients");
                    Console.WriteLine("3. Manage Appointment Records");
                    Console.WriteLine("4. Manage Medical Specialties");
                    isExit = SelectMenu();
                }
                while (!isExit);
            }
            catch (FormatException ex) { Console.WriteLine(ex.Message); }
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
                    DoctorMenu doctorMenu = new DoctorMenu();
                    doctorMenu.PrintMenu();
                    break;
                case 2:
                    Console.Clear();
                    //PatientMenu patientMenu = new PatientMenu(managePatient);
                    //patientMenu.PrintMenu();
                    break;
                case 3:
                    Console.Clear();
                    //AppointmentRecordMenu appointmentMenu = new AppointmentRecordMenu(manageAppointment);
                    //appointmentMenu.PrintMenu();
                    break;
                case 4:
                    Console.Clear();
                    //MedicalSpecialtieMenu medicalMenu = new MedicalSpecialtieMenu(manageMedical);
                    //medicalMenu.PrintMenu();
                    break;
                default:
                    Console.WriteLine("Input must be from 0 to 4!");
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
