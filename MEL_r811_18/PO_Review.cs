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
    public partial class PO_Review : Form
    {
        public string details;
        public string order;
        public string vend_query;
        public string tech_query;
        public string dep_query;
        public string mach_query;
        public string emp_query;
        public int updatedVend;
        public int updatedTech;
        public string conn_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\MEL\MEL.mdf;Integrated Security=True";
        SqlConnection conn = null;

        public int id;
        public PO_Review(int index)
        {
            InitializeComponent();
            id = index;
        }

        public void PO_Review_load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mELDataSet.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.mELDataSet.Employee);
            // TODO: This line of code loads data into the 'mELDataSet.Vendors' table. You can move, or remove it, as needed.
            this.vendorsTableAdapter.Fill(this.mELDataSet.Vendors);

            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                conn.Open();

                details = " SELECT PR_Details.OrderDetailsID, PR_Details.OrderID, PR_Details.Quantity, PR_Details.Unit, Parts.PartNumber, Parts.PartDescription, PR_Details.Per, PR_Details.DueDate, PR_Details.Received " +
                    "FROM Parts INNER JOIN PR_Details ON Parts.PartID = PR_details.PartID " +
                    "WHERE OrderID = " + id;

                SqlDataAdapter dataAdapter = new SqlDataAdapter(details, conn);

                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataGridView1.DataSource = dt;

                dataGridView1.Columns[0].FillWeight = 50;
                dataGridView1.Columns[0].HeaderText = "Order Details ID";
                dataGridView1.Columns[0].ReadOnly = false;
                dataGridView1.Columns[0].Visible = false;

                dataGridView1.Columns[1].FillWeight = 40;
                dataGridView1.Columns[1].HeaderText = "Order ID";
                dataGridView1.Columns[1].ReadOnly = false;
                dataGridView1.Columns[1].Visible = false;

                dataGridView1.Columns[2].FillWeight = 40;
                dataGridView1.Columns[2].HeaderText = "Qty";
                dataGridView1.Columns[2].ReadOnly = false;
                dataGridView1.Columns[2].Visible = true;

                dataGridView1.Columns[3].FillWeight = 50;
                dataGridView1.Columns[3].HeaderText = "Unit";
                dataGridView1.Columns[3].ReadOnly = false;
                dataGridView1.Columns[3].Visible = true;

                dataGridView1.Columns[4].FillWeight = 75;
                dataGridView1.Columns[4].HeaderText = "Part";
                dataGridView1.Columns[4].ReadOnly = true;
                dataGridView1.Columns[4].Visible = true;

                dataGridView1.Columns[5].FillWeight = 125;
                dataGridView1.Columns[5].HeaderText = "Description";
                dataGridView1.Columns[5].ReadOnly = true;
                dataGridView1.Columns[5].Visible = true;

                dataGridView1.Columns[6].FillWeight = 50;
                dataGridView1.Columns[6].HeaderText = "Per";
                dataGridView1.Columns[6].ReadOnly = false;
                dataGridView1.Columns[6].Visible = true;

                dataGridView1.Columns[7].FillWeight = 100;
                dataGridView1.Columns[7].HeaderText = "Due Date";
                dataGridView1.Columns[7].ReadOnly = false;
                dataGridView1.Columns[7].Visible = true;

                dataGridView1.Columns[8].FillWeight = 50;
                dataGridView1.Columns[8].HeaderText = "Recieved";
                dataGridView1.Columns[8].ReadOnly = false;
                dataGridView1.Columns[8].Visible = true;
            }

            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                conn.Open();

                order = "SELECT PR.OrderID, Vendors.VendorName, PR.DateIssued, Department.DepartmentID, Machines.BTNumber, Employee.Tech, PR.DeliverTo, PR.PONumber " +
                    "FROM Vendors INNER JOIN PR ON Vendors.VendorID = PR.VendorID " +
                    "INNER JOIN Department ON Department.DepartmentID = PR.DepartmentID " +
                    "INNER JOIN Machines ON Machines.MachineID = PR.MachineID " +
                    "INNER JOIN Employee ON Employee.EmployeeID = PR.EmployeeID " +
                    "WHERE PR.OrderID = " + id;

                SqlCommand command = new SqlCommand(order, conn);

                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    vendor_textBox.Text = (string)dr["VendorName"];
                    department_textBox.Text = (string)dr["DepartmentID"].ToString();
                    machine_textBox.Text = (string)dr["BTNumber"];
                    tech_textBox.Text = (string)dr["Tech"];
                    vendor_textBox.Text = (string)dr["VendorName"];
                    poNumber_textBox.Text = (string)dr["PONumber"];
                    deliverTo_textBox.Text = (string)dr["DeliverTO"];
                    issueDate_dateTimePicker.Text = (string)dr["DateIssued"];

                }

                    dr.Close();
            }

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                conn.Open();

                vend_query = "SELECT VendorID FROM Vendors WHERE VendorName = '" + vendor_textBox.Text + "'";

                SqlCommand command = new SqlCommand(vend_query, conn);

                SqlDataReader dr_vend = command.ExecuteReader();

                while (dr_vend.Read())
                {
                    updatedVend = (int)dr_vend["VendorID"];
                }

                dr_vend.Close();
            //}
            //using (SqlConnection conn = new SqlConnection(conn_string))
            //{
                //conn.Open();

                tech_query = "SELECT EmployeeID FROM Employee WHERE Tech = '" + tech_textBox.Text + "'";

                SqlCommand command_tech = new SqlCommand(tech_query, conn);

                SqlDataReader dr_tech = command_tech.ExecuteReader();

                while (dr_tech.Read())
                {
                    updatedTech = (int)dr_tech["EmployeeID"];
                }

                dr_tech.Close();
            }

            using (SqlConnection connection = new SqlConnection(conn_string))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE PR SET DateIssued = @issued, DeliverTo = @deliver, PONumber = @po, VendorID = @vend, EmployeeID = @tech WHERE OrderID = " + id;

                command.Parameters.AddWithValue("@issued", issueDate_dateTimePicker.Text);
                command.Parameters.AddWithValue("@deliver", deliverTo_textBox.Text);
                command.Parameters.AddWithValue("@po", poNumber_textBox.Text);
                command.Parameters.AddWithValue("@vend", updatedVend);
                command.Parameters.AddWithValue("@tech", updatedTech);

                connection.Open();

                command.ExecuteNonQuery();
            }
            this.Close();
        }
    }
}
