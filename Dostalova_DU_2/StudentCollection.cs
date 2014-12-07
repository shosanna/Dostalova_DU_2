using System.Collections.ObjectModel;

namespace Dostalova_DU_2
{
    public class StudentCollection {
        private StudentCollection() { }
        public static readonly StudentCollection Instance = new StudentCollection();

        public readonly ObservableCollection<Student> Students = new ObservableCollection<Student>();

        public void Add(Student student) {
            Students.Add(student);
        }

        public void Delete(Student student) {
            Students.Remove(student);
        }

    }
}