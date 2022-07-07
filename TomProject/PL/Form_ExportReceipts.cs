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
    public partial class Form_ExportReceipts : DevExpress.XtraEditors.XtraForm
    {
        public Form_ExportReceipts()
        {
            InitializeComponent();
        }
        #region Helps Function
        Garlic G=new Garlic();
        public void Customerfil()
        {
            lookUpEdit1.Properties.DataSource = G.Customers.Select(ww => new { ww.ID, ww.Name }).ToList();
            lookUpEdit1.EditValue = G.Customers.Select(ww => ww.ID).FirstOrDefault().ToString();
            lookUpEdit1.Properties.DisplayMember = "Name";
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.PopulateColumns();
            lookUpEdit1.Properties.Columns["ID"].Visible = false;
        }
        public void t3bafil()
        {
            lookUpEdit2.Properties.DataSource = G.FillItems.Select(ww => new { ww.ID, ww.Name }).ToList();
            lookUpEdit2.EditValue = G.FillItems.Select(ww => ww.ID).FirstOrDefault().ToString();
            lookUpEdit2.Properties.DisplayMember = "Name";
            lookUpEdit2.Properties.ValueMember = "ID";
            lookUpEdit2.Properties.PopulateColumns();
            lookUpEdit2.Properties.Columns["ID"].Visible = false;
        }
        public void clearFields()
        {
            txtid.Text = "";
            txtnoat.Text = "";
            txtnumberofunit.Text = "";
            txtpaid.Text = "";
            txtpeice.Text = "";
            txtquantity.Text = "";
            txtrest.Text = "";
            txttotalprice.Text = "";
            txttotalweight.Text = "";
            txtunitweight.Text = "";
            cmb.Text = "";
            date.Text = "";
        }
        public void gridfillview()
        {

            gridControl1.DataSource = G.ExportRecipets.Select(ww => new { ww.ID, Suplier = ww.Customer.Name, ww.Type, ww.Date, ww.Size, Fill = ww.FillItem.Name, ww.FillQuantity, ww.NumberOfUnit, ww.UnitWeight, ww.TotalWeight, ww.Price, ww.Total, ww.Paid, ww.Remaining, ww.Notes }).ToList();
            gridView1.Columns[0].Caption = "م";
            gridView1.Columns[1].Caption = "اسم المورد";
            gridView1.Columns[2].Caption = "نوع التوريد";
            gridView1.Columns[3].Caption = "التاريخ";
            gridView1.Columns[4].Caption = "الحجم";
            gridView1.Columns[5].Caption = "نوع التعبئة";
            gridView1.Columns[6].Caption = "كمية التعبئة";
            gridView1.Columns[7].Caption = "عدد الوحدات";
            gridView1.Columns[8].Caption = "وزن الوحده";
            gridView1.Columns[9].Caption = "اجمالى الوزن";
            gridView1.Columns[10].Caption = "السعر";
            gridView1.Columns[11].Caption = "الاجمالى";
            gridView1.Columns[12].Caption = "المدفوع";
            gridView1.Columns[13].Caption = "المتبقى";
            gridView1.Columns[14].Caption = "ملاحظات";
        }
        #endregion
        private void Form_ExportReceipts_Load(object sender, EventArgs e)
        {
            if (LoginInfo.UserRole == "موظف")
            {
                simpleButton3.Enabled = false;
            }
            Customerfil();
            t3bafil();
            gridfillview();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]) != null)
            {
                txtid.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                lookUpEdit1.EditValue = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
                cmbquantity.EditValue = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2].FieldName).ToString();
                date.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString();
                cmb.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString();
                lookUpEdit2.EditValue = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5]).ToString();
                txtquantity.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[6]).ToString();
                txtnumberofunit.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[7]).ToString();
                txtunitweight.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[8]).ToString();
                txttotalweight.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[9]).ToString();
                txtpeice.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[10]).ToString();
                txttotalprice.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[11]).ToString();
                txtpaid.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[12]).ToString();
                txtrest.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[13]).ToString();
                txtnoat.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[14]).ToString();

            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (txtnoat.Text != "" && txtnumberofunit.Text != "" && txtpaid.Text != "" && txtpeice.Text != "" && txtquantity.Text != "" && txtrest.Text != "" && txttotalprice.Text != "" && txttotalweight.Text != "" && txtunitweight.Text != "")
            {

                int totalfil = 0;
                decimal acount = 0;
                var CustomerID = int.Parse(lookUpEdit1.EditValue.ToString());
                var fillID = int.Parse(lookUpEdit2.EditValue.ToString());
                var fillitemInfac = G.FillItems.Where(ww => ww.ID == fillID).Select(ww => new { ww.ID, ww.Name, ww.Quantity }).FirstOrDefault();
                if (fillitemInfac.Quantity >= int.Parse(txtquantity.Text))
                {
                    var Customer = G.Customers.Where(ww => ww.ID == CustomerID).Select(ww => new { ww.ID, ww.Name, ww.Phone, ww.Address, ww.account, ww.Notes }).FirstOrDefault();
                    ExportRecipet HR = new ExportRecipet();
                    HR.Customer = G.Customers.FirstOrDefault(ww => ww.ID == CustomerID);
                    HR.Date = DateTime.Parse(date.Text);
                    HR.FillQuantity = int.Parse(txtquantity.Text);
                    HR.FillItem = G.FillItems.FirstOrDefault(ee => ee.ID == fillID);
                    HR.Notes = txtnoat.Text;
                    HR.NumberOfUnit = int.Parse(txtnumberofunit.Text);
                    HR.Paid = decimal.Parse(txtpaid.Text);
                    HR.Price = decimal.Parse(txtpeice.Text);
                    HR.Remaining = decimal.Parse(txtrest.Text);
                    HR.Total = decimal.Parse(txttotalprice.Text);
                    HR.UnitWeight = int.Parse(txtunitweight.Text);
                    HR.TotalWeight = int.Parse(txttotalweight.Text);
                    HR.Type = cmbquantity.Text;
                    HR.Size = int.Parse(cmb.Text);
                    G.ExportRecipets.Add(HR);
                    totalfil = fillitemInfac.Quantity - int.Parse(txtquantity.Text);
                    acount = Customer.account + decimal.Parse(txtrest.Text);
                    Customer s = new Customer { ID = Customer.ID, Name = Customer.Name, Phone = Customer.Phone, Address = Customer.Address, account = acount, Notes = Customer.Notes };
                    FillItem FI = new FillItem { ID = fillitemInfac.ID, Name = fillitemInfac.Name, Quantity = totalfil };
                    G.Customers.AddOrUpdate(s);
                    G.ExportRecipets.AddOrUpdate(HR);
                    G.FillItems.AddOrUpdate(FI);
                    G.SaveChanges();


                    MessageBox.Show("Added Succuessfuly", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    gridfillview();
                    clearFields();
                }
                else
                {
                    MessageBox.Show("Fill Quantity is less than ordered", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show("Please Complete Data", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (txtnoat.Text != "" && txtnumberofunit.Text != "" && txtpaid.Text != "" && txtpeice.Text != "" && txtquantity.Text != "" && txtrest.Text != "" && txttotalprice.Text != "" && txttotalweight.Text != "" && txtunitweight.Text != "")
            {
                int oldquantity = 0;
                decimal oldremain = 0;
                int totalfil = 0;
                decimal acount = 0;
                var CustomerID = int.Parse(lookUpEdit1.EditValue.ToString());
                var fillID = int.Parse(lookUpEdit2.EditValue.ToString());
                var harvestid = int.Parse(txtid.Text);
                var fillitemInfac = G.FillItems.Where(ww => ww.ID == fillID).Select(ww => new { ww.Name, ww.Quantity }).FirstOrDefault();
                if (fillitemInfac.Quantity >= int.Parse(txtquantity.Text))
                {
                    var Customer = G.Customers.Where(ww => ww.ID == CustomerID).Select(ww => new { ww.Name, ww.Phone, ww.Address, ww.account, ww.Notes }).FirstOrDefault();
                    var harvest = G.ExportRecipets.Where(ww => ww.ID == harvestid).Select(ww => new { ww.Date, ww.FillItem, ww.FillQuantity, ww.Notes, ww.NumberOfUnit, ww.Paid, ww.Price, ww.Remaining, ww.Size, ww.Customer, ww.Total, ww.TotalWeight, ww.Type, ww.UnitWeight }).FirstOrDefault();
                    oldremain = decimal.Parse(harvest.Remaining.ToString());
                    oldquantity = harvest.FillQuantity;
                    ExportRecipet HR = new ExportRecipet();
                    HR.ID = harvestid;
                    HR.Customer = G.Customers.FirstOrDefault(ww => ww.ID == CustomerID);
                    HR.Date = DateTime.Parse(date.Text);
                    HR.FillQuantity = int.Parse(txtquantity.Text);
                    HR.FillItem = G.FillItems.FirstOrDefault(ww => ww.ID == fillID);
                    HR.Notes = txtnoat.Text;
                    HR.NumberOfUnit = int.Parse(txtnumberofunit.Text);
                    HR.Paid = decimal.Parse(txtpaid.Text);
                    HR.Price = decimal.Parse(txtpeice.Text);
                    HR.Remaining = decimal.Parse(txtrest.Text);
                    HR.Total = decimal.Parse(txttotalprice.Text);
                    HR.UnitWeight = int.Parse(txtunitweight.Text);
                    HR.TotalWeight = int.Parse(txttotalweight.Text);
                    HR.Type = cmbquantity.Text;
                    HR.Size = int.Parse(cmb.Text);

                    totalfil = (fillitemInfac.Quantity + oldquantity) - int.Parse(txtquantity.Text);
                    acount = (Customer.account - oldremain) + decimal.Parse(txtrest.Text);
                    Customer s = new Customer { ID = CustomerID, Name = Customer.Name, Phone = Customer.Phone, Address = Customer.Address, account = acount, Notes = Customer.Notes };
                    FillItem FI = new FillItem { ID = fillID, Name = fillitemInfac.Name, Quantity = totalfil };

                    G.Customers.AddOrUpdate(s);
                    G.ExportRecipets.AddOrUpdate(HR);
                    G.FillItems.AddOrUpdate(FI);
                    G.SaveChanges();

                    MessageBox.Show("Added Succuessfuly", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    gridfillview();
                    clearFields();
                }
                else
                {
                    MessageBox.Show("Fill Quantity is less than ordered", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show("Please Complete Data", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public void simpleButton1_Click(object sender, EventArgs e)
        {
            gridfillview();

            gridControl1.ShowPrintPreview();

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]) != null)
            {
                int id = (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]);

                var receipt = G.ExportRecipets.Where(w => w.ID == id).Include(ww=>ww.Customer).FirstOrDefault();
                var receipt2 = G.ExportRecipets.Where(w => w.ID == id).Include(ww => ww.FillItem).FirstOrDefault();

                //var fillitem =G.FillItems.FirstOrDefault(ww=>ww.ID==receipt.fil)
                if (XtraMessageBox.Show($"Do you want to delete Receipt number {id}?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    #region Supplieraccount
                    receipt.Customer.account += receipt.Remaining;
                    receipt2.FillItem.Quantity += receipt.FillQuantity;
                    #endregion
                   G.ExportRecipets.Remove(receipt);
                   G.SaveChanges();
                    XtraMessageBox.Show("Removed Succuessfuly ", "Successed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearFields();
                    gridfillview();
                }
            }
            else
                XtraMessageBox.Show("Please Select Raw ", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}