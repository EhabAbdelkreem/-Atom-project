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
using TomProject.PL;


namespace TomProject.Reporting
{
    public partial class RepoertChoose : DevExpress.XtraEditors.XtraForm
    {
        Garlic db = new Garlic();
        
        CustomSet1 customSet1 = new CustomSet1();
        
        public RepoertChoose()
        { 
            InitializeComponent(); 
        }

       private void fill_editlookup()
        {
            #region 5azna
            var Treasures = db.WalletItems.Select(ee => new { ID = ee.ID, Name = ee.Name }).ToList();
            lue5azna.EditValue = db.WalletItems.Select(a => a.ID).FirstOrDefault();//to select first elment in form load
            lue5azna.Properties.DataSource = Treasures;
            lue5azna.Properties.DisplayMember = "Name";
            lue5azna.Properties.ValueMember = "ID";
            ///hide ID From lookupedit
            lue5azna.Properties.PopulateColumns();
            lue5azna.Properties.Columns[0].Visible = false;
            #endregion

            #region T3b2a
            var Fillitems = db.FillItems.Select(ee => new { ID = ee.ID, Name = ee.Name }).ToList();
            lueT3b2a.EditValue = db.FillItems.Select(a => a.ID).FirstOrDefault();//to select first elment in form load
            lueT3b2a.Properties.DataSource = Fillitems;
            lueT3b2a.Properties.DisplayMember = "Name";
            lueT3b2a.Properties.ValueMember = "ID";
            ///hide ID From lookupedit
            lueT3b2a.Properties.PopulateColumns();
            lueT3b2a.Properties.Columns[0].Visible = false;
            #endregion


        }

        private void RepoertChoose_Load(object sender, EventArgs e)
        {
            fill_editlookup();
        }

        private void btn5azna_Click(object sender, EventArgs e)
        {
            customSet1.TomReport.Rows.Clear();
            if(dateStart.Value.Date != null&& dateEnd.Value.Date != null)
            {

           
            if (!chx5azna.Checked)
            {
                var Treasure = db.Wallets.Select(w => w)
                    .Include(w=>w.WalletItem).ToList()
                    .Where(ww => ww.Date.Date.Ticks >= dateStart.Value.Date.Ticks && ww.Date.Date.Ticks <= dateEnd.Value.Date.Ticks)
                    ; 
                    decimal sum = Treasure.Sum(w => w.Money);
                
                
                foreach (var item in Treasure)
                {
                    customSet1.TomReport.Rows.Add(
                         sum,
                        item.ID,
                        item.WalletItem.Name,
                        item.Money,
                        item.Date.ToShortDateString(),
                        item.Notes
                    
                        );
                }
                    ShowReport frm = new ShowReport(customSet1, 2);

                    frm.ShowDialog();
            }
            else
            {

                int id = (int)lue5azna.EditValue;
                    var Treasure2 = db.Wallets.Where(w => w.ID==id)
                            .Include(w => w.WalletItem).ToList()
                            .Where(ww => ww.Date.Date >= dateStart.Value.Date && ww.Date.Date <= dateEnd.Value.Date).ToList();
                        
                decimal sum = Treasure2.Sum(w => w.Money);
                foreach (var item in Treasure2)
                {
                    customSet1.TomReport.Rows.Add(
                         sum,
                        item.ID,
                        item.WalletItem.Name,
                        item.Money,
                        item.Date.ToShortDateString(),
                        item.Notes
                        );
                }
                    ShowReport frm = new ShowReport(customSet1, 2);

                    frm.ShowDialog();
            }
            }
        }

        private void btnt3b2a_Click(object sender, EventArgs e)
        {
            customSet1.TomReport.Rows.Clear();
            ShowReport frm = new ShowReport(customSet1, 1);
            
            if (!chxT3b2a.Checked)
            {
                var FILLITEMS = db.FillItems.Select(w => w).ToList();

                string name = "";
                foreach (var item in FILLITEMS)
                {
                    customSet1.TomReport.Rows.Add(
                        name,
                        item.ID,
                        item.Name,
                        item.Quantity
                        );
                }
                frm.ShowDialog();
            }
            else
            {

               int id=(int)lueT3b2a.EditValue;
               var FILLITEMS2 = db.FillItems.Where(w => w.ID==id).ToList();
               string name = $"اسم البند :{FILLITEMS2[0].Name}";

                foreach (var item in FILLITEMS2)
                {
                    customSet1.TomReport.Rows.Add(
                        name,
                        item.ID,
                        item.Name,
                        item.Quantity
                        );
                }
                frm.ShowDialog();
            }
        }


        private void btntotalsader_Click(object sender, EventArgs e)
        {
            customSet1.TomReport.Rows.Clear();

            var ExportSum = db.ExportRecipets.ToList().Where(ww => ww.Date.Date.Ticks >= dateStart.Value.Date.Ticks && ww.Date.Date.Ticks <= dateEnd.Value.Date.Ticks).ToList();
            decimal sum = ExportSum.Sum(w => w.Total);
            string name = $"اجمالى الصادرات";
            string total = $"الاجمالى :{sum}";
            customSet1.TomReport.Rows.Add(
                     name,
                     total
                     );
            ShowReport frm = new ShowReport(customSet1, 3);
            frm.ShowDialog();
        }


        private void btnTotal_Click(object sender, EventArgs e)
        {
            customSet1.TomReport.Rows.Clear();
           var ExportSum2 = db.ExportRecipets.ToList().Where(ww => ww.Date.Date >= dateStart.Value.Date && ww.Date.Date <= dateEnd.Value.Date).ToList();


            decimal ExportSum =(decimal) db.ExportRecipets.ToList().Where(ww => ww.Date.Date.Ticks >= dateStart.Value.Date.Ticks && ww.Date.Date.Ticks <= dateEnd.Value.Date.Ticks).ToList().Sum(w => w.Total);
            decimal _5amSum = (decimal)db.RawRecipets.ToList().Where(ww => ww.Date.Date.Ticks >= dateStart.Value.Date.Ticks && ww.Date.Date.Ticks <= dateEnd.Value.Date.Ticks).ToList().Sum(w => w.Total);
            decimal M2sosSum = (decimal)db.harvestedRecipets.ToList().Where(ww => ww.Date.Date.Ticks >= dateStart.Value.Date.Ticks && ww.Date.Date.Ticks <= dateEnd.Value.Date.Ticks).ToList().Sum(w => w.Total);
            decimal _2rdSum = (decimal)db.YeildRecipts.ToList().Where(ww => ww.Date.Date.Ticks >= dateStart.Value.Date.Ticks && ww.Date.Date.Ticks <= dateEnd.Value.Date.Ticks).ToList().Sum(w => w.Total);
            decimal def=ExportSum-(_5amSum+_2rdSum+M2sosSum);
            string name = $"صافى الربح";
            string sader = $"اجمالى الصادرات :{ExportSum}";
            string _5am = $"اجمالى وارد الارض :{_2rdSum}";
            string _2rd = $"اجمالى وارد الخام :{_5amSum}";
            string M2sos = $"اجمالى وارد المقصوص :{M2sosSum}";

            string total = $"الاجمالى :{def}";
            customSet1.TomReport.Rows.Add(
                     name,
                     sader,
                     _5am,
                     _2rd,
                     M2sos,
                     total
                     );
            ShowReport frm = new ShowReport(customSet1, 3);

            frm.ShowDialog();
        }



        private void btntotalwared_Click(object sender, EventArgs e)
        {

            customSet1.TomReport.Rows.Clear();
            if(!checkBox2.Checked)
            {
                decimal _5amSum = (decimal)db.RawRecipets.ToList().Where(ww => ww.Date.Date.Ticks >= dateStart.Value.Date.Ticks && ww.Date.Date.Ticks <= dateEnd.Value.Date.Ticks).ToList().Sum(w => w.Total);
                decimal M2sosSum = (decimal)db.harvestedRecipets.ToList().Where(ww => ww.Date.Date.Ticks >= dateStart.Value.Date.Ticks && ww.Date.Date.Ticks <= dateEnd.Value.Date.Ticks).ToList().Sum(w => w.Total);
                decimal _2rdSum = (decimal)db.YeildRecipts.ToList().Where(ww => ww.Date.Date.Ticks >= dateStart.Value.Date.Ticks && ww.Date.Date.Ticks <= dateEnd.Value.Date.Ticks).ToList().Sum(w => w.Total);
                decimal def = (_5amSum + _2rdSum + M2sosSum);
                string name = $"صافى الربح";
                string _5am = $"اجمالى وارد الارض :{_2rdSum}";
                string _2rd = $"اجمالى وارد الخام :{_5amSum}";
                string M2sos = $"اجمالى وارد المقصوص :{M2sosSum}";

                string total = $"الاجمالى :{def}";
                customSet1.TomReport.Rows.Add(
                         name,
                         _5am,
                         _2rd,
                         M2sos,
                         "",
                         total
                         );
                ShowReport frm = new ShowReport(customSet1, 3);

                frm.ShowDialog();
            }
            else
            {
                if (comboBoxEdit1.Text.Trim() == "ارض")
                {
                    decimal _2rdSum = (decimal)db.YeildRecipts.ToList().Where(ww => ww.Date.Date.Ticks >= dateStart.Value.Date.Ticks && ww.Date.Date.Ticks <= dateEnd.Value.Date.Ticks).ToList().Sum(w => w.Total);
                    string name = $"وارد ارض";
                    string _5am = $"اجمالى وارد الارض :{_2rdSum}";
                    customSet1.TomReport.Rows.Add(
                             name,
                             "",
                             _5am,
                             "",
                             "",
                             ""
                             );
                    ShowReport frm = new ShowReport(customSet1, 3);

                    frm.ShowDialog();
                }
                else if (comboBoxEdit1.Text.Trim() == "خام")
                {
                    decimal _5amSum = (decimal)db.RawRecipets.ToList().Where(ww => ww.Date.Date.Ticks >= dateStart.Value.Date.Ticks && ww.Date.Date.Ticks <= dateEnd.Value.Date.Ticks).ToList().Sum(w => w.Total);
                    string name = $"وارد خام";
                    string _5am = $"اجمالى وارد خام :{_5amSum}";
                    customSet1.TomReport.Rows.Add(
                             name,
                             "",
                             _5am,
                             "",
                             "",
                             ""
                             );
                    ShowReport frm = new ShowReport(customSet1, 3);

                    frm.ShowDialog();
                }
                else if (comboBoxEdit1.Text.Trim() == "مقصوص")
                {
                    decimal M2sosSum = (decimal)db.harvestedRecipets.ToList().Where(ww => ww.Date.Date.Ticks >= dateStart.Value.Date.Ticks && ww.Date.Date.Ticks <= dateEnd.Value.Date.Ticks).ToList().Sum(w => w.Total);
                    string name = $"وارد مقصوص";
                    string _5am = $"اجمالى وارد مقصوص :{M2sosSum}";
                    customSet1.TomReport.Rows.Add(
                             name,
                             "",
                             _5am,
                             "",
                             "",
                             ""
                             );
                    ShowReport frm = new ShowReport(customSet1, 3);

                    frm.ShowDialog();
                }
            }
         

           

        }



        #region Checbox
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                comboBoxEdit1.Enabled = true;
            }
            else
                comboBoxEdit1.Enabled = false;

        }

        private void chxT3b2a_CheckedChanged(object sender, EventArgs e)
        {
            if (chxT3b2a.Checked)
            {
                lueT3b2a.Enabled = true;

            }
            else
            {
                lueT3b2a.Enabled = false;

            }

        }

        private void chx5azna_CheckedChanged(object sender, EventArgs e)
        {
            if (chx5azna.Checked)
            {
                lue5azna.Enabled = true;

            }
            else
            {
                lue5azna.Enabled = false;

            }
        }
        #endregion}

        #region inhereted Reports
        private void btn5am_Click(object sender, EventArgs e)
        {
            Form_RawRecipets frm = new Form_RawRecipets();
            frm.simpleButton4_Click(sender, e);
        }
        #endregion

        private void btn2rd_Click(object sender, EventArgs e)
        {
            Form_YeildReceiptcs frm = new Form_YeildReceiptcs();
            frm.simpleButton4_Click_1(sender, e);
        }

        private void btnm2sos_Click(object sender, EventArgs e)
        {
            Form_HarvestRecipets frm = new Form_HarvestRecipets();
            frm.simpleButton1_Click(sender, e);
        }

        private void btnsader_Click(object sender, EventArgs e)
        {
            Form_ExportReceipts frm = new Form_ExportReceipts();
            frm.simpleButton1_Click(sender, e);
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            Form_Supplier frm =new Form_Supplier();
            frm.simpleButton3_Click(sender,e);
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            Form_Customer frm = new Form_Customer();
            frm.simpleButton4_Click(sender, e);

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            FormSupplierTransactions frm = new FormSupplierTransactions();
            frm.simpleButton4_Click(sender, e);
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            Form_CustomerTransactions frm = new Form_CustomerTransactions();
            frm.simpleButton4_Click(sender, e);

        }
    }
}