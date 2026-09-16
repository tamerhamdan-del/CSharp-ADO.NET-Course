using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTable_Example3_Filter_Data_
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


            EmployeesCount = EmployeesDataTable.Rows.Count;
            TotalSalaries = Convert.ToDouble(EmployeesDataTable.Compute("SUM(Salary)", string.Empty));
            AverageSalary = Convert.ToDouble(EmployeesDataTable.Compute("AVG(Salary)", string.Empty));
            MinimumSalary = Convert.ToDouble(EmployeesDataTable.Compute("MIN(Salary)", string.Empty));
            MaximumSalary = Convert.ToDouble(EmployeesDataTable.Compute("MAX(Salary)", string.Empty));

            Console.WriteLine("\nCount Of Employees = " + EmployeesCount);
            Console.WriteLine("Total Employees Salaries= " + TotalSalaries);
            Console.WriteLine("Average Employees Salaries= " + AverageSalary);
            Console.WriteLine("Minimum Employees Salary= " + MinimumSalary);
            Console.WriteLine("Maximum Employees Salary= " + MaximumSalary);



            DataRow[] ResultRows;

            ResultRows = EmployeesDataTable.Select("Country='Nablus'");

            Console.WriteLine("\n\nFilter\"Nablus\"Employees\n");

            foreach(DataRow ResultRow in ResultRows)
            {
                Console.WriteLine("ID : {0}\t Name : {1}\t Country : {2}\t Salary : {3}\t DateOfBirth : {4}\n", ResultRow["ID"], ResultRow["Name"], ResultRow["Country"], ResultRow["Salary"], ResultRow["DateOfBirth"]);
            }


            EmployeesCount = ResultRows.Count();
            TotalSalaries = Convert.ToDouble(EmployeesDataTable.Compute("SUM(Salary)", "Country='Nablus'"));
            AverageSalary = Convert.ToDouble(EmployeesDataTable.Compute("AVG(Salary)", "Country = 'Nablus'"));
            MinimumSalary = Convert.ToDouble(EmployeesDataTable.Compute("MIN(Salary)", "Country = 'Nablus'"));
            MaximumSalary = Convert.ToDouble(EmployeesDataTable.Compute("MAX(Salary)", "Country = 'Nablus'"));

            Console.WriteLine("\nCount Of Employees = " + EmployeesCount);
            Console.WriteLine("Total Employees Salaries= " + TotalSalaries);
            Console.WriteLine("Average Employees Salaries= " + AverageSalary);
            Console.WriteLine("Minimum Employees Salary= " + MinimumSalary);
            Console.WriteLine("Maximum Employees Salary= " + MaximumSalary);










            ResultRows = EmployeesDataTable.Select("Country='Nablus' or Country='Jenin'");

            Console.WriteLine("\n\nFilter\"Nablus or Jenin\"Employees\n");

            foreach (DataRow ResultRow in ResultRows)
            {
                Console.WriteLine("ID : {0}\t Name : {1}\t Country : {2}\t Salary : {3}\t DateOfBirth : {4}\n", ResultRow["ID"], ResultRow["Name"], ResultRow["Country"], ResultRow["Salary"], ResultRow["DateOfBirth"]);
            }


            EmployeesCount = ResultRows.Count();
            TotalSalaries = Convert.ToDouble(EmployeesDataTable.Compute("SUM(Salary)", "Country='Nablus' or Country='Jenin'"));
            AverageSalary = Convert.ToDouble(EmployeesDataTable.Compute("AVG(Salary)", "Country = 'Nablus' or Country='Jenin'"));
            MinimumSalary = Convert.ToDouble(EmployeesDataTable.Compute("MIN(Salary)", "Country = 'Nablus' or Country='Jenin'"));
            MaximumSalary = Convert.ToDouble(EmployeesDataTable.Compute("MAX(Salary)", "Country = 'Nablus' or Country='Jenin'"));

            Console.WriteLine("\nCount Of Employees = " + EmployeesCount);
            Console.WriteLine("Total Employees Salaries= " + TotalSalaries);
            Console.WriteLine("Average Employees Salaries= " + AverageSalary);
            Console.WriteLine("Minimum Employees Salary= " + MinimumSalary);
            Console.WriteLine("Maximum Employees Salary= " + MaximumSalary);




            ResultRows = EmployeesDataTable.Select("ID=1");

            Console.WriteLine("\n\nFilter Employee With ID=1\n\n");

            foreach (DataRow ResultRow in ResultRows)
            {
                Console.WriteLine("ID : {0}\t Name : {1}\t Country : {2}\t Salary : {3}\t DateOfBirth : {4}\n", ResultRow["ID"], ResultRow["Name"], ResultRow["Country"], ResultRow["Salary"], ResultRow["DateOfBirth"]);
            }


            EmployeesCount = ResultRows.Count();
            TotalSalaries = Convert.ToDouble(EmployeesDataTable.Compute("SUM(Salary)", "ID = 1"));
            AverageSalary = Convert.ToDouble(EmployeesDataTable.Compute("AVG(Salary)", "ID = 1"));
            MinimumSalary = Convert.ToDouble(EmployeesDataTable.Compute("MIN(Salary)", "ID = 1"));
            MaximumSalary = Convert.ToDouble(EmployeesDataTable.Compute("MAX(Salary)", "ID = 1"));

            Console.WriteLine("\nCount Of Employees = " + EmployeesCount);
            Console.WriteLine("Total Employees Salaries= " + TotalSalaries);
            Console.WriteLine("Average Employees Salaries= " + AverageSalary);
            Console.WriteLine("Minimum Employees Salary= " + MinimumSalary);
            Console.WriteLine("Maximum Employees Salary= " + MaximumSalary);







        }
    }
}
