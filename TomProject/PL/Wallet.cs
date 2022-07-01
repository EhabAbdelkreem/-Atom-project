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

namespace TomProject
{
    public partial class Wallet : DevExpress.XtraEditors.XtraForm
    {
        public Wallet()
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