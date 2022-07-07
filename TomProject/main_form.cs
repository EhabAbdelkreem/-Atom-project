using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TomProject.PL;
using TomProject.Reporting;

namespace TomProject
{
    public partial class main_form : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public main_form()
        {
            InitializeComponent();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
             Form_Customer xx = new Form_Customer();
             xx.ShowDialog();
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form_CustomerTransactions xx = new Form_CustomerTransactions();
            xx.ShowDialog(this);
        }

        private void الصادرات_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form_ExportReceipts xx = new Form_ExportReceipts();
            xx.ShowDialog();
        }

        private void main_form_Load(object sender, EventArgs e)
        {

        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form_Supplier xx = new Form_Supplier();
            xx.ShowDialog();
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormSupplierTransactions xx = new FormSupplierTransactions();
            xx.ShowDialog();

        }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form_YeildReceiptcs xx = new Form_YeildReceiptcs();
            xx.ShowDialog();
        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form_HarvestRecipets xx = new Form_HarvestRecipets();
            xx.ShowDialog();
        }

        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form_RawRecipets xx = new Form_RawRecipets();
            xx.ShowDialog();
        }

        private void hgulghx_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form_Fillitem xx = new Form_Fillitem();
            xx.ShowDialog();
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form_FilleRecipets xx = new Form_FilleRecipets();
            xx.ShowDialog();

        }

        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form_Wallet xx = new Form_Wallet();
            xx.ShowDialog();
        }

        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
        {
            WalletItem xx = new WalletItem();
            xx.ShowDialog();
        }

        private void barButtonItem17_ItemClick(object sender, ItemClickEventArgs e)
        {
            RepoertChoose xx = new RepoertChoose();
            xx.ShowDialog();
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void main_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_Login frm = new Form_Login();
            frm.Close();
        }

        private void btnusers_ItemClick(object sender, ItemClickEventArgs e)
        {
            form_Users frm = new form_Users();
            frm.ShowDialog();
        }
    }
}