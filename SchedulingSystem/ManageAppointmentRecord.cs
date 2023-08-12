using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal class ManageAppointmentRecord : IManagement
    {
        private static List<AppointmentRecord> lstAppointmentRecords;
        public IReadOnlyCollection<AppointmentRecord> LstAppointmentRecords { get { return lstAppointmentRecords.AsReadOnly(); } }
        public ManageAppointmentRecord()
        {
            if (lstAppointmentRecords == null) lstAppointmentRecords = new List<AppointmentRecord>();
        }

        private static ManageAppointmentRecord instance;
        private static readonly object lockObj = new object();
        public static ManageAppointmentRecord Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        if (instance == null)
                            instance = new ManageAppointmentRecord();
                    }
                }
                return instance;
            }
        }
        public void Delete()
        {
            if (!IsEmpty())
            {
                AppointmentRecord a = FindAppointmentlId();
                if (a != null)
                {
                    DisplayInfor(a);
                    if (Confirm("sure"))
                    {
                        lstAppointmentRecords.Remove(a);
                        Console.WriteLine($"Appointment Record ID {a.Id} was deleted successfully!");
                    }
                }
            }
            StopScreen();
        }

        public void Update()
        {
            if (!IsEmpty())
            {
                AppointmentRecord a = FindAppointmentlId();
                if (a != null)
                {
                    DisplayInfor(a);
                    Console.WriteLine("========= Update Information =========");
                    AppointmentRecord newRecord = (AppointmentRecord)InputInformation();

                    a.DoctorId = newRecord.DoctorId;
                    a.PatientId = newRecord.PatientId;
                    a.AppointmentDate = newRecord.AppointmentDate;
                    a.IsAppointment = newRecord.IsAppointment;


                    Console.WriteLine($"Appointment Record ID {newRecord.Id} was updated!");
                }
            }
            StopScreen();
        }
        public AppointmentRecord FindAppointmentlId()
        {
            Console.WriteLine("[Press \"0\" to return to the menu.]");
            Console.Write("Choose Appointment Record ID: ");
            int id = int.Parse(Console.ReadLine());

            if (id == 0) return null;
            foreach (var a in LstAppointmentRecords)
            {
                if (a.Id == id)
                {
                    return a;
                }
            }
            Console.WriteLine("Appointment Record ID cannot exist in the system.\n");
            return FindAppointmentlId();
        }

        private static void StopScreen()
        {
            Console.WriteLine("[Press any key to return the menu.]");
            Console.ReadKey();
            Console.Clear();
        }

        public void Add()
        {
            if (!(ManageDoctor.Instance.IsEmpty() && ManagePatient.Instance.IsEmpty()))
            {
                Console.WriteLine();
                Console.WriteLine("========= Appointment Record Information =========");
                AppointmentRecord appointment = (AppointmentRecord)InputInformation();
                lstAppointmentRecords.Add(appointment);
                Console.WriteLine("Added successfully!");
                Console.WriteLine($"Appointment Record ID was added: {appointment.Id}");

                Console.WriteLine();
                Console.WriteLine("Do you want to continue adding a Appointment Record?");
                if (Confirm("continue")) Add();
            }
            StopScreen();
        }
        public bool IsEmpty()
        {
            if (lstAppointmentRecords.Count == 0)
            {
                Console.WriteLine("List Doctor is Empty!");
                return true;
            }
            return false;
        }

        public void Search()
        {
            FindAppointmentlId();
            StopScreen();
        }

        public Object InputInformation()
        {
            AppointmentRecord appointmentRecord = new AppointmentRecord();

        // User must choose a Doctor
        ChooseDoctor:
            Console.WriteLine("Choose Doctor by ID");
            appointmentRecord.DoctorId = ManageDoctor.Instance.FindDoctorId();
            if (appointmentRecord.DoctorId == null)
            {
                Console.Clear();
                goto ChooseDoctor;
            }
            Console.WriteLine($"Doctor {appointmentRecord.DoctorId.Id} has been selected.");
            Console.WriteLine("[next] >>");
            Console.ReadKey();
            Console.Clear();
        // User must choose a Patient
        ChoosePatient:
            Console.WriteLine("Choose Patient by ID");
            appointmentRecord.PatientId = ManagePatient.Instance.FindPatientId();
            if (appointmentRecord.PatientId == null)
            {
                Console.Clear();
                goto ChoosePatient;
            }
            Console.WriteLine($"Patient {appointmentRecord.PatientId.Id} has been selected.");
            Console.WriteLine("[next] >>");
            Console.ReadKey();
            Console.Clear();

        DateTime:
            try
            {
                Console.Write("Enter a date (dd-MM-yyyy): ");
                appointmentRecord.AppointmentDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine($"Date {appointmentRecord.AppointmentDate} has been selected.");
                Console.WriteLine("[next] >>");
                Console.ReadKey();
                Console.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
                Console.ReadKey();
                Console.Clear();
                goto DateTime;
            }

        Status:
            try
            {
                Console.WriteLine("Status: ");
                Console.WriteLine("0. Waiting ");
                Console.WriteLine("1. Confirmed ");
                Console.Write("Choose status [0 or 1]: ");
                int chooseStatus = int.Parse(Console.ReadLine());
                if (chooseStatus < 0 && chooseStatus > 1)
                {
                    Console.Clear() ;
                    goto Status;
                }
                Console.WriteLine("[finish] >>");
                if (chooseStatus == 1)
                {
                    appointmentRecord.IsAppointment = true;
                }
                else
                {
                    appointmentRecord.IsAppointment = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
                goto Status;
            }

            DisplayInfor(appointmentRecord);

            return appointmentRecord;
        }

        public void DisplayInfor(Patient patient)
        {
            Console.WriteLine($"Patient: {patient.Id} - {patient.Name}");
            Console.ReadKey();
            Console.Clear();
        }

        public void DisplayInfor(Doctor doctor)
        {
            Console.WriteLine($"Doctor: {doctor.Id} - {doctor.Name}");
            Console.ReadKey();
            Console.Clear();
        }

        public void DisplayInfor(AppointmentRecord a)
        {
            Console.WriteLine($"========= Appointment Record ID {a.Id} =========");
            Console.WriteLine($"Doctor ID: {a.DoctorId}");
            Console.WriteLine($"Patient Name: {a.PatientId}");
            Console.WriteLine($"Date: {a.AppointmentDate}");
            Console.WriteLine($"Status: {a.IsAppointment}");
            Console.WriteLine();
        }
        public void DisplayInfor()
        {
            if (!IsEmpty())
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
            }
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
