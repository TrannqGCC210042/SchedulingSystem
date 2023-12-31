﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal class MedicalSpecialty
    {
        string specialtyName;
        string specialtyDescription;
        private static int nextId = 0;
        public int Id { get; private set; }
        public string SpecialtyName
        {
            get { return specialtyName; }
            set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty or whitespace!\n");
                }
                if (!IsValidName(value))
                {
                    throw new ArgumentException("Name should contain only letters!\n");
                }
                specialtyName = value; 
            }
        }
        public string SpecialtyDescription
        {
            get { return specialtyDescription; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Description cannot be empty or whitespace!\n");
                }
                specialtyDescription = value;
            }
        }
        public MedicalSpecialty() { }
        public MedicalSpecialty(string specialtyName, string specialtyDescription) {
            Id = ++nextId;  
            SpecialtyName = specialtyName;
            SpecialtyDescription = specialtyDescription;
        }
        private bool IsValidName(string name)
        {
            // Using regular expression to check if the name contains only letters and spaces
            return Regex.IsMatch(name, @"^[a-zA-Z\s]+$");
        }
    }
}
