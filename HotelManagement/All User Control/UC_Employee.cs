using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement.All_User_Control
{
    public partial class UC_Employee : UserControl
    {
        function fn = new function();
        String query;
        public UC_Employee()
        {
            InitializeComponent();
        }

        private void UC_Employee_Load(object sender, EventArgs e)
        {
            getMaxId();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtID.Text != "")
            {
                if(MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    query = "delete from employee where eid = " + txtID.Text + "";
                    fn.setData(query, "Employee Record Deleted.");
                    txtID.Clear();
                    getEmployeeData(DeleteEmployeeGridView);
                }
            }
            
        }
        private void btnDelete_Leave(object sender, EventArgs e)
        {
            clearAll();
            txtID.Clear();
        }

        // Required method
        public void getMaxId()
        {
            query = "select max(eid) from employee";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                Int64 num = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                lblToSet.Text = (num + 1).ToString();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if(txtName.Text != "" && txtMobile.Text != "" && txtEmail.Text != "" && txtUserName.Text != "" && txtPassword.Text != "" && txtGender.Text != "")
            {
                String name = txtName.Text;
                String mobile = txtMobile.Text;
                String email = txtEmail.Text;
                String username = txtUserName.Text;
                String password = txtPassword.Text;
                String gender = txtGender.Text;

                query = "insert into employee (ename, mobile, gender, emailid, username, pass) " +
        "values ('" + name + "', " + mobile + ", '" + gender + "', '" + email + "', '" + username + "', '" + password + "')";
                fn.setData(query, "Registration Successful.");
                clearAll();
                getMaxId();
            }
            else
            {
                MessageBox.Show("Fill all the fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void clearAll()
        {
            txtName.Clear();
            txtMobile.Clear();
            txtEmail.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            txtGender.SelectedIndex = -1;
        }

        private void tabEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabEmployee.SelectedIndex == 1)
            {
                getEmployeeData(DataEmployeeGridView);
            }
            else if(tabEmployee.SelectedIndex == 2)
            {
                getEmployeeData(DeleteEmployeeGridView);
            }
        }

        public void getEmployeeData(DataGridView dgv)
        {
            query = "select * from employee";
            DataSet ds = fn.getData(query);
            dgv.DataSource = ds.Tables[0];
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            // Sử dụng truy vấn để tìm kiếm dữ liệu trong bảng employee
            query = "SELECT eid, ename, mobile, gender, emailid, username FROM employee WHERE eid LIKE '" + txtID.Text + "%'";

            // Lấy dữ liệu từ cơ sở dữ liệu
            DataSet ds = fn.getData(query);

            // Hiển thị dữ liệu lên DataGridView
            DeleteEmployeeGridView.DataSource = ds.Tables[0];
        }

        private void DeleteEmployeeGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
