using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal class Doctor : Person, ISubject
    {
        private static int nextId = 0;
        public int Id { get; private set; }
        private List<IObserver> observers = new List<IObserver>();
        public Doctor() { }
        public Doctor(Doctor doctor)
        {
            Id = ++nextId;
            Name = doctor.Name;
            Phone = doctor.Phone;
            Address = doctor.Address;
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyRelevant(ISubject subject)
        {
            Doctor deleteDoctor = subject as Doctor;
            foreach (IObserver observer in deleteDoctor.observers)
            {
                if (observer is AppointmentRecord doctor)
                {
                    if (deleteDoctor.Id == doctor.Id)
                    {
                        observer.update(doctor);
                        //ManageAppointmentRecord.Instance.lstAppointmentRecords.Remove(doctor);
                    }
                }
            }
        }
    }
}
