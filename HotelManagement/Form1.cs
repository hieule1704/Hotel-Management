using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class Form1 : Form
    {
        function fn = new function();
        String query;
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            query = "select username, pass from employee where username = '" + txtUsername.Text + "' and pass = '" + txtPassword.Text + "'";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows.Count != 0)
            {
                lblLoginError.Visible = false;
                this.Hide();
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
            }
            else
            {
                lblLoginError.Visible = true;
                txtPassword.Clear();
            }
        }
    }
}
