using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TomProject.Context;
using TomProject.Entities;

namespace TomProject.PL
{
    public partial class YeildReceiptcs : DevExpress.XtraEditors.XtraForm
    {
        Garlic db = new Garlic();

        public YeildReceiptcs()
        {
            InitializeComponent();
        }



        #region FormLoad
        private void YeildReceiptcs_Load(object sender, EventArgs e)
        {
            #region Supplierlookupedit
            var supplier = db.Suppliers.Select(ee => new { ID = ee.ID, Name = ee.Name }).ToList();
            LueItem.Text = db.Suppliers.Select(a => a.Name).FirstOrDefault();//to select first elment in form load
            LueItem.Properties.DataSource = supplier;
            LueItem.Properties.DisplayMember = "Name";
            LueItem.Properties.ValueMember = "ID";
            ///hide ID From lookupedit
            LueItem.Properties.PopulateColumns();
            LueItem.Properties.Columns[0].Visible = false;

            #endregion

            #region fillGridcontrol
            gridControl1.DataSource = db.YeildRecipts.Select(r => new { r.ID, SName = r.Supplier.Name, Fdan = r.AcrePrice, r.CaratPrice, r.Paid, r.Total, r.Remaining, r.Date, r.Notes, r.Price }).ToList();
            #endregion
        }

        #endregion

        #region Insert
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!(dateEdit1.Text == "" || textEdit6.Text == "" || textEdit5.Text == "" || textEdit1.Text == ""
                || textEdit2.Text == "" || textEdit3.Text == "" || textEdit4.Text == ""))
            {
                #region create object of reciept
                var newreceipt = new YeildRecipt();
                newreceipt.Date = Convert.ToDateTime(dateEdit1.Text);
                newreceipt.Notes = richTextBox1.Text;
                newreceipt.AcrePrice = float.Parse(textEdit6.Text);
                newreceipt.CaratPrice = float.Parse(textEdit5.Text);
                newreceipt.Price = decimal.Parse(textEdit1.Text);
                newreceipt.Total = decimal.Parse(textEdit2.Text);
                newreceipt.Paid = decimal.Parse(textEdit3.Text);
                newreceipt.Remaining = decimal.Parse(textEdit4.Text);

                newreceipt.Supplier = db.Suppliers.FirstOrDefault(d => d.ID == (int)LueItem.EditValue);
                #endregion


                #region Supplieraccount
                newreceipt.Supplier.account += decimal.Parse(textEdit4.Text);
                #endregion

                #region add to Database and show gridview

                db.YeildRecipts.Add(newreceipt);
                db.SaveChanges();
                gridControl1.DataSource = db.YeildRecipts.Select(r => new { r.ID, SName = r.Supplier.Name, Fdan = r.AcrePrice, r.CaratPrice, r.Paid, r.Total, r.Remaining, r.Date, r.Notes, Price = r.Price }).ToList();
                #endregion
                emptyControls();
                XtraMessageBox.Show("Added Succuessfuly ", "Successed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                XtraMessageBox.Show("Please Complete Data ", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
        #endregion

        #region Update
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (!(dateEdit1.Text == "" || textEdit6.Text == "" || textEdit5.Text == "" || textEdit1.Text == ""
                || textEdit2.Text == "" || textEdit3.Text == "" || textEdit4.Text == ""))
            {

                #region create object of reciept
                var newreceipt = new YeildRecipt();
           
                newreceipt.Date = Convert.ToDateTime(dateEdit1.Text);
                newreceipt.Notes = richTextBox1.Text;
                newreceipt.AcrePrice = float.Parse(textEdit6.Text);
                newreceipt.CaratPrice = float.Parse(textEdit5.Text);
                newreceipt.Price = decimal.Parse(textEdit1.Text);
                newreceipt.Total = decimal.Parse(textEdit2.Text);
                newreceipt.Paid = decimal.Parse(textEdit3.Text);
                newreceipt.Remaining = newreceipt.Total - newreceipt.Paid;
                textEdit4.Text = newreceipt.Remaining.ToString();
                newreceipt.Supplier = db.Suppliers.FirstOrDefault(d => d.ID == (int)LueItem.EditValue);
                int id = (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID");
                newreceipt.ID = id;

                #endregion


                #region update object
                #region Supplieraccount
                decimal Old_Reminaing = (decimal)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Remaining");
                newreceipt.Supplier.account += newreceipt.Remaining-Old_Reminaing;
                #endregion

                db.Entry(newreceipt).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                #endregion
                #region fillGridcontrol
                gridControl1.DataSource = db.YeildRecipts.Select(r => new { r.ID, SName = r.Supplier.Name, Fdan = r.AcrePrice, r.CaratPrice, r.Paid, r.Total, r.Remaining, r.Date, r.Notes, Price = r.Price }).ToList();
                #endregion
                XtraMessageBox.Show("Updated Succuessfuly ", "Successed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                emptyControls();
            }
            else
            {
                XtraMessageBox.Show("Please Complete Data ", "Warnning", MessageBoxButtons.OK);
            }
        }

        #endregion

        #region Delete

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            #region delete record
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SName") != null)
            {
                int id = (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID");

                var receipt = db.YeildRecipts.Where(w => w.ID == id).Include(ee=>ee.Supplier).FirstOrDefault();
                if (XtraMessageBox.Show($"Do you want to delete Receipt number {id}?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    #region Supplieraccount
                    receipt.Supplier.account -= receipt.Remaining;
                    #endregion
                    db.YeildRecipts.Remove(receipt);
                    db.SaveChanges();
                    XtraMessageBox.Show("Removed Succuessfuly ", "Successed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            #endregion
           
            #region fillGridcontrol
            gridControl1.DataSource = db.YeildRecipts.Select(r => new { r.ID, SName = r.Supplier.Name, Fdan = r.AcrePrice, r.CaratPrice, r.Paid, r.Total, r.Remaining, r.Date, r.Notes, Price = r.Price }).ToList();
            #endregion
            emptyControls();
        }

        #endregion

        #region Printing
        private void simpleButton4_Click_1(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();

        }
        #endregion

        #region GridViewSelect
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SName") != null)
            {

                #region fill form from gridbox
                richTextBox1.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Notes").ToString();
                DateTime date = (DateTime)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Date");

                dateEdit1.Text = date.ToShortDateString();
                textEdit6.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Fdan").ToString();
                textEdit5.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CaratPrice").ToString();
                textEdit1.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Price").ToString();
                textEdit2.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Total").ToString();
                textEdit3.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Paid").ToString();
                textEdit4.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Remaining").ToString();
                LueItem.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SName").ToString();

                #endregion



            }

        }

        #endregion
        
        #region RsestControlls
        private void emptyControls()
        {
            richTextBox1.Text = "";
            dateEdit1.Text = "";
            textEdit6.Text = "";
            textEdit5.Text = "";
            textEdit1.Text = "";
            textEdit2.Text = "0";
            textEdit3.Text = "0";
            textEdit4.Text = "0";

        }

        #endregion

        #region calculate Remaining
        private void textEdit2_TextChanged(object sender, EventArgs e)
        {
            textEdit4.Text = (decimal.Parse(textEdit2.Text) - decimal.Parse(textEdit3.Text)).ToString();

        }

        private void textEdit3_TextChanged(object sender, EventArgs e)
        {
            textEdit4.Text = (decimal.Parse(textEdit2.Text) - decimal.Parse(textEdit3.Text)).ToString();

        }


        #endregion

     
    }
}