using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1TranThanhNganVu
{
    internal class HourlyEmployee : Employee
    {
        public double HoursWorked { get; set; }
        public double HoursWage { get; set; }

        public HourlyEmployee(double hoursWorked, double hoursWage)
        {
            HoursWorked = hoursWorked;
            HoursWage = hoursWage;
        }

        public override double GrossEarnings
        {
            get
            {
                if(HoursWorked <= 40)
                {
                    return HoursWorked * HoursWage; 
                } else
                {
                    return 40 * HoursWage + (HoursWorked - 40) * HoursWage * 1.5;
                }
            }
        }
    }
}
