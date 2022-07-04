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
            Customer_form xx = new Customer_form();
            xx.ShowDialog();
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            Customer_Transaction xx = new Customer_Transaction();
            xx.ShowDialog(this);
        }

        private void الصادرات_ItemClick(object sender, ItemClickEventArgs e)
        {
            ExportRecipts_Form xx = new ExportRecipts_Form();
            xx.ShowDialog();
        }

        private void main_form_Load(object sender, EventArgs e)
        {

        }
    }
}