using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dostalova_DU_2 {
    class Subject {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; }
    }


    class SubjectCollection {
        private SubjectCollection() { }
        public static readonly SubjectCollection Instance = new SubjectCollection();

        public readonly ObservableCollection<Subject> Subjects = new ObservableCollection<Subject>();

        /// <summary>
        /// Saves subject and set all its fields based on the viewmodel
        /// </summary>
        public Subject Create(SubjectStudentViewModel subjectStudentView) {
            var subject = new Subject {
                Name = subjectStudentView.SubjectName,
                Capacity = subjectStudentView.SubjectCapacity,
                Description = subjectStudentView.SubjectDescription
            };

            Add(subject);
            return subject;
        }

        public void Add(Subject subject) {
            Subjects.Add(subject);
        }

        public void Delete(Subject subject) {
            Subjects.Remove(subject);
        }
    }
}
