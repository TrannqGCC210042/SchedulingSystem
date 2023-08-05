using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal class AppointmentRecord
    {
        private static int nextId = 1;
        public int Id { get { return nextId; } private set { } }
        public Doctor DoctorId { get; set; }
        public Patient PatientId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public bool IsAppointment { get; set; }
        public AppointmentRecord() { }
        public AppointmentRecord(Doctor doctorID, Patient patientID, DateTime appointmentDate, bool isAppointment)
        {
            Id = nextId++;
            DoctorId = doctorID;
            PatientId = patientID;
            AppointmentDate = appointmentDate;
            IsAppointment = isAppointment;
        }
        
    }
}
