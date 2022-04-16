using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp1
{
    internal class DateBirthday : INotifyPropertyChanged
    {
        public DateBirthday() { }
        private static readonly string[] Zodiacs =
       {
            "Водолій",
            "Риби",
            "Овен",
            "Телець",
            "Близнюки",
            "Рак",
            "Лев",
            "Діва",
            "Терези",
            "Скорпіон",
            "Стрілець",
            "Козеріг"
        };
        private static readonly string[] ChineseZodiacs =
        {
            "Щур",
            "Віл",
            "Тигр",
            "Кролик",
            "Дракон",
            "Змія",
            "Кінь",
            "Коза",
            "Мавпа",
            "Півень",
            "Собака",
            "Свиня"
        };

        private DateTime _dateBirthday = DateTime.Today;
        private int _age;
        private bool _Birthday;
        private string _Zodiacs;
        private string _ChineseZodiacs;
        public string AgeY
        {
            get => $"Вам {_age}.";

        }
        public DateTime Birthday
        {
            get => _dateBirthday;
            set
            {
                _dateBirthday = value;
                UpdateValues();
                OnPropertyChanged();
                if (_Birthday)
                {
                    MessageBox.Show("З днем народження))))");
                }    
            }
        }
       
        public string Zodiac
        {
            get => $"Знак зодіаку: {_Zodiacs}.";

            private set
            {
                _Zodiacs = value;
                OnPropertyChanged();
            }
        }
        public string Chinesezodiacs
        {
            get => $"Знак зодіаку(Китай): {_ChineseZodiacs}.";
            private set
            {
                _ChineseZodiacs = value;
                OnPropertyChanged();
            }
        }
        public void UpdateValues()
        {
            var days = (DateTime.Today - _dateBirthday).Days;
            _age = days / 365;
            if (days < 0 || _age > 135)
            {
                MessageBox.Show("((Error((");
            }
            else
            {
                MessageBox.Show(AgeY);
            }
            _Birthday = BirthdayD();
            Chinesezodiacs = GetChineseZodiac();
            Zodiac = GetZodiac();
           
        }

        public bool BirthdayD()
        {
            return DateTime.Today.DayOfYear == _dateBirthday.DayOfYear;
        }

        public string GetChineseZodiac()
        {
            return ChineseZodiacs[(_dateBirthday.Year - 5) % 12];
        }

        public string GetZodiac()
        {
            var day = _dateBirthday.Day;
            var month = _dateBirthday.Month;

            switch (month)
            {
                case 1:
                case 4:
                    return day >= 20 ? Zodiacs[month - 1] : month == 1 ? Zodiacs[Zodiacs.Length - 1] : Zodiacs[month - 2];
                case 2:
                    return day >= 19 ? Zodiacs[month - 1] : Zodiacs[month - 2];
                case 3:
                case 5:
                case 6:
                    return day >= 21 ? Zodiacs[month - 1] : Zodiacs[month - 2];
                case 7:
                case 8:
                case 9:
                case 10:
                    return day >= 23 ? Zodiacs[month - 1] : Zodiacs[month - 2];
                default:
                    return day >= 22 ? Zodiacs[month - 1] : Zodiacs[month - 2];
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
 
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}