using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Dostalova_DU_2 {
    class ViewModel : INotifyPropertyChanged
    {
        private string _StudentFirstName;
        public string StudentFirstName
        {
            get { return _StudentFirstName; }
            set
            {
                _StudentFirstName = value;
                OnPropertyChanged();
            }
        }

        private string _StudentLastName;
        public string StudentLastName {
            get { return _StudentLastName; }
            set {
                _StudentLastName = value;
                OnPropertyChanged();
            }
        }

        private DateTime _StudentDateOfBirth;
        public DateTime StudentDateOfBirth {
            get { return _StudentDateOfBirth; }
            set {
                _StudentDateOfBirth = value;
                OnPropertyChanged();
            }
        }

        private FieldOfStudy _StudentFieldOfStudy;
        public FieldOfStudy StudentFieldOfStudy {
            get { return _StudentFieldOfStudy; }
            set {
                _StudentFieldOfStudy = value;
                OnPropertyChanged();
            }
        }

        private Gender _StudentGender;
        public Gender StudentGender {
            get { return _StudentGender; }
            set {
                _StudentGender = value;
                OnPropertyChanged();
            }
        }

        private string _SubjectName;
        public string SubjectName { 
            get { return _SubjectName; }
            set {
                _SubjectName = value;
                OnPropertyChanged();
            }
        }

        private int _SubjectCapacity;
        public int SubjectCapacity {
            get { return _SubjectCapacity; }
            set {
                _SubjectCapacity = value;
                OnPropertyChanged();
            }
        }

        private string _SubjectDescription;
        public string SubjectDescription {
            get { return _SubjectDescription; }
            set {
                _SubjectDescription = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }


        // Stores the collection of sujects for the list box
        public ObservableCollection<Subject> Subjects = new ObservableCollection<Subject>();

        // Processes the form when creating a new subject
        public void ProcessSave()
        {
            var subject = Subject.Save(this);
            Subjects.Add(subject);
        }

        // Processes the form when deleting a selected subject
        public void ProcessDelete(object selectedItem)
        {
            var subject = (Subject) selectedItem;
            Subjects.Delete(subject);
        }
    }
}
