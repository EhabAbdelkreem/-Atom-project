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

namespace TomProject.PL
{
    public partial class WalletItem : DevExpress.XtraEditors.XtraForm
    {
        Garlic db = new Garlic();

        public WalletItem()
        {
            InitializeComponent();
        }

        #region FormLoad
        private void WalletItem_Load(object sender, EventArgs e)
        {
            #region fillGridcontrol
            gridControl1.DataSource = db.WalletItems.Select(r => new { r.ID, r.Name }).ToList();
            #endregion
        }

        #endregion

        #region Insert
        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            if (!(textBox3.Text == ""))
            {
                #region create object of Item
                var NewiTEM = new Entities.WalletItem();
                NewiTEM.Name = textBox3.Text;

                #endregion

                #region add to Database and show gridview

                db.WalletItems.Add(NewiTEM);
                db.SaveChanges();
                gridControl1.DataSource = db.WalletItems.ToList();
                #endregion
                textBox3.Text = "";
                XtraMessageBox.Show("Added Succuessfuly ", "Successed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                XtraMessageBox.Show("Please Complete Data ", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        #endregion

        #region GridViewSelect
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Name") != null)
            {
                #region fill form from gridbox
                textBox3.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Name").ToString();
                #endregion
            }
        }

        #endregion


        #region Update

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (!(textBox3.Text == ""))
            {

                #region create object of Item
                var NewiTEM = new Entities.WalletItem();
                NewiTEM.Name = textBox3.Text;
                NewiTEM.ID = (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID");

                #endregion


                #region update object
            
                db.Entry(NewiTEM).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                #endregion
                #region fillGridcontrol
                gridControl1.DataSource = db.WalletItems.ToList();
                #endregion
                XtraMessageBox.Show("Updated Succuessfuly ", "Successed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Text = "";


            }
            else
            {
                XtraMessageBox.Show("Please Complete Data ", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion


        #region Delete

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            #region delete record
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Name") != null)
            {
                int id = (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID");

                var Item = db.WalletItems.FirstOrDefault(w => w.ID == id);
                if (XtraMessageBox.Show($"Do you want to delete Receipt number {id}?", "Confirmation", MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.No)
                {

                    db.WalletItems.Remove(Item);
                    db.SaveChanges();
                    XtraMessageBox.Show("Removed Succuessfuly ", "Successed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                XtraMessageBox.Show("Please Select Raw ", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            #endregion

            #region fillGridcontrol
            gridControl1.DataSource = db.WalletItems.ToList();
            #endregion
            textBox3.Text = "";
        }

        #endregion

        #region Print
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }
        #endregion
    }
}