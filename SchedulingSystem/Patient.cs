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

        public Patient()
        {
            Id = ++nextId;
        }
        public Patient(string name, string phone, string address, List<string> lstAppointment) : base(name, phone, address, lstAppointment)
        {
            Id = ++nextId;
        }
    }
}
