using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal class ManagePatient
    {
        private static List<Patient> lstPatients;
        public IReadOnlyCollection<Patient> ListPatients { get { return lstPatients.AsReadOnly(); } }
        public ManagePatient() { if (lstPatients == null) lstPatients = new List<Patient>(); }

        public void Delete()
        {
            Patient p = FindPatientId();
            if (p == null)
                Console.WriteLine("Cannot find this Patient ID!");
            else
            {
                if (Confirm("sure"))
                {
                    lstPatients.Remove(p);
                    Console.WriteLine($"Patient ID {p.Id} was deleted successfully!");
                }
            }
            StopScreen();
        }

        public void Update()
        {
            Patient p = FindPatientId();
            if (p == null)
                Console.WriteLine("Cannot find this Patient ID!");
            else
            {
                Console.WriteLine("========= Update Information =========");
                Patient newPatient = (Patient)InputInformation();

                p.Name = newPatient.Name;
                p.Phone = newPatient.Phone;
                p.Address = newPatient.Address;

                Console.WriteLine($"Patient ID {newPatient.Id} was updated!");

            }
            StopScreen();
        }
        public Patient FindPatientId()
        {
            Patient patient = null;
            if (lstPatients.Count == 0)
            {
                Console.WriteLine("List Patient is Empty!");
            }
            else
            {
                Console.Write("Choose Patient ID: ");
                int id = int.Parse(Console.ReadLine());

                foreach (var p in lstPatients)
                {
                    if (p.Id == id)
                    {
                        Console.WriteLine($"========= Result: Patient ID {p.Id} =========");
                        Console.WriteLine($"Patient ID: {p.Id}");
                        Console.WriteLine($"Patient Name: {p.Name}");
                        Console.WriteLine($"Phone Number: {p.Phone}");
                        Console.WriteLine($"Address: {p.Address}");
                        Console.WriteLine();
                        patient = p;
                        break;
                    }
                }
            }
            return patient;
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
                Console.WriteLine("========= Patient Information =========");
                Patient patient = (Patient)InputInformation();
                lstPatients.Add(patient);
                Console.WriteLine("Added successfully!");
                Console.WriteLine($"Patient ID was added: {patient.Id}");

                Console.WriteLine();
                Console.WriteLine("Do you want to continue adding a Patient?");
                checkContinue = Confirm("continue");
            } while (checkContinue);
        }
        public void ShowAll()
        {
            if (lstPatients.Count == 0)
            {
                Console.WriteLine("List Patient is Empty!");

            }
            else
            {
                Console.WriteLine("========= All Patient =========");
                foreach (var patient in lstPatients)
                {
                    Console.WriteLine($"Patient ID: {patient.Id}");
                    Console.WriteLine($"Patient Name: {patient.Name}");
                    Console.WriteLine($"Phone Number: {patient.Phone}");
                    Console.WriteLine($"Address: {patient.Address}");
                    Console.WriteLine();
                }
            }

            StopScreen();
        }

        public void Search()
        {
            FindPatientId();
            StopScreen();
        }

        public Object InputInformation()
        {
            Console.Write("Patient Name: ");
            string name = Console.ReadLine();
            Console.Write("Patient Phone: ");
            string phone = Console.ReadLine();
            Console.Write("Patient Address: ");
            string address = Console.ReadLine();

            return new Patient(name, phone, address);
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
