using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal class AppointmentRecord : ISubject
    {
        private Doctor doctor;
        private Patient patient;
        private DateTime appointmentDate;
        private static int nextId = 1;
        private List<IObserver> observers = new List<IObserver>();

        public int Id { get { return nextId; } private set { } }
        public Doctor Doctor { 
            get { return doctor; }
            set { doctor = value; }
        }
        public Patient Patient 
        { 
            get { return patient; }
            set { patient = value; }
        }
        public DateTime AppointmentDate
        {
            get { return appointmentDate; }
            set
            {
                if (value < DateTime.Now)
                {
                    throw new ArgumentException("Cannot enter a day later than today.");
                }
                appointmentDate = value;
            }
        }
        public bool IsAppointment { get; set; }
        public AppointmentRecord() { }
        public AppointmentRecord(AppointmentRecord appointmentRecord)
        {
            Id = nextId++;
            Doctor = appointmentRecord.Doctor;
            Patient = appointmentRecord.Patient;
            AppointmentDate = appointmentRecord.AppointmentDate;
            IsAppointment = appointmentRecord.IsAppointment;
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyRelevant(string message)
        {
            foreach (var observer in observers)
            {
                observer.Update(message);
            }
        }
    }
}
