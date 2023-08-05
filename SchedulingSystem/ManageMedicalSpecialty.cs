using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal class ManageMedicalSpecialty
    {
        private List<MedicalSpecialty> lstMedicalSpecialties;
        public IReadOnlyCollection<MedicalSpecialty> LstMedicalSpecialties { get { return lstMedicalSpecialties.AsReadOnly(); } }
        public ManageMedicalSpecialty() { if (lstMedicalSpecialties == null) lstMedicalSpecialties = new List<MedicalSpecialty>(); }
        public void Delete()
        {
            MedicalSpecialty m = FindMedicalId();
            if (m == null)
                Console.WriteLine("Cannot find this Medical Specialty ID!");
            else
            {
                if (Confirm("sure"))
                {
                    lstMedicalSpecialties.Remove(m);
                    Console.WriteLine($"Medical Specialty ID {m.Id} was deleted successfully!");
                }
            }
            StopScreen();
        }

        public void Update()
        {
            MedicalSpecialty m = FindMedicalId();
            if (m == null)
                Console.WriteLine("Cannot find this Medical Specialty ID!");
            else
            {
                Console.WriteLine("========= Update Information =========");
                MedicalSpecialty newMedical = (MedicalSpecialty)InputInformation();

                m.SpecialtyName = newMedical.SpecialtyName;
                m.SpecialtyDescription = newMedical.SpecialtyDescription;

                Console.WriteLine($"Medical Specialty ID {newMedical.Id} was updated!");

            }
            StopScreen();
        }
        public MedicalSpecialty FindMedicalId()
        {
            Console.Write("Choose Medical Specialty ID: ");
            int id = int.Parse(Console.ReadLine());

            MedicalSpecialty medical = null;
            foreach (var m in lstMedicalSpecialties)
            {
                if (m.Id == id)
                {
                    Console.WriteLine($"========= Result: Medical Specialty ID {m.Id} =========");
                    Console.WriteLine($"Medical Specialty ID: {m.Id}");
                    Console.WriteLine($"Medical Specialty Name: {m.SpecialtyName}");
                    Console.WriteLine($"Medical Specialty Description: {m.SpecialtyDescription}");
                    Console.WriteLine();
                    medical = m;
                    break;
                }
            }
            return medical;
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
        public void ShowAll()
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

        public void Search()
        {
            FindMedicalId();
            StopScreen();
        }

        public Object InputInformation()
        {
            Console.Write("Medical Specialty Name: ");
            string name = Console.ReadLine();
            Console.Write("Medical Specialty Description: ");
            string description = Console.ReadLine();

            return new MedicalSpecialty(name, description); 
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
