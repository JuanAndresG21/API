using EmployeeOOP.Exceptions;

namespace EmployeeOOP.Classes
{
    public class Date
    {
        #region Fields

        private int _year;
        private int _month;
        private int _day;
        #endregion

        #region Methods

        public Date(int day, int month, int year)
        {
            _year = ValidateYear(year);
            _month = ValidateMonth(month);
            _day = ValidateDay(day, month, year);
        }

        private int ValidateYear(int year)
        {
            if (year >= 1900)
            {
                return year;
            }
            else
            {
                //exception
                throw new YearException(String.Format("El año ingresado {0} no es valido", year));
            }
        }

        private int ValidateMonth(int month)
        {
            if (month < 0 || month > 12)
            {
                //creacion de excepciones
                throw new MonthException(String.Format("El mes ingresado {0} no es valido", month));
            }
            else
            {
                return month;
            }

        }

        private int ValidateDay(int day, int month, int year)
        {
            if (month == 2 && day == 29 && IsLeapYear(year))
            {
                return day;
            }

            if (month == 2 && day == 29 && !IsLeapYear(year))
            {
                bool isLeapYear = false;
                IsLeapYearException(isLeapYear, year);
            }

            int[] daysPerMonth = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            if (day >= 1 && day <= daysPerMonth[month])
            {
                return day;
            }
            else
            {
                throw new DayException(String.Format("El dia {0} no es valido para el mes {1}. ", day, month));
            }
        }

        private void IsLeapYearException(bool isLeapYear, int year)
        {
            if (!isLeapYear)
            {
                throw new YearException(String.Format("El año {0} no es bisiesto. ", year));
            }
        }

        private bool IsLeapYear(int year)
        {
            return (year % 400 == 0 || year % 4 == 0 && year % 100 != 0);
        }

        public override string ToString()
        {
            //var dateConcatenated1 = _day + "/" + _month + "/" + _year; //la mas vieja
            //var dateConcatenated2 = $"{_day:00}/{_month:00}/{_year:00}";  //interpolacion
            return String.Format("{0:00}/{1:00}/{2:0000}", _day, _month, _year); //string.format
            //return dateConcatenated1;
        }

        #endregion
    }
}
