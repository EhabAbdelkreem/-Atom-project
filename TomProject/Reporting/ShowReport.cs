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

namespace TomProject.Reporting
{
    public partial class ShowReport : DevExpress.XtraEditors.XtraForm
    {
        CustomSet1 d = new CustomSet1();
        private int reportNo = 0;

           

        public ShowReport(CustomSet1 _d,int no)
        {
                this.d = _d;
                this.reportNo = no;
                InitializeComponent();
        }

      

        private void crystalReportViewer1_Load_1(object sender, EventArgs e)
        {
            if (reportNo == 1)
            {
                ReportFillItem rept = new ReportFillItem();
                rept.SetDataSource(d);
                crystalReportViewer1.ReportSource = rept;
                crystalReportViewer1.Refresh();
            }
            else if (reportNo == 2)
            {
                ReportWallet rept = new ReportWallet();
                rept.SetDataSource(d);
                crystalReportViewer1.ReportSource = rept;
                crystalReportViewer1.Refresh();
            }
            else if (reportNo == 3)
            {
                MainReport rept = new MainReport();
                rept.SetDataSource(d);
                crystalReportViewer1.ReportSource = rept;
                crystalReportViewer1.Refresh();
            }


        }

        private void ShowReport_Load(object sender, EventArgs e)
        {

        }
    }
}