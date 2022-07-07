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

namespace TomProject.PL
{
    public partial class FormSupplierTransactions : DevExpress.XtraEditors.XtraForm
    {
        Garlic db = new Garlic();

        public FormSupplierTransactions()
        {
            InitializeComponent();
        }


        #region formLoad
        private void FormSupplierTransactions_Load_1(object sender, EventArgs e)
        {
            if (LoginInfo.UserRole == "موظف")
            {
                simpleButton2.Enabled = false;
            }
            #region Supplierlookupedit
            var supplier = db.Suppliers.Select(ee => new { ID = ee.ID, Name = ee.Name }).ToList();
            LueItem.EditValue = db.Suppliers.Select(a => a.ID).FirstOrDefault();//to select first elment in form load
            LueItem.Properties.DataSource = supplier;
            LueItem.Properties.DisplayMember = "Name";
            LueItem.Properties.ValueMember = "ID";
            ///hide ID From lookupedit
            LueItem.Properties.PopulateColumns();
            LueItem.Properties.Columns[0].Visible = false;
    
            #endregion


            #region gridControl1
            gridControl1.DataSource =
            db.SupplierTransactions.Select(r => new
            { r.ID, SName = r.Supplier.Name, r.Date, r.Notes, r.TransactionType, r.Amount , c = r.Supplier.account }).ToList();
            #endregion

        }
        #endregion

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if (!(txtamount.Text == "" || txtType.Text == "" || LueItem.Text == "" || txtType.Text == ""))
            {
                #region create object of reciept
                var newreceipt = new SupplierTransaction();
                newreceipt.Date = Convert.ToDateTime( txtDate.Text) ;
                newreceipt.Notes = txtnotes.Text;
                newreceipt.Amount = (decimal)float.Parse(txtamount.Text); ;
                newreceipt.TransactionType = txtType.Text;
                


                newreceipt.Supplier = db.Suppliers.FirstOrDefault(d => d.ID == (int)LueItem.EditValue);
                #endregion
                #region Supplieraccount

                if (txtType.Text == "تحصيل")
                {
                    newreceipt.Supplier.account += decimal.Parse(txtamount.Text);
                }
                else
                {
                    newreceipt.Supplier.account -= decimal.Parse(txtamount.Text);

                }

                #endregion

                #region add to Database and show gridview

                db.SupplierTransactions.Add(newreceipt);
                db.SaveChanges();
                gridControl1.DataSource =
               db.SupplierTransactions.Select(r => new
               { r.ID, SName = r.Supplier.Name, r.Date, r.Notes, r.Amount, c = r.Supplier.account, r.TransactionType }).ToList();
                #endregion
                emptyControls();
                XtraMessageBox.Show("Added Succuessfuly ", "Successed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                XtraMessageBox.Show("Please Complete Data ", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        #region RsestControlls
        private void emptyControls()
        {
            txtnotes.Text = "";
            txtDate.Text = "";
            txtType.Text = "";
            txtamount.Text = "0";
            var supplieracc = db.Suppliers.FirstOrDefault(d => d.ID == (int)LueItem.EditValue);
            txtAccount.Text = supplieracc.account.ToString();

        }
        #endregion
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SName") != null)
            {

                #region fill form from gridbox
                txtnotes.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Notes").ToString();
                DateTime date = (DateTime)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Date");
                txtDate.Text = date.ToShortDateString();
                txtType.Text = (string)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TransactionType");
                txtamount.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Notes").ToString();
                LueItem.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SName").ToString();
                txtamount.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Amount").ToString();

                #endregion
            }

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (!(txtamount.Text == "" || txtType.Text == ""
                 || txtnotes.Text == "" || LueItem.Text == "" || txtType.Text == ""))
            {


                #region create object of reciept
                var newreceipt = new SupplierTransaction();
                newreceipt.Date = Convert.ToDateTime(txtDate.Text);
                newreceipt.Notes = txtnotes.Text;
                newreceipt.Amount = (decimal)float.Parse(txtamount.Text);

                newreceipt.TransactionType = txtType.Text;
                newreceipt.Supplier = db.Suppliers.FirstOrDefault(d => d.ID == (int)LueItem.EditValue);

                #endregion
                int id = (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID");
                newreceipt.ID = id;


                #region update object
                #region Supplieraccount
                string old_trans = (string)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TransactionType");
                decimal old_Money = (decimal)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Amount");
                if (txtType.Text == "تحصيل")
                {
                    if(txtType.Text==old_trans)
                    {
                        newreceipt.Supplier.account += newreceipt.Amount - old_Money;

                    }
                    else
                    {
                        newreceipt.Supplier.account +=( newreceipt.Amount + old_Money);
                    }
                }
                else
                {
                    if (txtType.Text == old_trans)
                    {
                        newreceipt.Supplier.account += newreceipt.Amount - old_Money;
                    }
                    else
                    {
                        newreceipt.Supplier.account -= (newreceipt.Amount + old_Money);
                    }

                }
                #endregion
                db.SupplierTransactions.AddOrUpdate(newreceipt);
                db.SaveChanges();

                #endregion
                #region fillGridcontrol
                gridControl1.DataSource =
                  db.SupplierTransactions.Select(r => new
                 { r.ID, SName = r.Supplier.Name, r.Date, r.Notes, r.Amount, c = r.Supplier.account, r.TransactionType }).ToList();
                #endregion
                XtraMessageBox.Show("Updated Succuessfuly ", "Successed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                emptyControls();
            }
            else
            {
                XtraMessageBox.Show("Please Complete Data ", "Warnning", MessageBoxButtons.OK);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            #region delete record
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SName") != null)
            {
                int id = (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID");

                var receipt = db.SupplierTransactions.Where(w => w.ID == id).Include(ee => ee.Supplier).FirstOrDefault();
                if (XtraMessageBox.Show($"Do you want to delete Receipt number {id}?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    #region Supplieraccount
                    string old_trans = (string)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TransactionType");
                    decimal old_Money = (decimal)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Amount");
                    if (old_trans == "تحصيل")
                    {
                        receipt.Supplier.account -= old_Money;
                    }
                    else
                    {
                        receipt.Supplier.account += old_Money;
                    }
                    #endregion
                    db.SupplierTransactions.Remove(receipt);
                    db.SaveChanges();
                    XtraMessageBox.Show("Removed Succuessfuly ", "Successed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            #endregion

            #region fillGridcontrol
            gridControl1.DataSource =
                      db.SupplierTransactions.Select(r => new
                      { r.ID, SName = r.Supplier.Name, r.Date, r.Notes, r.TransactionType, r.Amount, c = r.Supplier.account }).ToList();
            #endregion
            emptyControls();
        }

   

        public void simpleButton4_Click(object sender, EventArgs e)
        {
            #region fillGridcontrol
            gridControl1.DataSource =
                      db.SupplierTransactions.Select(r => new
                      { r.ID, SName = r.Supplier.Name, r.Date, r.Notes, r.TransactionType, r.Amount, c = r.Supplier.account }).ToList();
            #endregion
            gridControl1.ShowPrintPreview();

        }

        private void LueItem_EditValueChanged(object sender, EventArgs e)
        {
            var supplier = db.Suppliers.FirstOrDefault(d => d.ID == (int)LueItem.EditValue);
            txtAccount.Text= supplier.account.ToString();
        }
    }
}