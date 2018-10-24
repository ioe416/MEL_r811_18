using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEL_r811_18
{
    public partial class PR_Review : Form
    {
        public string q;
        public string details;
        public string order;
        public string orderDetails;
        public string vend_query;
        public string tech_query;
        public string dep_query;
        public string mach_query;
        public string emp_query;
        public string delete_order_q;
        public string delete_order_details_q;
        public int updatedVend;
        public int updatedTech;
        public int updatedDep;
        public int? updatedMach;
        public string updated_dueDate;
        public string e;
        public string conn_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\MEL\MEL.mdf;Integrated Security=True";
        SqlConnection conn = null;
        public bool a;

        List<PO_Details> order_detailsList = new List<PO_Details>();

        public int id;
        public PR_Review(int index)
        {
            InitializeComponent();
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
            id = index;
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8) dataGridView1.EndEdit();
        }

        public void PO_Review_load(object sender, EventArgs e)
        {
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

                order = "SELECT PR.OrderID, Vendors.VendorName, PR.DateIssued, Department.DepartmentName, Machines.BTNumber, Employee.Tech, PR.DeliverTo, PR.PONumber " +
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
                    department_textBox.Text = (string)dr["DepartmentName"];
                    machine_textBox.Text = (string)dr["BTNumber"];
                    tech_textBox.Text = (string)dr["Tech"];
                    vendor_textBox.Text = (string)dr["VendorName"];
                    poNumber_textBox.Text = (dr["PONumber"] == DBNull.Value) ? string.Empty : (string)dr["PONumber"];                 
                    deliverTo_textBox.Text = (string)dr["DeliverTO"];
                    issueDate_dateTimePicker.Text = (dr["DateIssued"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["DateIssued"]);
                    orderID_txb.Text = (string)dr["OrderID"].ToString();
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

                tech_query = "SELECT EmployeeID FROM Employee WHERE Tech = '" + tech_textBox.Text + "'";

                SqlCommand command_tech = new SqlCommand(tech_query, conn);

                SqlDataReader dr_tech = command_tech.ExecuteReader();

                while (dr_tech.Read())
                {
                    updatedTech = (int)dr_tech["EmployeeID"];
                }

                dr_tech.Close();

                dep_query = "SELECT DepartmentID FROM Department WHERE DepartmentName = '" + department_textBox.Text + "'";

                SqlCommand command_dep = new SqlCommand(dep_query, conn);

                SqlDataReader dr_dep = command_dep.ExecuteReader();

                while (dr_dep.Read())
                {
                    updatedDep = (int)dr_dep["DepartmentID"];
                }

                dr_dep.Close();

                mach_query = "SELECT MachineID FROM Machines WHERE BTNumber = '" + machine_textBox.Text + "'";

                SqlCommand command_mach = new SqlCommand(mach_query, conn);

                SqlDataReader dr_mach = command_mach.ExecuteReader();

                while (dr_mach.Read())
                {
                    updatedMach = (int?)dr_mach["MachineID"];
                }

                dr_mach.Close();


            }

            using (SqlConnection connection = new SqlConnection(conn_string))
            using (SqlCommand command = connection.CreateCommand())
            {

                command.CommandText = "UPDATE PR SET DateIssued = @issued, DeliverTo = @deliver, PONumber = @po, VendorID = @vend, " +
                    "EmployeeID = @tech, DepartmentID = @dep, MachineID = @mach WHERE OrderID = " + id;

                command.Parameters.AddWithValue("@issued", issueDate_dateTimePicker.Text);
                command.Parameters.AddWithValue("@deliver", deliverTo_textBox.Text);
                command.Parameters.AddWithValue("@po", poNumber_textBox.Text);
                command.Parameters.AddWithValue("@vend", updatedVend);
                command.Parameters.AddWithValue("@tech", updatedTech);
                command.Parameters.AddWithValue("@dep", updatedDep);
                command.Parameters.AddWithValue("@mach", updatedMach);

                connection.Open();

                command.ExecuteNonQuery();
            }
            Update_Details();
        }

        private void Update_Details()
        {
            q = "UPDATE PR_Details SET DueDate = @due, Received = @rec " +
                        "WHERE OrderID = " + id;

            SqlConnection conn = new SqlConnection(conn_string);
            SqlCommand cmd = new SqlCommand(q, conn);
            {
                cmd.Parameters.Add(new SqlParameter("@due", SqlDbType.Date));
                cmd.Parameters.Add(new SqlParameter("@rec", SqlDbType.VarChar));
                conn.Open();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (checkBox1.Checked == true)
                    {
                        cmd.Parameters["@due"].Value = dateTimePicker1.Value;
                    }
                    else
                    {
                        cmd.Parameters["@due"].Value = DBNull.Value;
                    }
                    cmd.Parameters["@rec"].Value = row.Cells[8].Value;

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            this.Close();
        }
        private void Load_PRDetails()
        {
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                conn.Open();
                orderDetails = "SELECT PR_Details.OrderDetailsID, PR_Details.OrderID, PR_Details.Quantity, PR_Details.Unit, Parts.PartNumber, Parts.PartDescription, PR_Details.DueDate, PR_Details.Received " +
                    "FROM Parts INNER JOIN PR_Details ON Parts.PartID = PR_Details.PartID " +
                    "WHERE PR.OrderID = " + id;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = orderDetails;
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
           
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            //CaptureScreen();
            //printDocument1.Print();
            //printDocument1.PrintPage += new PrintPageEventHandler(PrintDocument1_PrintPage);
        }
        Bitmap memoryImage;
        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }
        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new SqlConnection(conn_string))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        cmd.CommandText = "DELETE FROM PR_Details WHERE OrderID = @orderID";
                        cmd.Parameters.AddWithValue("@orderID", Convert.ToInt16(orderID_txb.Text));
                        cmd.ExecuteNonQuery();
                    }
                    cmd.CommandText = "DELETE FROM PR WHERE OrderID = @orderID";
                    cmd.Parameters.AddWithValue("@orderID", Convert.ToInt16(orderID_txb.Text));
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {

            }
            this.Close();
           
        }

        private void PrintPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
    class PO_Details
    {
        public int OrderDetailsID
        {
            get;
            set;
        }
        public int OrderID
        {
            get;
            set;
        }
        public int Quantity
        {
            get;
            set;
        }
        public string Unit
        {
            get;
            set;
        }
        public string PartNumber
        {
            get;
            set;
        }
        public string PartDescription
        {
            get;
            set;
        }
        public decimal UnitPrice
        {
            get;
            set;
        }
        public string Per
        {
            get;
            set;
        }
        public string DueDate
        {
            get;
            set;
        }
        public bool Received
        {
            get;
            set;
        }

    }
}
