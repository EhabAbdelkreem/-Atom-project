using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TomProject.Context;
using TomProject.Entities;
using TomProject.Permission;

namespace TomProject
{
    public partial class Form_RawRecipets : DevExpress.XtraEditors.XtraForm
    {
        Garlic db = new Garlic();
        public Form_RawRecipets()
        {
            InitializeComponent();
        }

        #region FormLoad

        private void Form_RawRecipets_Load(object sender, EventArgs e)
        {
            if (LoginInfo.UserRole == "موظف")
            {
                btnDelete.Enabled = false;
            }
            #region Supplierlookupedit
            var supplier = db.Suppliers.Select(ee => new { ID = ee.ID, Name = ee.Name }).ToList();

            LueItem.Properties.DataSource = supplier;
            LueItem.Properties.DisplayMember = "Name";
            LueItem.Properties.ValueMember = "ID";
            LueItem.EditValue = db.Suppliers.Select(a => a.ID).FirstOrDefault();//to select first elment in form load

            ///hide ID From lookupedit
            LueItem.Properties.PopulateColumns();
            LueItem.Properties.Columns[0].Visible = false;

            #endregion

            #region fillGridcontrol
            fillgird();
            #endregion
        }

        #endregion

        #region Insert
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!(dateEdit1.Text == "" || txtWeight.Text == "" || txtFinalWeight.Text == "" || cbxSize.Text == ""||txtPrice.Text==""
              || cbxType.Text == "" || txtTotal.Text == "" || txtPaid.Text == "" || txtRemaining.Text == ""))
            {
                #region create object of reciept
                var newreceipt = new RawRecipet();
                newreceipt.Type = cbxType.Text;
                newreceipt.Size =int.Parse(cbxSize.Text);
                newreceipt.Weight = float.Parse(txtWeight.Text);
                newreceipt.FinalWeight = float.Parse(txtFinalWeight.Text);
                newreceipt.Date = Convert.ToDateTime(dateEdit1.Text);
                newreceipt.Notes = txtNotes.Text;
                newreceipt.Price = decimal.Parse(txtPrice.Text);
                newreceipt.Total = decimal.Parse(txtTotal.Text);
                newreceipt.Paid = decimal.Parse(txtPaid.Text);
                newreceipt.Remaining = decimal.Parse(txtRemaining.Text);
                newreceipt.Supplier = db.Suppliers.FirstOrDefault(d => d.ID == (int)LueItem.EditValue);
                #endregion


                #region Supplieraccount
                newreceipt.Supplier.account += decimal.Parse(txtRemaining.Text);
                #endregion

                #region add to Database and show gridview
                db.RawRecipets.Add(newreceipt);
                db.SaveChanges();
                fillgird();
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
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!(dateEdit1.Text == "" || txtWeight.Text == "" || txtFinalWeight.Text == "" || cbxSize.Text == "" || txtPrice.Text == ""
              || cbxType.Text == "" || txtTotal.Text == "" || txtPaid.Text == "" || txtRemaining.Text == ""))
            {
                #region create object of reciept
                var newreceipt = new RawRecipet();
                newreceipt.Type = cbxType.Text;
                newreceipt.Size = int.Parse(cbxSize.Text);
                newreceipt.Weight = float.Parse(txtWeight.Text);
                newreceipt.FinalWeight = float.Parse(txtFinalWeight.Text);
                newreceipt.Date = Convert.ToDateTime(dateEdit1.Text);
                newreceipt.Notes = txtNotes.Text;
                newreceipt.Price = decimal.Parse(txtPrice.Text);
                newreceipt.Total = decimal.Parse(txtTotal.Text);
                newreceipt.Paid = decimal.Parse(txtPaid.Text);
                newreceipt.Remaining = decimal.Parse(txtRemaining.Text);
                newreceipt.Supplier = db.Suppliers.FirstOrDefault(d => d.ID == (int)LueItem.EditValue);
                int id = (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID");
                newreceipt.ID = id;

                #endregion


                #region update object
                #region Supplieraccount
                decimal Old_Reminaing = (decimal)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Remaining");
                newreceipt.Supplier.account += newreceipt.Remaining - Old_Reminaing;
                #endregion

                db.RawRecipets.AddOrUpdate(newreceipt);
                db.SaveChanges();

                #endregion

                #region fillGridcontrol
                fillgird();
                #endregion

                XtraMessageBox.Show("Updated Succuessfuly ", "Successed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                emptyControls();
            }
            else
                XtraMessageBox.Show("Please Complete Data ", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Delete

        private void btnDelete_Click(object sender, EventArgs e)
        {
            #region delete record
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SName") != null)
            {
                int id = (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID");

                var receipt = db.RawRecipets.Where(w => w.ID == id).Include(ee => ee.Supplier).FirstOrDefault();
                if (XtraMessageBox.Show($"Do you want to delete Receipt number {id}?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    #region Supplieraccount
                    receipt.Supplier.account -= receipt.Remaining;
                    #endregion
                    db.RawRecipets.Remove(receipt);
                    db.SaveChanges();
                    XtraMessageBox.Show("Removed Succuessfuly ", "Successed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            #endregion

            #region fillGridcontrol
            fillgird();
            #endregion
            emptyControls();
        }

        #endregion


        #region Printing
        public void simpleButton4_Click(object sender, EventArgs e)
        {
            fillgird();
            gridControl1.ShowPrintPreview();
        }
        #endregion

        #region GridViewSelect
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SName") != null)
            {

                #region fill form from gridbox
                txtNotes.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Notes").ToString();
                DateTime date = (DateTime)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Date");

                dateEdit1.Text = date.ToShortDateString();
                cbxType.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Type").ToString();
                cbxSize.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Size").ToString();
                txtPrice.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Price").ToString();
                txtTotal.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Total").ToString();
                txtPaid.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Paid").ToString();
                txtRemaining.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Remaining").ToString();
                LueItem.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SName").ToString();
                txtWeight.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Weight").ToString();
                txtFinalWeight.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FinalWeight").ToString();


                #endregion



            }

        }

        #endregion


        #region HelpsFunctions
        private void fillgird()
        {
            gridControl1.DataSource = db.RawRecipets.Select(r => new { r.ID, SName = r.Supplier.Name, r.Date, r.Type, r.Size, r.Paid, r.Total, r.Remaining, r.Notes, r.Price, r.Weight, r.FinalWeight }).ToList();

        }
        private void emptyControls()
        {
            dateEdit1.Text = "";
            txtWeight.Text = "0";
            txtFinalWeight.Text = "0";
            cbxSize.Text = "";
            txtPrice.Text = "0";
            cbxType.Text = "";
            txtTotal.Text = "0";
            txtPaid.Text = "0";
            txtRemaining.Text = "0";
            txtNotes.Text = "";
        }

        #endregion
        #region calculate Total
        private void txtFinalWeight_TextChanged(object sender, EventArgs e)
        {
            txtTotal.Text = txtRemaining.Text = (decimal.Parse(txtFinalWeight.Text) * decimal.Parse(txtPrice.Text)).ToString();

        }



        private void txtPrice_TextChanged_1(object sender, EventArgs e)
        {
            txtTotal.Text = txtRemaining.Text = (decimal.Parse(txtFinalWeight.Text) * decimal.Parse(txtPrice.Text)).ToString();

        }
        #endregion
        #region calculate Remaining
        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            txtRemaining.Text = (decimal.Parse(txtTotal.Text) - decimal.Parse(txtPaid.Text)).ToString();

        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            txtRemaining.Text = txtRemaining.Text = (decimal.Parse(txtTotal.Text) - decimal.Parse(txtPaid.Text)).ToString();


        }




        #endregion
    }
}