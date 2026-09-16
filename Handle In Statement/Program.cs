using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.InteropServices;


public class Program
{

    static string ConnectionString = "Server=.;Database=ContactsDB;User Id=sa;PassWord=123456;";

    static void DeleteContacts(string ContactIDs)
    {

        SqlConnection Connection = new SqlConnection(ConnectionString);
        string query = "Delete From Contacts Where ContactID IN("+ContactIDs+")";

        SqlCommand Command = new SqlCommand(query, Connection);

      

        try
        {
            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("Contact Deleted Succsessfully!");
            }
            else
            {
                Console.WriteLine("Contact Does Not Deleted !!");
            }

            Connection.Close();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }



    }

    public struct stContactInfo
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }
        public int CountryID { get; set; }
    }


    static void Main(string[] args)
    {



        DeleteContacts("1,2,6");

    }
}

