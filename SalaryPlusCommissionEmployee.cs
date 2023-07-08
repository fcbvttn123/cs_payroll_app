using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1TranThanhNganVu
{
    internal class SalaryPlusCommissionEmployee : CommissionEmployee
    {
        public double FixedWeeklySalary { get;  set; }

        public SalaryPlusCommissionEmployee(double grossSale, double commissionRate, double fixedWeeklySalary) 
                                            :base(grossSale, commissionRate) {
        
            FixedWeeklySalary = fixedWeeklySalary;
            
        }

        public override double GrossEarnings
        {
            get
            {
                return FixedWeeklySalary + GrossSale * (CommissionRate/100);
            }
        }
    }
}
