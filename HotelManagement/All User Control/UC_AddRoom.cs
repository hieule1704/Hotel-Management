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
    public partial class UC_AddRoom : UserControl
    {
        function fn = new function();
        String query;

        public UC_AddRoom()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(txtRoomNumber.Text != "" && txtRoomType.Text != "" && txtBed.Text != "" && txtPrice.Text != "")
            {
                String roomNo = txtRoomNumber.Text;
                String type = txtRoomType.Text;
                String bed = txtBed.Text;
                Int64 price = Int64.Parse(txtPrice.Text);

                query = "insert into rooms (roomNo, roomType, bed, price) values ('" + roomNo + "','" + type + "','" + bed + "'," + price + ")";
                fn.setData(query, "Room Added.");

                UC_AddRoom_Load(this, null);
                clearAll();
            }
            else
            {
                MessageBox.Show("Fill all fields", "Wardning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Load data from database to the DataGridView
        private void UC_AddRoom_Load(object sender, EventArgs e)
        {
            query = "select * from rooms";
            DataSet ds = fn.getData(query);
            DataGridView1.DataSource = ds.Tables[0];
        }
        // Update data from database ti the DataGridView
        //public void LoadRoomData()
        //{
        //    query = "SELECT * FROM rooms";
        //    DataSet ds = fn.getData(query);
        //    DataGridView1.DataSource = ds.Tables[0];
        //}


        public void clearAll()
        {
            txtRoomNumber.Clear();
            txtRoomType.SelectedIndex = -1;
            txtBed.SelectedIndex = -1;
            txtPrice.Clear();
        }

        private void UC_AddRoom_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void UC_AddRoom_Enter(object sender, EventArgs e)
        {
            UC_AddRoom_Load(this, null);
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UC_AddRoom_Load(this, null);
        }
        int id;
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

            if (DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                id = int.Parse(DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtRoomID.Text = DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            }
        }

        private void DataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            UC_AddRoom_Load(this, null);
        }
    }
}
