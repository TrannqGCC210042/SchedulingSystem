using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal class MedicalSpecialty
    {
        private static int nextId = 1;
        public int Id { get { return nextId; } private set { } }
        public string SpecialtyName;
        public string SpecialtyDescription;
        public MedicalSpecialty() { }
        public MedicalSpecialty(string specialtyName, string specialtyDescription) {
            Id = nextId++;
            SpecialtyDescription = specialtyDescription;
            SpecialtyName = specialtyName;
        }
    }
}
