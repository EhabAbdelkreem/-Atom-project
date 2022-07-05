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
    public partial class Customer_Transaction : DevExpress.XtraEditors.XtraForm
    {
        Garlic db = new Garlic();
        public Customer_Transaction()
        {
            InitializeComponent();
        }

        private void Customer_Transaction_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.CustomerTransactions.ToList();

            var emm = from ee in db.Customers
                      select ee;
            foreach (var i in emm)
            {
                comboBox_name.Items.Add(i.Name);
                 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            Customer cs = new Customer();
            var ee = db.Customers.Single(cc => cc.Name == comboBox_name.SelectedItem.ToString());
            if (ee != null)
            {
                ee.account -= decimal.Parse(textEdit_اprice.Text);
                db.SaveChanges();
            }
            else
            {
                MessageBox.Show("الاسم الذى ادخلته غير موجود");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Customer cs = new Customer();
            var ee = db.Customers.Single(cc => cc.Name == comboBox_name.SelectedItem.ToString());
            if (ee != null)
            {
                ee.account += decimal.Parse(textEdit_اprice.Text);
                db.SaveChanges();
            }
            else
            {
                MessageBox.Show("الاسم الذى ادخلته غير موجود");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //    if (comboBox_proccestype.SelectedItem.ToString() == "تنزيل من حساب ")
            //    {
            //        simpleButton_disaccount.Visible = true;
            //    }
            //    else if (comboBox_proccestype.SelectedItem.ToString() == "اضافة لحساب ")
            //    {
            //        simpleButton_increas.Visible = true;
            //    }
        }

        private void comboBox_proccestype_SelectedValueChanged(object sender, EventArgs e)
        {
           
        } 

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox_proccestype_MouseEnter(object sender, EventArgs e)
        {
        }

        private void simpleButton1_Click_2(object sender, EventArgs e)
        {
            if (comboBox_name.Text !=""||comboBox_name.Text !=""||
                textEdit_اprice.Text !="")
            {
                CustomerTransaction ctr = new CustomerTransaction();
            //var ct = db.Customers.Single(ee => ee.Name ==comboBox_name.SelectedItem.ToString());
            //ctr.Customer_ID = ct.ID;
            ctr.Notes = richTextBox1.Text;
            ctr.Date = dateTimePicker1.Value;
            ctr.TransactionType = comboBox_name.SelectedItem.ToString();
            ctr.Amount = decimal.Parse(textEdit_اprice.Text);
                
            db.CustomerTransactions.Add(ctr);
            db.SaveChanges();
                comboBox_name.SelectedItem = "";
                    comboBox_name.SelectedItem = "";
                textEdit_اprice.Text = richTextBox1.Text = " ";
               
                    
                    

            }
            else
            {
                MessageBox.Show("ادخل البيانات الناقصه");
            }

            }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }

        private void comboBox_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ee = db.Customers.Single(cc => cc.Name == comboBox_name.SelectedItem.ToString());
            textBoxnumcust.Text = (ee.ID).ToString();  
            textBoxnumcust.Visible = true;  
        }
    }
    }
