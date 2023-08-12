using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal class MenuFactory
    {
        public static IManageMenu CreateMenu(string menuType)
        {
            switch (menuType.ToLower())
            {
                case "main":
                    return new MainMenu();
                case "managedoctor":
                    return new DoctorMenu();
                case "managepatient":
                    return new PatientMenu();
                case "manageappointment":
                    return new AppointmentRecordMenu();
                case "managemedical":
                    return new MedicalSpecialtieMenu();
                default:
                    throw new ArgumentException("Invalid menu type.");
            }
        }
    }
}
