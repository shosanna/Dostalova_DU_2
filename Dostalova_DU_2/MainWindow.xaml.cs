using System.Windows;
using System.Windows.Controls;
using System.Xml;

namespace Dostalova_DU_2 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private readonly SubjectStudentViewModel _subjectStudentView = new SubjectStudentViewModel();

        public MainWindow() {
            InitializeComponent();

            // Data context for the whole form is set to the instance of the subjectStudentView model
            DataContext = _subjectStudentView;
            LbSubjects.DataContext = _subjectStudentView.Subjects;
        }

        private void MenuItem_Exit(object sender, RoutedEventArgs e) {
            // Creates XML document with all the subjects
            XmlWriter textWriter = XmlWriter.Create("C:\\subjects.xml");
            textWriter.WriteStartDocument();
            textWriter.WriteStartElement("Subjects");

            foreach (var subject in _subjectStudentView.Subjects) {
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
                _subjectStudentView.ProcessSave();
            }
        }

        /// <summary>
        /// Deletes a selected subject
        /// </summary>
        private void BtnDeleteSubject_Click(object sender, RoutedEventArgs e) {
            var messageBoxResult = MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes) {
                _subjectStudentView.ProcessDelete(LbSubjects.SelectedItem);
            }
        }
    }
}
