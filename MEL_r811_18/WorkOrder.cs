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

        bool woclosed;
        int woid;
        int partid;
        int vendorid;
        int employeeid;
        int statusid;

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

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Save_button_Click(object sender, EventArgs e)
        {

        }

        private void Save_WorkOrder()
        {
            string requestID = workRequestID_textBox.Text;
            string employee = tech_comboBox.Text;
            string status = status_comboBox.Text;
            if (checkBox1.Checked == true)
            {
                woclosed = true;
            }
            else
            {
                woclosed = false;
            }
            string dateClosed = dateTimePicker1.Text;

            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                string q = "INSERT INTO PR (WorkRequestID, EmployeeID, StatusID, WOCLosed, DateWOCLosed) OUTPUT INSERTED.OrderID " +
                    "VALUES (@WorkRequestID, @EmployeeID, @StatusID, @WOCLosed, @DateWOCLosed)";

                using (SqlCommand command = new SqlCommand(q, conn))
                {
                    command.Parameters.AddWithValue("@WorkRequestID", Convert.ToInt16(requestID));
                    command.Parameters.AddWithValue("@EmployeeID", Get_EmployeeID(employee));
                    command.Parameters.AddWithValue("@StatusID", Get_StatusID(status));
                    command.Parameters.AddWithValue("@WOCLosed", woclosed);
                    command.Parameters.AddWithValue("@DateWOCLosed", dateClosed);

                    conn.Open();
                    int orderID = (int)command.ExecuteScalar();
                }
                
            }
            Save_WorkOrderDetails();
        }
        private void Save_WorkOrderDetails()
        {
            string q = "INSERT INTO WODetails (WOID, PartID, Qty, WorkPerformed, Stock/Ordered) OUTPUT INSERTED.WODetailsID VALUES " +
               "(@WOID, @PartID, @Qty, @WorkPerformed, @Stock/Ordered)";

            SqlConnection conn = new SqlConnection(conn_string);
            SqlCommand cmd = new SqlCommand(q, conn);
            {
                cmd.Parameters.Add(new SqlParameter("@WOID", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@PartID", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@WorkPerformed", SqlDbType.NVarChar));
                cmd.Parameters.Add(new SqlParameter("@Stock/Ordered", SqlDbType.Bit));

                conn.Open();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    cmd.Parameters["@WOID"].Value = woid;
                    cmd.Parameters["@PartID"].Value = row.Cells[0].Value;
                    cmd.Parameters["@Qty"].Value = row.Cells[1].Value;
                    cmd.Parameters["@WorkPerformed"].Value = row.Cells[2].Value;
                    cmd.Parameters["@Stock/Ordered"].Value = row.Cells[5].Value;

                    cmd.ExecuteNonQuery();

                }
                conn.Close();
            }
        }

        private int Get_VendorID(string vendor)
        {
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                string vendor_q = "SELECT VendorID FROM Vendors WHERE VendorName = '" + vendor + "'";
                conn.Open();

                SqlCommand command = new SqlCommand(vendor_q, conn);
                SqlDataReader myReader = command.ExecuteReader();
                while (myReader.Read())
                {
                    vendorid = Convert.ToInt16(myReader["VendorID"].ToString());
                }
                myReader.Close();
            }
            return vendorid;
        }
        private int Get_PartID(string part)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conn_string))
                {
                    string part_q = "SELECT PartID FROM Parts WHERE PartNumber = '" + part + "'";
                    conn.Open();

                    SqlCommand command = new SqlCommand(part_q, conn);
                    SqlDataReader myReader = command.ExecuteReader();
                    while (myReader.Read())
                    {
                        partid = Convert.ToInt16(myReader["PartID"].ToString());
                    }
                    myReader.Close();
                }
                return partid;
            }
            catch (SqlException e) when (e.Number == 2601)
            {
                return 0;
            }

        }
        private int Get_EmployeeID(string emp)
        {
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                string employee_q = "SELECT EmployeeID FROM Employee WHERE Tech = '" + emp + "'";
                conn.Open();

                SqlCommand command = new SqlCommand(employee_q, conn);
                SqlDataReader myReader = command.ExecuteReader();
                while (myReader.Read())
                {
                    employeeid = Convert.ToInt16(myReader["EmployeeID"].ToString());
                }
                myReader.Close();
            }
            return employeeid;
        }
        private int Get_StatusID(string stat)
        {
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                string status_q = "SELECT SttatusID FROM Status WHERE Status = '" + stat + "'";
                conn.Open();

                SqlCommand command = new SqlCommand(status_q, conn);
                SqlDataReader myReader = command.ExecuteReader();
                while (myReader.Read())
                {
                    statusid = Convert.ToInt16(myReader["StatusID"].ToString());
                }
                myReader.Close();
            }
            return statusid;
        }

        private void AddToOrder_btn_Click(object sender, EventArgs e)
        {
            Get_PartID(part_comboBox.Text);

            switch (partid)
            {
                case 0:
                    if (MessageBox.Show("Part does not exist! \nDo you want to Add " + part_comboBox.Text +
                    " to the Parts table?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string partnumber = part_comboBox.Text;
                        string partdescription = partDesc_textbox.Text;
                        decimal unitprice = 0;

                        NewPart np = new NewPart(ms);

                        using (SqlConnection conn = new SqlConnection(conn_string))
                        {
                            string q = "SELECT PartID, PartDescription, UnitPrice " +
                                "FROM Parts " +
                                "WHERE PartID = '" + np.Save_Part_With_Return(partnumber, partdescription, unitprice) + "'";

                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = q;

                            DataTable td = new DataTable();
                            SqlDataAdapter da = new SqlDataAdapter(q, conn);
                            conn.Open();
                            da.Fill(td);
                            conn.Close();
                            partDesc_textbox.Text = td.Rows[0].ItemArray[1].ToString();
                            
                        }
                        int qty = Convert.ToInt16(qty_textBox.Text);
                        decimal price = Convert.ToDecimal(0);

                        Fill_Part_ComboBox();
                    }
                    break;

                default:
                    dataGridView1.Rows.Add(new String[]
                    {part_comboBox.SelectedValue.ToString(),
                    qty_textBox.Text,
                    .Text,
                    textBox2.Text,
                    });

                    dataGridView1.Sort(part, ListSortDirection.Ascending);
                    qty_txb.Clear();
                    unit_combo.SelectedIndex = 0;
                    part_combo.SelectedIndex = 0;
                    desc_txb.Clear();
                    price_txb.Clear();
                    per_combo.SelectedIndex = 0;
                    total_txb.Clear();
                    partID = 0;
                    break;

            }
        }

        private void part_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    
}
