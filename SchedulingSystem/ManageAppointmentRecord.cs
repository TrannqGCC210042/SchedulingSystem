using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal class ManageAppointmentRecord : IManagement
    {
        enum AppointmentStatus
        {
            Waiting,
            Confirmed
        }
        private static List<AppointmentRecord> lstAppointmentRecords;
        public IReadOnlyCollection<AppointmentRecord> LstAppointmentRecords { get { return lstAppointmentRecords.AsReadOnly(); } }
        private ManageAppointmentRecord()
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
                AppointmentRecord appointment = FindAppointmentlId();
                if (appointment != null)
                {
                    DisplayInfor(appointment);
                    if (Confirm("cancel this Appointment Record"))
                    {
                        ManageDoctor.Instance.UpdateAppointment($"Removed in appointment ID {appointment.Id} - {DateTime.Now}", appointment.Doctor);
                        ManagePatient.Instance.UpdateAppointment($"Removed in appointment ID {appointment.Id} - {DateTime.Today}", appointment.Patient);

                        appointment.NotifyRelevant("Appointment was canceled.");

                        appointment.RemoveObserver(appointment.Doctor);
                        appointment.RemoveObserver(appointment.Patient);

                        lstAppointmentRecords.Remove(appointment);
                        Console.WriteLine($"Appointment Record ID {appointment.Id} was deleted in the system!");
                    }
                }
            }
            StopScreen();
        }
        public void Delete(Doctor doctor)
        {
            foreach (var a in LstAppointmentRecords)
            {
                if (a.Doctor == doctor)
                {
                    a.RemoveObserver(a.Doctor);
                    break;
                }
            }
        }

        public void Delete(Patient patient)
        {
            foreach (var a in LstAppointmentRecords)
            {
                if (a.Patient == patient)
                {
                    a.RemoveObserver(a.Patient);
                    break;
                }
            }
        }

        public void Update()
        {
            if (!IsEmpty())
            {
                AppointmentRecord findRecord = FindAppointmentlId();
                if (findRecord != null)
                {
                    DisplayInfor(findRecord);
                    Console.WriteLine("\nEnter changes:");
                    DateTime newAppoinmentDate;
                    bool changeIsAppointment;
                DateTime:
                    try
                    {
                        Console.Write("Enter a date (dd-MM-yyyy): ");
                        newAppoinmentDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine($"Date {newAppoinmentDate:dd-MM-yyyy} has been selected.");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine();
                        goto DateTime;
                    }

                    Console.WriteLine();

                Status:
                    try
                    {
                        Console.WriteLine("Status: ");
                        Console.WriteLine("0. Waiting ");
                        Console.WriteLine("1. Confirmed ");
                        Console.Write("Choose status [0 or 1]: ");
                        int chooseStatus = int.Parse(Console.ReadLine());

                        if (Enum.IsDefined(typeof(AppointmentStatus), chooseStatus))
                        {
                            changeIsAppointment = chooseStatus == 1;
                            Console.WriteLine($"Appointment status: {Enum.GetName(typeof(AppointmentStatus), chooseStatus)}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice. Please choose 0 or 1.\n");
                            goto Status;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"{e.Message}");
                        goto Status;
                    }
                    Console.WriteLine();

                    if (findRecord.AppointmentDate != newAppoinmentDate)
                    {
                        ManageDoctor.Instance.UpdateAppointment($"Datetime was changed from {findRecord.AppointmentDate} to {newAppoinmentDate}", findRecord.Doctor);
                        ManagePatient.Instance.UpdateAppointment($"Datetime was changed from {findRecord.AppointmentDate} to {newAppoinmentDate}", findRecord.Patient);
                        findRecord.AppointmentDate = newAppoinmentDate;
                    }

                    if (findRecord.IsAppointment != changeIsAppointment)
                    {
                        ManageDoctor.Instance.UpdateAppointment($"Status was changed from {findRecord.IsAppointment} to {changeIsAppointment}", findRecord.Doctor);
                        ManagePatient.Instance.UpdateAppointment($"Status was changed from {findRecord.IsAppointment} to {changeIsAppointment}", findRecord.Patient);
                        findRecord.IsAppointment = changeIsAppointment;
                    }

                    findRecord.NotifyRelevant("Appointment was updated");
                    Console.WriteLine($"Appointment Record ID {findRecord.Id} was updated!");
                }
            }
            StopScreen();
        }

        public AppointmentRecord FindAppointmentlId()
        {
            try
            {
                Console.WriteLine("[Press \"0\" to return to the menu.]");
                Console.Write("Choose Appointment Record ID: ");
                int id = int.Parse(Console.ReadLine());

                if (id == 0)
                    return null;

                foreach (var a in LstAppointmentRecords)
                    if (a.Id == id)
                        return a;

                Console.WriteLine($"The Appointment Record ID {id} does not exist in the system.\n");
                return FindAppointmentlId();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
                return FindAppointmentlId();
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
            if (!ManageDoctor.Instance.IsEmpty() && !ManagePatient.Instance.IsEmpty())
            {
            Add:
                Console.WriteLine("========= Appointment Record Information =========");
                AppointmentRecord appointment = (AppointmentRecord)InputInformation();
                if (appointment == null) return;
                lstAppointmentRecords.Add(appointment);

                ManageDoctor.Instance.UpdateAppointment($"Created in appointment ID {appointment.Id} - {DateTime.Now}", appointment.Doctor);
                ManagePatient.Instance.UpdateAppointment($"Created in appointment ID {appointment.Id} - {DateTime.Today}", appointment.Patient);

                appointment.RegisterObserver(appointment.Doctor);
                appointment.RegisterObserver(appointment.Patient);

                appointment.NotifyRelevant("Appointment was added");

                Console.WriteLine($"Appointment Record ID: {appointment.Id}");
                Console.WriteLine("Added successfully!");

                Console.WriteLine();
                Console.WriteLine("Do you want to continue adding a Appointment Record?");
                if (Confirm("continue"))
                {
                    Console.WriteLine();
                    goto Add;
                }
            }
            StopScreen();
        }
        public bool IsEmpty()
        {
            if (lstAppointmentRecords.Count == 0)
            {
                Console.WriteLine("Notification: List Appointment Record is empty!");
                return true;
            }
            return false;
        }

        public void Search()
        {
            if (!IsEmpty())
            {
                Console.WriteLine("========= Search Appointment Record =========");
                AppointmentRecord appointment = FindAppointmentlId();
                if (appointment != null)
                {
                    Console.WriteLine("\nA result was found!");
                    DisplayInfor(appointment);
                }
            }
            StopScreen();
        }

        public Object InputInformation()
        {
            AppointmentRecord appointmentRecord = new AppointmentRecord();

        AddDoctor:
            appointmentRecord.Doctor = ManageDoctor.Instance.FindDoctorId();
            if (appointmentRecord.Doctor == null)
            {
                if (Confirm("cancel")) goto Cancel;
                goto AddDoctor;
            }
            DisplayInfor(appointmentRecord.Doctor);
            Console.WriteLine();

        AddPatient:
            appointmentRecord.Patient = ManagePatient.Instance.FindPatientId();
            if (appointmentRecord.Patient == null)
            {
                if (Confirm("cancel")) goto Cancel;
                goto AddPatient;
            }
            DisplayInfor(appointmentRecord.Patient);

        DateTime:
            try
            {
                Console.Write("\nEnter a date [MM-dd-yyyy]: ");
                DateTime dateTime = DateTime.Parse(Console.ReadLine());
                appointmentRecord.AppointmentDate = dateTime;
                Console.WriteLine($"Date {appointmentRecord.AppointmentDate} has been selected.\n");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
                goto DateTime;
            }
            appointmentRecord.IsAppointment = false;
            return appointmentRecord;
        Cancel:
            appointmentRecord = null;
            return appointmentRecord;
        }

        public void DisplayInfor(Patient patient)
        {
            Console.WriteLine($"Chosen Patient: \"{patient.Id} - {patient.Name}\"");
        }

        public void DisplayInfor(Doctor doctor)
        {
            Console.WriteLine($"Chosen Doctor: \"{doctor.Id} - {doctor.Name}\"");
        }

        public void DisplayInfor(AppointmentRecord a)
        {
            Console.WriteLine($"========= Appointment Record ID {a.Id} =========");
            Console.WriteLine($"Doctor:");
            DisplayInfor(a.Doctor);
            Console.WriteLine($"Patient:");
            DisplayInfor(a.Patient);
            Console.WriteLine($"Date: {a.AppointmentDate}");
            Console.Write("Status: ");
            if (a.IsAppointment) Console.WriteLine("Confirmed");
            else Console.WriteLine("Waiting confirm");
            Console.WriteLine();
        }
        public void DisplayInfor()
        {
            if (!IsEmpty())
            {
                Console.WriteLine("========= All Appointment Record =========");
                foreach (var a in LstAppointmentRecords)
                {
                    Console.WriteLine($"Doctor Information:");
                    DisplayInfor(a.Doctor);
                    Console.WriteLine($"Patient Information:");
                    DisplayInfor(a.Patient);
                    Console.WriteLine($"Date time: {a.AppointmentDate}");
                    Console.Write("Status: ");
                    if (a.IsAppointment) Console.WriteLine("Confirmed");
                    else Console.WriteLine("Waiting confirm");
                    Console.WriteLine("_______________________");
                }
            }
            StopScreen();
        }

        public bool Confirm(string message)
        {
            Console.Write($"Are you sure to {message}? [y/n]: ");
            string isExit = Console.ReadLine();
            if (isExit.Equals("y") || isExit.Equals("n"))
                return isExit.Equals("y");
            Console.WriteLine("Input must be \"y\" or \"n\".");
            return Confirm(message);
        }
    }
}
