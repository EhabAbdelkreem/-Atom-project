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

namespace TomProject.PL
{
    public partial class Form_CustomerTransactions : DevExpress.XtraEditors.XtraForm
    {
        Garlic db = new Garlic();

        public Form_CustomerTransactions()
        {
            InitializeComponent();
        }
        #region Fillgrid
        private void fillgrid()
        {

            gridControl1.DataSource =
            db.CustomerTransactions.Select(r => new
            { r.ID, SName = r.Customer.Name, r.Date, r.Notes, r.TransactionType, r.Amount, c = r.Customer.account }).ToList();
        }
        #endregion

        #region FormLoad
        private void Form_CustomerTransactions_Load(object sender, EventArgs e)
        {
            #region Supplierlookupedit
            var Customer = db.Customers.Select(ee => new { ID = ee.ID, Name = ee.Name }).ToList();
            LueItem.EditValue = db.Customers.Select(a => a.ID).FirstOrDefault();//to select first elment in form load
            LueItem.Properties.DataSource = Customer;
            LueItem.Properties.DisplayMember = "Name";
            LueItem.Properties.ValueMember = "ID";
            ///hide ID From lookupedit
            LueItem.Properties.PopulateColumns();
            LueItem.Properties.Columns[0].Visible = false;
            //for supplier account
            var Customeracc = db.Customers.FirstOrDefault(d => d.ID == (int)LueItem.EditValue);
            txtAccount.Text = Customeracc.account.ToString();
            #endregion


            #region gridControl1
            fillgrid();
            #endregion

        }
        #endregion

        #region RsestControlls
        private void emptyControls()
        {
            txtnotes.Text = "";
            txtDate.Text = "";
            txtType.Text = "";
            txtamount.Text = "0";
            var Customeracc = db.Customers.FirstOrDefault(d => d.ID == (int)LueItem.EditValue);
            txtAccount.Text = Customeracc.account.ToString();

        }
        #endregion

        #region Insert
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if (!(txtamount.Text == "" || txtType.Text == "" || LueItem.Text == "" || txtType.Text == ""))
            {
                #region create object of reciept
                var newreceipt = new CustomerTransaction();
                newreceipt.Date = Convert.ToDateTime(txtDate.Text);
                newreceipt.Notes = txtnotes.Text;
                newreceipt.Amount = (decimal)float.Parse(txtamount.Text); ;
                newreceipt.TransactionType = txtType.Text;



                newreceipt.Customer = db.Customers.FirstOrDefault(d => d.ID == (int)LueItem.EditValue);
                #endregion
                #region Supplieraccount

                if (txtType.Text == "تحصيل")
                {
                    newreceipt.Customer.account += decimal.Parse(txtamount.Text);
                }
                else
                {
                    newreceipt.Customer.account -= decimal.Parse(txtamount.Text);

                }

                #endregion

                #region add to Database and show gridview
                db.CustomerTransactions.Add(newreceipt);
                db.SaveChanges();
                fillgrid();
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

        #region GridView
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

        #endregion

        #region Update
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (!(txtamount.Text == "" || txtType.Text == ""
                || txtnotes.Text == "" || LueItem.Text == "" || txtType.Text == ""))
            {


                #region create object of reciept
                var newreceipt = new CustomerTransaction();
                newreceipt.Date = Convert.ToDateTime(txtDate.Text);
                newreceipt.Notes = txtnotes.Text;
                newreceipt.Amount = (decimal)float.Parse(txtamount.Text);

                newreceipt.TransactionType = txtType.Text;
                newreceipt.Customer = db.Customers.FirstOrDefault(d => d.ID == (int)LueItem.EditValue);

                #endregion
                int id = (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID");
                newreceipt.ID = id;


                #region update object
                #region Supplieraccount
                string old_trans = (string)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TransactionType");
                decimal old_Money = (decimal)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Amount");
                if (txtType.Text == "تحصيل")
                {
                    if (txtType.Text == old_trans)
                    {
                        newreceipt.Customer.account += newreceipt.Amount - old_Money;

                    }
                    else
                    {
                        newreceipt.Customer.account += (newreceipt.Amount + old_Money);
                    }
                }
                else
                {
                    if (txtType.Text == old_trans)
                    {
                        newreceipt.Customer.account += newreceipt.Amount - old_Money;
                    }
                    else
                    {
                        newreceipt.Customer.account -= (newreceipt.Amount + old_Money);
                    }

                }
                #endregion
                db.CustomerTransactions.AddOrUpdate(newreceipt);
                db.SaveChanges();

                #endregion
                #region 
                fillgrid();

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

                var receipt = db.CustomerTransactions.Where(w => w.ID == id).Include(ee => ee.Customer).FirstOrDefault();
                if (XtraMessageBox.Show($"Do you want to delete Receipt number {id}?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    #region Supplieraccount
                    string old_trans = (string)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TransactionType");
                    decimal old_Money = (decimal)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Amount");
                    if (old_trans == "تحصيل")
                    {
                        receipt.Customer.account -= old_Money;
                    }
                    else
                    {
                        receipt.Customer.account += old_Money;
                    }
                    #endregion
                    db.CustomerTransactions.Remove(receipt);
                    db.SaveChanges();
                    XtraMessageBox.Show("Removed Succuessfuly ", "Successed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            #endregion

            #region fillGridcontrol
            fillgrid();
            #endregion
            emptyControls();
        }
        #endregion

        #region Print
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();

        }
        #endregion

        private void LueItem_EditValueChanged(object sender, EventArgs e)
        {
            var Customer = db.Customers.FirstOrDefault(d => d.ID == (int)LueItem.EditValue);
            txtAccount.Text = Customer.account.ToString();
        }
    }
}