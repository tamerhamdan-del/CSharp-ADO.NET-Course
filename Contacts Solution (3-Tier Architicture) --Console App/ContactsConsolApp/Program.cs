
using ContactBusinessLayer;
using ContactsBusinessLayer;
using System;
using System.Data;
using System.Diagnostics.Contracts;

namespace ContactsConsolApp
{
    internal class Program
    {
        static void testFindContact(int ID)

        {
            clsContact Contact1 = clsContact.Find(ID);

            if (Contact1 != null)
            {
                Console.WriteLine(Contact1.FirstName+ " " + Contact1.LastName);
                Console.WriteLine(Contact1.Email);
                Console.WriteLine(Contact1.Phone);
                Console.WriteLine(Contact1.Address);
                Console.WriteLine(Contact1.DateOfBirth);
                Console.WriteLine(Contact1.CountryID);
                Console.WriteLine(Contact1.ImagePath);
            }
            else 
            {
                Console.WriteLine("Contact [" + ID + "] Not found!");   
            }
        }


        static void testAddNewContact()
        {
            clsContact Contact1=new clsContact();
            Contact1.FirstName = "Fadi";
            Contact1.LastName = "Maher";
            Contact1.Email = "A@a.com";
            Contact1.Phone = "010010";
            Contact1.Address = "address1";
            Contact1.DateOfBirth = new DateTime(1977, 11, 6, 10, 30, 0);
            Contact1.CountryID = 1;
            Contact1.ImagePath = "";


            if (Contact1.Save())
            {
                Console.WriteLine("Contact Added Successfully !!! With ID = " + Contact1.ID);
            }
            else
            {
                Console.WriteLine("Contact Does Not Added !!!!!!!");
            }

        }


        static void testUpdateContact(int ID)

        {
            clsContact Contact1 = clsContact.Find(ID);

            if (Contact1 != null)
            {
                //update whatever info you want
                Contact1.FirstName = "Fadi22";
                Contact1.LastName = "Maher2";
                Contact1.Email = "A2@a.com";
                Contact1.Phone = "2222";
                Contact1.Address = "222";
                Contact1.DateOfBirth = new DateTime(1977, 11, 6, 10, 30, 0);
                Contact1.CountryID = 1;
                Contact1.ImagePath = "";

                if (Contact1.Save())
                {

                    Console.WriteLine("Contact updated Successfully ");
                }

            }
            else
            {
                Console.WriteLine("Not found!");
            }





        }


        static void testDeleteContact(int ID)
        {  clsContact Contact = clsContact.Find(ID);

            if (clsContact.DeleteContact(ID))
            {
               
                Console.WriteLine("Contact With ID= " + ID + " Is Deleted Successfully!!");


            }

            else{
                Console.WriteLine("Contact Does Deleted !!");
            }



        }


        static void ListContacts()
        {
            DataTable dataTable = new DataTable();
            dataTable = clsContact.GetAllContacts();

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["ContactID"]},{row["FirstName"]}  {row["LastName"]}");


            }


        }


        static void IsContactExist(int ID)
        {

            if (clsContact.IsContactExist(ID))
            {
                Console.WriteLine("Yes Contact Is Found!");
            }
            else
            {
                Console.WriteLine("NO Contact Is NOT Found!");
            }

        }



        static void testFindContry(int ID)

        {
            clsCountries Country1 = clsCountries.Find(ID);

            if (Country1 != null)
            {
                Console.WriteLine(Country1.CountryName);


            }
            else
            {
                Console.WriteLine("Country [" + ID + "] Not found!");
            }
        }

        static void testFindContryByName(string CountryName)

        {
            clsCountries Country1 = clsCountries.FindByCountryName(CountryName);

            if (Country1 != null)
            {
                Console.WriteLine(Country1.CountryName);


            }
            else
            {
                Console.WriteLine("Country [" + CountryName + "] Not found!");
            }
        }


        static void testAddNewCountry()
        {
            clsCountries Country1 = new clsCountries();
            Country1.CountryName = "Nablus";
            Country1.Code = "xcd";
            Country1.PhoneCode = "972";


            if (Country1.Save())
            {
                Console.WriteLine("Country Added Successfully !!! With ID = " + Country1.ID);
            }
            else
            {
                Console.WriteLine("Country Does Not Added !!!!!!!");
            }

        }


        static void testUpdateCountry(int ID)

        {
            clsCountries country1 = clsCountries.Find(ID);

            if (country1 != null)
            {
                //update whatever info you want
                country1.CountryName = "jenin";
                country1.Code = "xcd";
                country1.PhoneCode = "972";


                if (country1.Save())
                {

                    Console.WriteLine("country updated Successfully ");
                }

            }
            else
            {
                Console.WriteLine("Not found!");
            }





        }


        static void testDeleteCountry(int ID)
        {
            clsCountries country = clsCountries.Find(ID);

            if (clsCountries.DeleteCountry(ID))
            {

                Console.WriteLine("country With ID= " + ID + " Is Deleted Successfully!!");


            }

            else
            {
                Console.WriteLine("country Does NOT Deleted !!");
            }



        }


        static void ListContries()
        {
            DataTable dataTable = new DataTable();
            dataTable = clsCountries.GetAllCountries();

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["CountryID"]},{row["CountryName"]},{row["Code"]} ,{row["PhoneCode"]} ");


            }


        }


        static void IsCountryExist(int ID)
        {

            if (clsCountries.IsCountryExist(ID))
            {
                Console.WriteLine("Yes Country Is Found!");
            }
            else
            {
                Console.WriteLine("NO Country Is NOT Found!");
            }

        }

        static void IsCountryExist(string countryName)
        {

            if (clsCountries.IsCountryExist(countryName))
            {
                Console.WriteLine("Yes Country Is Found!");
            }
            else
            {
                Console.WriteLine("NO, Country Is NOT Found!");
            }

        }


        static void Main(string[] args)
        {

            //  testFindContact(1);
            // testAddNewContact();
            // testUpdateContact(1);
            //testDeleteContact(6);
            // ListContacts();
           // IsContactExist(4);





            //  testFindContry(1);
            //  testFindContryByName("vvv");
            // testAddNewCountry();
            // testUpdateCountry(1);
            // testDeleteCountry(6);
              ListContries();
            // IsCountryExist(4);
            // IsCountryExist("jenin");


            Console.ReadKey();

        }
    }
}
