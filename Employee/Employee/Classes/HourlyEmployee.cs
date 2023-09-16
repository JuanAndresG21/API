using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeOOP.Classes
{
    internal class HourlyEmployee : Employee
    {
        #region Properties

        public decimal HourValue { get; set; }

        public int Hours { get; set; }

        #endregion

        #region Methods

        public HourlyEmployee() { }

        public override decimal GetValueToPay()
        {
            return HourValue * Hours;
        }

        public override string ToString()
        {
            return $"{base.ToString()}" +
                $"Valor a Pagar: {HourValue * Hours:C2}\n\t";
        }

        #endregion
    }
}
