﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeOOP.Classes
{
    internal class ComissionEmployee : Employee
    {
        #region Properties

        public decimal ComissionPercentaje { get; set; }

        public decimal Sales { get; set; }

        #endregion

        #region Methods

        public ComissionEmployee() { }

        public override decimal GetValueToPay()
        {
            return (ComissionPercentaje / 100) * Sales;
        }

        public override string ToString()
        {
            return $"{base.ToString()}" +
                $"Valor a Pagar: {(ComissionPercentaje/100) * Sales:C2}\n\t";
        }

        #endregion
    }
}
