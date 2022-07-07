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
using TomProject.Permission;

namespace TomProject
{
    public partial class Form_Wallet : DevExpress.XtraEditors.XtraForm
    {
        Garlic db = new Garlic();
        public Form_Wallet()
        {
            InitializeComponent();
        }
        #region FormLoad
        private void Wallet_Load(object sender, EventArgs e)
        {
            if (LoginInfo.UserRole == "موظف")
            {
                simpleButton2.Enabled = false;
            }

            #region Supplierlookupedit
            var Items = db.WalletItems.Select(a => new { a.ID, a.Name }).ToList();
            LueItem.Text = db.WalletItems.Select(a => a.Name).FirstOrDefault();//to select first elment in form load
            LueItem.Properties.DataSource = Items;
            LueItem.Properties.DisplayMember = "Name";
            LueItem.Properties.ValueMember = "ID";
            ///hide ID From lookupedit
            LueItem.Properties.PopulateColumns();
            LueItem.Properties.Columns[0].Visible = false;
            #endregion

            #region fillGridcontrol
            fillgrid();
            #endregion


        }
        #endregion

        #region Insert

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!(dateEdit1.Text == "" || textEdit1.Text == "" ))
            {
                #region create object of reciept
                var NewWallet = new Wallet();
                NewWallet.Date = Convert.ToDateTime(dateEdit1.Text);
                NewWallet.Notes = textBox1.Text;
                NewWallet.Money = decimal.Parse(textEdit1.Text);

                NewWallet.WalletItem= db.WalletItems.FirstOrDefault(d => d.ID == (int)LueItem.EditValue);
                #endregion

                #region add to Database and show gridview

                db.Wallets.Add(NewWallet);
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

        #region Update
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (!(dateEdit1.Text == "" || textEdit1.Text == "")&& gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IName") != null)
            {
                #region Edit object of Wallet
                var NewWallet = new Wallet();
                NewWallet.Date = Convert.ToDateTime(dateEdit1.Text);
                NewWallet.Notes = textBox1.Text;
                NewWallet.Money = decimal.Parse(textEdit1.Text);
                NewWallet.WalletItem = db.WalletItems.FirstOrDefault(d => d.ID == (int)LueItem.EditValue);
                int id = (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID");
                NewWallet.ID = id;
                #endregion
                #region update object


                db.Entry(NewWallet).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                #endregion
                fillgrid();
                XtraMessageBox.Show("Updated Succuessfuly ", "Successed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                emptyControls();
            }
            else
                XtraMessageBox.Show("Please Complete Data ", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        #endregion

        #region Delete
        private void simpleButton2_Click(object sender, EventArgs e)
        {
           
                #region delete record
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IName") != null)
                {
                    int id = (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID");

                    var Walletreceipt = db.Wallets.Where(w => w.ID == id).FirstOrDefault();
                    if (XtraMessageBox.Show($"Do you want to delete Receipt number {id}?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
                    {
                        db.Wallets.Remove(Walletreceipt);
                        db.SaveChanges();
                        XtraMessageBox.Show("Removed Succuessfuly ", "Successed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    XtraMessageBox.Show("Please Select Raw ", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        #region Helps Function
            #region GridViewSelect
            private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
            {

                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IName") != null)
                {

                    #region fill form from gridbox
                    textBox1.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Notes").ToString();
                    DateTime date = (DateTime)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Date");
                    dateEdit1.Text = date.ToShortDateString();
                    textEdit1.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Money").ToString();
                    LueItem.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IName").ToString();
                    #endregion
                }

            }

            #endregion
            #region RsestControlls
            private void emptyControls()
            {
                textEdit1.Text = "";
                dateEdit1.Text = "";
                textBox1.Text = "";
                dateEdit1.Text = "";
            }

            #endregion
            #region FillGridFunction
            private void fillgrid()
            {
                gridControl1.DataSource = db.Wallets.Select(ww => new { ww.ID, IName = ww.WalletItem.Name, ww.Money, ww.Notes }).ToList();

            }


        #endregion

        #endregion

        
    }
}