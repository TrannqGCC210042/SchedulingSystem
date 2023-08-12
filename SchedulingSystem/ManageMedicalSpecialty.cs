using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal class ManageMedicalSpecialty : IManagement
    {
        private List<MedicalSpecialty> lstMedicalSpecialties;
        public IReadOnlyCollection<MedicalSpecialty> LstMedicalSpecialties { get { return lstMedicalSpecialties.AsReadOnly(); } }
        public ManageMedicalSpecialty() { if (lstMedicalSpecialties == null) lstMedicalSpecialties = new List<MedicalSpecialty>(); }

        //Singleton
        private static ManageMedicalSpecialty instance;
        private static readonly object lockObj = new object();
        public static ManageMedicalSpecialty Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        if (instance == null)
                            instance = new ManageMedicalSpecialty();
                    }
                }
                return instance;
            }
        }
        public void Delete()
        {
            Console.WriteLine("========= Delete Medical Specialty =========");
            if (!IsEmpty())
            {
                MedicalSpecialty m = FindMedicalId();
                if (m != null)
                {
                    DisplayInfor(m);
                    if (Confirm("Sure"))
                    {
                        lstMedicalSpecialties.Remove(m);
                        Console.WriteLine($"Medical Specialty ID {m.Id} was deleted successfully!");
                    }
                }
            }
            StopScreen();
        }

        public void Update()
        {
            Console.WriteLine("========= Update Medical Specialty =========");
            if (!IsEmpty())
            {
                MedicalSpecialty m = FindMedicalId();
                if (m != null)
                {
                    DisplayInfor(m);
                    if (Confirm("Sure"))
                    {
                        MedicalSpecialty newMedical = (MedicalSpecialty)InputInformation();
                        m.SpecialtyName = newMedical.SpecialtyName;
                        m.SpecialtyDescription = newMedical.SpecialtyDescription;
                        Console.WriteLine($"Medical Specialty ID {newMedical.Id} was updated!");
                    }
                }
            }
            StopScreen();
        }
        public MedicalSpecialty FindMedicalId()
        {
            Console.WriteLine("[Press \"0\" to cancel.]");
            Console.Write("Choose Medical Specialty ID: ");
            int id = int.Parse(Console.ReadLine());
            if (id == 0) return null;
            foreach (var m in lstMedicalSpecialties)
            {
                if (m.Id == id)
                {
                    Console.WriteLine($"A result was found!");
                    return m;
                }
            }
            Console.WriteLine("Cannot find this Medical Specialty ID!\n");
            return FindMedicalId();
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
                Console.WriteLine("========= Medical Specialtie Information =========");
                MedicalSpecialty medical = (MedicalSpecialty)InputInformation();
                lstMedicalSpecialties.Add(medical);
                Console.WriteLine("Added successfully!");
                Console.WriteLine($"Medical Specialty ID was added: {medical.Id}");

                Console.WriteLine();
                Console.WriteLine("Do you want to continue adding a Medical Specialty?");
                checkContinue = Confirm("continue");
            } while (checkContinue);
        }
        public void DisplayInfor()
        {
            Console.WriteLine("========= All Medical Specialty =========");
            foreach (var medical in lstMedicalSpecialties)
            {
                Console.WriteLine($"Medical Specialty ID: {medical.Id}");
                Console.WriteLine($"Medical Specialty Name: {medical.SpecialtyName}");
                Console.WriteLine($"Medical Specialty Description: {medical.SpecialtyDescription}");
                Console.WriteLine();
            }
            StopScreen();
        }

        public void DisplayInfor(MedicalSpecialty medicalSpecialty)
        {
            Console.WriteLine($"========= Result: Medical Specialty ID {medicalSpecialty.Id} =========");
            Console.WriteLine($"Medical Specialty ID: {medicalSpecialty.Id}");
            Console.WriteLine($"Medical Specialty Name: {medicalSpecialty.SpecialtyName}");
            Console.WriteLine($"Medical Specialty Description: {medicalSpecialty.SpecialtyDescription}");
            Console.WriteLine();
        }

        public void Search()
        {
            FindMedicalId();
            StopScreen();
        }

        public Object InputInformation()
        {
            MedicalSpecialty medicalSpecialty = new MedicalSpecialty();
            Name:
            try
            {
                Console.Write("Medical Specialty Name: ");
                medicalSpecialty.SpecialtyName = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto Name;
            }

        Description:
            try
            {
                Console.Write("Medical Specialty Description: ");
                medicalSpecialty.SpecialtyDescription = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto Description;
            }

            return new MedicalSpecialty(medicalSpecialty);
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

        public bool IsEmpty()
        {
            if (lstMedicalSpecialties.Count == 0)
            {
                Console.WriteLine("List Patient is Empty!");
                return true;
            }
            return false;
        }
    }
}
