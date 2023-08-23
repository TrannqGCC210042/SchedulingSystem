using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal class ManagePatient : IManagement
    {
        private List<Patient> lstPatients;
        private static ManagePatient instance;
        private static readonly object lockObj = new object();
        public static ManagePatient Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        if (instance == null)
                            instance = new ManagePatient();
                    }
                }
                return instance;
            }
        }
        public List<Patient> LstPatients
        {
            get { return lstPatients; }
            set { lstPatients = value; }
        }
        //public IReadOnlyCollection<Patient> ListPatients => lstPatients.AsReadOnly();
        private ManagePatient()
        {
            if (lstPatients == null) lstPatients = new List<Patient>();
        }
        public void UpdateAppointment(string message, Patient patient)
        {
            patient.LstAppointment.Add(message);
        }
        public void Delete()
        {
            if (!IsEmpty())
            {
                Patient p = FindPatientId();
                if (p != null)
                {
                    DisplayInfor(p);
                    if (Confirm($"delete Patient ID {p.Id}"))
                    {
                        ManageAppointmentRecord.Instance.Delete(p);
                        lstPatients.Remove(p);
                        Console.WriteLine($"Patient ID {p.Id} was deleted successfully!");
                        Delete();
                    }
                }
            }
            StopScreen();
        }

        public void Update()
        {
            Console.WriteLine("========= Update Patient =========");
            if (!IsEmpty())
            {
                Patient p = FindPatientId();
                if (p != null)
                {
                    DisplayInfor(p);
                    Console.WriteLine("\nEnter changes:");
                    Patient newPatient = (Patient)InputInformation();

                    p.Name = newPatient.Name;
                    p.Phone = newPatient.Phone;
                    p.Address = newPatient.Address;

                    Console.WriteLine($"Patient ID {p.Id} was updated!");
                }
            }
            StopScreen();
        }
        public Patient FindPatientId()
        {
        Id:
            try
            {
                Console.WriteLine("[Press \"0\" to cancel.]");
                Console.Write("Choose Patient ID: ");
                int id = int.Parse(Console.ReadLine());

                if (id == 0)
                    return null;

                foreach (var p in lstPatients)
                    if (p.Id == id)
                        return p;

                Console.WriteLine("Cannot find this Patient ID!\n");
                return FindPatientId();
            }
            catch (Exception)
            {
                Console.WriteLine("Patient ID must be a number.\n");
                goto Id;
            }
        }

        private static void StopScreen()
        {
            Console.WriteLine("[Press any key to return the menu.]");
            Console.ReadKey();
            Console.Clear();
        }

        public void Add()
        {
            Console.WriteLine();
            Console.WriteLine("========= Patient Information =========");
            Patient patient = (Patient)InputInformation();
            patient.LstAppointment = new List<string>
            {
                $"Created at {DateTime.Now}"
            };
            lstPatients.Add(new Patient(patient.Name, patient.Phone, patient.Address, patient.LstAppointment));
            Console.WriteLine("Added successfully!");
            Console.WriteLine($"Your Patient ID has been provided: " +
                            $"{lstPatients[lstPatients.Count - 1].Id}\n");
            if (Confirm("continue adding a Patient"))
            {
                Console.WriteLine();
                Add();
            }
        }
        public void DisplayInfor(Patient p)
        {
            Console.WriteLine($"Patient ID: {p.Id}");
            Console.WriteLine($"Patient Name: {p.Name}");
            Console.WriteLine($"Phone Number: {p.Phone}");
            Console.WriteLine($"Address: {p.Address}");
            Console.WriteLine();
        }
        public void DisplayInfor()
        {

            /*Patient p2 = new Patient
            {
                Name = "Minh Dat",
                Phone = "0987654321",
                Address = "Can Tho",
                LstAppointment = new List<string>
                {
                    $"Created at {DateTime.Now}"
                }
            };
            lstPatients.Add(p2);

            Patient p1 = new Patient
            {
                Name = "Duy Quang",
                Phone = "0987654123",
                Address = "Vinh Long",
                LstAppointment = new List<string>
                {
                    $"Created at {DateTime.Now}"
                }
            };
            lstPatients.Add(p1);*/

            if (!IsEmpty())
            {
                Console.WriteLine("========= All Patient =========");
                foreach (var patient in this.lstPatients)
                {
                    Console.WriteLine($"Patient ID: {patient.Id}");
                    Console.WriteLine($"Patient Name: {patient.Name}");
                    Console.WriteLine($"Phone Number: {patient.Phone}");
                    Console.WriteLine($"Address: {patient.Address}");
                    Console.WriteLine($"Appointment status:");
                    foreach (var notification in patient.LstAppointment)
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
                Console.WriteLine();
                Console.WriteLine("========= Search Doctor =========");
                Patient p = FindPatientId();
                if (p != null) DisplayInfor(p);
            }
            StopScreen();
        }

        public Object InputInformation()
        {
            Patient patient = new Patient();

        Name:
            try
            {
                Console.Write("Patient Name: ");
                patient.Name = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto Name;
            }

        Phone:
            try
            {
                Console.Write("Patient Phone: ");
                patient.Phone = Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Phone number must be 10 digits.");
                goto Phone;
            }

        Address:
            try
            {
                Console.Write("Patient Address: ");
                patient.Address = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto Address;
            }

            return patient;
        }
        public bool IsEmpty()
        {
            if (lstPatients.Count == 0)
            {
                Console.WriteLine("Notification: List Patient is Empty!");
                return true;
            }
            return false;
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
