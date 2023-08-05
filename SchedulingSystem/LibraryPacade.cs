using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal class LibraryPacade
    {
        ManageDoctor manageDoctor { get; set; }
        ManagePatient managePatient { get; set; }
        ManageAppointmentRecord manageAppointment { get; set; }
        ManageMedicalSpecialty manageMedical { get; set; }
        LibraryPacade(ManageDoctor manageDoctor,
                        ManagePatient managePatient,
                        ManageAppointmentRecord manageAppointment,
                        ManageMedicalSpecialty manageMedical)
        {
            this.manageDoctor = manageDoctor;
            this.managePatient = managePatient;
            this.manageAppointment = manageAppointment;
            this.manageMedical = manageMedical;
        }
    }
}
