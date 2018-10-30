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

        MainScreen ms;

        bool woclosed;
        bool stock;
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
        private void Part_comboBox_Fill()
        {
            string part_fill_q = "SELECT PartID, PartNumber FROM Parts";
            DataTable table = new DataTable("myData");
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(part_fill_q, conn))
                {

                    da.Fill(table);


                    DataRow row0 = table.NewRow();
                    DataRow row1 = table.NewRow();
                    row0["PartNumber"] = "-Select Part-";
                    row1["PartNumber"] = "-Add Part-";
                    table.Rows.InsertAt(row0, 0);
                    table.Rows.InsertAt(row1, 1);
                    table.DefaultView.Sort = "PartNumber asc";

                    part_comboBox.DataSource = table;
                    part_comboBox.DisplayMember = "PartNumber";
                    part_comboBox.ValueMember = "PartID";
                }

            }

        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            bool converted = false;
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlCommand command = conn.CreateCommand())
                {
                    command.CommandText = "UPDATE WorkRequest SET RequestConverted = @Converted WHERE RequestID = " + Convert.ToInt16(workRequestID_textBox.Text);

                    command.Parameters.AddWithValue("@Converted", converted);

                    conn.Open();
                    command.ExecuteNonQuery();
                }
            }
            this.Close();
        }
        private void Save_button_Click(object sender, EventArgs e)
        {
            Save_WorkOrder();
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
                string q = "INSERT INTO WorkOrder (WorkRequestID, EmployeeID, StatusID, WOCLosed, DateWOCLosed) OUTPUT INSERTED.WOID " +
                    "VALUES (@WorkRequestID, @EmployeeID, @StatusID, @WOCLosed, @DateWOCLosed)";

                using (SqlCommand command = new SqlCommand(q, conn))
                {
                    command.Parameters.AddWithValue("@WorkRequestID", Convert.ToInt16(requestID));
                    command.Parameters.AddWithValue("@EmployeeID", Get_EmployeeID(employee));
                    command.Parameters.AddWithValue("@StatusID", Get_StatusID(status));
                    command.Parameters.AddWithValue("@WOCLosed", woclosed);
                    command.Parameters.AddWithValue("@DateWOCLosed", dateClosed);

                    conn.Open();
                    int woid = (int)command.ExecuteScalar();
                    Save_WorkOrderDetails(woid);
                }
                
            }
            
        }
        private void Save_WorkOrderDetails(int id)
        {
            if (radioButton1.Checked == true)
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
                        cmd.Parameters["@WOID"].Value = id;
                        cmd.Parameters["@PartID"].Value = row.Cells[0].Value;
                        cmd.Parameters["@Qty"].Value = row.Cells[1].Value;
                        cmd.Parameters["@Stock/Ordered"].Value = row.Cells[3].Value;
                        cmd.Parameters["@WorkPerformed"].Value = row.Cells[4].Value;

                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            else if (radioButton2.Checked == true)
            {
                string q = "INSERT INTO WODetails (WOID, PartID, Qty, WorkPerformed, [Stock/Ordered]) OUTPUT INSERTED.WODetailsID VALUES " +
                   "(@WOID, @PartID, @Qty, @WorkPerformed, @StockOrdered)";

                SqlConnection conn = new SqlConnection(conn_string);
                SqlCommand cmd = new SqlCommand(q, conn);
                {
                    cmd.Parameters.Add(new SqlParameter("@WOID", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@PartID", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@WorkPerformed", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@StockOrdered", SqlDbType.Bit));

                    conn.Open();

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        cmd.Parameters["@WOID"].Value = id;
                        cmd.Parameters["@PartID"].Value = DBNull.Value;
                        cmd.Parameters["@Qty"].Value = DBNull.Value;
                        cmd.Parameters["@StockOrdered"].Value = DBNull.Value;
                        cmd.Parameters["@WorkPerformed"].Value = textBox2.Text;

                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            this.Close();
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
                string status_q = "SELECT StatusID FROM Status WHERE Status = '" + stat + "'";
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

                        Part_comboBox_Fill();
                    }
                    else
                    {
                        dataGridView1.Rows.Add(new String[]
                        {DBNull.Value.ToString(),
                        DBNull.Value.ToString(),
                        DBNull.Value.ToString(),
                        DBNull.Value.ToString(),
                        textBox2.Text,
                        });
                    }
                    break;

                default:
                    if (stock_radioButton.Checked == true)
                    {
                        stock = true;
                    }
                    else if (ordered_radioButton.Checked == true)
                    {
                        stock = false;
                    }
                    dataGridView1.Rows.Add(new String[]
                    {part_comboBox.SelectedValue.ToString(),
                    qty_textBox.Text,
                    partDesc_textbox.Text,
                    stock.ToString(),
                    textBox2.Text,
                    });

                    dataGridView1.Sort(part, ListSortDirection.Ascending);
                    qty_textBox.Clear();
                    partDesc_textbox.Clear();
                    textBox2.Clear();

                    break;

            }
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                part_comboBox.Visible = true;
                partDesc_textbox.Visible = true;
                qty_textBox.Visible = true;
                stock_radioButton.Visible = true;
                ordered_radioButton.Visible = true;
                addToList_button.Visible = true;
                dataGridView1.Visible = true;
            }
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                part_comboBox.Visible = false;
                partDesc_textbox.Visible = false;
                qty_textBox.Visible = false;
                stock_radioButton.Visible = false;
                ordered_radioButton.Visible = false;
                addToList_button.Visible = false;
                dataGridView1.Visible = false;
            }
        }
    }
    
}
