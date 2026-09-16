using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ContactsBusinessLayer;

namespace Contacts_Win_Forms_Solution
{
    public partial class frmListContacts : Form
    {
        public frmListContacts()
        {
            InitializeComponent();



        }


        private void _RefrechContactList()
        {

            dgvAllContacts.DataSource = clsContact.GetAllContacts();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void frmListContacts_Load(object sender, EventArgs e)
        {
            _RefrechContactList();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            frmAddEditContact frm = new frmAddEditContact(-1);

            frm.ShowDialog();

            _RefrechContactList();
            

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditContact frm=new frmAddEditContact((int)dgvAllContacts.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefrechContactList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You Sure You Want To Delete Contact [" + dgvAllContacts.CurrentRow.Cells[0].Value+"]","Confirm Delete",MessageBoxButtons.OKCancel) == DialogResult.OK){


                if (clsContact.DeleteContact((int)dgvAllContacts.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Contact Deleted Successsfully!!!");
                    _RefrechContactList();
                }

                else
                {
                    MessageBox.Show("Contact Is Not deleted!!");
                }
            }
        }
    }
}
