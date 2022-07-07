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
using System.Data.Entity;
using TomProject.Permission;

namespace TomProject
{
    public partial class Form_Fillitem : DevExpress.XtraEditors.XtraForm
    {
        Garlic g;
        public void gridfillview()
        {
            g = new Garlic();

            gridControl1.DataSource = g.FillItems.Select(ww => new { ww.ID, ww.Name, ww.Quantity }).ToList();
            gridView1.Columns[0].Caption = "م";
            gridView1.Columns[1].Caption = "نوع التعبئة";
            gridView1.Columns[2].Caption = "الكميه المتاحه";
        }
        public void clear()
        {
            txtype.Text = "";
            txtquantity.Text = "";
        }
        public Form_Fillitem()
        {
            InitializeComponent();
           
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            g = new Garlic();

            if (txtype.Text != "" && txtquantity.Text != "") 
            {
                FillItem fill = new FillItem();
                fill.Name = txtype.Text;
                fill.Quantity = int.Parse(txtquantity.Text);

                g.FillItems.Add(fill);
                g.SaveChanges();
                MessageBox.Show("Added Succuessfuly ", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
                gridfillview();
            }
            else
            {
                MessageBox.Show("يرجى ادخال كافة الحقول", "Warrning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }


        }

        private void formFollitem_Load(object sender, EventArgs e)
        {
            if (LoginInfo.UserRole == "موظف")
            {
                simpleButton3.Enabled = false;
            }
            gridfillview();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            g = new Garlic();

            if (txtype.Text != "" && txtquantity.Text != "")
            {
                FillItem fill = new FillItem();
                fill.ID = int.Parse(txtid.Text);
                fill.Name = txtype.Text;
                fill.Quantity = int.Parse(txtquantity.Text);
                g.Entry(fill).State = System.Data.Entity.EntityState.Modified;

                g.SaveChanges();
                MessageBox.Show("تم تعديل البيانات بنجاح", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
                gridfillview();

            }
            else
            {
                MessageBox.Show("يرجى اختيار الحقل لتعديله", "Warrning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            txtid.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();

            txtype.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
            txtquantity.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString();
               
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            g = new Garlic();

            try
            {
                if (txtype.Text != "" && txtquantity.Text != "")
                {
                    FillItem fill = new FillItem();
                    fill.ID = int.Parse(txtid.Text);
                    fill.Name = txtype.Text;
                    fill.Quantity = int.Parse(txtquantity.Text);
                    g.Entry(fill).State = System.Data.Entity.EntityState.Deleted;
                    
                    if(MessageBox.Show("يرجى التاكد من حذف البيانات", "Warrning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)==DialogResult.OK)
                    {
                        g.SaveChanges();
                        MessageBox.Show("تم حذف البيانات بنجاح", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                        gridfillview();

                    }
                    else
                    {
                        clear();
                        gridfillview();
                    }
                   
                }
                else
                {
                    MessageBox.Show("يرجى اختيار الحقل لحذفه", "Warrning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            catch
            {
                MessageBox.Show("يرجى حذف جميع العنصر المرتبطه بهه التعبئة فى السجلات الاخرى اولا", "Warrning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

   

        private void simpleButton4_Click_1(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();

        }
    }
}