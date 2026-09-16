using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using ContactsDataAccessLayer;

namespace ContactBusinessLayer
{
    public class clsCountries
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }
        public string CountryName { set; get; }
        public string Code { set; get; }
        public string PhoneCode { set; get; }

        public clsCountries()

        {
            this.ID = -1;
            this.CountryName = "";
            this.Code = "";
            this.PhoneCode = "";

            Mode = enMode.AddNew;


        }

        private clsCountries(int ID, string CountryName,string Code,string PhoneCode)

        {
            this.ID = ID;
            this.CountryName = CountryName;
            this.Code=Code;
            this.PhoneCode = PhoneCode;
            Mode = enMode.Update;


        }



        private bool _AddNewCountry()
        {
            this.ID = clsCountriesDataAccess.AddNewCountry(this.CountryName,this.Code,this.PhoneCode);
            return (this.ID != -1);
        }


        private bool _UpdateCountry()
        {
            return (clsCountriesDataAccess.UpdateCountry(this.ID, this.CountryName,this.Code,this.PhoneCode));


        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCountry())
                    {
                        Mode = enMode.Update;
                        return true;
                    }

                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return (_UpdateCountry());


            }


            return false;
        }




        public static bool DeleteCountry(int ID)
        {
            return clsCountriesDataAccess.DeleteCountry(ID);
        }


        public static DataTable GetAllCountries()
        {
            return clsCountriesDataAccess.GetAllCountries();
        }


        public static bool IsCountryExist(int ID)
        {
            return clsCountriesDataAccess.IsCountryExist(ID);
        }

        public static bool IsCountryExist(string countryName)
        {
            return clsCountriesDataAccess.IsCountryExist(countryName);
        }


        public static clsCountries Find(int ID)
        {

            string CountryName = "",Code="",PhoneCode="";


            if (clsCountriesDataAccess.GetCountryInfoByID(ID, ref CountryName,ref Code,ref PhoneCode))
            {

                return new clsCountries(ID, CountryName,Code,PhoneCode);

            }
            else
                return null;

        }



        public static clsCountries FindByCountryName(string CountryName)
        {

            int ID = -1;
            string Code = "", PhoneCode="";

            if (clsCountriesDataAccess.GetCountryInfoByCountryName(ref ID, CountryName,ref Code,ref PhoneCode))
            {

                return new clsCountries(ID, CountryName, Code, PhoneCode);

            }
            else
                return null;

        }
    }
}
