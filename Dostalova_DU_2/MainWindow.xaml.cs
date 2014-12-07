using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace Dostalova_DU_2 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private ViewModel View = new ViewModel();

        public MainWindow() {
            InitializeComponent();
            // Data context for the whole form is set to the instance of the view model
            DataContext = View;
            LbSubjects.DataContext = View.Subjects;

        }

        private void MenuItem_Exit(object sender, RoutedEventArgs e)
        {
            // Creates XML document with all the subjects
            XmlWriter textWriter = XmlWriter.Create("C:\\subjects.xml");
            textWriter.WriteStartDocument();
            textWriter.WriteStartElement("Subjects");

            foreach (var subject in View.Subjects)
            {
                // Write first element
                textWriter.WriteStartElement("Subject");

                // Write name
                textWriter.WriteElementString("Name", subject.Name);
                  
                // Write capacity
                textWriter.WriteElementString("Capacity", subject.Capacity.ToString());
         
                // Write description
                textWriter.WriteElementString("Description", subject.Description);
                textWriter.WriteEndElement();
     
            }
            textWriter.WriteEndElement();
            textWriter.Close();

            // Exit the application
            Application.Current.Shutdown(110);
        }

        // Creates a new subject
        private void BtnCreateSubject_Click(object sender, RoutedEventArgs e) {

            if (!Validation.GetHasError(TbSubjectName) || !Validation.GetHasError(TbCapacity)) {
                View.ProcessSave();
            }
        }

        // Deletes a selected subject
        private void BtnDeleteSubject_Click(object sender, RoutedEventArgs e) {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                View.ProcessDelete(LbSubjects.SelectedItem);
            }
        }

    }
}
