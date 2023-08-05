using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal class ManageAppointmentRecord
    {
        private static List<AppointmentRecord> lstAppointmentRecords;
        public IReadOnlyCollection<AppointmentRecord> LstAppointmentRecords { get { return lstAppointmentRecords.AsReadOnly(); } }

        private List<Doctor> lstDoctors;
        public IReadOnlyCollection<Doctor> LstDoctors { get { return lstDoctors.AsReadOnly(); } }

        private static List<Patient> lstPatients;
        public IReadOnlyCollection<Patient> ListPatients { get { return lstPatients.AsReadOnly(); } }

        public ManageAppointmentRecord() { 
            if (lstAppointmentRecords == null) lstAppointmentRecords = new List<AppointmentRecord>();
            if (lstDoctors == null) lstDoctors = new List<Doctor>();
            if (lstPatients == null) lstPatients = new List<Patient>();
        }

        public void Delete()
        {
            AppointmentRecord a = FindAppointmentlId();
            if (a == null)
                Console.WriteLine("Cannot find this Appointment Record ID!");
            else
            {
                if (Confirm("sure"))
                {
                    lstAppointmentRecords.Remove(a);
                    Console.WriteLine($"Appointment Record ID {a.Id} was deleted successfully!");
                }
            }
            StopScreen();
        }

        public void Update()
        {
            AppointmentRecord a = FindAppointmentlId();
            if (a == null)
                Console.WriteLine("Cannot find this Appointment Record ID!");
            else
            {
                Console.WriteLine("========= Update Information =========");
                AppointmentRecord newRecord = (AppointmentRecord)InputInformation();

                a.DoctorId = newRecord.DoctorId;
                a.PatientId = newRecord.PatientId;
                a.AppointmentDate = newRecord.AppointmentDate;
                a.IsAppointment = newRecord.IsAppointment;
                

                Console.WriteLine($"Appointment Record ID {newRecord.Id} was updated!");

            }
            StopScreen();
        }
        public AppointmentRecord FindAppointmentlId()
        {
            Console.Write("Choose Appointment Record ID: ");
            int id = int.Parse(Console.ReadLine());

            AppointmentRecord appointment = null;
            foreach (var a in LstAppointmentRecords)
            {
                if (a.Id == id)
                {
                    Console.WriteLine($"========= Result: Appointment Record ID {a.Id} =========");
                    Console.WriteLine($"Doctor ID: {a.DoctorId}");
                    Console.WriteLine($"Patient Name: {a.PatientId}");
                    Console.WriteLine($"Date: {a.AppointmentDate}");
                    Console.WriteLine($"Status: {a.IsAppointment}");
                    Console.WriteLine();
                    appointment = a;
                    break;
                }
            }
            return appointment;
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
                Console.WriteLine("========= Appointment Record Information =========");
                AppointmentRecord appointment = (AppointmentRecord)InputInformation();
                lstAppointmentRecords.Add(appointment);
                Console.WriteLine("Added successfully!");
                Console.WriteLine($"Appointment Record ID was added: {appointment.Id}");

                Console.WriteLine();
                Console.WriteLine("Do you want to continue adding a Appointment Record?");
                checkContinue = Confirm("continue");
            } while (checkContinue);
        }
        public void ShowAll()
        {
            Console.WriteLine("========= All Appointment Record =========");
            foreach (var a in LstAppointmentRecords)
            {
                Console.WriteLine($"Doctor ID: {a.DoctorId}");
                Console.WriteLine($"Patient Name: {a.PatientId}");
                Console.WriteLine($"Date: {a.AppointmentDate}");
                Console.WriteLine($"Status: {a.IsAppointment}");
                Console.WriteLine();
            }
            StopScreen();
        }

        public void Search()
        {
            FindAppointmentlId();
            StopScreen();
        }

        public Object InputInformation()
        {
            Doctor doctor = null;
            Patient patient = null;
            DateTime date = DateTime.Now;
            bool status = false;
            while (doctor == null && patient == null){
                ManageDoctor manageDoctor = new ManageDoctor();
                doctor = manageDoctor.FindDoctorId();

                ManagePatient managePatient = new ManagePatient();
                patient = managePatient.FindPatientId();

                Console.Write("Date [dd/mm/yyyy]: ");
                date = DateTime.Parse(Console.ReadLine());

                status = ChooseStatus();
            }
            return new AppointmentRecord(doctor, patient, date, status);
        }

        private bool ChooseStatus()
        {
            int chooseStatus;
            do
            {
                Console.WriteLine("Status: ");
                Console.WriteLine("0. Waiting ");
                Console.WriteLine("1. Confirmed ");
                Console.Write("Choose status [0 or 1]: ");
                chooseStatus = int.Parse(Console.ReadLine());
            } while (chooseStatus == 0 || chooseStatus == 1);

            if (chooseStatus == 0) return false; 
            else return true;            
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
