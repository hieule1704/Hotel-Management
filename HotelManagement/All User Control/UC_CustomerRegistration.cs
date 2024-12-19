using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement.All_User_Control
{
    public partial class UC_CustomerRegistration : UserControl
    {
        function fn = new function();
        String querry;

        public UC_CustomerRegistration()
        {
            InitializeComponent();
        }

        public void setComboBox(string querry, ComboBox combo)
        {
            SqlDataReader sdr = fn.getForCombo(querry);
            while (sdr.Read())
            {
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    combo.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
        }

        private void txtRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoomNo.Items.Clear();
            txtPrice.Clear();

            querry = "select roomNo from rooms where bed = '"+ txtBed.Text + "' and roomType = '" + txtRoomType.Text + "' and booked = 'NO'";
            setComboBox(querry, txtRoomNo);
        }

        private void txtBed_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoomType.SelectedIndex = -1;
            txtRoomNo.Items.Clear();
            txtPrice.Clear();
        }
        int rid;

        private void txtRoomNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            querry = "select price, roomid from rooms where roomNo = '" + txtRoomNo.Text + "'";
            DataSet ds = fn.getData(querry);
            txtPrice.Text = ds.Tables[0].Rows[0][0].ToString();
            rid = int.Parse(ds.Tables[0].Rows[0][1].ToString());
        }

        private void btnAllotRoom_Click(object sender, EventArgs e)
        {
            if (txtName.Text !="" && txtContact.Text !="" && txtNationality.Text != "" && txtGender.Text != "" && txtGender.Text != "" && txtDob.Text!= "" && txtIdProof.Text != "" && txtAddress.Text != "" && txtCheckIn.Text != "")
            {
                String name = txtName.Text;
                Int64 mobile = Int64.Parse(txtContact.Text);
                String national = txtNationality.Text;
                String gender = txtGender.Text;
                String dob = txtDob.Text;
                String idproof = txtIdProof.Text;
                String address = txtAddress.Text;
                String checkin = txtCheckIn.Text;

                querry = "insert into customers (cname, mobile, nationality, gender, dob, idproof, addres, checkin, roomid) values ('"+ name + "'," + mobile + ",'" + national + "','"+gender + "','" + dob + "','" + idproof + "','" + address + "','" + checkin + "'," + rid + ") update rooms set booked = 'YES' where roomNo = '"+txtRoomNo.Text+"' ";
                fn.setData(querry, "Room No " + txtRoomNo.Text + "Allocation Successful.");
                clearAll();

            }
            else
            {
                MessageBox.Show("Fill all fields", "Information!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void clearAll()
        {
            txtName.Clear();
            txtContact.Clear();
            txtNationality.Clear();
            txtGender.SelectedIndex = -1;
            txtDob.ResetText();
            txtIdProof.Clear();
            txtAddress.Clear();
            txtCheckIn.ResetText();
            txtRoomType.SelectedIndex = -1;
            txtBed.SelectedIndex = -1;
            txtRoomNo.SelectedIndex = -1;
            txtPrice.Clear();
        }

        private void UC_CustomerRegistration_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        
        private void FormLoad(object sender, EventArgs e)
        {
            // Thiết lập ngày nhỏ nhất cho DateTimePicker
            txtCheckIn.MinDate = DateTime.Now.Date;
        }
    }
}
