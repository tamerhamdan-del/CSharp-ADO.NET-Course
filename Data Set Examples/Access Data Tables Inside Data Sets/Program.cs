using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access_Data_Tables_Inside_Data_Sets
{
    internal class Program
    {
        static void Main(string[] args)
        {


            DataTable EmployeesDataTable = new DataTable("EmployeesDataTable");

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



            DataTable DepartmentsDataTable = new DataTable("DepartmentsDataTable");
            DepartmentsDataTable.Columns.Add("DepartmentID", typeof(int));
            DepartmentsDataTable.Columns.Add("DepartmentName", typeof(string));

            DepartmentsDataTable.Rows.Add(1, "HR");
            DepartmentsDataTable.Rows.Add(2, "IT");
            DepartmentsDataTable.Rows.Add(1, "Marketing");




           

            DataSet DataSet1 = new DataSet();

            DataSet1.Tables.Add(EmployeesDataTable);
            DataSet1.Tables.Add(DepartmentsDataTable);


            Console.WriteLine("\nEmployees List From Data Set :\n\n");

            foreach (DataRow Record in DataSet1.Tables["EmployeesDataTable"].Rows)
            {

                Console.WriteLine("ID : {0}\t Name : {1}\t Country : {2}\t Salary : {3}\t DateOfBirth : {4}\n", Record["ID"], Record["Name"], Record["Country"], Record["Salary"], Record["DateOfBirth"]);
            }



            Console.WriteLine("\nDepartments List From Data Set :\n\n");

            foreach (DataRow Record in DataSet1.Tables["DepartmentsDataTable"].Rows)
            {
                Console.WriteLine("ID : {0}\t Name : {1}\n", Record["DepartmentID"], Record["DepartmentName"]);
            }
        }
    }
}
