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
using TomProject.Permission;

namespace TomProject.PL
{
    public partial class Form_Login : DevExpress.XtraEditors.XtraForm
    {

        Garlic db = new Garlic();

        public Form_Login()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form_Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            if (txtUsername.Text != string.Empty  && txtUserpass.Text != string.Empty)
            {
                var user = db.Users.Where(a => a.UserName.Equals(txtUsername.Text)).FirstOrDefault();
                LoginInfo.UserRole = db.Users.Where(a => a.UserName.Equals(txtUsername.Text)).Select(ww=>ww.Type).FirstOrDefault();
                if (user != null)
                {
                    if (user.Password.Equals(txtUserpass.Text))
                    {
                       
                        main_form main = new main_form();
                        this.Hide();
                        main.ShowDialog();

                        if (user.Type == "manger") 
                        {
                            form_Users form = new form_Users();
                            //form.simpleButton1.Visible = false;
                        };
                    }else
                    {
                        MessageBox.Show("the password not corrct");

                    }
                }
                else
                {
                    MessageBox.Show("the username  not corrct");

                }

            }
            else
            {
                MessageBox.Show("the username is required");

            };
           
        }

        private void label2_Click(object sender, EventArgs e)
        {
            txtUserpass.Clear();
            txtUsername.Clear();
        }

        private void exixt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}