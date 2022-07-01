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

namespace TomProject
{
    public partial class ExportRecipts_Form : DevExpress.XtraEditors.XtraForm
    {
        public ExportRecipts_Form()
        {
            InitializeComponent();
        }
        Garlic db = new Garlic();
        private void ExportRecipts_Form_Load(object sender, EventArgs e)
        {
            var result= db.Suppliers.Select(er => er).ToList();
            gridControl1.DataSource = result;
        }
    }
}