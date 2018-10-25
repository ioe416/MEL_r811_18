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

        public string conn_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\MEL\MEL.mdf;Integrated Security=True";
        public string q;
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
                //cmd.Parameters.AddWithValue("@btNumber", btNumber);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    venNum_textBox.Text = (reader["CommonName"].ToString());
                    venName_textBox.Text = (reader["Make"].ToString());
                    contact_textBox.Text = (reader["Model"].ToString());
                    email_textBox.Text = (reader["Serial"].ToString());
                    phone_textBox.Text = (reader["DepartmentID"].ToString());
                }

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
    }
}
