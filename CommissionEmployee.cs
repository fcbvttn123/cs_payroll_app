using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1TranThanhNganVu
{
    internal class CommissionEmployee : Employee
    {
        public double GrossSale { get; set; }
        public double CommissionRate { get; set; }

        public CommissionEmployee( double grossSale, double commissionRate)
        {
            GrossSale = grossSale;
            CommissionRate = commissionRate;
        }

        public override double GrossEarnings
        {
            get
            {
                //return GrossSale * CommissionRate;
                return GrossSale * (CommissionRate/100);
            }
        }
    }
}
