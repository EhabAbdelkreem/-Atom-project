using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TomProject.Context;

namespace TomProject
{
    public partial class MainView : DevExpress.XtraEditors.XtraForm
    {
        Garlic db = new Garlic();
        public MainView()
        {
            InitializeComponent();
            if (!mvvmContext1.IsDesignMode)
                InitializeBindings();
        }

        void InitializeBindings()
        {
            var fluent = mvvmContext1.OfType<MainViewModel>();
        }

        private void MainView_Load(object sender, EventArgs e)
        {

        }
    }
}
