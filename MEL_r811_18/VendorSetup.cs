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

        public string conn_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\joe\source\repos\MEL_r811_18\MEL_r811_18\MEL.mdf;Integrated Security=True";
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
    }
}
