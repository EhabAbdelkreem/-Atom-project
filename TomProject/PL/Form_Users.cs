using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TomProject.Context;
using System.Data.Entity;
using TomProject.Entities;
using DevExpress.XtraEditors;

namespace TomProject
{
    public partial class form_Users : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        Garlic db = new Garlic();

        public form_Users()
        {
            InitializeComponent();
        }

        #region sidebar



        #region Admin
        private void admin_Click(object sender, EventArgs e)
        {


            gridControl1.DataSource = db.Users.Where(a => a.Type == "admin").
                  Select(em => new { sName = em.UserName, em.ID, em.Type, em.Password }).ToList();

        }
        #endregion


        #region manger
        private void manger_Click(object sender, EventArgs e)
        {


            gridControl1.DataSource =
                         db.Users.Where(a => a.Type == "manger")
                         .Select(em => new { sName = em.UserName, em.ID, em.Type, em.Password }).ToList();

        }
        #endregion


        #region Employees
        private void employee_Click(object sender, EventArgs e)
        {

            gridControl1.DataSource =
             db.Users.Where(a => a.Type == "Employees")
             .Select(em => new { sName = em.UserName, em.ID, em.Type, em.Password }).ToList();

        }




        #endregion

        #endregion



        private void Administration_loadk(object sender, EventArgs e)
        {

            gridControl1.DataSource =
             db.Users
             .Select(em => new { sName = em.UserName, em.ID, em.Type, em.Password }).ToList();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!(txtName.Text == "" || txtpass.Text == "" || txtpermission.Text == ""))
            {
                #region create object of reciept
                var newreceipt = new User();
                newreceipt.UserName = txtName.Text;
                newreceipt.Type = txtpermission.Text;
                newreceipt.Password = txtpass.Text;



                #endregion



                #region add to Database and show gridview

                db.Users.Add(newreceipt);
                db.SaveChanges();
                gridControl1.DataSource = db.Users.Select(r => new { r.ID, sName = r.UserName, r.Password, r.Type }).ToList();
                #endregion
                emptyControls();
                XtraMessageBox.Show("Added Succuessfuly ", "Successed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                XtraMessageBox.Show("Please Complete Data ", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }
        #region emptyControls
        private void emptyControls()
        {
            txtName.Text = "";
            txtpass.Text = "";
            txtpermission.Text = "";


        }
        #endregion

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "sName") != null)
            {

                #region fill form from gridbox
                txtName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "sName").ToString();

                txtpass.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Password").ToString();
                txtpermission.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Type").ToString();

                #endregion


            }
        }

        private void fluentDesignFormContainer1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (!(txtName.Text == "" || txtpass.Text == "" || txtpermission.Text == ""))
            {
                #region create object of reciept
                var newreceipt = new User();
                newreceipt.UserName = txtName.Text;
                newreceipt.Type = txtpermission.Text;
                newreceipt.Password = txtpass.Text;

                #endregion
                int id = (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID");
                newreceipt.ID = id;



                #region update object


                db.Entry(newreceipt).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                #endregion
                #region fillGridcontrol
                gridControl1.DataSource =
                 db.Users.Select(r => new { r.ID, sName = r.UserName, r.Password, r.Type }).ToList();
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
            if (!(txtName.Text == "" || txtpass.Text == "" || txtpermission.Text == ""))
            {
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "sName") != null)
                {
                    int id = (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID");

                    var receipt = db.Users.Where(w => w.ID == id).FirstOrDefault();
                    if (XtraMessageBox.Show($"Do you want to delete Receipt number {id}?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
                    {

                        db.Users.Remove(receipt);
                        db.SaveChanges();
                        XtraMessageBox.Show("Removed Succuessfuly ", "Successed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                    XtraMessageBox.Show("Please Select Raw ", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);

                #endregion

                #region fillGridcontrol
                gridControl1.DataSource = db.Users.Select(r => new { r.ID, sName = r.UserName, r.Password, r.Type }).ToList();
                #endregion
                emptyControls();
            }
            else
            {
                XtraMessageBox.Show("Please Complete Data ", "Warnning", MessageBoxButtons.OK);

            }
        }
    }
}
