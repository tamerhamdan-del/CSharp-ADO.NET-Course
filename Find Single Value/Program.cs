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

    static bool FindContactByID(int ContactID,ref stContactInfo ContactInfo)
    {
        bool isFound = false;
        SqlConnection Connection = new SqlConnection(ConnectionString);
        string query = "Select * From Contacts where ContactID=@ContactID";

        SqlCommand Command = new SqlCommand(query, Connection);
        Command.Parameters.AddWithValue("@ContactID", ContactID);

        try
        {
            Connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();

            if (Reader.Read())
            {
                isFound = true;
                ContactInfo.ID = (int)Reader["ContactID"];
                ContactInfo.FirstName = (string)Reader["FirstName"];
                ContactInfo.LastName = (string)Reader["LastName"];
                ContactInfo.Email = (string)Reader["Email"];
                ContactInfo.Phone= (string)Reader["Phone"];
                ContactInfo.Address = (string)Reader["Address"];
                ContactInfo.CountryID = (int)Reader["CountryID"];
            }

            else
            {
                isFound= false;
            }

                Reader.Close();
                Connection.Close();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        return isFound;

    }

    public  struct stContactInfo
    {
        public int ID {  get; set; }
        public string FirstName {  get; set; }  
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email {  get; set; }

        public string Phone { get; set; }
        public int CountryID {  get; set; }
    } 


    static void Main(string[] args)
    {
        stContactInfo contactInfo = new stContactInfo();
       if(FindContactByID(4,ref contactInfo))
        {
            Console.WriteLine($"ContactID={contactInfo.ID}");
            Console.WriteLine($"FirstName={contactInfo.FirstName}");
            Console.WriteLine($"LastName={contactInfo.LastName}");
            Console.WriteLine($"Email={contactInfo.Email}");
            Console.WriteLine($"Phone={contactInfo.Phone}");
            Console.WriteLine($"Address={contactInfo.Address}");
            Console.WriteLine($"CountryID={contactInfo.CountryID}");
        }
    }
}

