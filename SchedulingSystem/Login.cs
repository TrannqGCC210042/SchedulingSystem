using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal class Login
    {
        public Login() { }
        public void InputUsernamePassword()
        {
            bool checkAccount = false;
            while (checkAccount)
            {
                Console.Write("Username: ");
                string username = Console.ReadLine();
                Console.Write("Password");
                string password = Console.ReadLine();
                checkAccount = CheckAccount(username, password);
            }
        }
        private bool CheckAccount(string username, string password)
        {
            if (username == "admin" && password == "1")
            {
                ManageDoctor manageDoctor = new ManageDoctor();
                ManagePatient managePatient = new ManagePatient();
                ManageAppointmentRecord manageAppointment = new ManageAppointmentRecord();
                ManageMedicalSpecialty manageMedical = new ManageMedicalSpecialty();

                MainMenu m = new MainMenu(manageDoctor, managePatient, manageAppointment, manageMedical);
                m.PrintMenu();
            }       

            return true;
        }
    }
}
