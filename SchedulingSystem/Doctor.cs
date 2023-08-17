using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal class Doctor : Person, IObserver
    {
        private static int nextId = 0;
        public int Id { get; private set; }
        public Doctor() { }
        public Doctor(Doctor doctor)
        {
            Id = ++nextId;  
            Name = doctor.Name;
            Phone = doctor.Phone;
            Address = doctor.Address;
        }
    }
}
