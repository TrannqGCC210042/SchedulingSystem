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
        
        public Doctor() {
            Id = ++nextId;
        }
        public Doctor(string name, string phone, string address, List<string> lstAppointment) : base(name, phone, address, lstAppointment)
        {
            Id = ++nextId;
        }
    }
}
