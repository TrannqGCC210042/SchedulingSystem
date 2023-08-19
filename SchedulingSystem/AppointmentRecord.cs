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
        public int Id { get; private set; }
        private Doctor doctor;
        private Patient patient;
        private DateTime appointmentDate;
        private bool isAppointment;
        private static int nextId = 1;
        private List<IObserver> observers = new List<IObserver>();

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
        public bool IsAppointment
        {
            get { return isAppointment; }
            set { isAppointment = value; }
        }

        public AppointmentRecord()
        {
            Id = nextId++;
        }
        public AppointmentRecord(Doctor doctor, Patient patient, DateTime appointmentDate, bool isAppointment)
        {
            Id = nextId++;
            Doctor = doctor;
            Patient = patient;
            AppointmentDate = appointmentDate;
            IsAppointment = isAppointment;
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
