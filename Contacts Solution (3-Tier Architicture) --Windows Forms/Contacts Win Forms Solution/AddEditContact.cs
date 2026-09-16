using ContactBusinessLayer;
using ContactsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contacts_Win_Forms_Solution
{
    public partial class frmAddEditContact : Form
    {

        public enum enMode { AddNew = 0, Update = 1 };
        enMode Mode;

        int _ContactID;
        clsContact Contact;
        public frmAddEditContact(int ContactID)
        {
            InitializeComponent();

            _ContactID = ContactID;

            if (_ContactID == -1)
            {
                Mode = enMode.AddNew;
            }

            else
            {
                Mode = enMode.Update;
            }



        }



        private void _FillCountriesInComboBox()
        {

            DataTable datatable = clsCountries.GetAllCountries();

            foreach (DataRow row in datatable.Rows)
            {



                cbCountry.Items.Add(row["CountryName"]);
            }
        }



        private void _LoadData()
        {
            _FillCountriesInComboBox();
            cbCountry.SelectedIndex = 0;

            if (Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Contact";
                Contact = new clsContact();
                return;
            }

            Contact = clsContact.Find(_ContactID);

            if (Contact == null)
            {
                MessageBox.Show("This Form Will Be Closed Because No Contact With ID = " + _ContactID);
                this.Close();
                return;
            }

            lblMode.Text = "Edit Contact ID = " + _ContactID;

            txtContactID.Text=_ContactID.ToString();

            txtFirstName.Text = Contact.FirstName;
            txtLastName.Text=Contact.LastName;
            txtEmail.Text = Contact.Email;
            txtPhone.Text = Contact.Phone;
            txtAddress.Text = Contact.Address;
            dtpDateOfBirth.Value= Contact.DateOfBirth;

            if (Contact.ImagePath != "")
            {
                pbContactImage.Load(Contact.ImagePath);
            }

            LLRemoveImage.Visible = (Contact.ImagePath != "");

            cbCountry.SelectedIndex = cbCountry.FindString(clsCountries.Find(Contact.CountryID).CountryName);


        }

        private void frmAddEditContact_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int CountryID=clsCountries.FindByCountryName(cbCountry.Text).ID;

            Contact.FirstName= txtFirstName.Text;
            Contact.LastName= txtLastName.Text;
            Contact.Email= txtEmail.Text;
            Contact.Phone= txtPhone.Text;
            Contact.Address= txtAddress.Text;
            Contact.DateOfBirth=dtpDateOfBirth.Value;
            Contact.CountryID= CountryID;

            if (pbContactImage.ImageLocation != null)
            {
                Contact.ImagePath= pbContactImage.ImageLocation.ToString();
            }

            else
            {
                Contact.ImagePath = "";
            }



            if (Contact.Save())
            {
                MessageBox.Show("Data Saved Successfully!");
            }

            else
            {
                MessageBox.Show("Error : Data Is Not Saved Successfully");
            }

            Mode = enMode.Update;
            lblMode.Text = "Etid Contact With ID=" + Contact.ID;
            txtContactID.Text = Contact.ID.ToString();


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LLRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbContactImage.ImageLocation = null;
            LLRemoveImage.Visible = false;
        }

        private void LLSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
