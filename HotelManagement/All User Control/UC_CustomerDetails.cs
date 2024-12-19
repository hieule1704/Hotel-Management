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
    public partial class UC_CustomerDetails : UserControl
    {
        function fn = new function();
        String query;
        public UC_CustomerDetails()
        {
            InitializeComponent();
        }

        private void txtSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtSearchBy.SelectedIndex == 0)
            {
                query = "SELECT customers.cid, customers.cname, customers.mobile, customers.nationality, customers.gender, customers.dob, customers.idproof, customers.addres, customers.checkin, customers.checkout, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price FROM customers INNER JOIN rooms ON customers.roomid = rooms.roomid";
                getRecord(query);
            }
            else if(txtSearchBy.SelectedIndex == 1)
            {
                query = "SELECT customers.cid, customers.cname, customers.mobile, customers.nationality, customers.gender, customers.dob, customers.idproof, customers.addres, customers.checkin, customers.checkout, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price FROM customers INNER JOIN rooms ON customers.roomid = rooms.roomid where checkout is NULL";
                getRecord(query);
            }
            else
            {
                query = "SELECT customers.cid, customers.cname, customers.mobile, customers.nationality, customers.gender, customers.dob, customers.idproof, customers.addres, customers.checkin, customers.checkout, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price FROM customers INNER JOIN rooms ON customers.roomid = rooms.roomid where checkout is not NULL";
                getRecord(query);
            }
        }

        // Get data from database base on query
        private void getRecord(String query)
        {
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
    }
}
