using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTable_Example9_Auto_Increment_And_Others_
{
    internal class Program
    {
        static void Main(string[] args)
        {


            DataTable EmployeesDataTable = new DataTable();

            //EmployeesDataTable.Columns.Add("ID", typeof(int));
            //EmployeesDataTable.Columns.Add("Name", typeof(string));
            //EmployeesDataTable.Columns.Add("Country", typeof(string));
            //EmployeesDataTable.Columns.Add("Salary", typeof(Double));
            //EmployeesDataTable.Columns.Add("DateOfBirth", typeof(DateTime));


            DataColumn dtColumn;

            // ID
            dtColumn = new DataColumn();

            dtColumn.DataType = typeof(int);
            dtColumn.ColumnName = "ID";
            dtColumn.AutoIncrement = true;
            dtColumn.AutoIncrementSeed = 1;
            dtColumn.AutoIncrementStep = 1;
            dtColumn.Caption = "Employee ID";
            dtColumn.ReadOnly = true;
            dtColumn.Unique = true;

            EmployeesDataTable.Columns.Add(dtColumn);


            // Name
            dtColumn = new DataColumn();

            dtColumn.DataType = typeof(string);
            dtColumn.ColumnName = "Name";
            dtColumn.AutoIncrement = false;
            dtColumn.Caption = "Employee Name";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;

            EmployeesDataTable.Columns.Add(dtColumn);


            // Country
            dtColumn = new DataColumn();

            dtColumn.DataType = typeof(string);
            dtColumn.ColumnName = "Country";
            dtColumn.AutoIncrement = false;
            dtColumn.Caption = "Employee Country";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;

            EmployeesDataTable.Columns.Add(dtColumn);


            // Salary
            dtColumn = new DataColumn();

            dtColumn.DataType = typeof(double);
            dtColumn.ColumnName = "Salary";
            dtColumn.AutoIncrement = false;
            dtColumn.Caption = "Employee Salary";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;

            EmployeesDataTable.Columns.Add(dtColumn);


            // Date Of Birth
            dtColumn = new DataColumn();

            dtColumn.DataType = typeof(DateTime);
            dtColumn.ColumnName = "Date Of Birth";
            dtColumn.AutoIncrement = false;
            dtColumn.Caption = "Employee Date Of Birth";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;

            EmployeesDataTable.Columns.Add(dtColumn);




            EmployeesDataTable.Rows.Add(null, "Tamer Hamdan", "Nablus", 3000, DateTime.Now);
            EmployeesDataTable.Rows.Add(null, "Ahmad Ali", "Jenin", 6000, DateTime.Now);
            EmployeesDataTable.Rows.Add(null, "Maher Khalid", "Salem", 4000, DateTime.Now);
            EmployeesDataTable.Rows.Add(null, "Amr Yousef", "Israil", 5000, DateTime.Now);
            EmployeesDataTable.Rows.Add(null, "Yahya Dwikat", "Nablus", 8000, DateTime.Now);


            DataColumn[] PrimaryKeyColumn = new DataColumn[1];
            PrimaryKeyColumn[0] = EmployeesDataTable.Columns["ID"];
            EmployeesDataTable.PrimaryKey = PrimaryKeyColumn;


            Console.WriteLine("\nEmployees List:\n\n");

            foreach (DataRow Record in EmployeesDataTable.Rows)
            {
                Console.WriteLine("ID : {0}\t Name : {1}\t Country : {2}\t Salary : {3}\t DateOfBirth : {4}\n", Record["ID"], Record["Name"], Record["Country"], Record["Salary"], Record["Date Of Birth"]);
            }
        }
    }
}
