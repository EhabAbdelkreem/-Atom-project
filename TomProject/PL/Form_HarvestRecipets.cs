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
    public partial class Form_HarvestRecipets : DevExpress.XtraEditors.XtraForm
    {
        Garlic G;
        public void moredfil()
        {
            G = new Garlic();
            lookUpEdit1.Properties.DataSource = G.Suppliers.Select(ww => new { ww.ID, ww.Name }).ToList();
            lookUpEdit1.EditValue = G.Suppliers.Select(ww => ww.ID).FirstOrDefault().ToString();
            lookUpEdit1.Properties.DisplayMember = "Name";
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.PopulateColumns();
            lookUpEdit1.Properties.Columns["ID"].Visible = false;
        }
        public void t3bafil()
        {
            G = new Garlic();
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
            txtpaid.Text = "0";
            txtpeice.Text = "";
            txtquantity.Text = "";
            txtrest.Text = "0";
            txttotalprice.Text = "0";
            txttotalweight.Text = "";
            txtunitweight.Text = "";
            cmb.Text = "";
            date.Text = "";
        }
        public void gridfillview()
        {
            G = new Garlic();

            gridControl1.DataSource = G.harvestedRecipets.Select(ww => new { ww.ID, Suplier=ww.Supplier.Name , ww.Type, ww.Date, ww.Size,Fill= ww.FillItem.Name  , ww.FillQuantity, ww.NumberOfUnit, ww.UnitWeight, ww.TotalWeight, ww.Price, ww.Total, ww.Paid, ww.Remaining,ww.Notes }).ToList();
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
        public Form_HarvestRecipets()
        {
            InitializeComponent();
        }

        private void formharvestRecipets_Load(object sender, EventArgs e)
        {
            if (LoginInfo.UserRole == "موظف")
            {
                simpleButton3.Enabled = false;
            }
            moredfil();
            gridfillview();
            t3bafil();
        }



        private void gridControl1_Click(object sender, EventArgs e)
        {
         
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]) != null)
            {
                txtid.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                lookUpEdit1.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
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
            G = new Garlic();
            if ( txtnumberofunit.Text != "" && txtpaid.Text != "" && txtpeice.Text != "" && txtquantity.Text != "" && txtrest.Text != "" && txttotalprice.Text != "" && txttotalweight.Text != "" && txtunitweight.Text != "")
            {
                int totalfil = 0;
                decimal acount = 0;
                var supplierID =  int.Parse(lookUpEdit1.EditValue.ToString()) ;
                var fillID = int.Parse(lookUpEdit2.EditValue.ToString());
                var fillitemInfac = G.FillItems.Where(ww => ww.ID == fillID).Select(ww => new {ww.ID, ww.Name, ww.Quantity }).FirstOrDefault();
                if (fillitemInfac.Quantity >= int.Parse(txtquantity.Text))
                {
                    var suplier = G.Suppliers.Where(ww => ww.ID == supplierID).Select(ww => new { ww.ID, ww.Name, ww.Type, ww.Phone, ww.Address, ww.account, ww.Notes }).FirstOrDefault();
                    harvestedRecipet HR = new harvestedRecipet();
                    HR.Supplier = G.Suppliers.FirstOrDefault(ww => ww.ID == supplierID);
                    HR.Date = DateTime.Parse(date.Text);
                    HR.FillQuantity = int.Parse(txtquantity.Text);
                    HR.FillItem = G.FillItems.FirstOrDefault(ee => ee.ID == fillID);
                    HR.Notes = txtnoat.Text;
                    HR.NumberOfUnit = int.Parse(txtnumberofunit.Text);
                    HR.Paid = decimal.Parse(txtpaid.Text);
                    HR.Price = decimal.Parse(txtpeice.Text);
                    HR.Remaining = decimal.Parse(txtrest.Text);
                    HR.Total = decimal.Parse(txttotalprice.Text);
                    HR.UnitWeight = float.Parse(txtunitweight.Text);
                    HR.TotalWeight = float.Parse(txttotalweight.Text);
                    HR.Type = cmbquantity.Text;
                    HR.Size = int.Parse(cmb.Text);
                    G.harvestedRecipets.Add(HR);
                    totalfil = fillitemInfac.Quantity - int.Parse(txtquantity.Text);
                    acount = suplier.account + decimal.Parse(txtrest.Text);
                    Supplier s = new Supplier { ID = suplier.ID, Name = suplier.Name, Type = suplier.Type, Phone = suplier.Phone, Address = suplier.Address, account = acount, Notes = suplier.Notes };
                    FillItem FI = new FillItem { ID = fillitemInfac.ID, Name = fillitemInfac.Name, Quantity = totalfil };
                    Garlic GG = new Garlic();
                    Garlic GGG = new Garlic();
                    GG.Entry(s).State = System.Data.Entity.EntityState.Modified;
                    GGG.Entry(FI).State = System.Data.Entity.EntityState.Modified;
                    G.SaveChanges();
                    GG.SaveChanges();
                    GGG.SaveChanges();

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
            G = new Garlic();
            if ( txtnumberofunit.Text != "" && txtpaid.Text != "" && txtpeice.Text != "" && txtquantity.Text != "" && txtrest.Text != "" && txttotalprice.Text != "" && txttotalweight.Text != "" && txtunitweight.Text != "")
            {
                int oldquantity = 0;
                decimal oldremain = 0;
                int totalfil = 0;
                decimal acount = 0;
                var supplierID = int.Parse(lookUpEdit1.EditValue.ToString());
                var fillID = int.Parse(lookUpEdit2.EditValue.ToString());
                var harvestid = int.Parse(txtid.Text);
                var suplier = G.Suppliers.Where(ww => ww.ID == supplierID).Select(ww => new { ww.Name, ww.Type, ww.Phone, ww.Address, ww.account, ww.Notes }).FirstOrDefault();
                var harvest = G.harvestedRecipets.Where(ww => ww.ID == harvestid).Select(ww => new { ww.Date, ww.FillItem, ww.FillQuantity, ww.Notes, ww.NumberOfUnit, ww.Paid, ww.Price, ww.Remaining, ww.Size, ww.Supplier, ww.Total, ww.TotalWeight, ww.Type, ww.UnitWeight }).FirstOrDefault();
                oldremain = decimal.Parse(harvest.Remaining.ToString());
                oldquantity = harvest.FillQuantity;
                var fillitemInfac = G.FillItems.Where(ww => ww.ID == fillID).Select(ww => new { ww.Name, ww.Quantity }).FirstOrDefault();
                if ((fillitemInfac.Quantity+oldquantity) >= int.Parse(txtquantity.Text))
                {
                   
                harvestedRecipet HR = new harvestedRecipet();
                HR.ID = harvestid;
                HR.Supplier = G.Suppliers.FirstOrDefault(ww => ww.ID == supplierID);
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
                acount = (suplier.account - oldremain) + decimal.Parse(txtrest.Text);
                Supplier s = new Supplier { ID = supplierID, Name = suplier.Name, Type = suplier.Type, Phone = suplier.Phone, Address = suplier.Address, account = acount, Notes = suplier.Notes };
                FillItem FI = new FillItem { ID = fillID, Name = fillitemInfac.Name, Quantity = totalfil };

                Garlic GG = new Garlic();
                Garlic GGG = new Garlic();
                GG.Entry(s).State = System.Data.Entity.EntityState.Modified;
                G.Entry(HR).State = System.Data.Entity.EntityState.Modified;
                GGG.Entry(FI).State = System.Data.Entity.EntityState.Modified;
                G.SaveChanges();
                GG.SaveChanges();
                GGG.SaveChanges();
                MessageBox.Show("Updated Succuessfuly ", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                MessageBox.Show("Please Select Row", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            G = new Garlic();
            if (txtnoat.Text != "" && txtnumberofunit.Text != "" && txtpaid.Text != "" && txtpeice.Text != "" && txtquantity.Text != "" && txtrest.Text != "" && txttotalprice.Text != "" && txttotalweight.Text != "" && txtunitweight.Text != "")
            {
                int oldquantity = 0;
                decimal oldremain = 0;
                int totalfil = 0;
                decimal acount = 0;
                var supplierID = new Supplier { ID = int.Parse(lookUpEdit1.EditValue.ToString()) };
                var fillID = new FillItem { ID = int.Parse(lookUpEdit2.EditValue.ToString()) };
                var harvestid = new harvestedRecipet { ID = int.Parse(txtid.Text) };
                var fillitemInfac = G.FillItems.Where(ww => ww.ID == fillID.ID).Select(ww => new { ww.Name, ww.Quantity }).FirstOrDefault();
                var suplier = G.Suppliers.Where(ww => ww.ID == supplierID.ID).Select(ww => new { ww.Name, ww.Type, ww.Phone, ww.Address, ww.account, ww.Notes }).FirstOrDefault();
                var harvest = G.harvestedRecipets.Where(ww => ww.ID == harvestid.ID).Select(ww => new { ww.Date, ww.FillItem, ww.FillQuantity, ww.Notes, ww.NumberOfUnit, ww.Paid, ww.Price, ww.Remaining, ww.Size, ww.Supplier, ww.Total, ww.TotalWeight, ww.Type, ww.UnitWeight }).FirstOrDefault();
                oldremain = decimal.Parse(harvest.Remaining.ToString());
                oldquantity = harvest.FillQuantity;
                harvestedRecipet HR = new harvestedRecipet();
                HR.ID = harvestid.ID;
                //HR.Supplier = supplierID;
                HR.Date = DateTime.Parse(date.Text);
                HR.FillQuantity = int.Parse(txtquantity.Text);
                //HR.FillItem = fillID;
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

                totalfil = fillitemInfac.Quantity + oldquantity;
                acount = supplierID.account - oldremain;
                Supplier s = new Supplier { ID = supplierID.ID, Name = suplier.Name, Type = suplier.Type, Phone = suplier.Phone, Address = suplier.Address, account = acount, Notes = suplier.Notes };
                FillItem FI = new FillItem { ID = fillID.ID, Name = fillitemInfac.Name, Quantity = totalfil };
                Garlic GGG = new Garlic();
                Garlic GG = new Garlic();

                G.Entry(s).State = System.Data.Entity.EntityState.Modified;
                GG.Entry(FI).State = System.Data.Entity.EntityState.Modified;
                GGG.Entry(HR).State = System.Data.Entity.EntityState.Deleted;
                if (MessageBox.Show("Are You Sure to Delete Row", "Warrning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    G.SaveChanges();
                    GG.SaveChanges();
                    GGG.SaveChanges();
                    MessageBox.Show("Deleted Successfuly", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gridfillview();
                    clearFields();
                }
                else
                {
                    gridfillview();
                    clearFields();
                }
            }
            else
            {
                MessageBox.Show("Please Slecet Row", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void simpleButton1_Click(object sender, EventArgs e)
        {
            gridfillview();
            gridControl1.ShowPrintPreview();

        }




        private void txtrest_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void txttotalprice_TextChanged(object sender, EventArgs e)
        {

            txtrest.Text = (decimal.Parse(txttotalprice.Text) - decimal.Parse(txtpaid.Text)).ToString();
        }

        private void txtpaid_TextChanged(object sender, EventArgs e)
        {
            txtrest.Text = (decimal.Parse(txttotalprice.Text) - decimal.Parse(txtpaid.Text)).ToString();

        }
    }
}