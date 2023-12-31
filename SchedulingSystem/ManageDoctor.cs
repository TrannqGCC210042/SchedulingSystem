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

        public List<Doctor> LstDoctors
        {
            get { return lstDoctors; }
            set { lstDoctors = value; }
        }
        public IReadOnlyCollection<Doctor> LstDoctor { get { return lstDoctors.AsReadOnly(); } }
        private ManageDoctor()
        {
            if (lstDoctors == null) lstDoctors = new List<Doctor>();
        }

        public void UpdateAppointment(string message, Doctor doctor)    
        {
            doctor.LstAppointment.Add(message);
        }

        public void DisplayInfor(Doctor doctor)
        {
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
                    if (Confirm($"delete Doctor ID {d.Id}"))
                    {
                        ManageAppointmentRecord.Instance.Delete(d);
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
                    Console.WriteLine("\nEnter changes:");
                    Doctor newDoctor = (Doctor)InputInformation();

                    d.Name = newDoctor.Name;
                    d.Phone = newDoctor.Phone;
                    d.Address = newDoctor.Address;

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
            catch (Exception)
            {
                Console.WriteLine("Phone number must be 10 digits.");
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

            return doctor;
        }
        public Doctor FindDoctorId()
        {
        Id:
            try
            {
                Console.WriteLine("[Press \"0\" to return to cancel.]");
                Console.Write("Choose Doctor ID: ");
                string id = Console.ReadLine();

                if (id == "0")
                    return null;

                foreach (var d in lstDoctors)
                    if (d.Id == int.Parse(id))
                        return d;

                Console.WriteLine("Doctor ID cannot exist in the system.\n");
                return FindDoctorId();
            }
            catch (Exception)
            {
                Console.WriteLine("Doctor ID must be a number.\n");
                goto Id;
            }
        }

        public bool IsEmpty()
        {
            if (lstDoctors.Count == 0)
            {
                Console.WriteLine("Notification: List Doctor is Empty!");
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
            Console.WriteLine("========= Doctor Information =========");
            Doctor doctor = (Doctor)InputInformation();
            doctor.LstAppointment = new List<string>
            {
                $"Created at {DateTime.Now}"
            };
            lstDoctors.Add(new Doctor(doctor.Name, doctor.Phone, doctor.Address, doctor.LstAppointment));
            Console.WriteLine("Added successfully!");
            Console.WriteLine($"Your Doctor ID has been provided: " +
                $"{lstDoctors[lstDoctors.Count - 1].Id}\n");
            if (Confirm("continue adding a Doctor"))
            {
                Console.WriteLine();
                Add();
            }
        }

        public void DisplayInfor()
        {
            /*Doctor d = new Doctor
            {
                Name = "Tran",
                Phone = "0987654321",
                Address = "Can Tho",
                LstAppointment = new List<string>
                {
                    $"Created at {DateTime.Now}"
                }
            };
            lstDoctors.Add(d);

            Doctor d1 = new Doctor
            {
                Name = "Duy",
                Phone = "0987654123",
                Address = "Can Tho",
                LstAppointment = new List<string>
                {
                    $"Created at {DateTime.Now}"
                }
            };
            lstDoctors.Add(d1);*/

            if (!IsEmpty())
            {
                Console.WriteLine("========= All Doctors =========");
                foreach (var doctor in lstDoctors)
                {
                    Console.WriteLine($"Doctors ID: {doctor.Id}");
                    Console.WriteLine($"Doctors Name: {doctor.Name}");
                    Console.WriteLine($"Phone Number: {doctor.Phone}");
                    Console.WriteLine($"Address: {doctor.Address}");
                    Console.WriteLine($"Appointment status:");
                    foreach (var notification in doctor.LstAppointment)
                    {
                        Console.WriteLine($"[{notification}]");
                    }
                    Console.WriteLine();
                }
            }

            StopScreen();
        }

        public void Search()
        {
            if (!IsEmpty())
            {
                Console.WriteLine("========= Search Doctor =========");
                Doctor d = FindDoctorId();
                if (d != null) DisplayInfor(d);
            }
            StopScreen();
        }

        public bool Confirm(string message)
        {
            Console.Write($"Are you sure to {message}? [y/n]: ");
            string isExit = Console.ReadLine();
            if (isExit.Equals("y") || isExit.Equals("n"))
            {
                return isExit.Equals("y");
            }
            Console.WriteLine("Input must be \"y\" or \"n\".");
            return Confirm(message);
        }
    }
}
