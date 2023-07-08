using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1TranThanhNganVu
{
    internal class SalariedEmployee :Employee
    {
        public double FixedWeeklySalary { get; set; }

        public SalariedEmployee(double fixedWeeklySalary) { 
        
            FixedWeeklySalary = fixedWeeklySalary;

        }

        public override double GrossEarnings
        {
            get { return FixedWeeklySalary; }
        }

    }
}
