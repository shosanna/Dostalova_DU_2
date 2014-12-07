using System.Collections.ObjectModel;

namespace Dostalova_DU_2 {
    class SubjectCollection {
        private SubjectCollection() { }
        public static readonly SubjectCollection Instance = new SubjectCollection();

        public readonly ObservableCollection<Subject> Subjects = new ObservableCollection<Subject>();

        public void Add(Subject subject) {
            Subjects.Add(subject);
        }

        public void Delete(Subject subject) {
            Subjects.Remove(subject);
        }

        // TODO 1. saving student into students collection and deleting student
        // TODO 2. Student can sign at particular subject - student has many subjects - only if the subject has capacity
        // TODO 3. Student can unassign from a subject - remove one subject from student's list of all subjects
    }
}