using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal class ManageDoctor
    {
        private List<Doctor> lstDoctors;
        public IReadOnlyCollection<Doctor> LstDoctors { get { return lstDoctors.AsReadOnly(); } }
        public ManageDoctor()
        {
            if (lstDoctors == null) lstDoctors = new List<Doctor>();
        }


        public void Delete()
        {
            Doctor d = FindDoctorId();
            if (d == null)
                Console.WriteLine("Cannot find this Doctor ID!");
            else
            {
                if (Confirm("sure"))
                {
                    lstDoctors.Remove(d);
                    Console.WriteLine($"Doctor ID {d.Id} was deleted successfully!");
                }
            }
            StopScreen();
        }

        public void Update()
        {
            Doctor d = FindDoctorId();
            if (d == null)
                Console.WriteLine("Cannot find this Doctor ID!");
            else
            {
                Console.WriteLine("========= Update Information =========");
                Doctor newDoctor = (Doctor)InputInformation();

                d.Name = newDoctor.Name;
                d.Phone = newDoctor.Phone;
                d.Address = newDoctor.Address;

                Console.WriteLine($"Doctor ID {newDoctor.Id} was updated!");

            }
            StopScreen();
        }
        public Doctor FindDoctorId()
        {
            if (lstDoctors.Count == 0)
            {
                Console.WriteLine("List Doctor is Empty!");
                return null;
            }
            Console.Write("Choose Doctor ID: ");
            int id = int.Parse(Console.ReadLine());

            Doctor doctor = null;
            foreach (var d in LstDoctors)
            {
                if (d.Id == id)
                {
                    Console.WriteLine($"========= Result: Doctor ID {d.Id} =========");
                    Console.WriteLine($"Doctors ID: {d.Id}");
                    Console.WriteLine($"Doctors Name: {d.Name}");
                    Console.WriteLine($"Phone Number: {d.Phone}");
                    Console.WriteLine($"Address: {d.Address}");
                    Console.WriteLine();
                    doctor = d;
                    break;
                }
            }
            return doctor;
        }

        private static void StopScreen()
        {
            Console.WriteLine("[Press any key to return the menu.]");
            Console.ReadKey();
            Console.Clear();
        }

        public void Add()
        {
            bool checkContinue;
            do
            {
                Console.WriteLine();
                Console.WriteLine("========= Doctor Information =========");
                Doctor doctor = (Doctor)InputInformation();
                lstDoctors.Add(doctor);
                Console.WriteLine("Added successfully!");
                Console.WriteLine($"Doctor ID was added: {doctor.Id}");

                Console.WriteLine();
                Console.WriteLine("Do you want to continue adding a Doctor?");
                checkContinue = Confirm("continue");
            } while (checkContinue);
        }
        public void ShowAll()
        {
            if (lstDoctors.Count == 0)
            {
                Console.WriteLine("List Doctor is Empty!");
            }
            else
            {
                Console.WriteLine("========= All Doctors =========");
                foreach (var doctor in lstDoctors)
                {
                    Console.WriteLine($"Doctors ID: {doctor.Id}");
                    Console.WriteLine($"Doctors Name: {doctor.Name}");
                    Console.WriteLine($"Phone Number: {doctor.Phone}");
                    Console.WriteLine($"Address: {doctor.Address}");
                    Console.WriteLine();
                }
            }

            StopScreen();
        }

        public void Search()
        {
            FindDoctorId();
            StopScreen();
        }

        public Object InputInformation()
        {
            Console.Write("Doctor Name: ");
            string name = Console.ReadLine();
            Console.Write("Doctor Phone: ");
            string phone = Console.ReadLine();
            Console.Write("Doctor Address: ");
            string address = Console.ReadLine();

            return new Doctor(name, phone, address);
        }

        public bool Confirm(string message)
        {
            bool checkContinue = false;
            string isExit = "";
            while (!isExit.Equals("y") || !isExit.Equals("y"))
            {
                Console.Write($"Are you sure to {message}? [y/n]: ");
                isExit = Console.ReadLine();

                if (isExit.Equals("y"))
                {
                    checkContinue = true;
                    break;
                }
                else if (isExit.Equals("n"))
                {
                    break;
                }
                else
                    Console.WriteLine("Input must be \"y\" or \"n\".");
            }

            Console.Clear();
            return checkContinue;
        }
    }
}
