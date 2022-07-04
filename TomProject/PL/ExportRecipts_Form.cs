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

namespace TomProject
{

    public partial class ExportRecipts_Form : DevExpress.XtraEditors.XtraForm
    {
        Garlic db = new Garlic();
        public ExportRecipts_Form()
        {
            InitializeComponent();
        }

        private void ExportRecipts_Form_Load(object sender, EventArgs e)
        {
            var custom = db.Customers.Select(ee => new { ID = ee.ID, Name = ee.Name }).ToList();
            LueItem_name.Text = db.Suppliers.Select(a => a.Name).FirstOrDefault();//to select first elment in form load
            LueItem_name.Properties.DataSource = custom;
            LueItem_name.Properties.DisplayMember = "Name";
            LueItem_name.Properties.ValueMember = "ID";
           
            LueItem_name.Properties.PopulateColumns();
            LueItem_name.Properties.Columns[0].Visible = false;




            gridControl1.DataSource = db.ExportRecipets.Select(r => new { r.ID, Name = r.Customer.Name, r.Date, r.FillQuantity, r.Paid, r.Total, r.Remaining, r.Size, r.Notes, r.Price, r.NumberOfUnit, r.UnitWeight, r.TotalWeight }).ToList();



        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if(comboBoxEdit_typofproduct.Text == " " ||
             textBox_fillquantity.Text == " " ||
            comboBoxEdit_size.Text == " " ||
            textEdit_numofunit.Text == " " ||
             textEdit_paid.Text ==  " " ||
               LueItem_name.Text==" " ||
               
               richTextBox1.Text==" "||
               textEdit1.Text==" "||
               textEdit_weighttotal.Text==" "||
             textEdit_total.Text == " " ||
             textEdit_wightunit.Text == " " ||
             textEdit_remaind.Text == " " )



            {
                XtraMessageBox.Show("Please Complete Data ", "Warnning", MessageBoxButtons.OK);

            }
            else
            {
                ExportRecipet ex = new ExportRecipet();
                ex.Date = dateTimePicker1.Value;
                ex.Notes = richTextBox1.Text;
                ex.Type = comboBoxEdit_typofproduct.Text;
                ex.Size = int.Parse(comboBoxEdit_size.Text);
                ex.FillQuantity = int.Parse(textBox_fillquantity.Text);
                ex.NumberOfUnit = int.Parse(textEdit_numofunit.Text);
                ex.UnitWeight = float.Parse(textEdit_wightunit.Text);
                ex.TotalWeight = float.Parse(textEdit_weighttotal.Text);
                ex.Price = decimal.Parse(textEdit1.Text);
                ex.Total = decimal.Parse(textEdit_total.Text);
                ex.Paid = decimal.Parse(textEdit_paid.Text);
                ex.Remaining = decimal.Parse(textEdit_remaind.Text);


                ex.Customer = db.Customers.FirstOrDefault(d => d.ID == (int)LueItem_name.EditValue);
                ex.Customer.account += decimal.Parse(textEdit_remaind.Text);




                db.ExportRecipets.Add(ex);

                db.SaveChanges();
                
                XtraMessageBox.Show("Added Succuessfuly ", "Successed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     this.ExportRecipts_Form_Load(sender, e);
                  textEdit_wightunit.Text = textEdit_weighttotal.Text =
                    textBox_fillquantity.Text = textEdit_numofunit.Text = richTextBox1.Text = 
                comboBoxEdit_size.Text = comboBoxEdit_typofproduct.Text  = dateTimePicker1.Text = LueItem_name.Text= "";

                textEdit_total.Text = textEdit_paid.Text = textEdit1.Text= textEdit_remaind.Text = "0";


            }




        }

        private void comboBox_name_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            if (comboBoxEdit_typofproduct.Text == "" ||
             textBox_fillquantity.Text == "" ||
            comboBoxEdit_size.Text == "" ||
            textEdit_numofunit.Text == "" ||
             textEdit_paid.Text == "" ||
               LueItem_name.Text == "" ||
               dateTimePicker1.Text == "" ||
               richTextBox1.Text == "" ||
               textEdit1.Text ==""||
               textEdit_weighttotal.Text == "" ||
             textEdit_total.Text == "" ||
             textEdit_wightunit.Text == "" ||
             textEdit_remaind.Text == "")




            {
                XtraMessageBox.Show("Please Complete Data ", "Warnning", MessageBoxButtons.OK);

            }
            else
            {
                ExportRecipet ex = new ExportRecipet();
                ex.Date = dateTimePicker1.Value;
                ex.Notes = richTextBox1.Text;
                ex.Type = comboBoxEdit_typofproduct.Text;
                ex.Size = int.Parse(comboBoxEdit_size.Text);
                ex.FillQuantity = int.Parse(textBox_fillquantity.Text);
                ex.NumberOfUnit = int.Parse(textEdit_numofunit.Text);
                ex.UnitWeight = float.Parse(textEdit_wightunit.Text);
                ex.TotalWeight = float.Parse(textEdit_weighttotal.Text);
                ex.Price = decimal.Parse(textEdit1.Text);
                ex.Total = decimal.Parse(textEdit_total.Text);
                ex.Paid = decimal.Parse(textEdit_paid.Text);
                ex.Remaining = decimal.Parse(textEdit_remaind.Text);
                
                ex.Customer = db.Customers.FirstOrDefault(d => d.ID == (int)LueItem_name.EditValue);
                int id = (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID");
                ex.ID = id;





                decimal Old_Reminaing = (decimal)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Remaining");
                ex.Customer.account += ex.Remaining - Old_Reminaing;


                db.Entry(ex).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();


               
                gridControl1.DataSource = db.YeildRecipts.Select(r => new { r.ID, SName = r.Supplier.Name, Fdan = r.AcrePrice, r.CaratPrice, r.Paid, r.Total, r.Remaining, r.Date, r.Notes, Price = r.Price }).ToList();

                
                XtraMessageBox.Show("Updated Succuessfuly ", "Successed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                 textEdit_wightunit.Text = textEdit_weighttotal.Text =textBox_fillquantity.Text = textEdit_numofunit.Text = richTextBox1.Text= 
                     
                 comboBoxEdit_size.Text = comboBoxEdit_typofproduct.Text = dateTimePicker1.Text = LueItem_name.Text = "";

                textEdit_remaind.Text = textEdit_paid.Text = textEdit_total.Text = "0";
            }

        }




        private void lookUpEdit_typeofproduct_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            
            
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Name") != null)
                {
                    int id = (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID");

                    var receipt = db.ExportRecipets.Where(w => w.ID == id).Include(ee => ee.Customer).FirstOrDefault();
                    if (XtraMessageBox.Show($"Do you want to delete Receipt number {id}?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
                    {
                        
                        receipt.Customer.account -= receipt.Remaining;
                        
                        db.ExportRecipets.Remove(receipt);
                        db.SaveChanges();
                        XtraMessageBox.Show("Removed Succuessfuly ", "Successed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }


                
                gridControl1.DataSource = db.ExportRecipets.Select(r => new { r.ID, Name = r.Customer.Name, r.Date, r.FillQuantity, r.Paid, r.Total, r.Remaining, r.Size, r.Notes, r.Price, r.NumberOfUnit, r.UnitWeight, r.TotalWeight }).ToList();

            textEdit_wightunit.Text = textEdit_weighttotal.Text = textBox_fillquantity.Text = textEdit_numofunit.Text = richTextBox1.Text =

            comboBoxEdit_size.Text = comboBoxEdit_typofproduct.Text = dateTimePicker1.Text = LueItem_name.Text = "";

            textEdit_remaind.Text = textEdit_paid.Text = textEdit_total.Text = "0";
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            gridView1_RowClick(sender, e, textEdit_numofunit.Text);
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e, string text)
        {
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Name") != null)
            {

                
                richTextBox1.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Notes").ToString();
                DateTime date = (DateTime)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Date");

                dateTimePicker1.Text = date.ToShortDateString();
                LueItem_name.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Name").ToString();
                comboBoxEdit_typofproduct.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Type").ToString();
                textBox_fillquantity.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FillQuantity").ToString();
                comboBoxEdit_size.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Size").ToString();
                textEdit_numofunit.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NumberOfUnit").ToString();
                textEdit_paid.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Paid").ToString();
                textEdit_remaind.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Remaining").ToString();
                textEdit_total.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Total").ToString();
                textEdit_weighttotal.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TotalWeight").ToString();
                textEdit_wightunit.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "UnitWeight").ToString();
                textEdit1.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Price").ToString();


            }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit_total_TextChanged(object sender, EventArgs e)
        {
            textEdit_remaind.Text = (decimal.Parse(textEdit_total.Text) - decimal.Parse(textEdit_paid.Text)).ToString();
        }

        private void textEdit_paid_TextChanged(object sender, EventArgs e)
        {
            textEdit_remaind.Text = (decimal.Parse(textEdit_total.Text) - decimal.Parse(textEdit_paid.Text)).ToString();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();

        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
