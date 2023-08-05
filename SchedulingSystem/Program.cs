using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ManageDoctor manageDoctor = new ManageDoctor();
            //ManagePatient managePatient = new ManagePatient();
            //ManageAppointmentRecord manageAppointment = new ManageAppointmentRecord();
            //ManageMedicalSpecialty manageMedical = new ManageMedicalSpecialty();

            //MainMenu m = new MainMenu(manageDoctor, managePatient, manageAppointment, manageMedical);
            MainMenu m = new MainMenu();
            m.PrintMenu();
            Console.ReadLine();
        }
    }
}
