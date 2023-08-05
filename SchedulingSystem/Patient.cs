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
        public int Id { get { return nextId; } private set { } }

        public Patient() { }
        public Patient(string name, string phone, string address): base(name, phone, address) {
            Id = nextId++;
        }
    }
}
