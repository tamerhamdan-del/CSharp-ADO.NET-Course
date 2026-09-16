using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


public class Program
{

    static string ConnectionString = "Server=.;Database=ContactsDB;User Id=sa;PassWord=123456;";

    static string GetFirstName(int ContactID)
    {
        string FirstName = "";
        SqlConnection Connection = new SqlConnection(ConnectionString);
        string query = "Select FirstName From Contacts where ContactID=@ContactID";

        SqlCommand Command = new SqlCommand(query, Connection);
        Command.Parameters.AddWithValue("@ContactID", ContactID);

        try
        {
            Connection.Open();
            object result = Command.ExecuteScalar();
            if (result != null)
            {
                FirstName=result.ToString();
            }
            else
            {
                FirstName = "";
            }
                Connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        return FirstName;   

    }


    static void Main(string[] args)
    {
        Console.WriteLine(GetFirstName(1));
    }
}

