namespace A1TranThanhNganVu
{

    using ConsoleTables;

    enum Menu
    {
        Add = 1, 
        Edit,
        Delete,
        View,
        Search, 
    }

    enum EmployeeType
    {
        Hourly_Employee = 1,
        Commission_Employee,
        Salaried_Employee,
        Salary_Plus_Commission_Employee,
    }
    internal class Program
    {

        private static List<Employee> hourly_Employee = new List<Employee>();
        private static List<Employee> commission_Employee = new List<Employee>();
        private static List<Employee> salaried_Employee = new List<Employee>();
        private static List<Employee> salary_commission_Employee = new List<Employee>();
        static int id = 0;
        static void Main(string[] args)
        {
            Print_Menu();
        }

        // Print menu and sub-menu function

        static void Print_Menu()
        {
            // Print menu options

            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-\n");

            Console.WriteLine("     1 - Add Employee");

            Console.WriteLine("     2 - Edit Employee");

            Console.WriteLine("     3 - Delete Employee");

            Console.WriteLine("     4 - View Employee");

            Console.WriteLine("     5 - Search Employee");

            Console.WriteLine("     6 - Exit");

            // Get and Check input 

            Console.Write("\n\nEnter your choice: ");

            int menuOption;

            bool isValid = int.TryParse(Console.ReadLine(), out menuOption);

            if(!isValid)
            {
                while(!isValid || menuOption < 1 || menuOption > 6)
                {
                    Console.Write("Invalid Input. Do it again:  ");
                    isValid = int.TryParse(Console.ReadLine(), out menuOption);
                }
            }

            // exit if user choose 6

            if (menuOption == 6)
            {

                Console.WriteLine("\nExit !!!\n");

                Environment.Exit(0);
            }

            // call viewEmployee() function if user choose 4

            else if (menuOption == 4) {

                ViewEmployee();
            
            }

            // call searchEmployee() function if user choose 5

            else if (menuOption == 5)
            {
                SearchEmployee();
            }

            // Print sub-menu options

            Console.WriteLine($"\n\n{Enum.GetName(typeof(Menu), (Menu)menuOption)} Employees: \n");

            Console.WriteLine($"     1 - {Enum.GetName(typeof(Menu), (Menu) menuOption)} Hourly Employee");

            Console.WriteLine($"     2 - {Enum.GetName(typeof(Menu), (Menu) menuOption)} Commission Employee");

            Console.WriteLine($"     3 - {Enum.GetName(typeof(Menu), (Menu)menuOption)} Salaried Employee");

            Console.WriteLine($"     4 - {Enum.GetName(typeof(Menu), (Menu)menuOption)} Salary Plus Commission Employee");

            Console.WriteLine($"     5 - Back to menu");

            // Get and Check input 

            Console.Write("\n\nEnter your choice: ");

            int sub_menu;

            isValid = int.TryParse(Console.ReadLine(), out sub_menu);

            if (!isValid)
            {
                while (!isValid || sub_menu < 1 || sub_menu > 5)
                {
                    Console.Write("Invalid Input. Do it again:  ");
                    isValid = int.TryParse(Console.ReadLine(), out sub_menu);
                }
            }

            // If sub-menu choice is 5, call the method again 

            if(sub_menu == 5)
            {
                Console.WriteLine("\n\n");

                Print_Menu();
            }

            // If menu choice is 1, call AddEmployee() function

            if(menuOption == 1)
            {
                AddEmployee((EmployeeType) sub_menu);
            }

            // If menu choice is 3, call DeleteEmployee() function

            else if (menuOption == 3)
            {
                DeleteEmployee((EmployeeType)sub_menu);
            }

            // If menu choice is 2, call EditEmployee() function

            else if (menuOption == 2)
            {
                EditEmployee((EmployeeType)sub_menu);
            }

        }

        // View Employee Function
        static void ViewEmployee()
        {
            // print hourly employee

            Console.WriteLine("\nView Hourly Employee: \n");

            var table = new ConsoleTable("ID", "Name", "Employee Type", "Hours Worked", "Hours Wage", "Gross Earnings", "Tax", "Net Earnings");

            foreach (HourlyEmployee arrItem in hourly_Employee)
            {

                table.AddRow(
                    arrItem.EmployeeId,
                    arrItem.EmployeeName,
                    arrItem.EmployeeType,
                    arrItem.HoursWorked,
                    arrItem.HoursWage.ToString("C2"),
                    arrItem.GrossEarnings.ToString("C2"),
                    arrItem.Tax.ToString("C2"),
                    arrItem.NetEarnings.ToString("C2")
                );

            }

            table.Write();

            Console.WriteLine("\n\n");

            // print commission employee

            Console.WriteLine("\n View Commission Emplyee: \n");

            table = new ConsoleTable("ID", "Name", "Employee Type", "Gross Sale", "Commission Rate", "Gross Earnings", "Tax", "Net Earnings");

            foreach (CommissionEmployee arrItem in commission_Employee)
            {

                table.AddRow(
                    //commission_Employee.IndexOf(arrItem),
                    arrItem.EmployeeId,
                    arrItem.EmployeeName,
                    arrItem.EmployeeType,
                    arrItem.GrossSale.ToString("C2"),
                    arrItem.CommissionRate.ToString("P"),
                    arrItem.GrossEarnings.ToString("C2"),
                    arrItem.Tax.ToString("C2"),
                    arrItem.NetEarnings.ToString("C2")
                );
            }

            table.Write();

            Console.WriteLine("\n\n");

            // print salary employee

            Console.WriteLine("\n View Salary Emplyee: \n");

            table = new ConsoleTable("ID", "Name", "Employee Type", "Fixed Weekly Salary", "Gross Earnings", "Tax", "Net Earnings");

            foreach (SalariedEmployee arrItem in salaried_Employee)
            {

                table.AddRow(
                    arrItem.EmployeeId,
                    arrItem.EmployeeName,
                    arrItem.EmployeeType,
                    arrItem.FixedWeeklySalary.ToString("C2"),
                    arrItem.GrossEarnings.ToString("C2"),
                    arrItem.Tax.ToString("C2"),
                    arrItem.NetEarnings.ToString("C2")
                );
            }

            table.Write();

            Console.WriteLine("\n\n");

            // print salary commission employee

            Console.WriteLine("\n View Salary plus Commission Employee: \n");

            table = new ConsoleTable("ID", "Name", "Employee Type", "Fixed Weekly Salary", "Gross Earnings", "Tax", "Net Earnings");

            foreach (SalaryPlusCommissionEmployee arrItem in salary_commission_Employee)
            {

                table.AddRow(
                    arrItem.EmployeeId,
                    arrItem.EmployeeName,
                    arrItem.EmployeeType,
                    //arrItem.grossSale,
                    //"Gross Sale", "Commission Rate",
                    arrItem.FixedWeeklySalary.ToString("C2"),
                    arrItem.GrossEarnings.ToString("C2"),
                    arrItem.Tax.ToString("C2"),
                    arrItem.NetEarnings.ToString("C2")
                );
            }

            table.Write();

            Console.WriteLine("\n\n");

            Print_Menu();
        }

        // Search Employee Function
        static void SearchEmployee()
        {

            // Get name input 

            Console.Write("\n\nEnter employee name: ");

            string empName = Console.ReadLine();

            //  check hourly employee table 

            var empArr = from emp in hourly_Employee
                         let upperEmp = emp.EmployeeName.ToUpper()
                         where upperEmp.Contains(empName.ToUpper())
                         select emp;

            if(!empArr.Any())
            {
                Console.WriteLine("\nThis name is not on the hourly employee list");

            } else
            {
                // Print all employee 

                Console.WriteLine("\nHourly Emplyee: \n");

                var table = new ConsoleTable("ID", "Name", "Employee Type", "Hours Worked", "Hours Wage", "Gross Earnings", "Tax", "Net Earnings");

                foreach (HourlyEmployee arrItem in empArr)
                {

                    table.AddRow(
                        arrItem.EmployeeId,
                        arrItem.EmployeeName,
                        arrItem.EmployeeType,
                        arrItem.HoursWorked,
                        arrItem.HoursWage.ToString("C2"),
                        arrItem.GrossEarnings.ToString("C2"),
                        arrItem.Tax.ToString("C2"),
                        arrItem.NetEarnings.ToString("C2")
                    );

                }

                table.Write();

                Console.WriteLine("\n\n");
            }

            //  check commission employee table 

            empArr = from emp in commission_Employee
                     let upperEmp = emp.EmployeeName.ToUpper()
                     where upperEmp.Contains(empName.ToUpper())
                     select emp;

            if (!empArr.Any())
            {
                Console.WriteLine("\nThis name is not on the commission employee list");
            }
            else
            {
                // Print 

                Console.WriteLine("\nCommission Emplyee: \n");

                var table = new ConsoleTable("ID", "Name", "Employee Type", "Gross Sale", "Commission Rate", "Gross Earnings", "Tax", "Net Earnings");

                foreach (CommissionEmployee arrItem in empArr)
                {

                    table.AddRow(
                        arrItem.EmployeeId,
                        arrItem.EmployeeName,
                        arrItem.EmployeeType,
                        arrItem.GrossSale.ToString("C2"),
                        arrItem.CommissionRate.ToString("P"),
                        arrItem.GrossEarnings.ToString("C2"),
                        arrItem.Tax.ToString("C2"),
                        arrItem.NetEarnings.ToString("C2")
                    );

                }

                table.Write();

                Console.WriteLine("\n\n");
            }

            //  check salary employee table 

            empArr = from emp in salaried_Employee
                     let upperEmp = emp.EmployeeName.ToUpper()
                     where upperEmp.Contains(empName.ToUpper())
                     select emp;

            if (!empArr.Any())
            {
                Console.WriteLine("\nThis name is not on salary list");

            } else
            {
                // Print all employee 

                Console.WriteLine("\nSalary Employee: \n");

                var table = new ConsoleTable("ID", "Name", "Employee Type", "Fixed Weekly Salary", "Gross Earnings", "Tax", "Net Earnings");

                foreach (SalariedEmployee arrItem in empArr)
                {

                    table.AddRow(
                        arrItem.EmployeeId,
                        arrItem.EmployeeName,
                        arrItem.EmployeeType,
                        arrItem.FixedWeeklySalary.ToString("C2"),
                        arrItem.GrossEarnings.ToString("C2"),
                        arrItem.Tax.ToString("C2"),
                        arrItem.NetEarnings.ToString("C2")
                    );

                }

                table.Write();

                Console.WriteLine("\n\n");
            }

            // check salary commission employee

            empArr = from emp in salary_commission_Employee
                     let upperEmp = emp.EmployeeName.ToUpper()
                     where upperEmp.Contains(empName.ToUpper())
                     select emp;

            if (!empArr.Any())
            {
                Console.WriteLine("\nThis name is not on the salary plus commission list");

            } else
            {
                // Print all employee 

                Console.WriteLine("\nSalary plus Commission Employee: \n");

                var table = new ConsoleTable("ID", "Name", "Employee Type", "Fixed Weekly Salary", "Gross Earnings", "Tax", "Net Earnings");

                foreach (SalaryPlusCommissionEmployee arrItem in empArr)
                {

                    table.AddRow(
                        arrItem.EmployeeId,
                        arrItem.EmployeeName,
                        arrItem.EmployeeType,
                        //arrItem.grossSale,
                        //"Gross Sale", "Commission Rate",
                        arrItem.FixedWeeklySalary.ToString("C2"),
                        arrItem.GrossEarnings.ToString("C2"),
                        arrItem.Tax.ToString("C2"),
                        arrItem.NetEarnings.ToString("C2")
                    );
                }

                table.Write();

                Console.WriteLine("\n\n");
            }

            Console.WriteLine("\n\n\n\n");

            Print_Menu();

        }

        // Delete Employee Function
        static void DeleteEmployee(EmployeeType employeeType)
        {

            // Delete hourly employee

            if (employeeType == EmployeeType.Hourly_Employee)
            {
                // Back to manu if it had nothing on the list

                if(!hourly_Employee.Any())
                {
                    Console.WriteLine("\nNothing on this list");

                    Console.WriteLine("\n\n\n\n");

                    Print_Menu();
                }

                // Print all employee 

                Console.WriteLine("\nDelete Hourly Employee: \n");

                var table = new ConsoleTable("ID", "Name", "Employee Type", "Hours Worked", "Hours Wage", "Gross Earnings", "Tax", "Net Earnings");

                foreach (HourlyEmployee arrItem in hourly_Employee)
                {

                    table.AddRow(
                        //hourly_Employee.IndexOf(arrItem), 
                        arrItem.EmployeeId,
                        arrItem.EmployeeName,
                        arrItem.EmployeeType,
                        arrItem.HoursWorked,
                        arrItem.HoursWage.ToString("C2"),
                        arrItem.GrossEarnings.ToString("C2"),
                        arrItem.Tax.ToString("C2"),
                        arrItem.NetEarnings.ToString("C2")
                    );
                }

                table.Write();

                // ask the user for the Employee ID and check

                Console.Write("\nEnter employee id: ");

                int deletedId;

                bool isValid = int.TryParse(Console.ReadLine(), out deletedId);

                if (!isValid)
                {
                    while (!isValid)
                    {
                        Console.Write("Invalid Input. Do it again:  ");
                        isValid = int.TryParse(Console.ReadLine(), out deletedId);
                    }
                }

                var deletedEmployeeArr = from employee in hourly_Employee
                                         where employee.EmployeeId == deletedId
                                         select employee;

                // delete id 

                if(!deletedEmployeeArr.Any())
                {

                    while (!deletedEmployeeArr.Any())
                    {
                        Console.WriteLine("\nEntered id is not in the list. Try again: ");
                        isValid = int.TryParse(Console.ReadLine(), out deletedId);
                    }

                    hourly_Employee.Remove(deletedEmployeeArr.First());

                    Console.WriteLine("\nRemoved Employee !!!");

                } else
                {
                    hourly_Employee.Remove(deletedEmployeeArr.First());

                    Console.WriteLine("\nRemoved Employee !!!");
                }

                // Print all employee 

                Console.WriteLine("\nView Hourly Employee: \n");

                table = new ConsoleTable("ID", "Name", "Employee Type", "Hours Worked", "Hours Wage", "Gross Earnings", "Tax", "Net Earnings");

                foreach (HourlyEmployee arrItem in hourly_Employee)
                {

                    table.AddRow(
                        arrItem.EmployeeId,
                        arrItem.EmployeeName,
                        arrItem.EmployeeType,
                        arrItem.HoursWorked,
                        arrItem.HoursWage.ToString("C2"),
                        arrItem.GrossEarnings.ToString("C2"),
                        arrItem.Tax.ToString("C2"),
                        arrItem.NetEarnings.ToString("C2")
                    );
                }

                table.Write();

                Console.WriteLine("\n\n\n\n");

                Print_Menu();
            }

            // delete commission employee

            else if (employeeType == EmployeeType.Commission_Employee)
            {
                // Back to manu if it had nothing on the list

                if (!commission_Employee.Any())
                {
                    Console.WriteLine("\nNothing on this list");

                    Console.WriteLine("\n\n\n\n");

                    Print_Menu();
                }

                // Print all employee 

                Console.WriteLine("\n Delete Commission Emplyee: \n");

                var table = new ConsoleTable("ID", "Name", "Employee Type", "Gross Sale", "Commission Rate", "Gross Earnings", "Tax", "Net Earnings");

                foreach (CommissionEmployee arrItem in commission_Employee)
                {

                    table.AddRow(
                        arrItem.EmployeeId,
                        arrItem.EmployeeName,
                        arrItem.EmployeeType,
                        arrItem.GrossSale.ToString("C2"),
                        arrItem.CommissionRate.ToString("P"),
                        arrItem.GrossEarnings.ToString("C2"),
                        arrItem.Tax.ToString("C2"),
                        arrItem.NetEarnings.ToString("C2")
                    );

                }

                table.Write();

                // ask the user for the Employee ID and check

                Console.Write("\nEnter employee id: ");

                int deletedId;

                bool isValid = int.TryParse(Console.ReadLine(), out deletedId);

                if (!isValid)
                {
                    while (!isValid)
                    {
                        Console.Write("Invalid Input. Do it again:  ");
                        isValid = int.TryParse(Console.ReadLine(), out deletedId);
                    }
                }

                var deletedEmployeeArr = from employee in commission_Employee
                                         where employee.EmployeeId == deletedId
                                         select employee;

                // delete id 

                if (!deletedEmployeeArr.Any())
                {

                    while (!deletedEmployeeArr.Any())
                    {
                        Console.WriteLine("\nEntered id is not in the list. Try again: ");
                        isValid = int.TryParse(Console.ReadLine(), out deletedId);
                    }

                    commission_Employee.Remove(deletedEmployeeArr.First());

                    Console.WriteLine("\nRemoved Employee !!!");

                }
                else
                {
                    commission_Employee.Remove(deletedEmployeeArr.First());

                    Console.WriteLine("\nRemoved Employee !!!");
                }

                // Print all employee 

                Console.WriteLine("\nView Commission Employee: \n");

                table = new ConsoleTable("ID", "Name", "Employee Type", "Gross Sale", "Commission Rate", "Gross Earnings", "Tax", "Net Earnings");

                foreach (CommissionEmployee arrItem in commission_Employee)
                {

                    table.AddRow(
                        arrItem.EmployeeId,
                        arrItem.EmployeeName,
                        arrItem.EmployeeType,
                        arrItem.GrossSale.ToString("C2"),
                        arrItem.CommissionRate.ToString("P"),
                        arrItem.GrossEarnings.ToString("C2"),
                        arrItem.Tax.ToString("C2"),
                        arrItem.NetEarnings.ToString("C2")
                    );

                }

                table.Write();

                Console.WriteLine("\n\n\n\n");

                Print_Menu();
            }

            // delete salary employee

            else if (employeeType == EmployeeType.Salaried_Employee)
            {
                // Back to manu if it had nothing on the list

                if (!salaried_Employee.Any())
                {
                    Console.WriteLine("\nNothing on this list");

                    Console.WriteLine("\n\n\n\n");

                    Print_Menu();
                }

                // Print all employee 

                Console.WriteLine("\n Delete Salary Emplyee: \n");

                var table = new ConsoleTable("ID", "Name", "Employee Type", "Fixed Weekly Salary", "Gross Earnings", "Tax", "Net Earnings");

                foreach (SalariedEmployee arrItem in salaried_Employee)
                {

                    table.AddRow(
                        arrItem.EmployeeId,
                        arrItem.EmployeeName,
                        arrItem.EmployeeType,
                        arrItem.FixedWeeklySalary.ToString("C2"),
                        arrItem.GrossEarnings.ToString("C2"),
                        arrItem.Tax.ToString("C2"),
                        arrItem.NetEarnings.ToString("C2")
                    );

                }

                table.Write();

                // ask the user for the Employee ID and check

                Console.Write("\nEnter employee id: ");

                int deletedId;

                bool isValid = int.TryParse(Console.ReadLine(), out deletedId);

                if (!isValid)
                {
                    while (!isValid)
                    {
                        Console.Write("Invalid Input. Do it again:  ");
                        isValid = int.TryParse(Console.ReadLine(), out deletedId);
                    }
                }

                var deletedEmployeeArr = from employee in salaried_Employee
                                         where employee.EmployeeId == deletedId
                                         select employee;

                // delete id 

                if (!deletedEmployeeArr.Any())
                {

                    while (!deletedEmployeeArr.Any())
                    {
                        Console.WriteLine("\nEntered id is not in the list. Try again: ");
                        isValid = int.TryParse(Console.ReadLine(), out deletedId);
                    }

                    salaried_Employee.Remove(deletedEmployeeArr.First());

                    Console.WriteLine("\nRemoved Employee !!!");

                }
                else
                {
                    salaried_Employee.Remove(deletedEmployeeArr.First());

                    Console.WriteLine("\nRemoved Employee !!!");
                }

                // Print all employee 

                Console.WriteLine("\nView Salary Employee: \n");

                table = new ConsoleTable("ID", "Name", "Employee Type", "Fixed Weekly Salary", "Gross Earnings", "Tax", "Net Earnings");

                foreach (SalariedEmployee arrItem in salaried_Employee)
                {

                    table.AddRow(
                        arrItem.EmployeeId,
                        arrItem.EmployeeName,
                        arrItem.EmployeeType,
                        arrItem.FixedWeeklySalary.ToString("C2"),
                        arrItem.GrossEarnings.ToString("C2"),
                        arrItem.Tax.ToString("C2"),
                        arrItem.NetEarnings.ToString("C2")
                    );

                }

                table.Write();

                Console.WriteLine("\n\n\n\n");

                Print_Menu();
            }

            // delete salary commission employee

            else if (employeeType == EmployeeType.Salary_Plus_Commission_Employee)
            {
                // Back to manu if it had nothing on the list

                if (!salary_commission_Employee.Any())
                {
                    Console.WriteLine("\nNothing on this list");

                    Console.WriteLine("\n\n\n\n");

                    Print_Menu();
                }

                // Print all employee 

                Console.WriteLine("\n View Salary plus Commission Employee: \n");

                var table = new ConsoleTable("ID", "Name", "Employee Type", "Fixed Weekly Salary", "Gross Earnings", "Tax", "Net Earnings");

                foreach (SalaryPlusCommissionEmployee arrItem in salary_commission_Employee)
                {

                    table.AddRow(
                        arrItem.EmployeeId,
                        arrItem.EmployeeName,
                        arrItem.EmployeeType,
                        //arrItem.grossSale,
                        //"Gross Sale", "Commission Rate",
                        arrItem.FixedWeeklySalary.ToString("C2"),
                        arrItem.GrossEarnings.ToString("C2"),
                        arrItem.Tax.ToString("C2"),
                        arrItem.NetEarnings.ToString("C2")
                    );
                }

                table.Write();

                // ask the user for the Employee ID and check

                Console.Write("\nEnter employee id: ");

                int deletedId;

                bool isValid = int.TryParse(Console.ReadLine(), out deletedId);

                if (!isValid)
                {
                    while (!isValid)
                    {
                        Console.Write("Invalid Input. Do it again:  ");
                        isValid = int.TryParse(Console.ReadLine(), out deletedId);
                    }
                }

                var deletedEmployeeArr = from employee in salary_commission_Employee
                                         where employee.EmployeeId == deletedId
                                         select employee;

                // delete id 

                if (!deletedEmployeeArr.Any())
                {

                    while (!deletedEmployeeArr.Any())
                    {
                        Console.WriteLine("\nEntered id is not in the list. Try again: ");
                        isValid = int.TryParse(Console.ReadLine(), out deletedId);
                    }

                    salary_commission_Employee.Remove(deletedEmployeeArr.First());

                    Console.WriteLine("\nRemoved Employee !!!");

                }
                else
                {
                    salary_commission_Employee.Remove(deletedEmployeeArr.First());

                    Console.WriteLine("\nRemoved Employee !!!");
                }

                // Print all employee 

                Console.WriteLine("\n View Salary plus Commission Employee: \n");

                table = new ConsoleTable("ID", "Name", "Employee Type", "Fixed Weekly Salary", "Gross Earnings", "Tax", "Net Earnings");

                foreach (SalaryPlusCommissionEmployee arrItem in salary_commission_Employee)
                {

                    table.AddRow(
                        arrItem.EmployeeId,
                        arrItem.EmployeeName,
                        arrItem.EmployeeType,
                        //arrItem.grossSale,
                        //"Gross Sale", "Commission Rate",
                        arrItem.FixedWeeklySalary.ToString("C2"),
                        arrItem.GrossEarnings.ToString("C2"),
                        arrItem.Tax.ToString("C2"),
                        arrItem.NetEarnings.ToString("C2")
                    );
                }

                table.Write();

                Console.WriteLine("\n\n\n\n");

                Print_Menu();
            }
        }

        // Edit Employee Function
        static void EditEmployee(EmployeeType employeeType)
        {
            // Edit hourly employee

            if (employeeType == EmployeeType.Hourly_Employee)
            {
                // Back to manu if it had nothing on the list

                if (!hourly_Employee.Any())
                {
                    Console.WriteLine("\nNothing on this list");

                    Console.WriteLine("\n\n\n\n");

                    Print_Menu();
                }

                // print hourly employee

                Console.WriteLine("\nView Hourly Employee: \n");

                var table = new ConsoleTable("ID", "Name", "Employee Type", "Hours Worked", "Hours Wage", "Gross Earnings", "Tax", "Net Earnings");

                foreach (HourlyEmployee arrItem in hourly_Employee)
                {

                    table.AddRow(
                        arrItem.EmployeeId,
                        arrItem.EmployeeName,
                        arrItem.EmployeeType,
                        arrItem.HoursWorked,
                        arrItem.HoursWage.ToString("C2"),
                        arrItem.GrossEarnings.ToString("C2"),
                        arrItem.Tax.ToString("C2"),
                        arrItem.NetEarnings.ToString("C2")
                    );

                }

                table.Write();

                Console.WriteLine("\n\n");

                // Get id you want to edit

                Console.Write("\nEnter employee id: ");

                int editId;

                bool isValid = int.TryParse(Console.ReadLine(), out editId);

                if (!isValid)
                {
                    while (!isValid)
                    {
                        Console.Write("Invalid Input. Do it again:  ");
                        isValid = int.TryParse(Console.ReadLine(), out editId);
                    }
                }

                var editEmployeeArr = from employee in hourly_Employee
                                         where employee.EmployeeId == editId
                                         select employee;

                Console.WriteLine("\n");

                // edit id 

                if (!editEmployeeArr.Any())
                {

                    while (!editEmployeeArr.Any())
                    {
                        Console.WriteLine("\nEntered id is not in the list. Try again: ");
                        isValid = int.TryParse(Console.ReadLine(), out editId);
                    }

                    // Get new info

                    Console.WriteLine("\nEnter employee name: ");
                    string empName = Console.ReadLine();

                    Console.WriteLine("\nEnter hours worked: ");
                    double hourWorked;
                    isValid = double.TryParse(Console.ReadLine(), out hourWorked);
                    if (!isValid || hourWorked < 0)
                    {
                        while (!isValid || hourWorked < 0)
                        {
                            Console.Write("Invalid Input. Do it again:  ");
                            isValid = double.TryParse(Console.ReadLine(), out hourWorked);
                        }
                    }

                    Console.WriteLine("\nEnter hours wage: ");
                    double hourWage;
                    isValid = double.TryParse(Console.ReadLine(), out hourWage);
                    if (!isValid || hourWage < 0)
                    {
                        while (!isValid || hourWage < 0)
                        {
                            Console.Write("Invalid Input. Do it again:  ");
                            isValid = double.TryParse(Console.ReadLine(), out hourWage);
                        }
                    }

                    // Change info

                    HourlyEmployee editEmployee = (HourlyEmployee)editEmployeeArr.First();
                    editEmployee.EmployeeName = empName;
                    editEmployee.HoursWorked = hourWorked;
                    editEmployee.HoursWage = hourWage;

                    // print hourly employee

                    Console.WriteLine("\nView Hourly Employee: \n");

                    table = new ConsoleTable("ID", "Name", "Employee Type", "Hours Worked", "Hours Wage", "Gross Earnings", "Tax", "Net Earnings");

                    foreach (HourlyEmployee arrItem in hourly_Employee)
                    {

                        table.AddRow(
                            arrItem.EmployeeId,
                            arrItem.EmployeeName,
                            arrItem.EmployeeType,
                            arrItem.HoursWorked,
                            arrItem.HoursWage.ToString("C2"),
                            arrItem.GrossEarnings.ToString("C2"),
                            arrItem.Tax.ToString("C2"),
                            arrItem.NetEarnings.ToString("C2")
                        );

                    }

                    table.Write();

                    Console.WriteLine("\nEdited Employee !!!");

                }
                else
                {
                    // Get new info

                    Console.WriteLine("\nEnter employee name: ");
                    string empName = Console.ReadLine();

                    Console.WriteLine("\nEnter hours worked: ");
                    double hourWorked;
                    isValid = double.TryParse(Console.ReadLine(), out hourWorked);
                    if (!isValid || hourWorked < 0)
                    {
                        while (!isValid || hourWorked < 0)
                        {
                            Console.Write("Invalid Input. Do it again:  ");
                            isValid = double.TryParse(Console.ReadLine(), out hourWorked);
                        }
                    }

                    Console.WriteLine("\nEnter hours wage: ");
                    double hourWage;
                    isValid = double.TryParse(Console.ReadLine(), out hourWage);
                    if (!isValid || hourWage < 0)
                    {
                        while (!isValid || hourWage < 0)
                        {
                            Console.Write("Invalid Input. Do it again:  ");
                            isValid = double.TryParse(Console.ReadLine(), out hourWage);
                        }
                    }

                    // Change info

                    HourlyEmployee editEmployee = (HourlyEmployee)editEmployeeArr.First();
                    editEmployee.EmployeeName = empName;
                    editEmployee.HoursWorked = hourWorked;
                    editEmployee.HoursWage = hourWage;

                    // print hourly employee

                    Console.WriteLine("\nView Hourly Employee: \n");

                    table = new ConsoleTable("ID", "Name", "Employee Type", "Hours Worked", "Hours Wage", "Gross Earnings", "Tax", "Net Earnings");

                    foreach (HourlyEmployee arrItem in hourly_Employee)
                    {

                        table.AddRow(
                            arrItem.EmployeeId,
                            arrItem.EmployeeName,
                            arrItem.EmployeeType,
                            arrItem.HoursWorked,
                            arrItem.HoursWage.ToString("C2"),
                            arrItem.GrossEarnings.ToString("C2"),
                            arrItem.Tax.ToString("C2"),
                            arrItem.NetEarnings.ToString("C2")
                        );

                    }

                    table.Write();

                    Console.WriteLine("\nEdited Employee !!!");
                }

                Console.WriteLine("\n\n\n\n");

                Print_Menu();

            }

            // Edit commission employee

            else if (employeeType == EmployeeType.Commission_Employee)
            {
                // Back to manu if it had nothing on the list

                if (!commission_Employee.Any())
                {
                    Console.WriteLine("\nNothing on this list");

                    Console.WriteLine("\n\n\n\n");

                    Print_Menu();
                }

                // Print commission employee 

                Console.WriteLine("\n View Commission Emplyee: \n");

                var table = new ConsoleTable("ID", "Name", "Employee Type", "Gross Sale", "Commission Rate", "Gross Earnings", "Tax", "Net Earnings");

                foreach (CommissionEmployee arrItem in commission_Employee)
                {

                    table.AddRow(
                        arrItem.EmployeeId,
                        arrItem.EmployeeName,
                        arrItem.EmployeeType,
                        arrItem.GrossSale.ToString("C2"),
                        arrItem.CommissionRate.ToString("P"),
                        arrItem.GrossEarnings.ToString("C2"),
                        arrItem.Tax.ToString("C2"),
                        arrItem.NetEarnings.ToString("C2")
                    );

                }

                table.Write();

                Console.WriteLine("\n\n");

                // Get id you want to edit

                Console.Write("\nEnter employee id: ");

                int editId;

                bool isValid = int.TryParse(Console.ReadLine(), out editId);

                if (!isValid)
                {
                    while (!isValid)
                    {
                        Console.Write("Invalid Input. Do it again:  ");
                        isValid = int.TryParse(Console.ReadLine(), out editId);
                    }
                }

                var editEmployeeArr = from employee in commission_Employee
                                      where employee.EmployeeId == editId
                                      select employee;

                Console.WriteLine("\n");

                // edit id 

                if (!editEmployeeArr.Any())
                {

                    while (!editEmployeeArr.Any())
                    {
                        Console.WriteLine("\nEntered id is not in the list. Try again: ");
                        isValid = int.TryParse(Console.ReadLine(), out editId);
                    }

                    // Get new info

                    Console.WriteLine("\n\nEnter employee name: ");
                    string empName = Console.ReadLine();

                    Console.WriteLine("\n\nEnter gross sale: ");
                    double gross_sale;
                    isValid = double.TryParse(Console.ReadLine(), out gross_sale);
                    if (!isValid || gross_sale < 0)
                    {
                        while (!isValid || gross_sale < 0)
                        {
                            Console.Write("Invalid Input. Do it again:  ");
                            isValid = double.TryParse(Console.ReadLine(), out gross_sale);
                        }
                    }

                    Console.WriteLine("\n\nEnter commission rate: ");
                    double commission_rate;
                    isValid = double.TryParse(Console.ReadLine(), out commission_rate);
                    if (!isValid || commission_rate < 0)
                    {
                        while (!isValid || commission_rate < 0)
                        {
                            Console.Write("Invalid Input. Do it again:  ");
                            isValid = double.TryParse(Console.ReadLine(), out commission_rate);
                        }
                    }

                    // Change info

                    CommissionEmployee editEmployee = (CommissionEmployee)editEmployeeArr.First();
                    editEmployee.EmployeeName = empName;
                    editEmployee.GrossSale = gross_sale;
                    editEmployee.CommissionRate = commission_rate;

                    // Print commission employee 

                    Console.WriteLine("\nView Commission Emplyee: \n");

                    table = new ConsoleTable("ID", "Name", "Employee Type", "Gross Sale", "Commission Rate", "Gross Earnings", "Tax", "Net Earnings");

                    foreach (CommissionEmployee arrItem in commission_Employee)
                    {

                        table.AddRow(
                            arrItem.EmployeeId,
                            arrItem.EmployeeName,
                            arrItem.EmployeeType,
                            arrItem.GrossSale.ToString("C2"),
                            arrItem.CommissionRate.ToString("P"),
                            arrItem.GrossEarnings.ToString("C2"),
                            arrItem.Tax.ToString("C2"),
                            arrItem.NetEarnings.ToString("C2")
                        );

                    }

                    table.Write();

                    Console.WriteLine("\n\n");

                    Console.WriteLine("Edited Employee !!!");

                }
                else
                {
                    // Get new info

                    Console.WriteLine("\n\nEnter employee name: ");
                    string empName = Console.ReadLine();

                    Console.WriteLine("\n\nEnter gross sale: ");
                    double gross_sale;
                    isValid = double.TryParse(Console.ReadLine(), out gross_sale);
                    if (!isValid || gross_sale < 0)
                    {
                        while (!isValid || gross_sale < 0)
                        {
                            Console.Write("Invalid Input. Do it again:  ");
                            isValid = double.TryParse(Console.ReadLine(), out gross_sale);
                        }
                    }

                    Console.WriteLine("\n\nEnter commission rate: ");
                    double commission_rate;
                    isValid = double.TryParse(Console.ReadLine(), out commission_rate);
                    if (!isValid || commission_rate < 0)
                    {
                        while (!isValid || commission_rate < 0)
                        {
                            Console.Write("Invalid Input. Do it again:  ");
                            isValid = double.TryParse(Console.ReadLine(), out commission_rate);
                        }
                    }

                    // Change info

                    CommissionEmployee editEmployee = (CommissionEmployee)editEmployeeArr.First();
                    editEmployee.EmployeeName = empName;
                    editEmployee.GrossSale = gross_sale;
                    editEmployee.CommissionRate = commission_rate;

                    // Print commission employee 

                    Console.WriteLine("\nView Commission Emplyee: \n");

                    table = new ConsoleTable("ID", "Name", "Employee Type", "Gross Sale", "Commission Rate", "Gross Earnings", "Tax", "Net Earnings");

                    foreach (CommissionEmployee arrItem in commission_Employee)
                    {

                        table.AddRow(
                            arrItem.EmployeeId,
                            arrItem.EmployeeName,
                            arrItem.EmployeeType,
                            arrItem.GrossSale.ToString("C2"),
                            arrItem.CommissionRate,
                            arrItem.GrossEarnings.ToString("C2"),
                            arrItem.Tax.ToString("C2"),
                            arrItem.NetEarnings.ToString("C2")
                        );

                    }

                    table.Write();

                    Console.WriteLine("\n\n");

                    Console.WriteLine("Edited Employee !!!");
                }

                Console.WriteLine("\n\n\n\n");

                Print_Menu();
            }

            // Edit salary employee

            else if (employeeType == EmployeeType.Salaried_Employee)
            {
                // Back to manu if it had nothing on the list

                if (!salaried_Employee.Any())
                {
                    Console.WriteLine("\nNothing on this list");

                    Console.WriteLine("\n\n\n\n");

                    Print_Menu();
                }

                // Print all employee 

                Console.WriteLine("\n View Salary Emplyee: \n");

                var table = new ConsoleTable("ID", "Name", "Employee Type", "Fixed Weekly Salary", "Gross Earnings", "Tax", "Net Earnings");

                foreach (SalariedEmployee arrItem in salaried_Employee)
                {

                    table.AddRow(
                        arrItem.EmployeeId,
                        arrItem.EmployeeName,
                        arrItem.EmployeeType,
                        arrItem.FixedWeeklySalary.ToString("C2"),
                        arrItem.GrossEarnings.ToString("C2"),
                        arrItem.Tax.ToString("C2"),
                        arrItem.NetEarnings.ToString("C2")
                    );

                }

                table.Write();

                Console.WriteLine("\n\n");

                // Get id you want to edit

                Console.Write("\nEnter employee id: ");

                int editId;

                bool isValid = int.TryParse(Console.ReadLine(), out editId);

                if (!isValid)
                {
                    while (!isValid)
                    {
                        Console.Write("Invalid Input. Do it again:  ");
                        isValid = int.TryParse(Console.ReadLine(), out editId);
                    }
                }

                var editEmployeeArr = from employee in salaried_Employee
                                      where employee.EmployeeId == editId
                                      select employee;

                Console.WriteLine("\n");

                // edit id 

                if (!editEmployeeArr.Any())
                {

                    while (!editEmployeeArr.Any())
                    {
                        Console.WriteLine("\nEntered id is not in the list. Try again: ");
                        isValid = int.TryParse(Console.ReadLine(), out editId);
                    }

                    // Get new info

                    Console.WriteLine("\n\nEnter employee name: ");
                    string empName = Console.ReadLine();

                    Console.WriteLine("\n\nEnter Fixed Weekly Salary: ");
                    double fixed_Weekly_Salary;
                    isValid = double.TryParse(Console.ReadLine(), out fixed_Weekly_Salary);
                    if (!isValid || fixed_Weekly_Salary < 0)
                    {
                        while (!isValid || fixed_Weekly_Salary < 0)
                        {
                            Console.Write("Invalid Input. Do it again:  ");
                            isValid = double.TryParse(Console.ReadLine(), out fixed_Weekly_Salary);
                        }
                    }

                    // Change info

                    SalariedEmployee editEmployee = (SalariedEmployee)editEmployeeArr.First();
                    editEmployee.EmployeeName = empName;
                    editEmployee.FixedWeeklySalary = fixed_Weekly_Salary;

                    // Print all employee 

                    Console.WriteLine("\nView Salary Emplyee: \n");

                    table = new ConsoleTable("ID", "Name", "Employee Type", "Fixed Weekly Salary", "Gross Earnings", "Tax", "Net Earnings");

                    foreach (SalariedEmployee arrItem in salaried_Employee)
                    {

                        table.AddRow(
                            arrItem.EmployeeId,
                            arrItem.EmployeeName,
                            arrItem.EmployeeType,
                            arrItem.FixedWeeklySalary.ToString("C2"),
                            arrItem.GrossEarnings.ToString("C2"),
                            arrItem.Tax.ToString("C2"),
                            arrItem.NetEarnings.ToString("C2")
                        );

                    }

                    table.Write();

                    Console.WriteLine("\n\n");

                    Console.WriteLine("Edited Employee !!!");

                }
                else
                {
                    // Get new info

                    Console.WriteLine("\n\nEnter employee name: ");
                    string empName = Console.ReadLine();

                    Console.WriteLine("\n\nEnter Fixed Weekly Salary: ");
                    double fixed_Weekly_Salary;
                    isValid = double.TryParse(Console.ReadLine(), out fixed_Weekly_Salary);
                    if (!isValid || fixed_Weekly_Salary < 0)
                    {
                        while (!isValid || fixed_Weekly_Salary < 0)
                        {
                            Console.Write("Invalid Input. Do it again:  ");
                            isValid = double.TryParse(Console.ReadLine(), out fixed_Weekly_Salary);
                        }
                    }

                    // Change info

                    SalariedEmployee editEmployee = (SalariedEmployee)editEmployeeArr.First();
                    editEmployee.EmployeeName = empName;
                    editEmployee.FixedWeeklySalary = fixed_Weekly_Salary;

                    // Print all employee 

                    Console.WriteLine("\nView Salary Emplyee: \n");

                    table = new ConsoleTable("ID", "Name", "Employee Type", "Fixed Weekly Salary", "Gross Earnings", "Tax", "Net Earnings");

                    foreach (SalariedEmployee arrItem in salaried_Employee)
                    {

                        table.AddRow(
                            arrItem.EmployeeId,
                            arrItem.EmployeeName,
                            arrItem.EmployeeType,
                            arrItem.FixedWeeklySalary.ToString("C2"),
                            arrItem.GrossEarnings.ToString("C2"),
                            arrItem.Tax.ToString("C2"),
                            arrItem.NetEarnings.ToString("C2")
                        );

                    }

                    table.Write();

                    Console.WriteLine("\n\n");

                    Console.WriteLine("Edited Employee !!!");
                }

                Console.WriteLine("\n\n\n\n");

                Print_Menu();
            }

            // Edit salary commission employee

            else if (employeeType == EmployeeType.Salary_Plus_Commission_Employee)
            {
                // Back to manu if it had nothing on the list

                if (!salary_commission_Employee.Any())
                {
                    Console.WriteLine("\nNothing on this list");

                    Console.WriteLine("\n\n\n\n");

                    Print_Menu();
                }

                // Print all employee 

                Console.WriteLine("\n View Salary plus Commission Employee: \n");

                var table = new ConsoleTable("ID", "Name", "Employee Type", "Fixed Weekly Salary", "Gross Earnings", "Tax", "Net Earnings");

                foreach (SalaryPlusCommissionEmployee arrItem in salary_commission_Employee)
                {

                    table.AddRow(
                        //salary_commission_Employee.IndexOf(arrItem),
                        arrItem.EmployeeId,
                        arrItem.EmployeeName,
                        arrItem.EmployeeType,
                        //arrItem.grossSale,
                        //"Gross Sale", "Commission Rate",
                        arrItem.FixedWeeklySalary.ToString("C2"),
                        arrItem.GrossEarnings.ToString("C2"),
                        arrItem.Tax.ToString("C2"),
                        arrItem.NetEarnings.ToString("C2")
                    );
                }

                table.Write();

                Console.WriteLine("\n\n");

                // Get id you want to edit

                Console.Write("\nEnter employee id: ");

                int editId;

                bool isValid = int.TryParse(Console.ReadLine(), out editId);

                if (!isValid)
                {
                    while (!isValid)
                    {
                        Console.Write("Invalid Input. Do it again:  ");
                        isValid = int.TryParse(Console.ReadLine(), out editId);
                    }
                }

                var editEmployeeArr = from employee in salary_commission_Employee
                                      where employee.EmployeeId == editId
                                      select employee;

                Console.WriteLine("\n");

                // edit id 

                if (!editEmployeeArr.Any())
                {

                    while (!editEmployeeArr.Any())
                    {
                        Console.WriteLine("\nEntered id is not in the list. Try again: ");
                        isValid = int.TryParse(Console.ReadLine(), out editId);
                    }

                    // Get new info

                    Console.WriteLine("\n\nEnter employee name: ");
                    string empName = Console.ReadLine();

                    Console.WriteLine("\n\nEnter gross sale: ");
                    double gross_sale;
                    isValid = double.TryParse(Console.ReadLine(), out gross_sale);
                    if (!isValid || gross_sale < 0)
                    {
                        while (!isValid || gross_sale < 0)
                        {
                            Console.Write("Invalid Input. Do it again:  ");
                            isValid = double.TryParse(Console.ReadLine(), out gross_sale);
                        }
                    }

                    Console.WriteLine("\n\nEnter commission rate: ");
                    double commission_rate;
                    isValid = double.TryParse(Console.ReadLine(), out commission_rate);
                    if (!isValid || commission_rate < 0)
                    {
                        while (!isValid || commission_rate < 0)
                        {
                            Console.Write("Invalid Input. Do it again:  ");
                            isValid = double.TryParse(Console.ReadLine(), out commission_rate);
                        }
                    }

                    Console.WriteLine("\n\nEnter Fixed Weekly Salary: ");
                    double fixed_Weekly_Salary;
                    isValid = double.TryParse(Console.ReadLine(), out fixed_Weekly_Salary);
                    if (!isValid || fixed_Weekly_Salary < 0)
                    {
                        while (!isValid || fixed_Weekly_Salary < 0)
                        {
                            Console.Write("Invalid Input. Do it again:  ");
                            isValid = double.TryParse(Console.ReadLine(), out fixed_Weekly_Salary);
                        }
                    }

                    // Change info

                    SalaryPlusCommissionEmployee editEmployee = (SalaryPlusCommissionEmployee)editEmployeeArr.First();
                    editEmployee.EmployeeName = empName;
                    editEmployee.GrossSale = gross_sale;
                    editEmployee.CommissionRate = commission_rate;
                    editEmployee.FixedWeeklySalary = fixed_Weekly_Salary;

                    // Print all employee 

                    Console.WriteLine("\n View Salary plus Commission Employee: \n");

                    table = new ConsoleTable("ID", "Name", "Employee Type", "Fixed Weekly Salary", "Gross Earnings", "Tax", "Net Earnings");

                    foreach (SalaryPlusCommissionEmployee arrItem in salary_commission_Employee)
                    {

                        table.AddRow(
                            //salary_commission_Employee.IndexOf(arrItem),
                            arrItem.EmployeeId,
                            arrItem.EmployeeName,
                            arrItem.EmployeeType,
                            //arrItem.grossSale,
                            //"Gross Sale", "Commission Rate",
                            arrItem.FixedWeeklySalary.ToString("C2"),
                            arrItem.GrossEarnings.ToString("C2"),
                            arrItem.Tax.ToString("C2"),
                            arrItem.NetEarnings.ToString("C2")
                        );
                    }

                    table.Write();

                    Console.WriteLine("\n\n");

                    Console.WriteLine("Edited Employee !!!");

                }
                else
                {
                    // Get new info

                    Console.WriteLine("\n\nEnter employee name: ");
                    string empName = Console.ReadLine();

                    Console.WriteLine("\n\nEnter gross sale: ");
                    double gross_sale;
                    isValid = double.TryParse(Console.ReadLine(), out gross_sale);
                    if (!isValid || gross_sale < 0)
                    {
                        while (!isValid || gross_sale < 0)
                        {
                            Console.Write("Invalid Input. Do it again:  ");
                            isValid = double.TryParse(Console.ReadLine(), out gross_sale);
                        }
                    }

                    Console.WriteLine("\n\nEnter commission rate: ");
                    double commission_rate;
                    isValid = double.TryParse(Console.ReadLine(), out commission_rate);
                    if (!isValid || commission_rate < 0)
                    {
                        while (!isValid || commission_rate < 0)
                        {
                            Console.Write("Invalid Input. Do it again:  ");
                            isValid = double.TryParse(Console.ReadLine(), out commission_rate);
                        }
                    }

                    Console.WriteLine("\n\nEnter Fixed Weekly Salary: ");
                    double fixed_Weekly_Salary;
                    isValid = double.TryParse(Console.ReadLine(), out fixed_Weekly_Salary);
                    if (!isValid || fixed_Weekly_Salary < 0)
                    {
                        while (!isValid || fixed_Weekly_Salary < 0)
                        {
                            Console.Write("Invalid Input. Do it again:  ");
                            isValid = double.TryParse(Console.ReadLine(), out fixed_Weekly_Salary);
                        }
                    }

                    // Change info

                    SalaryPlusCommissionEmployee editEmployee = (SalaryPlusCommissionEmployee)editEmployeeArr.First();
                    editEmployee.EmployeeName = empName;
                    editEmployee.GrossSale = gross_sale;
                    editEmployee.CommissionRate = commission_rate;
                    editEmployee.FixedWeeklySalary = fixed_Weekly_Salary;

                    // Print all employee 

                    Console.WriteLine("\n View Salary plus Commission Employee: \n");

                    table = new ConsoleTable("ID", "Name", "Employee Type", "Fixed Weekly Salary", "Gross Earnings", "Tax", "Net Earnings");

                    foreach (SalaryPlusCommissionEmployee arrItem in salary_commission_Employee)
                    {

                        table.AddRow(
                            //salary_commission_Employee.IndexOf(arrItem),
                            arrItem.EmployeeId,
                            arrItem.EmployeeName,
                            arrItem.EmployeeType,
                            //arrItem.grossSale,
                            //"Gross Sale", "Commission Rate",
                            arrItem.FixedWeeklySalary.ToString("C2"),
                            arrItem.GrossEarnings.ToString("C2"),
                            arrItem.Tax.ToString("C2"),
                            arrItem.NetEarnings.ToString("C2")
                        );
                    }

                    table.Write();

                    Console.WriteLine("\n\n");

                    Console.WriteLine("Edited Employee !!!");
                }

                Console.WriteLine("\n\n\n\n");

                Print_Menu();
            }
        }

        // Add Employee Function
        static void AddEmployee(EmployeeType employeeType)
        {

            id += 1;

            // Add hourly employee

            if(employeeType == EmployeeType.Hourly_Employee)
            {
                // Get and check input of hourly employee

                Console.WriteLine("\n\nEnter employee name: ");
                string empName = Console.ReadLine();

                Console.WriteLine("\n\nEnter hours worked: ");
                double hourWorked;
                bool isValid =  double.TryParse(Console.ReadLine(), out hourWorked);
                if (!isValid || hourWorked < 0)
                {
                    while (!isValid || hourWorked < 0)
                    {
                        Console.Write("Invalid Input. Do it again:  ");
                        isValid = double.TryParse(Console.ReadLine(), out hourWorked);
                    }
                }

                Console.WriteLine("\n\nEnter hours wage: ");
                double hourWage;
                isValid = double.TryParse(Console.ReadLine(), out hourWage);
                if (!isValid || hourWage < 0)
                {
                    while (!isValid || hourWage < 0)
                    {
                        Console.Write("Invalid Input. Do it again:  ");
                        isValid = double.TryParse(Console.ReadLine(), out hourWage);
                    }
                }

                // Add employee to the list of hourly employee

                HourlyEmployee newEmp = new HourlyEmployee(hourWorked, hourWage);
                newEmp.EmployeeId = id;
                newEmp.EmployeeName = empName;
                newEmp.EmployeeType = "Hourly Employee";

                hourly_Employee.Add(newEmp);

                Console.WriteLine("\n\n Add successfully !\n\n");

                // Print all employee 

                Console.WriteLine("\n View Hourly Emplyee: \n");

                var table = new ConsoleTable("ID", "Name", "Employee Type", "Hours Worked", "Hours Wage", "Gross Earnings", "Tax", "Net Earnings");

                foreach (HourlyEmployee arrItem in hourly_Employee)
                {

                    table.AddRow(
                        arrItem.EmployeeId,
                        arrItem.EmployeeName, 
                        arrItem.EmployeeType, 
                        arrItem.HoursWorked,
                        arrItem.HoursWage.ToString("C2"),
                        arrItem.GrossEarnings.ToString("C2"),
                        arrItem.Tax.ToString("C2"),
                        arrItem.NetEarnings.ToString("C2")
                    );

                }

                table.Write();

                Console.WriteLine("\n\n");

                Print_Menu();

            } 

            // Add commission employee

            else if (employeeType == EmployeeType.Commission_Employee)
            {

                // Get and check input of hourly employee

                Console.WriteLine("\n\nEnter employee name: ");
                string empName = Console.ReadLine();

                Console.WriteLine("\n\nEnter gross sale: ");
                double gross_sale;
                bool isValid = double.TryParse(Console.ReadLine(), out gross_sale);
                if (!isValid || gross_sale < 0)
                {
                    while (!isValid || gross_sale < 0)
                    {
                        Console.Write("Invalid Input. Do it again:  ");
                        isValid = double.TryParse(Console.ReadLine(), out gross_sale);
                    }
                }

                Console.WriteLine("\n\nEnter commission rate: ");
                double commission_rate;
                isValid = double.TryParse(Console.ReadLine(), out commission_rate);
                if (!isValid || commission_rate < 0)
                {
                    while (!isValid || commission_rate < 0)
                    {
                        Console.Write("Invalid Input. Do it again:  ");
                        isValid = double.TryParse(Console.ReadLine(), out commission_rate);
                    }
                }

                // Add employee to the list of hourly employee

                CommissionEmployee newEmp = new CommissionEmployee(gross_sale, commission_rate);
                newEmp.EmployeeId = id;
                newEmp.EmployeeName = empName;
                newEmp.EmployeeType = "Commission Employee";

                commission_Employee.Add(newEmp);

                Console.WriteLine("\n\n Add successfully !\n\n");

                // Print all employee 

                Console.WriteLine("\n View Commission Emplyee: \n");

                var table = new ConsoleTable("ID", "Name", "Employee Type", "Gross Sale", "Commission Rate", "Gross Earnings", "Tax", "Net Earnings");

                foreach (CommissionEmployee arrItem in commission_Employee)
                {

                    table.AddRow(
                        arrItem.EmployeeId,
                        arrItem.EmployeeName,
                        arrItem.EmployeeType,
                        arrItem.GrossSale.ToString("C2"),
                        arrItem.CommissionRate.ToString("P"),
                        arrItem.GrossEarnings.ToString("C2"),
                        arrItem.Tax.ToString("C2"),
                        arrItem.NetEarnings.ToString("C2")
                    );

                }

                table.Write();

                Console.WriteLine("\n\n");

                Print_Menu();

            }

            // Add salary employee

            else if (employeeType == EmployeeType.Salaried_Employee)
            {

                // Get and check input of hourly employee

                Console.WriteLine("\n\nEnter employee name: ");
                string empName = Console.ReadLine();

                Console.WriteLine("\n\nEnter Fixed Weekly Salary: ");
                double fixed_Weekly_Salary;
                bool isValid = double.TryParse(Console.ReadLine(), out fixed_Weekly_Salary);
                if (!isValid || fixed_Weekly_Salary < 0)
                {
                    while (!isValid || fixed_Weekly_Salary < 0)
                    {
                        Console.Write("Invalid Input. Do it again:  ");
                        isValid = double.TryParse(Console.ReadLine(), out fixed_Weekly_Salary);
                    }
                }

                // Add employee to the list of hourly employee

                SalariedEmployee newEmp = new SalariedEmployee(fixed_Weekly_Salary);
                newEmp.EmployeeId = id;
                newEmp.EmployeeName = empName;
                newEmp.EmployeeType = "Salaried Employee";

                salaried_Employee.Add(newEmp);

                Console.WriteLine("\n\n Add successfully !\n\n");

                // Print all employee 

                Console.WriteLine("\n View Salary Emplyee: \n");

                var table = new ConsoleTable("ID", "Name", "Employee Type", "Fixed Weekly Salary", "Gross Earnings", "Tax", "Net Earnings");

                foreach (SalariedEmployee arrItem in salaried_Employee)
                {

                    table.AddRow(
                        arrItem.EmployeeId,
                        arrItem.EmployeeName,
                        arrItem.EmployeeType,
                        arrItem.FixedWeeklySalary.ToString("C2"),
                        arrItem.GrossEarnings.ToString("C2"),
                        arrItem.Tax.ToString("C2"),
                        arrItem.NetEarnings.ToString("C2")
                    );

                }

                table.Write();

                Console.WriteLine("\n\n");

                Print_Menu();

            }

            // Add Salary Commission Employee

            else if (employeeType == EmployeeType.Salary_Plus_Commission_Employee)
            {

                // Get and check input of salary commission employee

                Console.WriteLine("\n\nEnter employee name: ");
                string empName = Console.ReadLine();

                Console.WriteLine("\n\nEnter gross sale: ");
                double gross_sale;
                bool isValid = double.TryParse(Console.ReadLine(), out gross_sale);
                if (!isValid || gross_sale < 0)
                {
                    while (!isValid || gross_sale < 0)
                    {
                        Console.Write("Invalid Input. Do it again:  ");
                        isValid = double.TryParse(Console.ReadLine(), out gross_sale);
                    }
                }

                Console.WriteLine("\n\nEnter commission rate: ");
                double commission_rate;
                isValid = double.TryParse(Console.ReadLine(), out commission_rate);
                if (!isValid || commission_rate < 0)
                {
                    while (!isValid || commission_rate < 0)
                    {
                        Console.Write("Invalid Input. Do it again:  ");
                        isValid = double.TryParse(Console.ReadLine(), out commission_rate);
                    }
                }

                Console.WriteLine("\n\nEnter Fixed Weekly Salary: ");
                double fixed_Weekly_Salary;
                isValid = double.TryParse(Console.ReadLine(), out fixed_Weekly_Salary);
                if (!isValid || fixed_Weekly_Salary < 0)
                {
                    while (!isValid || fixed_Weekly_Salary < 0)
                    {
                        Console.Write("Invalid Input. Do it again:  ");
                        isValid = double.TryParse(Console.ReadLine(), out fixed_Weekly_Salary);
                    }
                }

                // Add employee to the list of hourly employee

                SalaryPlusCommissionEmployee newEmp = new SalaryPlusCommissionEmployee(gross_sale, commission_rate, fixed_Weekly_Salary);
                newEmp.EmployeeId = id;
                newEmp.EmployeeName = empName;
                newEmp.EmployeeType = "Salary plus Commission Employee";

                salary_commission_Employee.Add(newEmp);

                Console.WriteLine("\n\n Add successfully !\n\n");

                // Print all employee 

                Console.WriteLine("\n View Salary plus Commission Employee: \n");

                var table = new ConsoleTable("ID", "Name", "Employee Type", "Fixed Weekly Salary", "Gross Earnings", "Tax", "Net Earnings");

                foreach (SalaryPlusCommissionEmployee arrItem in salary_commission_Employee)
                {

                    table.AddRow(
                        arrItem.EmployeeId,
                        arrItem.EmployeeName,
                        arrItem.EmployeeType,
                        //arrItem.grossSale,
                        //"Gross Sale", "Commission Rate",
                        arrItem.FixedWeeklySalary.ToString("C2"),
                        arrItem.GrossEarnings.ToString("C2"),
                        arrItem.Tax.ToString("C2"),
                        arrItem.NetEarnings.ToString("C2")
                    );
                }

                table.Write();

                Console.WriteLine("\n\n");

                Print_Menu();

            }
        }
    }
}