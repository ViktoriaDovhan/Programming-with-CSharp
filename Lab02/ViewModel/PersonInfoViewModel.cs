using System.ComponentModel;
using System.Windows;
using CommunityToolkit.Mvvm.Input;

namespace Lab02.ViewModel
{
    public class PersonInfoViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _surname;
        private string _email;
        private DateTime? _birthDate;
        private bool _isAdult;
        private string _sunSign;
        private string _chineseSign;
        private bool _isBirthday;

        public event PropertyChangedEventHandler PropertyChanged;
        public PersonInfoViewModel()
        {
            ProceedCommand = new RelayCommand(ProceedAsync, CanExecute);
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                ProceedCommand.NotifyCanExecuteChanged();
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                ProceedCommand.NotifyCanExecuteChanged();
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                ProceedCommand.NotifyCanExecuteChanged();
            }
        }

        public DateTime? BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                ProceedCommand.NotifyCanExecuteChanged();
            }
        }

        public bool IsAdult
        {
            get { return _isAdult; }
            private set
            {
                _isAdult = value;
            }
        }

        public string SunSign
        {
            get { return _sunSign; }
            private set
            {
                _sunSign = value;
            }
        }

        public string ChineseSign
        {
            get { return _chineseSign; }
            private set
            {
                _chineseSign = value;
            }
        }

        public bool IsBirthday
        {
            get { return _isBirthday; }
            private set
            {
                _isBirthday = value;
            }
        }

        public RelayCommand ProceedCommand { get; }

        
        private bool CanExecute()
        {
            return !string.IsNullOrWhiteSpace(Name)
                    && !string.IsNullOrWhiteSpace(Surname)
                    && !string.IsNullOrWhiteSpace(Email)
                    && BirthDate.HasValue;
        }

        private async void ProceedAsync()
        {
            try
            {
                if (!IsAgeValid())
                {
                    MessageBox.Show("Age must be between 0 and 135 years old.");
                    return;
                }

                if (IsTodayBirthday())
                {
                    MessageBox.Show("Happy Birthday!");
                }

                await Task.Delay(2000);

                await Task.Run(() =>
                {
                    IsAdult = GetAge() >= 18;
                    IsBirthday = IsTodayBirthday();
                    SunSign = GetSunSign(BirthDate!.Value);
                    ChineseSign = GetChineseSign(BirthDate!.Value);
                    OnPropertyChanged(nameof(Name));
                    OnPropertyChanged(nameof(Surname));
                    OnPropertyChanged(nameof(Email));
                    OnPropertyChanged(nameof(BirthDate));
                    OnPropertyChanged(nameof(IsAdult));
                    OnPropertyChanged(nameof(IsBirthday));
                    OnPropertyChanged(nameof(SunSign));
                    OnPropertyChanged(nameof(ChineseSign));

                });

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private bool IsAgeValid()
        {
            var age = GetAge();
            if (age < 0 || age > 135)
            {
                return false;
            }
            return true;
        }

        private int GetAge()
        {
            var age = DateTime.Now.Year - BirthDate!.Value.Year;
            if (BirthDate > DateTime.Now.AddYears(-age)) age--;
            return age;
        }

        private bool IsTodayBirthday()
        {
            return BirthDate!.Value.Month == DateTime.Now.Month && BirthDate!.Value.Day == DateTime.Now.Day;
        }

        private string GetSunSign(DateTime birthDate)
        {
            int day = birthDate.Day;
            int month = birthDate.Month;
            
            return month switch
            {
                1 => (day <= 19) ? "Capricorn" : "Aquarius",
                2 => (day <= 18) ? "Aquarius" : "Pisces",
                3 => (day <= 20) ? "Pisces" : "Aries",
                4 => (day <= 19) ? "Aries" : "Taurus",
                5 => (day <= 20) ? "Taurus" : "Gemini ",
                6 => (day <= 20) ? "Gemini " : "Cancer",
                7 => (day <= 22) ? "Cancer" : "Leo",
                8 => (day <= 22) ? "Leo" : "Virgo",
                9 => (day <= 22) ? "Virgo" : "Libra",
                10 => (day <= 22) ? "Libra" : "Scorpio",
                11 => (day <= 21) ? "Scorpio" : "Sagittarius",
                12 => (day <= 21) ? "Sagittarius" : "Capricorn",
                _ => "Unknown"
            };
        }

        private string GetChineseSign(DateTime birthDate)
        {
            int year = birthDate.Year;
            string[] chineseSigns = { "Monkey", "Rooster", "Dog", "Pig", "Rat", "Ox",
                "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat" };;
            return chineseSigns[year % 12];
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
