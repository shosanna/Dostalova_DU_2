using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Dostalova_DU_2.Annotations;

namespace Dostalova_DU_2 {
    class StudentViewModel : INotifyPropertyChanged {
        private string _firstName;
        public string FirstName {
            get { return _firstName; }
            set {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        private string _lastName;
        public string LastName {
            get { return _lastName; }
            set {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        private DateTime _dateOfBirth;
        public DateTime DateOfBirth {
            get { return _dateOfBirth; }
            set {
                _dateOfBirth = value;
                OnPropertyChanged();
            }
        }

        private FieldOfStudy _fieldOfStudy;
        public FieldOfStudy FieldOfStudy {
            get { return _fieldOfStudy; }
            set {
                _fieldOfStudy = value;
                OnPropertyChanged();
            }
        }

        private Gender _gender;
        public Gender Gender {
            get { return _gender; }
            set {
                _gender = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
