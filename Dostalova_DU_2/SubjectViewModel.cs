using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Dostalova_DU_2.Annotations;

namespace Dostalova_DU_2 {
    class SubjectViewModel : INotifyPropertyChanged {
        private string _name;
        public string Name {
            get { return _name; }
            set {
                _name = value;
                OnPropertyChanged();
            }
        }

        private int _capacity;
        public int Capacity {
            get { return _capacity; }
            set {
                _capacity = value;
                OnPropertyChanged();
            }
        }

        private string _description;
        public string Description {
            get { return _description; }
            set {
                _description = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
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
            var subject = new Subject {
                Name = Name,
                Capacity = Capacity,
                Description = Description
            };

            SubjectCollection.Instance.Add(subject);
            Clear();
            
        }

        /// <summary>
        /// Processes the form when deleting a selected subject
        /// </summary>
        public void ProcessDelete(object selectedItem) {
            SubjectCollection.Instance.Delete((Subject)selectedItem);
        }

        public void Clear()
        {
            Name = "";
            Description = "";
            Capacity = 0;
        }
    }
}
