using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TomProject.Context;
using TomProject.Entities;

namespace TomProject
{
    public partial class Form_Customer : DevExpress.XtraEditors.XtraForm
    {

        Garlic db = new Garlic();
        public Form_Customer()
        {
            InitializeComponent();
        }


        private void Customer_form_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.Customers.ToList();



        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
           
                if (textEdit_name.Text == "" || textEdit_address.Text == "" || textEdit_mobile.Text == "")
                {
                    XtraMessageBox.Show("Please Complete Data ", "Warnning", MessageBoxButtons.OK);
                }
                else
                {
                    Customer ee = new Customer();
                    ee.Name = textEdit_name.Text;
                    ee.Address = textEdit_address.Text;
                    ee.Notes = notes_richtext.Text;
                    ee.Phone = int.Parse(textEdit_mobile.Text); 

                    db.Customers.Add(ee);

                    db.SaveChanges();
                  gridControl1.DataSource = db.Customers.ToList();


                XtraMessageBox.Show("added Succuessfuly ", "Successed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textEdit_name.Text = textEdit_address.Text = textEdit_mobile.Text = notes_richtext.Text ="";
                }

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (textEdit_name.Text == "" ||
            textEdit_mobile.Text == "" ||
           textEdit_address.Text == "" )
            {
                XtraMessageBox.Show("Please Complete Data ", "Warnning", MessageBoxButtons.OK);

            }
            else
            {

                Customer ee = new Customer();

                ee.Address = textEdit_address.Text;
                ee.Notes = notes_richtext.Text;
                ee.Phone = int.Parse(textEdit_mobile.Text);
                ee.Name = textEdit_name.Text;

                int id = (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID");
                ee.ID = id;
                db.Customers.AddOrUpdate(ee);
                db.SaveChanges();


                gridControl1.DataSource = db.Customers.ToList();


                XtraMessageBox.Show("Updated Succuessfuly ", "Successed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textEdit_name.Text = textEdit_mobile.Text = textEdit_address.Text = notes_richtext.Text = "";
            }

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

        public void simpleButton4_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.Customers.ToList();
            gridControl1.ShowPrintPreview();

        }

    }
}
