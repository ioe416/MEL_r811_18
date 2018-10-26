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

namespace MEL_r811_18
{
    public partial class VendorSetup : Form
    {
        public MainScreen ms;

        public int vendorID;
        public int index;
        public int count;

        public string conn_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\MEL\MEL.mdf;Integrated Security=True";
        public string q;
        public string query;
        public string error_msg = "";


        public VendorSetup(MainScreen ms)
        {
            InitializeComponent();
            Fill_Form();
        }

        private void Fill_Form()
        {
            q = ("SELECT * FROM Vendors WHERE VendorID = " + currentRecord_toolStripLabel.Text);

            try
            {
                SqlConnection con = new SqlConnection(conn_string);
                DataTable dt = new DataTable();
                con.Open();
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand(q, con);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    venNum_textBox.Text = (reader["VendorNumber"].ToString());
                    venName_textBox.Text = (reader["VendorName"].ToString());
                    contact_textBox.Text = (reader["Contact"].ToString());
                    email_textBox.Text = (reader["VendorEmail"].ToString());
                    phone_textBox.Text = (reader["VendorPhone"].ToString());
                }
                con.Close();

                query = "SELECT Count(*) from Vendors";
                SqlCommand cmd2 = new SqlCommand(query, con);
                con.Open();
                count = (int)cmd2.ExecuteScalar();
                totalRecords_toolStripLabel.Text = count.ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                error_msg = ex.Message;
                MessageBox.Show(error_msg);
            }


        }
        public int Save_Vendor_With_Return(string vendorname)
        {
            string vendorName = vendorname;

            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                q = "INSERT INTO Vendors (VendorNumber, VendorName, Contact, VendorEmail, VendorPhone) OUTPUT INSERTED.VendorID " +
                    "VALUES (@VendorNumber, @VendorName, @Contact, @VendorEmail, @VendorPhone)";

                using (SqlCommand command = new SqlCommand(q, conn))
                {
                    command.Parameters.AddWithValue("@VendorNumber", venNum_textBox.Text);
                    command.Parameters.AddWithValue("@VendorName", vendorName);
                    command.Parameters.AddWithValue("@Contact", contact_textBox.Text);
                    command.Parameters.AddWithValue("@VendorEmail", email_textBox.Text);
                    command.Parameters.AddWithValue("@VendorPhone", phone_textBox.Text);

                    conn.Open();
                    vendorID = (int)command.ExecuteScalar();
                    return vendorID;
                }
            }
        }

        private void FirstRecord_button_Click(object sender, EventArgs e)
        {
            index = 1;
            currentRecord_toolStripLabel.Text = index.ToString();
            Fill_Form();
        }
        private void PrevRecord_button_Click(object sender, EventArgs e)
        {
            if (index > 1)
            {
                index -= 1;
                currentRecord_toolStripLabel.Text = index.ToString();
                Fill_Form();
            }
            else
            {
                index = 1;
            }
        }
        private void NextRecord_button_Click(object sender, EventArgs e)
        {
            index += 1;
            currentRecord_toolStripLabel.Text = index.ToString();
            Fill_Form();
        }
        private void LastRecord_button_Click(object sender, EventArgs e)
        {
            index = count;
            currentRecord_toolStripLabel.Text = index.ToString();
            Fill_Form();
        }
        private void SaveRecord_button_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                q = "INSERT INTO Vendors (VendorNumber, VendorName, Contact, VendorEmail, VendorPhone) OUTPUT INSERTED.VendorID " +
                    "VALUES (@VendorNumber, @VendorName, @Contact, @VendorEmail, @VendorPhone)";

                using (SqlCommand command = new SqlCommand(q, conn))
                {
                    command.Parameters.AddWithValue("@VendorNumber", venNum_textBox.Text);
                    command.Parameters.AddWithValue("@VendorName", venName_textBox.Text);
                    command.Parameters.AddWithValue("@Contact", contact_textBox.Text);
                    command.Parameters.AddWithValue("@VendorEmail", email_textBox.Text);
                    command.Parameters.AddWithValue("@VendorPhone", phone_textBox.Text);

                    conn.Open();
                    vendorID = (int)command.ExecuteScalar();
                }
            }
            this.Close();
        }
    }
}
