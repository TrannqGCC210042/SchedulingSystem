﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal class ManageDoctor : IManagement
    {
        private List<Doctor> lstDoctors;
        private static ManageDoctor instance;
        private static readonly object lockObj = new object();
        public static ManageDoctor Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        if (instance == null)
                            instance = new ManageDoctor();
                    }
                }
                return instance;
            }
        }
        public IReadOnlyCollection<Doctor> LstDoctors { get { return lstDoctors.AsReadOnly(); } }
        public ManageDoctor()
        {
            if (lstDoctors == null) lstDoctors = new List<Doctor>();
        }

        public void DisplayInfor(Doctor doctor)
        {
            Console.WriteLine($"Result: ");
            Console.WriteLine($"Doctors ID: {doctor.Id}");
            Console.WriteLine($"Doctors Name: {doctor.Name}");
            Console.WriteLine($"Phone Number: {doctor.Phone}");
            Console.WriteLine($"Address: {doctor.Address}");
            Console.WriteLine();
        }

        public void Delete()
        {
            Console.WriteLine();
            Console.WriteLine("========= Delete Doctor =========");
            if (!IsEmpty())
            {
                Doctor d = FindDoctorId();
                if (d != null)
                {
                    DisplayInfor(d);
                    if (Confirm("sure"))
                    {
                        lstDoctors.Remove(d);
                        Console.WriteLine($"Doctor ID {d.Id} was deleted successfully!");
                    }
                }
            }
            StopScreen();
        }

        public void Update()
        {
            Console.WriteLine("========= Update Doctor =========");
            if (!IsEmpty())
            {
                Doctor d = FindDoctorId();
                if (d != null)
                {
                    DisplayInfor(d);
                    Console.WriteLine("========= Update Information =========");
                    Console.Write("Doctor Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Doctor Phone: ");
                    string phone = Console.ReadLine();
                    Console.Write("Doctor Address: ");
                    string address = Console.ReadLine();

                    d.Name = name;
                    d.Phone = phone;
                    d.Address = address;

                    Console.WriteLine($"Doctor ID {d.Id} was updated!");
                }
            }
            StopScreen();
        }

        public Object InputInformation()
        {
            Doctor doctor = new Doctor();
        Name:
            try
            {
                Console.Write("Doctor Name: ");
                doctor.Name = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto Name;
            }

        Phone:
            try
            {
                Console.Write("Doctor Phone: ");
                doctor.Phone = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto Phone;
            }

        Address:
            try
            {
                Console.Write("Doctor Address: ");
                doctor.Address = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto Address;
            }

            return new Doctor(doctor);
        }
        public Doctor FindDoctorId()
        {
            Id:
            try
            {
                Console.WriteLine("[Press \"0\" to return to the menu.]");
                Console.Write("Choose Doctor ID: ");
                string id = Console.ReadLine();
                if (id == "0") return null;
                foreach (var d in LstDoctors)
                {
                    if (d.Id == int.Parse(id))
                    {                        
                        Console.WriteLine($"A result was found!");
                        Console.Clear();
                        return d;
                    }
                }
                Console.WriteLine("Doctor ID cannot exist in the system.\n");
                return FindDoctorId();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n");
                goto Id;
            }            
        }

        public bool IsEmpty()
        {
            if (lstDoctors.Count == 0)
            {
                Console.WriteLine("List Doctor is Empty!");
                return true;
            }
            return false;
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
            StopScreen();
        }

        public void DisplayInfor()
        {
            if (!IsEmpty())
            {
                Console.WriteLine("========= All Doctors =========");
                foreach (var doctor in LstDoctors)
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
            Console.WriteLine();
            Console.WriteLine("========= Search Doctor =========");
            Doctor d = FindDoctorId();
            if (d != null) DisplayInfor(d);
            StopScreen();
        }

        public bool Confirm(string message)
        {
            Console.Write($"Are you sure to {message}? [y/n]: ");
            string isExit = Console.ReadLine();
            if (isExit.Equals("y") || isExit.Equals("n"))
            {
                return isExit.Equals("y") ? true : false;
            }
            Console.WriteLine("Input must be \"y\" or \"n\".");
            return Confirm(message);
        }
    }
}
