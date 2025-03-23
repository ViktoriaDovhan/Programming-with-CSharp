using Lab01.Model;
using System;
using System.ComponentModel;
using System.Windows;
using CommunityToolkit.Mvvm.Input;

namespace Lab01.ViewModel
{
    public class BirthdayAppViewModel : INotifyPropertyChanged
    {
        private DateTime? _birthDate;
        private string _age = "Your age:";
        private string _westernZodiac = "Western zodiac sign:";
        private string _chineseZodiac = "Chinese zodiac sign:";
        private string _birthdayMessage;
        private string _errorMessage;

        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime? BirthDate
        {
            get => _birthDate;
            set
            {
                if (_birthDate != value)
                {
                    _birthDate = value;
                    OnPropertyChanged(nameof(BirthDate));
                    CalculateCommand.NotifyCanExecuteChanged();
                }
            }
        }

        public string Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        public string WesternZodiac
        {
            get { return _westernZodiac; }
            set
            {
                _westernZodiac = value;
                OnPropertyChanged(nameof(WesternZodiac));
            }
        }

        public string ChineseZodiac
        {
            get { return _chineseZodiac; }
            set
            {
                _chineseZodiac = value;
                OnPropertyChanged(nameof(ChineseZodiac));
            }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public string BirthdayMessage
        {
            get { return _birthdayMessage; }
            set
            {
                _birthdayMessage = value;
                OnPropertyChanged(nameof(BirthdayMessage));
            }
        }

        public RelayCommand CalculateCommand { get; }

        public BirthdayAppViewModel()
        {
            CalculateCommand = new RelayCommand(CalculateAgeAndZodiac, CanExecute);
        }

        private void CalculateAgeAndZodiac()
        {
            if (_birthDate == null) return;

            DateTime birthDate = _birthDate.Value;
            int age = ZodiacCalculator.CalculateAge(birthDate);

            if (age < 0 || age > 135)
            {
                MessageBox.Show("Age must be between 0 and 135 years old.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Age += $" {age}";
            WesternZodiac += $" {ZodiacCalculator.GetWesternZodiac(birthDate)}";
            ChineseZodiac += $" {ZodiacCalculator.GetChineseZodiac(birthDate)}";

            BirthdayMessage = (birthDate.Month == DateTime.Today.Month && birthDate.Day == DateTime.Today.Day)
                ? "Happy Birthday!" : string.Empty;
        }

        private bool CanExecute()
        {
            return BirthDate.HasValue;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
