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

    static void AddNewContact(stContactInfo ContactInfo)
    {

        SqlConnection Connection = new SqlConnection(ConnectionString);
        string query = "Insert Into Contacts (FirstName,LastName,Email,Phone,Address,CountryID) " +
            "Values  (@FirstName,@LastName,@Email,@Phone,@Address,@CountryID)  ;  select SCOPE_IDENTITY()";

        SqlCommand Command = new SqlCommand(query, Connection);
        Command.Parameters.AddWithValue("@FirstName", ContactInfo.FirstName);
        Command.Parameters.AddWithValue("@LastName", ContactInfo.LastName);
        Command.Parameters.AddWithValue("@Email", ContactInfo.Email);
        Command.Parameters.AddWithValue("@Phone", ContactInfo.Phone);
        Command.Parameters.AddWithValue("@Address", ContactInfo.Address);
        Command.Parameters.AddWithValue("@CountryID", ContactInfo.CountryID);

        try
        {
            Connection.Open();
          object result=Command.ExecuteScalar();

            if (result !=null  && int.TryParse(result.ToString(),out int InsertedId))
            {
                Console.WriteLine( $"New Inserted ID Is = {InsertedId}" );
            }

            else
            {
                Console.WriteLine("Cannot Find The Inserted ID !!!!!!\n");
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


        AddNewContact(contactInfo);

    }
}

