using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal class Doctor : Person
    {
        private static int nextId = 0;
        public int Id { get { return nextId; } private set { } }

        public Doctor() { }
        public Doctor(string name, string phone, string address) : base(name, phone, address)
        {
            Id = nextId++;
            }

    }
}
