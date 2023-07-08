using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1TranThanhNganVu
{
    abstract class Employee
    {
        public string EmployeeType { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public abstract double GrossEarnings { get; }
        public double Tax { 
            get
            {
                return GrossEarnings * 0.2;
            } 
        }
        public double NetEarnings { 
            get
            {
                return GrossEarnings - Tax;
            } 
        }
    }
}
