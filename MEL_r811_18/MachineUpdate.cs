using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEL_r811_18
{
    public partial class MachineUpdate : Form
    {
        MachineSetup ms;
        public string conn_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\joe\source\repos\MEL_r811_18\MEL_r811_18\MEL.mdf;Integrated Security=True";
        public string q = "";

        public int machine;

        public string error_msg = "";
        public string btNumber = "";

        SqlDataReader reader = null;

        public MachineUpdate(MachineSetup ms)
        {
            InitializeComponent();
            Machine_ComboBox_Fill();
        }
        public void Update_Machine(object sender, EventArgs e)
        {

        }
        public void Cancel(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Machine_ComboBox_Fill()
        {
            try
            {
                SqlConnection conn = new SqlConnection(conn_string);
                conn.Open();

                q = "SELECT MachineID, BTNumber FROM Machines";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(q, conn);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                btNumber_comboBox.DataSource = dt;
                btNumber_comboBox.DisplayMember = "BTNumber";
                btNumber_comboBox.ValueMember = "MachineID";
                conn.Close();

                if (btNumber_comboBox.SelectedIndex != -1)
                    machine = (int)btNumber_comboBox.SelectedValue;
            }
            catch (Exception ex)
            {
                error_msg = ex.Message;
                MessageBox.Show(error_msg);
            }
        }

        public void Fill_Form(object sender, EventArgs e)
        {
            if (btNumber_comboBox.SelectedIndex != -1)
                machine = (int)btNumber_comboBox.SelectedValue;
                btNumber = (string)btNumber_comboBox.Text;

            try
            {
                SqlConnection con = new SqlConnection(conn_string);
                DataTable dt = new DataTable();
                con.Open();
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("SELECT CommonName, Make, Model, Serial, DepartmentID FROM Machines WHERE BTNumber = @btNumber", con);
                cmd.Parameters.AddWithValue("@btNumber", btNumber);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    name_txtbox.Text = (reader["CommonName"].ToString());
                    make_txtbox.Text = (reader["Make"].ToString());
                    model_txtbox.Text = (reader["Model"].ToString());
                    serial_txtbox.Text = (reader["Serial"].ToString());
                    department_textBox.Text = (reader["DepartmentID"].ToString());
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
