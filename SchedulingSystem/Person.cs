using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal class Person
    {
        private string name;
        private string phone;
        private string address;

        public string Name { get { return name; } set { name = value; } }
        public string Phone { 
            get { return phone; } 
            set {
                if (value.Length != 10)
                    throw new ArgumentException("Phone number must be 10 digits!");
                phone = value;
            } 
        }
        public string Address { get { return address; } set { address = value; } }
        public Person() { }
        public Person(string name, string phone, string address) { 
            Name = name;
            Phone = phone;
            Address = address;
        }
    }
}
