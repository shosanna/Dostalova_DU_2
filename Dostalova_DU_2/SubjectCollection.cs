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
    }
}