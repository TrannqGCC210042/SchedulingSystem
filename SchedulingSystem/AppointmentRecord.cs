using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal class AppointmentRecord : IObserver
    {
        private DateTime appointmentDate;
        private static int nextId = 1;
        public int Id { get { return nextId; } private set { } }
        public Doctor DoctorId { get; set; }
        public Patient PatientId { get; set; }
        public DateTime AppointmentDate {
            get { return appointmentDate; }
            set
            {
                if (!IsValidDate(value))
                {
                    throw new ArgumentException("Invalid birth date!");
                }
                appointmentDate = value;
            }
        }
        public bool IsAppointment { get; set; }
        public AppointmentRecord() { }
        public AppointmentRecord(AppointmentRecord appointmentRecord)
        {
            Id = nextId++;
            DoctorId = appointmentRecord.DoctorId;
            PatientId = appointmentRecord.PatientId;
            AppointmentDate = appointmentRecord.AppointmentDate;
            IsAppointment = appointmentRecord.IsAppointment;
        }

        public void update(AppointmentRecord appointmentRecord)
        {
            Console.WriteLine($"Computer ID {appointmentRecord.Id} was deleted!");
        }

        private bool IsValidDate(DateTime date)
        {
            // Assuming you want to ensure the date is within a certain reasonable range
            DateTime minDate = new DateTime(1900, 1, 1);
            DateTime maxDate = DateTime.Now;

            return date >= minDate && date <= maxDate;
        }
    }
}
