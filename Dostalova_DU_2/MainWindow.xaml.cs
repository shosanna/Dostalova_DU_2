using System.Windows;
using System.Windows.Controls;
using System.Xml;

namespace Dostalova_DU_2 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private readonly SubjectViewModel _subjectView = new SubjectViewModel();
        private readonly StudentViewModel _studentView = new StudentViewModel();

        public MainWindow() {
            InitializeComponent();

            AddTestSubject("foo");
            AddTestSubject("bar");
            AddTestSubject("baz");
            AddTestSubject("huhu");

            // Data context for the whole form is set to the instance of the subjectStudentView model
            TabItemSubjects.DataContext = _subjectView;
            TabItemStudents.DataContext = _studentView;
            //LbSubjects.DataContext = _subjectView.Subjects;

            LbSubjects.DataContext = SubjectCollection.Instance.Subjects;
            ComboAvailableSubjects.DataContext = SubjectCollection.Instance.Subjects;
            ComboStudentSubjects.DataContext = _studentView.Subjects;

            TbSubjectName.Focus();
        }

        private void MenuItem_Exit(object sender, RoutedEventArgs e) {
            // Creates XML document with all the subjects
            XmlWriter textWriter = XmlWriter.Create("C:\\subjects.xml");
            textWriter.WriteStartDocument();
            textWriter.WriteStartElement("Subjects");

            foreach (var subject in _subjectView.Subjects) {
                textWriter.WriteStartElement("Subject");
                textWriter.WriteElementString("Name", subject.Name);
                textWriter.WriteElementString("Capacity", subject.Capacity.ToString());
                textWriter.WriteElementString("Description", subject.Description);
                textWriter.WriteEndElement();

            }
            textWriter.WriteEndElement();
            textWriter.Close();

            Application.Current.Shutdown(110);
        }

        /// <summary>
        /// Creates a new subject
        /// </summary>
        private void BtnCreateSubject_Click(object sender, RoutedEventArgs e) {
            if (!Validation.GetHasError(TbSubjectName) || !Validation.GetHasError(TbCapacity)) {
                _subjectView.ProcessSave();
                TbSubjectName.Focus();
            }
        }

        /// <summary>
        /// Deletes a selected subject
        /// </summary>
        private void BtnDeleteSubject_Click(object sender, RoutedEventArgs e) {
            var messageBoxResult = MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes) {
                _subjectView.ProcessDelete(LbSubjects.SelectedItem);
            }
        }

        private void BtnAddStudentSubject_Click(object sender, RoutedEventArgs e) {
            var subject = (Subject)ComboAvailableSubjects.SelectedItem;
            _studentView.Subjects.Add(subject);
        }

        private void BtnRemoveStudentSubject_OnClick(object sender, RoutedEventArgs e) {
            var subject = (Subject)ComboStudentSubjects.SelectedItem;
            _studentView.Subjects.Remove(subject);
        }

        private void AddTestSubject(string name) {
            _subjectView.Name = name;
            _subjectView.Description = name;
            _subjectView.ProcessSave();
            _subjectView.Clear();
        }
    }
}
