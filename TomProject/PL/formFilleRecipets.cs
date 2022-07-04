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

namespace TomProject
{
    public partial class formFilleRecipets : DevExpress.XtraEditors.XtraForm
    {
        Garlic G;
        int x = 0;
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
        public void gridfillview()
        {
            G = new Garlic();

            gridControl1.DataSource = G.FillRecipets.Select(ww => new { ww.ID, ww.Supplier.Name,name= ww.FillItem.Name, ww.Quantity, ww.Price, ww.Date,ww.Total,ww.Paid,ww.Remaining, ww.Notes }).ToList();
            gridView1.Columns[0].Caption = "م";
            gridView1.Columns[1].Caption = "اسم المورد";
            gridView1.Columns[2].Caption = "نوع التعبئة";
            gridView1.Columns[3].Caption = "الكمية";
            gridView1.Columns[4].Caption = "السعر";
            gridView1.Columns[5].Caption = "التاريخ";
            gridView1.Columns[6].Caption = "الاجمالى";
            gridView1.Columns[7].Caption = "المدفوع";
            gridView1.Columns[8].Caption = "المتبقى";
            gridView1.Columns[9].Caption = "ملاحظات";
        }
        public void clearfiels()
        {
            txtnoat.Text = "";
            txtpaid.Text = x.ToString();
            txtprice.Text = x.ToString();
            txtquan.Text = x.ToString();
            txtrest.Text = x.ToString();
            txttotal.Text = x.ToString();
        }
        public formFilleRecipets()
        {
            InitializeComponent();
        }

        private void formFilleRecipets_Load(object sender, EventArgs e)
        {

            moredfil();
            t3bafil();
            gridfillview();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (txtnoat.Text != "" && txtpaid.Text != "" && txtprice.Text != "" && txtquan.Text != "" && txtrest.Text != "" && txttotal.Text != "")
            {
                decimal totalfil = 0;
                G = new Garlic();
                FillItem FI = new FillItem();
                Supplier SP = new Supplier();

                var suplierid =  int.Parse(lookUpEdit1.EditValue.ToString()) ;
                var filitemid =  int.Parse(lookUpEdit2.EditValue.ToString());
                int cou = int.Parse(filitemid.ToString());
                var fillitemInfac = G.FillItems.Where(ww => ww.ID == filitemid).Select(ww => new { ww.Name, ww.Quantity }).FirstOrDefault();
                var suplier = G.Suppliers.Where(ww => ww.ID == suplierid).Select(ww => new {ww.Name,ww.Type,ww.Phone,ww.Address,ww.account,ww.Notes }).FirstOrDefault();
                FillRecipet FR = new FillRecipet();
                FR.Supplier = G.Suppliers.FirstOrDefault(ww=>ww.ID==suplierid);
                FR.FillItem = G.FillItems.FirstOrDefault(ww => ww.ID == filitemid);
                FR.Quantity = int.Parse(txtquan.Text);
                FR.Price = decimal.Parse(txtprice.Text);
                FR.Date = DateTime.Parse(dateEdit1.Text);
                FR.Total = decimal.Parse(txttotal.Text);
                FR.Paid = decimal.Parse(txtpaid.Text);
                FR.Remaining = decimal.Parse(txtrest.Text);
                FR.Notes = txtnoat.Text;
                totalfil = decimal.Parse(txtquan.Text) + decimal.Parse(fillitemInfac.Quantity.ToString());
                FI.ID = int.Parse(filitemid.ToString());
                FI.Quantity =int.Parse( totalfil.ToString());
                FI.Name = fillitemInfac.Name.ToString();
                SP.ID = suplierid; SP.Name = suplier.Name; SP.Type = suplier.Type; SP.Phone = suplier.Phone; SP.Address = suplier.Address; SP.account =( suplier.account + decimal.Parse(txtrest.Text)); SP.Notes = suplier.Notes;
                Garlic GG = new Garlic();
                Garlic GGG = new Garlic();

                GG.Entry(FI).State = System.Data.Entity.EntityState.Modified;
                GGG.Entry(SP).State = System.Data.Entity.EntityState.Modified;
                G.FillRecipets.Add(FR);
                G.SaveChanges();
                GG.SaveChanges();
                GGG.SaveChanges();
                MessageBox.Show("تم ادخال بيانات الفاتوره بنجاح", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridfillview();
                clearfiels();
            }
            else
            {
                MessageBox.Show("يرجى ادخال كافة الحقول", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void txttotal_EditValueChanged(object sender, EventArgs e)
        {
           // txtrest.Text = (float.Parse(txttotal.Text) - float.Parse(txtpaid.Text)).ToString();

        }

        private void txtrest_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtpaid_EditValueChanged(object sender, EventArgs e)
        {
            //txtrest.Text = (float.Parse(txttotal.Text) - float.Parse(txtpaid.Text)).ToString();

        }

        private void txtprice_EditValueChanged(object sender, EventArgs e)
        {
           // txttotal.Text = (float.Parse(txtquan.Text) * float.Parse(txtprice.Text)).ToString();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (txtnoat.Text != "" && txtpaid.Text != "" && txtprice.Text != "" && txtquan.Text != "" && txtrest.Text != "" && txttotal.Text != "")
            {
                decimal totalfil = 0;
                G = new Garlic();
                FillRecipet FR = new FillRecipet();
                Supplier SP = new Supplier();
                decimal oldquantity = 0;
                decimal oldremain = 0;
                var suplierid =int.Parse(lookUpEdit1.EditValue.ToString());
                var filitemid =  int.Parse(lookUpEdit2.EditValue.ToString()) ;
                int cou = int.Parse(filitemid.ToString());
                var fillitemInfac = G.FillItems.Where(ww => ww.ID == filitemid).Select(ww => new { ww.Name, ww.Quantity }).FirstOrDefault();
                var suplier = G.Suppliers.Where(ww => ww.ID == suplierid).Select(ww => new { ww.Name, ww.Type, ww.Phone, ww.Address, ww.account, ww.Notes }).FirstOrDefault();
                FR.ID = int.Parse(txtid.Text);
                FR.Supplier = G.Suppliers.FirstOrDefault(ww=>ww.ID==suplierid);
                FR.FillItem = G.FillItems.FirstOrDefault(ww => ww.ID == filitemid);
                FR.Quantity = int.Parse(txtquan.Text);
                oldquantity= G.FillRecipets.Where(ww=>ww.ID==FR.ID).Select(ww=>ww.Quantity).FirstOrDefault();
                FR.Price = decimal.Parse(txtprice.Text);
                FR.Date =DateTime.Parse( dateEdit1.Text);
                FR.Total = decimal.Parse(txttotal.Text);
                FR.Paid = decimal.Parse(txtpaid.Text);
                FR.Remaining = decimal.Parse(txtrest.Text);
                oldremain = G.FillRecipets.Where(ww => ww.ID == FR.ID).Select(ww => ww.Remaining).FirstOrDefault();
                FR.Notes = txtnoat.Text;
                totalfil = decimal.Parse(txtquan.Text) + (decimal.Parse(fillitemInfac.Quantity.ToString())-oldquantity);
                FillItem FI = new FillItem { ID=filitemid,Quantity= int.Parse(totalfil.ToString()),Name= fillitemInfac.Name.ToString()};
                SP.ID = suplierid; SP.Name = suplier.Name; SP.Type = suplier.Type; SP.Phone = suplier.Phone; SP.Address = suplier.Address; SP.account = ((suplier.account-oldremain) + decimal.Parse(txtrest.Text)); SP.Notes = suplier.Notes;
                Garlic GG = new Garlic();
                Garlic GGG = new Garlic();
                GG.Entry(FI).State = System.Data.Entity.EntityState.Modified;
                GGG.Entry(SP).State = System.Data.Entity.EntityState.Modified;
               
                G.Entry(FR).State = System.Data.Entity.EntityState.Modified;
                G.SaveChanges();
                GG.SaveChanges();
                GGG.SaveChanges();
                MessageBox.Show("تم تعديل بيانات الفاتوره بنجاح", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridfillview();
                clearfiels();
            }
            else
            {
                MessageBox.Show("يرجى ادخال كافة الحقول", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

            txtid.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
            lookUpEdit1.EditValue = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
            lookUpEdit2.EditValue = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString();
            txtnoat.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[9]).ToString();
            txtquan.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString();
            txtprice.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString();
            dateEdit1.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5]).ToString();
            txttotal.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[6]).ToString();
            txtpaid.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[7]).ToString();
            txtrest.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[8]).ToString();

            
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            G = new Garlic();

            try
            {
                if (txtnoat.Text != "" && txtpaid.Text != "" && txtprice.Text != "" && txtquan.Text != "" && txtrest.Text != "" && txttotal.Text != "")
                {
                    decimal totalfil = 0;
                    G = new Garlic();
                    FillItem FI = new FillItem();
                    FillRecipet FR = new FillRecipet();
                    Supplier SP = new Supplier();
                    decimal oldquantity = 0;
                    decimal oldremain = 0;
                    var suplierid = int.Parse(lookUpEdit1.EditValue.ToString());
                    var filitemid = int.Parse(lookUpEdit2.EditValue.ToString());
                    int cou = int.Parse(filitemid.ToString());
                    var fillitemInfac = G.FillItems.Where(ww => ww.ID == filitemid).Select(ww => new { ww.Name, ww.Quantity }).FirstOrDefault();
                    var suplier = G.Suppliers.Where(ww => ww.ID == suplierid).Select(ww => new { ww.Name, ww.Type, ww.Phone, ww.Address, ww.account, ww.Notes }).FirstOrDefault();
                    FR.ID = int.Parse(txtid.Text);
                    //FR.Supplier = suplierid;
                    //FR.FillItem = filitemid;
                    FR.Quantity = int.Parse(txtquan.Text);
                    oldquantity = G.FillRecipets.Where(ww => ww.ID == FR.ID).Select(ww => ww.Quantity).FirstOrDefault();
                    FR.Price = decimal.Parse(txtprice.Text);
                    FR.Date = DateTime.Parse(dateEdit1.Text);
                    FR.Total = decimal.Parse(txttotal.Text);
                    FR.Paid = decimal.Parse(txtpaid.Text);
                    FR.Remaining = decimal.Parse(txtrest.Text);
                    oldremain = G.FillRecipets.Where(ww => ww.ID == FR.ID).Select(ww => ww.Remaining).FirstOrDefault();
                    FR.Notes = txtnoat.Text;
                    totalfil = (decimal.Parse(fillitemInfac.Quantity.ToString()) - oldquantity);
                    FI.ID = int.Parse(filitemid.ToString());
                    FI.Quantity = int.Parse(totalfil.ToString());
                    FI.Name = fillitemInfac.Name.ToString();
                    SP.ID = suplierid; SP.Name = suplier.Name; SP.Type = suplier.Type; SP.Phone = suplier.Phone; SP.Address = suplier.Address; SP.account = suplier.account - oldremain ; SP.Notes = suplier.Notes;

                    G.Entry(FI).State = System.Data.Entity.EntityState.Modified;
                    G.Entry(SP).State = System.Data.Entity.EntityState.Modified;
                    Garlic GG = new Garlic();
                    GG.Entry(FR).State = System.Data.Entity.EntityState.Deleted;
                    
                    if (MessageBox.Show("يرجى التاكد من حذف البيانات", "Warrning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        G.SaveChanges();
                        GG.SaveChanges();
                        MessageBox.Show("تم حذف البيانات بنجاح", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearfiels();
                        gridfillview();

                    }
                    else
                    {
                        clearfiels();
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
    }
}