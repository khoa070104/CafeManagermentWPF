using FunnyCafeManagerment_DataAccess.ViewModels;
using System;
using System.ComponentModel;

namespace FunnyCafeManagerment_DataAcess.ViewModels
{
    public class MainVM : INotifyPropertyChanged
    {
        private UserVM _currentUser;
        public UserVM CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 