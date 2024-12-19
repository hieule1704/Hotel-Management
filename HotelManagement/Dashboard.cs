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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            MovingPanel.Visible = true;
            MovingPanel.Left = btnAddRoom.Left + 25;

            uC_AddRoom1.Visible = true;
            uC_AddRoom1.BringToFront();
            
        }

        private void btnCustomerRegistration_Click(object sender, EventArgs e)
        {
            MovingPanel.Visible = true;
            MovingPanel.Left = btnCustomerRegistration.Left + 25;

            uC_CustomerRegistration1.Visible = true;
            uC_CustomerRegistration1.BringToFront();

        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            MovingPanel.Visible = true;
            MovingPanel.Left = btnCheckOut.Left + 25;

            uC_CustomerCheckOut1.Visible = true;
            uC_CustomerCheckOut1.BringToFront();
        }

        private void btnCustomerDetails_Click(object sender, EventArgs e)
        {
            MovingPanel.Visible = true;
            MovingPanel.Left = btnCustomerDetails.Left + 25;

            uC_CustomerDetails1.Visible = true;
            uC_CustomerDetails1.BringToFront();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            MovingPanel.Visible = true;
            MovingPanel.Left = btnEmployee.Left + 25;

            uC_Employee1.Visible = true;
            uC_Employee1.BringToFront();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            uC_AddRoom1.Visible = false;
            MovingPanel.Visible = false;
            uC_AddRoom1.Visible = false;
            uC_CustomerRegistration1.Visible = false;
            uC_CustomerCheckOut1.Visible = false;
            uC_CustomerDetails1.Visible = false;
            uC_Employee1.Visible = false;
            // btnAddRoom.PerformClick();
        }

        private void uC_CustomerRegistration1_Load(object sender, EventArgs e)
        {

        }
    }
}
