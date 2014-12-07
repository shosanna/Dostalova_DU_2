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

        // Saves subject and set all its fields based on the viewmodel
        public static Subject Save(ViewModel view)
        {
            Subject subject = new Subject();
            subject.Name = view.SubjectName;
            subject.Capacity = view.SubjectCapacity;
            subject.Description = view.SubjectDescription;

            SubjectCollection.Add(subject);
            return subject;
        }

    }


    class SubjectCollection
    {
        private static ObservableCollection<Subject> _Subjects = new ObservableCollection<Subject>();

        public static void Add(Subject subject)
        {
            _Subjects.Add(subject);
        }

        public static void Delete(Subject subject) {
            // TODO IMPLEMENT
        }
    }
}
