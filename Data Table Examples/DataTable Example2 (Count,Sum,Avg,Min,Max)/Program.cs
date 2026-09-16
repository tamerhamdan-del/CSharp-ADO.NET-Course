using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTable_Example2__Count_Sum_Avg_Min_Max_
{
    internal class Program
    {
        static void Main(string[] args)
        {


            DataTable EmployeesDataTable = new DataTable();

            EmployeesDataTable.Columns.Add("ID", typeof(int));
            EmployeesDataTable.Columns.Add("Name", typeof(string));
            EmployeesDataTable.Columns.Add("Country", typeof(string));
            EmployeesDataTable.Columns.Add("Salary", typeof(Double));
            EmployeesDataTable.Columns.Add("DateOfBirth", typeof(DateTime));


            EmployeesDataTable.Rows.Add(1, "Tamer Hamdan", "Nablus", 3000, DateTime.Now);
            EmployeesDataTable.Rows.Add(2, "Ahmad Ali", "Jenin", 6000, DateTime.Now);
            EmployeesDataTable.Rows.Add(3, "Maher Khalid", "Salem", 4000, DateTime.Now);
            EmployeesDataTable.Rows.Add(4, "Amr Yousef", "Israil", 5000, DateTime.Now);
            EmployeesDataTable.Rows.Add(5, "Yahya Dwikat", "Nablus", 8000, DateTime.Now);


            Console.WriteLine("\nEmployees List:\n\n");

            foreach (DataRow Record in EmployeesDataTable.Rows)
            {
                Console.WriteLine("ID : {0}\t Name : {1}\t Country : {2}\t Salary : {3}\t DateOfBirth : {4}\n", Record["ID"], Record["Name"], Record["Country"], Record["Salary"], Record["DateOfBirth"]);
            }


            int EmployeesCount = 0;
            double TotalSalaries = 0;
            double AverageSalary = 0;
            double MinimumSalary = 0;
            double MaximumSalary = 0;


            EmployeesCount=EmployeesDataTable.Rows.Count;
            TotalSalaries =Convert.ToDouble( EmployeesDataTable.Compute("SUM(Salary)", string.Empty));
            AverageSalary = Convert.ToDouble(EmployeesDataTable.Compute("AVG(Salary)", string.Empty));
            MinimumSalary = Convert.ToDouble(EmployeesDataTable.Compute("MIN(Salary)", string.Empty));
            MaximumSalary = Convert.ToDouble(EmployeesDataTable.Compute("MAX(Salary)", string.Empty));

            Console.WriteLine("\nCount Of Employees = " + EmployeesCount);
            Console.WriteLine("Total Employees Salaries= " + TotalSalaries);
            Console.WriteLine("Average Employees Salaries= " + AverageSalary);
            Console.WriteLine("Minimum Employees Salary= " + MinimumSalary);
            Console.WriteLine("Maximum Employees Salary= " + MaximumSalary);








        }
    }
}
