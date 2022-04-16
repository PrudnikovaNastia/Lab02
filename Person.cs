using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Person
    {
        private string name;
        private string surname;
        private string email;
        private DateTime? dateOfBirth;
        const int adult_age = 18;
        WpfApp1.DateBirthday dateBirthday;

        public Person(string _name, string _surname, string _email, DateTime? _dateOfBirth)
        {
            name = _name;
            surname = _surname;
            email = _email;
            dateOfBirth = _dateOfBirth;

            return;
        }

        public Person(string _name, string _surname, DateTime? _dateOfBirth)
        {
            name = _name;
            surname = _surname;
            email = null;
            dateOfBirth = _dateOfBirth;
        }
        public Person(string _name, string _surname, string _email)
        {
            name = _name;
            surname = _surname;
            email = _email;
        }
        public bool Is_Adult => is_Adult();
        public int? Age => IsAdult();
        private bool is_Adult() => Age >= adult_age;
        private int? IsAdult()
        {
            int now_y = DateTime.Now.Year;
            int birthday_y=dateOfBirth.Value.Year;
            int now_m = DateTime.Now.Month;
            int birthday_m = dateOfBirth.Value.Month;
            int now_d = DateTime.Now.Day;
            int birthday_d = dateOfBirth.Value.Day;
            if (dateOfBirth == null) 
                return null;
            return (now_y - birthday_y + ((now_m >= birthday_m && now_d >= birthday_d) || now_y == birthday_y ? 0 : -1));
        }
        private string SunSign
        {
            get
            {
                return dateBirthday.GetZodiac();
            }
        }
        private string ChineseSign
        {
            get
            {
                return dateBirthday.GetChineseZodiac();
            }
        }
        private bool IsBirthday
        {
            get
            {
                return dateBirthday.BirthdayD();
            }
        }
       

    }
}