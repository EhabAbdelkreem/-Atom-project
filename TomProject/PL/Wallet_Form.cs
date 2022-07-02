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
    public partial class Wallet_Form : DevExpress.XtraEditors.XtraForm
    {
        Garlic db = new Garlic();
        public Wallet_Form()
        {
            InitializeComponent();
        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
       
        private void Wallet_Load(object sender, EventArgs e)
        {
            



        }
    }
}