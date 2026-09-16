using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsDataAccessLayer
{
    public class clsCountriesDataAccess
    {


        public static bool GetCountryInfoByID(int ID, ref string CountryName,ref string Code,ref  string PhoneCode)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Countries WHERE CountryID = @CountryID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CountryID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    CountryName = (string)reader["CountryName"];
                    if (reader["Code"] == DBNull.Value)
                    {
                        Code = "";

                    }

                    else
                    {
                        Code = (string)reader["Code"];
                    }





                    if (reader["PhoneCode"] == DBNull.Value)
                    {
                        PhoneCode = "";

                    }

                    else
                    {
                        PhoneCode = (string)reader["PhoneCode"];
                    }

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }


        public static bool GetCountryInfoByCountryName(ref int ID, string CountryName, ref string Code, ref string PhoneCode)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Countries WHERE CountryName = @CountryName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    ID = (int)reader["CountryID"];

                    if (reader["Code"] == DBNull.Value)
                    {
                        Code = "";

                    }

                    else
                    {
                        Code = (string)reader["Code"];
                    }





                    if (reader["PhoneCode"] == DBNull.Value)
                    {
                        PhoneCode = "";

                    }

                    else
                    {
                        PhoneCode = (string)reader["PhoneCode"];
                    }


                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int AddNewCountry(string CountryName,  string Code,  string PhoneCode)
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int CountryID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Countries (CountryName,Code,PhoneCode)
                             VALUES (@CountryName,@Code,@PhoneCode);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CountryName", CountryName);



            if(Code!="")
            command.Parameters.AddWithValue("@Code", Code);
            else
                command.Parameters.AddWithValue("@Code", DBNull.Value);




            if (PhoneCode != "")
                command.Parameters.AddWithValue("@PhoneCode", PhoneCode);
            else
                command.Parameters.AddWithValue("@PhoneCode", DBNull.Value);



            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    CountryID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return CountryID;

        }


        public static bool UpdateCountry(int ID, string CountryName,  string Code,  string PhoneCode)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Update Countries 
                           set  CountryName=@CountryName,
                                Code=@Code
                                PhoneCode=@PhoneCode
                                where CountryID=@CountryID";

            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@CountryID", ID);
            command.Parameters.AddWithValue("@CountryName", CountryName);


            if (Code != "")
                command.Parameters.AddWithValue("@Code", Code);
            else
                command.Parameters.AddWithValue("@Code", DBNull.Value);




            if (PhoneCode != "")
                command.Parameters.AddWithValue("@PhoneCode", PhoneCode);
            else
                command.Parameters.AddWithValue("@PhoneCode", DBNull.Value);


            int rowsAffected = 0;
            try
            {
                Connection.Open();
                rowsAffected = command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

            }

            finally
            {
                Connection.Close();
            }

            return rowsAffected > 0;



        }



        public static bool DeleteCountry(int ID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Delete From Countries Where CountryID=@CountryID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryID", ID);

            int rowsAffected = 0;

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();





            }
            catch (Exception ex)
            {

            }

            finally { connection.Close(); }
            return rowsAffected > 0;
        }



        public static DataTable GetAllCountries()
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "Select * From Countries";
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            DataTable dataTable = new DataTable();

            try

            {
                connection.Open();
                SqlDataReader Reader = sqlCommand.ExecuteReader();

                if (Reader.HasRows)
                {
                    dataTable.Load(Reader);
                }

                Reader.Close();
            }

            catch (Exception ex)
            {
            }

            finally
            {
                connection.Close();
            }

            return dataTable;
        }


        public static bool IsCountryExist(int ID)
        {

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "Select Found=1 From Countries Where CountryID=@CountryID";
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("@CountryID", ID);


            bool isFound = false;

            try

            {
                connection.Open();
                SqlDataReader Reader = sqlCommand.ExecuteReader();

                isFound = Reader.HasRows;
                Reader.Close();
            }

            catch (Exception ex)
            {
            }

            finally
            {
                connection.Close();

            }

            return isFound;
        }

        public static bool IsCountryExist(string CountryName)
        {

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "Select Found=1 From Countries Where CountryName=@CountryName";
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("@CountryName", CountryName);


            bool isFound = false;

            try

            {
                connection.Open();
                SqlDataReader Reader = sqlCommand.ExecuteReader();

                isFound = Reader.HasRows;
                Reader.Close();
            }

            catch (Exception ex)
            {
            }

            finally
            {
                connection.Close();

            }

            return isFound;
        }








    }
}
