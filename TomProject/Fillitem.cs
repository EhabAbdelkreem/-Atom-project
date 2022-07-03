﻿using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace ProjectDS
{
    public partial class Fillitem : DevExpress.XtraEditors.XtraForm
    {
        public Fillitem()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            // Instantiate a new DBContext
            garlic_DataBase.garlicModel dbContext = new garlic_DataBase.garlicModel();
            // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
            dbContext.add_Fills.LoadAsync().ContinueWith(loadTask =>
            {
                // Bind data to control when loading complete
                gridControl1.DataSource = dbContext.add_Fills.Local.ToBindingList();
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
            // This line of code is generated by Data Source Configuration Wizard
            // Instantiate a new DBContext
           
        }
    }
}