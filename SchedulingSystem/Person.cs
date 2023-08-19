using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal class Person : IObserver
    {
        private string name;
        private string phone;
        private string address;
        private List<string> lstAppointment { get; set; }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty or whitespace!");
                }
                if (!IsValidName(value))
                {
                    throw new ArgumentException("Name should contain only letters!");
                }
                name = value;
            }
        }
        public string Phone
        {
            get { return phone; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Address cannot be empty or whitespace!");
                }
                if (!IsValidPhoneNumber(value))
                {
                    throw new ArgumentException("Invalid phone number format.");
                }
                if (value.Length != 10)
                    throw new ArgumentException("Phone number must be 10 digits!");
                phone = value;
            }
        }
        public string Address
        {
            get { return address; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Address cannot be empty or whitespace!");
                }
                address = value;
            }
        }
        public List<string> LstAppointment
        {
            get { return lstAppointment; }
            set { lstAppointment = value; }
        }

        public Person() { }
        public Person(string name, string phone, string address, List<string> lstAppointment)
        {
            Name = name;
            Phone = phone;
            Address = address;
            LstAppointment = lstAppointment;
        }

        private bool IsValidName(string name)
        {
            // Using regular expression to check if the name contains only letters and spaces
            return Regex.IsMatch(name, @"^[a-zA-Z\s]+$");
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Using regular expression to check if the phone number matches a basic pattern
            return Regex.IsMatch(phoneNumber, @"^\d{10}$");
        }

        public void Update(string message)
        {
            Console.WriteLine($"{this.name} has been notified: {message}");
        }
    }
}
