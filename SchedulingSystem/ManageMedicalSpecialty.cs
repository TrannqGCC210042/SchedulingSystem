using System;
using System.Collections.Generic;

namespace SchedulingSystem
{
    internal class ManageMedicalSpecialty : IManagement
    {
        private List<MedicalSpecialty> lstMedicalSpecialties;
        public IReadOnlyCollection<MedicalSpecialty> LstMedicalSpecialties { 
            get { return lstMedicalSpecialties.AsReadOnly(); } 
        }
        private ManageMedicalSpecialty()
        {
            if (lstMedicalSpecialties == null) lstMedicalSpecialties = new List<MedicalSpecialty>();
        }
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
            Console.WriteLine("===== Delete Medical Specialty =====");
            if (!IsEmpty())
            {
                MedicalSpecialty medicalRemoved = FindMedicalId();
                if (medicalRemoved != null)
                {
                    DisplayInfor(medicalRemoved);
                    if (Confirm($"to delete Medical Specialty ID {medicalRemoved.Id}"))
                    {
                        lstMedicalSpecialties.Remove(medicalRemoved);
                        Console.WriteLine($"Medical Specialty ID {medicalRemoved.Id} was deleted in the system!");
                    }
                }
            }
            StopScreen();
        }

        public void Update()
        {
            Console.WriteLine("===== Update Medical Specialty =====");
            if (!IsEmpty())
            {
                MedicalSpecialty findMedical = FindMedicalId();
                if (findMedical != null)
                {
                    DisplayInfor(findMedical);
                    Console.WriteLine("Enter changes:");
                    MedicalSpecialty newMedical = (MedicalSpecialty)InputInformation();
                    findMedical.SpecialtyName = newMedical.SpecialtyName;
                    findMedical.SpecialtyDescription = newMedical.SpecialtyDescription;
                    Console.WriteLine($"Medical Specialty ID {findMedical.Id} was updated!");
                }
            }
            StopScreen();
        }
        public MedicalSpecialty FindMedicalId()
        {
        FindID:
            try
            {
                Console.WriteLine("[Press \"0\" to cancel.]");
                Console.Write("Choose Medical Specialty ID: ");
                string id = Console.ReadLine();

                if (id == "0")
                    return null;

                foreach (var medical in LstMedicalSpecialties)
                    if (medical.Id == int.Parse(id))
                        return medical;

                Console.WriteLine($"Medical Specialty ID \"{id}\" cannot exist in the system.\n");
                goto FindID;
            }
            catch (Exception)
            {
                Console.WriteLine("Medical Specialty ID must be a number.");
                Console.WriteLine();
                goto FindID;
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
            Console.WriteLine("===== Medical Specialty Information =====");
            MedicalSpecialty createMedical = (MedicalSpecialty)InputInformation();
            lstMedicalSpecialties.Add(new MedicalSpecialty(
                createMedical.SpecialtyName, createMedical.SpecialtyDescription));
            Console.Write("Added successfully!");
            Console.WriteLine($"Your Medical Specialty ID has been provided: " +
                $"{lstMedicalSpecialties[lstMedicalSpecialties.Count - 1].Id}\n");
            if (Confirm("continue adding a Medical Specialty")) {
                Console.WriteLine();
                Add();
            }
        }
        public void DisplayInfor()
        {
            //MedicalSpecialty medical1 = new MedicalSpecialty
            //{
            //    SpecialtyName = "Dermatology",
            //    SpecialtyDescription = "Dermatology is the branch of medicine dealing with the skin. It is a specialty with both medical and surgical aspects. A dermatologist is a specialist medical doctor who manages diseases related to skin, hair, nails, and some cosmetic problems."
            //};
            //lstMedicalSpecialties.Add(new MedicalSpecialty(medical1));

            //MedicalSpecialty medical2 = new MedicalSpecialty
            //{
            //    SpecialtyName = "Cardiology",
            //    SpecialtyDescription = "Cardiology is the branch of medicine that deals with disorders of the heart."
            //};
            //lstMedicalSpecialties.Add(new MedicalSpecialty(medical2));

            if (!IsEmpty())
            {
                Console.WriteLine("===== All Medical Specialties =====");
                foreach (var medical in lstMedicalSpecialties)
                {
                    Console.WriteLine($"Medical Specialty ID: {medical.Id}");
                    Console.WriteLine($"Medical Specialty Name: {medical.SpecialtyName}");
                    Console.WriteLine($"Medical Specialty Description: {medical.SpecialtyDescription}");
                    Console.WriteLine();
                }
                StopScreen();
            }

        }

        public void DisplayInfor(MedicalSpecialty medical)
        {
            Console.WriteLine("\nResult: 1 was found.");
            Console.WriteLine($"Medical Specialty ID: {medical.Id}");
            Console.WriteLine($"Medical Specialty Name: {medical.SpecialtyName}");
            Console.WriteLine($"Medical Specialty Description: {medical.SpecialtyDescription}");
            Console.WriteLine();
        }

        public void Search()
        {
            if (!IsEmpty())
            {
                Console.WriteLine("===== Search Medical Specialty =====");
                MedicalSpecialty result = FindMedicalId();
                if (result != null)
                {
                    Console.WriteLine();
                    DisplayInfor(result);
                }
                StopScreen();
            }
        }

        public Object InputInformation()
        {
            MedicalSpecialty inputMedical = new MedicalSpecialty();
        Name:
            try
            {
                Console.Write("Medical Specialty Name: ");
                inputMedical.SpecialtyName = Console.ReadLine();
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
                inputMedical.SpecialtyDescription = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto Description;
            }

            return inputMedical;
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

        public bool IsEmpty()
        {
            if (lstMedicalSpecialties.Count == 0)
            {
                Console.WriteLine("Notification: List Patient is Empty!");
                return true;
            }
            return false;
        }
    }
}
