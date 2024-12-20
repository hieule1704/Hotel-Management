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
        int id;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtCustomerName.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            }
        }

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                // Truy vấn dữ liệu hóa đơn dựa trên id của khách hàng
                query = $@"
            SELECT 
                i.invoiceid, 
                c.cname, 
                c.mobile, 
                r.roomNo, 
                r.roomType, 
                r.bed, 
                i.checkin_date, 
                i.checkout_date, 
                i.number_of_days, 
                i.room_price, 
                i.total_amount, 
                i.created_at
            FROM invoice i
            INNER JOIN customers c ON i.cid = c.cid
            INNER JOIN rooms r ON i.roomid = r.roomid
            WHERE i.cid = {id}";

                DataSet ds = fn.getData(query);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];

                    // Lấy thông tin từ cơ sở dữ liệu
                    string customerName = row["cname"].ToString();
                    string mobile = row["mobile"].ToString();
                    string roomNo = row["roomNo"].ToString();
                    string roomType = row["roomType"].ToString();
                    string bed = row["bed"].ToString();
                    DateTime checkinDate = DateTime.Parse(row["checkin_date"].ToString());
                    DateTime checkoutDate = DateTime.Parse(row["checkout_date"].ToString());
                    int numberOfDays = int.Parse(row["number_of_days"].ToString());
                    long roomPrice = long.Parse(row["room_price"].ToString());
                    long totalAmount = long.Parse(row["total_amount"].ToString());
                    DateTime createdAt = DateTime.Parse(row["created_at"].ToString());

                    // Tạo nội dung hóa đơn
                    string invoiceContent = $@"
                Invoice ID: {row["invoiceid"]}
                Customer Name: {customerName}
                Mobile: {mobile}
                Room Number: {roomNo}
                Room Type: {roomType}
                Bed: {bed}
                Check-in Date: {checkinDate:yyyy-MM-dd}
                Check-out Date: {checkoutDate:yyyy-MM-dd}
                Number of Days: {numberOfDays}
                Room Price: {roomPrice}
                Total Amount: {totalAmount}
                Invoice Created At: {createdAt:yyyy-MM-dd HH:mm:ss}";

                    // Hiển thị hóa đơn (có thể lưu vào tệp hoặc gửi đến máy in)
                    MessageBox.Show(invoiceContent, "Invoice Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No invoice found for this customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
