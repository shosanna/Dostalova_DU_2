using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dostalova_DU_2 {
    class SubjectStudentViewModel : INotifyPropertyChanged {
        private string _studentFirstName;
        public string StudentFirstName {
            get { return _studentFirstName; }
            set {
                _studentFirstName = value;
                OnPropertyChanged();
            }
        }

        private string _studentLastName;
        public string StudentLastName {
            get { return _studentLastName; }
            set {
                _studentLastName = value;
                OnPropertyChanged();
            }
        }

        private DateTime _studentDateOfBirth;
        public DateTime StudentDateOfBirth {
            get { return _studentDateOfBirth; }
            set {
                _studentDateOfBirth = value;
                OnPropertyChanged();
            }
        }

        private FieldOfStudy _studentFieldOfStudy;
        public FieldOfStudy StudentFieldOfStudy {
            get { return _studentFieldOfStudy; }
            set {
                _studentFieldOfStudy = value;
                OnPropertyChanged();
            }
        }

        private Gender _studentGender;
        public Gender StudentGender {
            get { return _studentGender; }
            set {
                _studentGender = value;
                OnPropertyChanged();
            }
        }

        private string _subjectName;
        public string SubjectName {
            get { return _subjectName; }
            set {
                _subjectName = value;
                OnPropertyChanged();
            }
        }

        private int _subjectCapacity;
        public int SubjectCapacity {
            get { return _subjectCapacity; }
            set {
                _subjectCapacity = value;
                OnPropertyChanged();
            }
        }

        private string _subjectDescription;
        public string SubjectDescription {
            get { return _subjectDescription; }
            set {
                _subjectDescription = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string caller = "") {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        public ObservableCollection<Subject> Subjects {
            get { return SubjectCollection.Instance.Subjects; }
        }

        /// <summary>
        /// Processes the form when creating a new subject
        /// </summary>
        public void ProcessSave() {
            SubjectCollection.Instance.Create(this);
        }

        /// <summary>
        /// Processes the form when deleting a selected subject
        /// </summary>
        public void ProcessDelete(object selectedItem) {
            SubjectCollection.Instance.Delete((Subject)selectedItem);
        }
    }
}
