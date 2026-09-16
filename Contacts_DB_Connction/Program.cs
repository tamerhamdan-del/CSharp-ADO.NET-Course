using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


    public class Program
    {

    static string ConnectionString = "Server=.;Database=ContactsDB;User Id=sa;PassWord=123456;";

    static void PrintAllContacts()
    {
        SqlConnection Connection = new SqlConnection(ConnectionString);
        string query = "Select * From Contacts where CountryID=1 and FirstName='Jane'";

        SqlCommand Command = new SqlCommand(query, Connection);

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



    static void PrintAllContactsWithFirstName(string FirstName)
    {
        SqlConnection Connection = new SqlConnection(ConnectionString);
        string query = "Select * From Contacts where FirstName=@FirstName";

        SqlCommand Command = new SqlCommand(query, Connection);
        Command.Parameters.AddWithValue("@FirstName", FirstName);


        try
        {
            Connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                int ContactId = (int)Reader["ContactId"];
                string Firstname = (string)Reader["FirstName"];
                string LastName = (string)Reader["LastName"];
                string Email = (string)Reader["Email"];
                string Phone = (string)Reader["Phone"];
                string Address = (string)Reader["Address"];
                int CountryId = (int)Reader["CountryId"];

                Console.WriteLine($"ContactId :{ContactId}");
                Console.WriteLine($"FirstName :{Firstname}");
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



    static void PrintAllContactsWithFirstNameAndCountryID(string FirstName,int CountryID)
    {
        SqlConnection Connection = new SqlConnection(ConnectionString);
        string query = "Select * From Contacts where FirstName=@FirstName and CountryID=@CountryID";

        SqlCommand Command = new SqlCommand(query, Connection);

        Command.Parameters.AddWithValue("@FirstName", FirstName);

        Command.Parameters.AddWithValue("@CountryID", CountryID);


        try
        {
            Connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                int ContactId = (int)Reader["ContactId"];
                string Firstname = (string)Reader["FirstName"];
                string LastName = (string)Reader["LastName"];
                string Email = (string)Reader["Email"];
                string Phone = (string)Reader["Phone"];
                string Address = (string)Reader["Address"];
                int CountryId = (int)Reader["CountryId"];

                Console.WriteLine($"ContactId :{ContactId}");
                Console.WriteLine($"FirstName :{Firstname}");
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

        // PrintAllContacts();
       // PrintAllContactsWithFirstName("Jane");

        PrintAllContactsWithFirstNameAndCountryID("Ali", 1);
        }
    }

