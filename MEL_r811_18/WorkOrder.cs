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
    public partial class WorkOrder : Form
    {
        public string conn_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\MEL\MEL.mdf;Integrated Security=True";

        public WorkOrder(int id)
        {
            InitializeComponent();
        }
        private void WorkOrder_Load(object sender, EventArgs e)
        {
            Tech_comboBox_Fill();
            Status_comboBox_Fill();
        }

        private void Tech_comboBox_Fill()
        {
            string q = "SELECT EmployeeID, Tech FROM Employee";
            DataTable table = new DataTable("EmployeeData");
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(q, conn))
                {
                    da.Fill(table);

                    DataRow row = table.NewRow();
                    row["Tech"] = "-Select Employee-";
                    table.Rows.InsertAt(row, 0);

                    tech_comboBox.DataSource = table;
                    tech_comboBox.DisplayMember = "Tech";
                    tech_comboBox.ValueMember = "EmployeeID";
                }

            }
        }
        private void Status_comboBox_Fill()
        {
            string q = "SELECT StatusID, Status FROM Status";
            DataTable table = new DataTable("StatusData");
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(q, conn))
                {
                    da.Fill(table);

                    DataRow row = table.NewRow();
                    row["Status"] = "-Select Status-";
                    table.Rows.InsertAt(row, 0);

                    status_comboBox.DataSource = table;
                    status_comboBox.DisplayMember = "Status";
                    status_comboBox.ValueMember = "StatusID";
                }

            }
        }
    }
    
}
