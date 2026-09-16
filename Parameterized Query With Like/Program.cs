using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


public class Program
{

    static string ConnectionString = "Server=.;Database=ContactsDB;User Id=sa;PassWord=123456;";

    static void SearchContactsStartsWith(string startsWith)
    {
        SqlConnection Connection = new SqlConnection(ConnectionString);
        string query = "Select * From Contacts where FirstName like ''+@startsWith+'%'";

        SqlCommand Command = new SqlCommand(query, Connection);
        Command.Parameters.AddWithValue("@startsWith", startsWith);

        try
        {
            Connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                int ContactId = (int)Reader["ContactId"];
                string FirstName = (string)Reader["FirstName"];
                string LastName = (string)Reader["LastName"];
                string Email = (string)Reader["Email"];
                string Phone = (string)Reader["Phone"];
                string Address = (string)Reader["Address"];
                int CountryId = (int)Reader["CountryId"];

                Console.WriteLine($"ContactId :{ContactId}");
                Console.WriteLine($"FirstName :{FirstName}");
                Console.WriteLine($"LastName :{LastName}");
                Console.WriteLine($"Email :{Email}");
                Console.WriteLine($"Phone :{Phone}");
                Console.WriteLine($"Address :{Address}");
                Console.WriteLine($"CountryId :{CountryId}\n\n");

            }
            Reader.Close();
            Connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }


    }



    static void SearchContactsEndsWith(string EndsWith)
    {
        SqlConnection Connection = new SqlConnection(ConnectionString);
        string query = "Select * From Contacts where FirstName like '%'+@EndsWith+''";

        SqlCommand Command = new SqlCommand(query, Connection);
        Command.Parameters.AddWithValue("@EndsWith", EndsWith);

        try
        {
            Connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                int ContactId = (int)Reader["ContactId"];
                string FirstName = (string)Reader["FirstName"];
                string LastName = (string)Reader["LastName"];
                string Email = (string)Reader["Email"];
                string Phone = (string)Reader["Phone"];
                string Address = (string)Reader["Address"];
                int CountryId = (int)Reader["CountryId"];

                Console.WriteLine($"ContactId :{ContactId}");
                Console.WriteLine($"FirstName :{FirstName}");
                Console.WriteLine($"LastName :{LastName}");
                Console.WriteLine($"Email :{Email}");
                Console.WriteLine($"Phone :{Phone}");
                Console.WriteLine($"Address :{Address}");
                Console.WriteLine($"CountryId :{CountryId}\n\n");

            }
            Reader.Close();
            Connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }


    }




    static void SearchContactsContains(string Contains)
    {
        SqlConnection Connection = new SqlConnection(ConnectionString);
        string query = "Select * From Contacts where FirstName like '%'+@Contains+'%'";

        SqlCommand Command = new SqlCommand(query, Connection);
        Command.Parameters.AddWithValue("@Contains", Contains);

        try
        {
            Connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                int ContactId = (int)Reader["ContactId"];
                string FirstName = (string)Reader["FirstName"];
                string LastName = (string)Reader["LastName"];
                string Email = (string)Reader["Email"];
                string Phone = (string)Reader["Phone"];
                string Address = (string)Reader["Address"];
                int CountryId = (int)Reader["CountryId"];

                Console.WriteLine($"ContactId :{ContactId}");
                Console.WriteLine($"FirstName :{FirstName}");
                Console.WriteLine($"LastName :{LastName}");
                Console.WriteLine($"Email :{Email}");
                Console.WriteLine($"Phone :{Phone}");
                Console.WriteLine($"Address :{Address}");
                Console.WriteLine($"CountryId :{CountryId}\n\n");

            }
            Reader.Close();
            Connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }


    }






    static void Main(string[] args)
    {
        //SearchContactsStartsWith("J");

       // SearchContactsEndsWith("n");

        SearchContactsContains("oh");
        
    }
}

