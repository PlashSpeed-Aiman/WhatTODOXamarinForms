using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace App2.Model
{
    public class WhatsAppNumber: INotifyPropertyChanged
    {
        private string _name;
        private string _phoneNumber;
        private string _description;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
                
            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();

            }
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}