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
            //Customer ee = new Customer();
            //ee.Name = name_text.Text.ToLower();
            //ee.Address = address_text.Text.ToLower();
            //ee.Notes = notes_richtext.Text.ToLower();
            //ee.Phone = int.Parse(mopile_text.Text);
            //ee.account = int.Parse(account_text.Text);
            //db.Customers.Add(ee);
            //db.SaveChanges();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //try
            //{
                if (textEdit_name.Text == "" || textEdit_address.Text == "" || textEdit_mobile.Text == "")
                {
                    XtraMessageBox.Show("Please Complete Data ", "Warnning", MessageBoxButtons.OK);
                }
                else
                {
                    Customer ee = new Customer();
                    ee.Name = textEdit_name.Text.ToLower();
                    ee.Address = textEdit_address.Text.ToLower();
                    ee.Notes = notes_richtext.Text.ToLower();
                    ee.Phone = (int)float.Parse(textEdit_mobile.Text); 

                    db.Customers.Add(ee);

                    db.SaveChanges();
                    this.Customer_form_Load(sender, e);
                   
                    XtraMessageBox.Show("added Succuessfuly ", "Successed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textEdit_name.Text = textEdit_address.Text = textEdit_mobile.Text = notes_richtext.Text ="";
                }

            //}
            //catch
            //{

            //    XtraMessageBox.Show("Please Complete Data ", "Warnning", MessageBoxButtons.OK);
            //}

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (textEdit_name.Text == "" ||
            textEdit_mobile.Text == "" ||
           textEdit_address.Text == "" ||
           notes_richtext.Text == "" )
           
      
            {
                XtraMessageBox.Show("Please Complete Data ", "Warnning", MessageBoxButtons.OK);

            }

            Customer cs = new Customer();

            cs.Address = textEdit_address.Text;
            cs.Notes=notes_richtext.Text;
            cs.Phone = int.Parse(textEdit_mobile.Text);
            cs.Name = textEdit_name.Text;

            int id = (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID");
            cs.ID = id;

            db.Entry(cs).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();


            gridControl1.DataSource = db.Customers.Select(r => new { r.ID,r.Name,r.Address,r.Phone,r.Notes }).ToList();

            XtraMessageBox.Show("Updated Succuessfuly ", "Successed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textEdit_name.Text = textEdit_mobile.Text = textEdit_address.Text = notes_richtext.Text ="" ;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {


            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Name") != null)
            {
                int id = (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID");
                var receipt = db.Customers.Single(w => w.ID == id);
                if (XtraMessageBox.Show($"Do you want to delete Receipt number {id}?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
                {

                    db.Customers.Remove(receipt);
                    db.SaveChanges();
                    XtraMessageBox.Show("Removed Succuessfuly ", "Successed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gridControl1.DataSource = db.Customers.ToList();
                    textEdit_name.Text = textEdit_address.Text = textEdit_mobile.Text = notes_richtext.Text = "";
                }
            }



            }

        private void gridView1_ClipboardRowCopying(object sender, DevExpress.XtraGrid.Views.Grid.ClipboardRowCopyingEventArgs e)
        {

        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle , "Name") != null)
            {

            
                
                notes_richtext.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Notes").ToString();



                textEdit_address.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Address").ToString();
                textEdit_name.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Name").ToString();
                textEdit_mobile.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Phone").ToString();

            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();

        }

        private void gridControl1_Click_1(object sender, EventArgs e)
        {
           
        }
    }
}
