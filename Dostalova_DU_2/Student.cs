using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dostalova_DU_2 {
    public enum FieldOfStudy {
        IT,
        ManagementIT,
        Economy
    }

    public enum Gender {
        Male,
        Female
    }

    public class Student {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public FieldOfStudy FieldOfStudy { get; set; }
        public Gender Gender { get; set; }
    }
}
