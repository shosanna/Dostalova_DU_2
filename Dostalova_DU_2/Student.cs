using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dostalova_DU_2 {
    enum FieldOfStudy {
        IT,
        ManagementIT,
        Economy
    }

    enum Gender {
        Male,
        Female
    }

    class Student {
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private DateTime DateOfBirth { get; set; }
        private FieldOfStudy FieldOfStudy { get; set; }
        private Gender Gender { get; set; }
    }

    // TODO 1. saving student into students collection and deleting student
    // TODO 2. Student can sign at particular subject - student has many subjects - only if the subject has capacity
    // TODO 3. Student can unassign from a subject - remove one subject from student's list of all subjects
}
