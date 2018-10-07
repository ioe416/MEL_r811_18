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
    public partial class MachineSetup : Form
    {
        public string conn_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\joe\source\repos\MEL_r811_18\MEL_r811_18\MEL.mdf;Integrated Security=True";
        public string q = "";

        public int department;

        public string error_msg = "";

        public MachineSetup(MainScreen ms)
        {
            InitializeComponent();
            Department_ComboBox_Fill();
        }

        
        public void Update_Machine(object sender, EventArgs e)
        {

        }
        public void Cancel(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Department_ComboBox_Fill()
        {
            try
            {
                SqlConnection conn = new SqlConnection(conn_string);
                conn.Open();

                q = "SELECT DepartmentID, DepartmentName FROM Department";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(q, conn);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                department_combobox.DataSource = dt;
                department_combobox.DisplayMember = "DepartmentName";
                department_combobox.ValueMember = "DepartmentID";
                conn.Close();

                if (department_combobox.SelectedIndex != -1)
                    department = (int)department_combobox.SelectedValue;
            }
            catch (Exception ex)
            {
                error_msg = ex.Message;
                MessageBox.Show(error_msg);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void MachineUpdate_FormClosed(object sender, EventArgs e)
        {
            this.Show();
        }

        public void Save_Machine(object sender, EventArgs e)
        {
            if (department_combobox.SelectedIndex != -1)
                department = (int)department_combobox.SelectedValue;

            SqlConnection conn = new SqlConnection(conn_string);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            SqlCommand cmdSelect = conn.CreateCommand();
            cmd.CommandText = @"INSERT INTO Machines(BTNumber,CommonName,Make,Model,Serial,DepartmentID)VALUES(@BTNumber,@CommonName,@Make,@Model,@Serial,@DepartmentID)";
            cmd.Parameters.AddWithValue("@BTNumber", btNumber_txtbox.Text);
            cmd.Parameters.AddWithValue("@CommonName", name_txtbox.Text);
            cmd.Parameters.AddWithValue("@Make", name_txtbox.Text);
            cmd.Parameters.AddWithValue("@Model", model_txtbox.Text);
            cmd.Parameters.AddWithValue("@Serial", serial_txtbox.Text);
            cmd.Parameters.AddWithValue("@DepartmentID", department);

            cmd.ExecuteNonQuery();

            conn.Close();

        }
    }
}
