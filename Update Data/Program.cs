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

    static void UpdateContact(int ContactID,stContactInfo ContactInfo)
    {

        SqlConnection Connection = new SqlConnection(ConnectionString);
        string query = "Update Contacts SET FirstName=@FirstName,LastName=@LastName,Email=@Email,Phone=@Phone,Address=@Address,CountryID=@CountryID Where ContactID=@ContactID";

        SqlCommand Command = new SqlCommand(query, Connection);
        Command.Parameters.AddWithValue("@FirstName", ContactInfo.FirstName);
        Command.Parameters.AddWithValue("@LastName", ContactInfo.LastName);
        Command.Parameters.AddWithValue("@Email", ContactInfo.Email);
        Command.Parameters.AddWithValue("@Phone", ContactInfo.Phone);
        Command.Parameters.AddWithValue("@Address", ContactInfo.Address);
        Command.Parameters.AddWithValue("@CountryID", ContactInfo.CountryID);
        Command.Parameters.AddWithValue("@ContactID", ContactID);

        try
        {
            Connection.Open();
           int rowsAffected=Command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("Contact Updated Succsessfully!");
            }
            else
            {
                Console.WriteLine("Contact Does Not Updated !!");
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
        stContactInfo contactInfo = new stContactInfo
        {
            FirstName = "Tamer"
            ,
            LastName = "Hamdan"
            ,
            Email = "tt@exx.com"
            ,
            Phone = "54545454"
            ,
            Address = "mckmck"
            ,
            CountryID = 1
        };


        UpdateContact(1,contactInfo);

    }
}

