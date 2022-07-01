using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TomProject.Context;
using TomProject.Entities;

namespace TomProject
{
    public partial class Customer_form : DevExpress.XtraEditors.XtraForm
    {

        Garlic db = new Garlic();
        public Customer_form()
        {
            InitializeComponent();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Customer_form_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.Customers.ToList();
        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer ee = new Customer();
            ee.Name = name_text.Text.ToLower();
            ee.Address = address_text.Text.ToLower();
            ee.Notes = notes_richtext.Text.ToLower();
            ee.Phone = int.Parse(mopile_text.Text);
            ee.account = int.Parse(account_text.Text);
            db.Customers.Add(ee);
            db.SaveChanges();
        }
    }
}