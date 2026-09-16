using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Create_Data_Set
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



            DataTable DepartmentsDataTable=new DataTable();
            DepartmentsDataTable.Columns.Add("DepartmentID", typeof(int));
            DepartmentsDataTable.Columns.Add("DepartmentName", typeof(string));

            DepartmentsDataTable.Rows.Add(1, "HR");
            DepartmentsDataTable.Rows.Add(2, "IT");
            DepartmentsDataTable.Rows.Add(1, "Marketing");




            Console.WriteLine("\nEmployees List:\n\n");

            foreach (DataRow Record in EmployeesDataTable.Rows)
            {
                Console.WriteLine("ID : {0}\t Name : {1}\t Country : {2}\t Salary : {3}\t DateOfBirth : {4}\n", Record["ID"], Record["Name"], Record["Country"], Record["Salary"], Record["DateOfBirth"]);
            }


            Console.WriteLine("\nDepartments List:\n\n");

            foreach (DataRow Record in DepartmentsDataTable.Rows)
            {
                Console.WriteLine("ID : {0}\t Name : {1}\n", Record["DepartmentID"], Record["DepartmentName"]);
            }


            DataSet DataSet1=new DataSet();

            DataSet1.Tables.Add(EmployeesDataTable);
            DataSet1.Tables.Add(DepartmentsDataTable);


            Console.WriteLine("\nEmployees List From Data Set :\n\n");

            foreach (DataRow Record in DataSet1.Tables[0].Rows)
            {

                Console.WriteLine("ID : {0}\t Name : {1}\t Country : {2}\t Salary : {3}\t DateOfBirth : {4}\n", Record["ID"], Record["Name"], Record["Country"], Record["Salary"], Record["DateOfBirth"]);
            }



            Console.WriteLine("\nDepartments List From Data Set :\n\n");

            foreach (DataRow Record in DataSet1.Tables[1].Rows)
            {
                Console.WriteLine("ID : {0}\t Name : {1}\n", Record["DepartmentID"], Record["DepartmentName"]);
            }

        }
    }
}
