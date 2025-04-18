using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02.Model
{
    public class Person
    {
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthDate;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        public Person(string name, string surname, string email, DateTime birthDate)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _birthDate = birthDate;
        }

        public Person(string firstName, string lastName, string email)
            : this(firstName, lastName, email, DateTime.Now) { }

        public Person(string firstName, string lastName, DateTime birthDate)
            : this(firstName, lastName, string.Empty, birthDate) { }


        private readonly bool _isAdult;
        private readonly string _sunSign;
        private readonly string _chineseSign;
        private readonly bool _isBirthday;

        public bool IsAdult
        {
            get { return _isAdult; }
        }

        public string SunSign
        {
            get { return _sunSign; }
        }

        public string ChineseSign
        {
            get { return _chineseSign; }
        }

        public bool IsBirthday
        {
            get { return _isBirthday; }
        }

    }
}
