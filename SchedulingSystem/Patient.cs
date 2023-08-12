using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal class Patient : Person
    {
        private static int nextId = 0;
        public int Id { get; private set; }

        public Patient() { }
        public Patient(Patient patient) {
            Id = ++nextId;
            Name = patient.Name;
            Phone = patient.Phone;
            Address = patient.Address;
        }
    }
}
