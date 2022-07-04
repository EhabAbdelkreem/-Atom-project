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
    public partial class Form_Supplier : DevExpress.XtraEditors.XtraForm
    {
        Garlic db = new Garlic();

        public Form_Supplier()
        {
            InitializeComponent();
        }





        private void Form_Supplier_Load_1(object sender, EventArgs e)
        {
            gridControl1.DataSource =
             db.Suppliers.Select(em => new { sName = em.Name, em.ID, em.Phone, em.Type, em.Notes, em.Address }).ToList();
        }


        private void emptyControls()
        {
            Txtnotes.Text = "";
            Txtphone.Text = "";
            Txtaddress.Text = "";
            combType.Text = "";
            TxtName.Text = "";

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            if (!(TxtName.Text == "" || Txtaddress.Text == "" || combType.Text == ""
           || Txtphone.Text == "" || Txtnotes.Text == ""))
            {
                #region create object of reciept
                var newreceipt = new Supplier();
                newreceipt.Notes = Txtnotes.Text;
                newreceipt.Phone = (int)float.Parse(Txtphone.Text);
                newreceipt.Address = Txtaddress.Text;
                newreceipt.Type = combType.Text;
                newreceipt.Name = TxtName.Text;



                #endregion




                #region add to Database and show gridview

                db.Suppliers.Add(newreceipt);
                db.SaveChanges();
                emptyControls();
                XtraMessageBox.Show("Added Succuessfuly ", "Successed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridControl1.DataSource =
                 db.Suppliers.Select(em => new { sName = em.Name, em.ID, em.Phone, em.Type, em.Notes, em.Address }).ToList();
            }
            else
            {
                XtraMessageBox.Show("Please Complete Data ", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }





        #endregion




        #region update
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            #region
            if (!(TxtName.Text == "" || Txtaddress.Text == "" || combType.Text == ""
        || Txtphone.Text == "" || Txtnotes.Text == ""))
            {



                #region create object of reciept
                var newreceipt = new Supplier();
                newreceipt.Notes = Txtnotes.Text;
                newreceipt.Phone = (int)float.Parse(Txtphone.Text);
                newreceipt.Address = Txtaddress.Text;
                newreceipt.Type = combType.Text;
                newreceipt.Name = TxtName.Text;

                #endregion
                int id = (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID");
                newreceipt.ID = id;



                #region update object
              

                db.Entry(newreceipt).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                #endregion
                #region fillGridcontrol
                gridControl1.DataSource =
                 db.Suppliers.Select(em => new { sName = em.Name, em.ID, em.Phone, em.Type, em.Notes, em.Address }).ToList();
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

        #endregion

        #region GridViewSelect
        private void gridView1_RowClick_1(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {


            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "sName") != null)
            {

                #region fill form from gridbox
                TxtName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "sName").ToString();
                Txtphone.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Phone").ToString();
                Txtaddress.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Address").ToString();
                combType.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Type").ToString();
                #endregion

            }

        }
        #endregion


        #region print
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();

        }
        #endregion 


    }

}