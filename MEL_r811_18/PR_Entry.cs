using System;
//using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data;
//using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace MEL_r811_18
{
    public partial class PR_Entry : Form
    {
        public string conn_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\MEL\MEL.mdf;Integrated Security=True";
        SqlConnection conn = null;
        public string q;
        public string vendor_q;
        public string department_q;
        public string machine_q;
        public string employee_q;
        public string part_q;
        public string vendor_fill_q;
        public string department_fill_q;
        public string machine_fill_q;
        public string employee_fill_q;
        public string part_fill_q;
        public string vendor;
        public string orderDate;
        public string dep;
        public string mach;
        public string emp;
        public string deliver;
        public int? machToAdd;

        public int vendorId;
        public int departmentId;
        public int machineId;
        public int employeeId;
        public int orderID;
        public int partID;
        MainScreen ms;

        public PR_Entry(MainScreen ms)
        {
            InitializeComponent();
        }

        private void PR_Entry_Load(object sender, EventArgs e)
        {
            Fill_Vendor_ComboBox();
            Fill_Department_ComboBox();
            Fill_Machine_ComboBox();
            Fill_Employee_ComboBox();
            Fill_Part_ComboBox();

        }
 

        private void Cncl_btn_Click(object sender, EventArgs e)
        {
            desc_txb.Clear();
            price_txb.Clear();
            this.Close();
        }

        private void Part_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (part_combo.SelectedIndex == 1)
            {
                NewPart np = new NewPart(ms);
                np.FormClosed += new FormClosedEventHandler(PartSetupClosed);
                np.Show();
            }
            else
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(conn_string))
                    {
                        q = "SELECT PartID, PartDescription, UnitPrice " +
                            "FROM Parts " +
                            "WHERE PartNumber = '" + part_combo.Text + "'";

                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = q;

                        DataTable td = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(q, conn);
                        conn.Open();
                        da.Fill(td);
                        conn.Close();
                        desc_txb.Text = td.Rows[0].ItemArray[1].ToString();
                        price_txb.Text = td.Rows[0].ItemArray[2].ToString();
                    }
                    int qty = Convert.ToInt16(qty_txb.Text);
                    decimal price = Convert.ToDecimal(price_txb.Text);
                    decimal total = qty * price;
                    total_txb.Text = total.ToString();
                }
                catch
                {

                }
            }

            
            
            
        }
        private void Dep_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_Machine_ComboBox();
        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            Save_PR();
        }

        private int Get_VendorID(string vendor)
        {
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                vendor_q = "SELECT VendorID FROM Vendors WHERE VendorName = '" + vendor + "'";
                conn.Open();

                SqlCommand command = new SqlCommand(vendor_q, conn);
                SqlDataReader myReader = command.ExecuteReader();
                while (myReader.Read())
                {
                    vendorId = Convert.ToInt16(myReader["VendorID"].ToString());
                }
                myReader.Close();
            }
            return vendorId;
        }
        private int Get_DepartmentID(string department)
        {
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                department_q = "SELECT DepartmentID FROM Department WHERE DepartmentName = '" + department + "'";
                conn.Open();

                SqlCommand command = new SqlCommand(department_q, conn);
                SqlDataReader myReader = command.ExecuteReader();
                while (myReader.Read())
                {
                    departmentId = Convert.ToInt16(myReader["DepartmentID"].ToString());
                }
                myReader.Close();
            }
            return departmentId;
        }
        private int Get_MachineID(string mach)
        {
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                machine_q = "SELECT MachineID FROM Machines WHERE BTNumber = '" + mach + "'";
                conn.Open();

                SqlCommand command = new SqlCommand(machine_q, conn);
                SqlDataReader myReader = command.ExecuteReader();
                while (myReader.Read())
                {
                    machineId = Convert.ToInt16(myReader["MachineID"].ToString());
                }
                myReader.Close();
            }
            return machineId;
        }
        private int Get_EmployeeID(string emp)
        {
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                employee_q = "SELECT EmployeeID FROM Employee WHERE Tech = '" + emp + "'";
                conn.Open();

                SqlCommand command = new SqlCommand(employee_q, conn);
                SqlDataReader myReader = command.ExecuteReader();
                while (myReader.Read())
                {
                    employeeId = Convert.ToInt16(myReader["EmployeeID"].ToString());
                }
                myReader.Close();
            }
            return employeeId;
        }
        private int Get_PartID(string part)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conn_string))
                {
                    part_q = "SELECT PartID FROM Parts WHERE PartNumber = '" + part + "'";
                    conn.Open();

                    SqlCommand command = new SqlCommand(part_q, conn);
                    SqlDataReader myReader = command.ExecuteReader();
                    while (myReader.Read())
                    {
                        partID = Convert.ToInt16(myReader["PartID"].ToString());
                    }
                    myReader.Close();
                }
                return partID;
            }
            catch (SqlException e) when (e.Number == 2601)
            {
                return 0;
            }
            
        }

        private void Save_PR()
        {
            string vendor = vend_combo.Text;
            string orderDate = dateIsued_dtp.Text;
            string dep = dep_combo.Text;
            if (mach_combo.Text == "-Select Machine-")
            {
                machToAdd = null;
            }
            else
            {
                machToAdd = Get_MachineID(mach_combo.Text);

            }
            string emp = employee_combo.Text;
            string deliver = deliverTo_txb.Text;

            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                q = "INSERT INTO PR (VendorID, DateIssued, DepartmentID, MachineID, EmployeeID, DeliverTo) OUTPUT INSERTED.OrderID " +
                    "VALUES (@VendorID, @DateIssued, @DepartmentID, @MachineID, @EmployeeID, @DeliverTo)";

                using (SqlCommand command = new SqlCommand(q, conn))
                {
                    command.Parameters.AddWithValue("@VendorID", Get_VendorID(vendor));
                    command.Parameters.AddWithValue("@DateIssued", dateIsued_dtp.Text);
                    command.Parameters.AddWithValue("@DepartmentID", Get_DepartmentID(dep));
                    command.Parameters.AddWithValue("@MachineID", machToAdd);
                    command.Parameters.AddWithValue("@EmployeeID", Get_EmployeeID(emp));
                    command.Parameters.AddWithValue("@DeliverTo", deliverTo_txb.Text);

                    conn.Open();
                    orderID = (int)command.ExecuteScalar();

                    Save_PRDetails();
                  
                }
            }
            
        }
        private void Save_PRDetails()
        {
            q = "INSERT INTO PR_Details (OrderID, Quantity, Unit, PartID, UnitPrice, Per, DueDate, Received) OUTPUT INSERTED.OrderDetailsID VALUES " +
                "(@OrderID, @Quantity, @Unit, @PartID, @UnitPrice, @Per, @DueDate, @Received)";

            SqlConnection conn = new SqlConnection(conn_string);
            SqlCommand cmd = new SqlCommand(q, conn);
            {
                cmd.Parameters.Add(new SqlParameter("@OrderID", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@Unit", SqlDbType.VarChar));
                cmd.Parameters.Add(new SqlParameter("@PartID", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@UnitPrice", SqlDbType.Money));
                cmd.Parameters.Add(new SqlParameter("@Per", SqlDbType.VarChar));
                cmd.Parameters.Add(new SqlParameter("@DueDate", SqlDbType.VarChar));
                cmd.Parameters.Add(new SqlParameter("@Received", SqlDbType.VarChar));

                conn.Open();

                foreach (DataGridViewRow row in newOrderDetails_dataGridView.Rows)
                {
                    cmd.Parameters["@OrderID"].Value = orderID;
                    cmd.Parameters["@Quantity"].Value = row.Cells[0].Value;
                    cmd.Parameters["@Unit"].Value = row.Cells[1].Value;
                    cmd.Parameters["@PartID"].Value = row.Cells[2].Value;
                    cmd.Parameters["@UnitPrice"].Value = row.Cells[5].Value;
                    cmd.Parameters["@Per"].Value = row.Cells[6].Value;
                    cmd.Parameters["@DueDate"].Value = DBNull.Value;
                    cmd.Parameters["@Received"].Value = row.Cells[8].Value;

                    cmd.ExecuteNonQuery();

                }
                conn.Close();
            }
            this.Close();
            
        }

        private void Fill_Vendor_ComboBox()
        {
            vendor_fill_q = "SELECT VendorID, VendorName FROM Vendors";
            DataTable table = new DataTable("VendorData");
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(vendor_fill_q, conn))
                {
                    da.Fill(table);

                    DataRow row = table.NewRow();
                    row["VendorName"] = "-Select Vendor-";
                    table.Rows.InsertAt(row, 0);

                    vend_combo.DataSource = table;
                    vend_combo.DisplayMember = "VendorName";
                    vend_combo.ValueMember = "VendorID";
                }

            }
                
        }
        private void Fill_Department_ComboBox()
        {
            department_fill_q = "SELECT DepartmentID, DepartmentName FROM Department";
            DataTable table = new DataTable("DepartmentData");
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(department_fill_q, conn))
                {
                    da.Fill(table);

                    DataRow row = table.NewRow();
                    row["DepartmentName"] = "-Select Department-";
                    table.Rows.InsertAt(row, 0);

                    dep_combo.DataSource = table;
                    dep_combo.DisplayMember = "DepartmentName";
                    dep_combo.ValueMember = "DepartmentID";
                }

            }
            Fill_Machine_ComboBox();

        }
        private void Fill_Machine_ComboBox()
        {
            machine_fill_q = "SELECT MachineID, BTNumber FROM Machines WHERE DepartmentID = '"
                    + (dep_combo.SelectedValue.ToString()) + "'";
            DataTable table = new DataTable("MachineData");
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(machine_fill_q, conn))
                {
                    da.Fill(table);

                    DataRow row = table.NewRow();
                    row["BTNumber"] = "-Select Machine-";
                    table.Rows.InsertAt(row, 0);

                    mach_combo.DataSource = table;
                    mach_combo.DisplayMember = "BTNumber";
                    mach_combo.ValueMember = "MachineID";
                }

            }

        }
        private void Fill_Employee_ComboBox()
        {
            employee_fill_q = "SELECT EmployeeID, Tech FROM Employee";
            DataTable table = new DataTable("EmployeeData");
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(employee_fill_q, conn))
                {
                    da.Fill(table);

                    DataRow row = table.NewRow();
                    row["Tech"] = "-Select Technician-";
                    table.Rows.InsertAt(row, 0);

                    employee_combo.DataSource = table;
                    employee_combo.DisplayMember = "Tech";
                    employee_combo.ValueMember = "EmployeeID";
                }
                
            }

        }
        private void Fill_Part_ComboBox()
        {
            part_fill_q = "SELECT PartID, PartNumber FROM Parts";
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

                    part_combo.DataSource = table;
                    part_combo.DisplayMember = "PartNumber";
                    part_combo.ValueMember = "PartID";
                }
  
            }

        }

        private void AddToOrder_btn_Click(object sender, EventArgs e)
        {
            Get_PartID(part_combo.Text);

            switch (partID)
            {
                case 0:
                    if (MessageBox.Show("Part does not exist! \nDo you want to Add " + part_combo.Text +
                    " to the Parts table?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string partnumber = part_combo.Text;
                        string partdescription = desc_txb.Text;
                        decimal unitprice = Convert.ToDecimal(price_txb.Text);

                        NewPart np = new NewPart(ms);

                        using (SqlConnection conn = new SqlConnection(conn_string))
                        {
                            q = "SELECT PartID, PartDescription, UnitPrice " +
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
                            desc_txb.Text = td.Rows[0].ItemArray[1].ToString();
                            price_txb.Text = td.Rows[0].ItemArray[2].ToString();
                        }
                        int qty = Convert.ToInt16(qty_txb.Text);
                        decimal price = Convert.ToDecimal(price_txb.Text);
                        decimal total = qty * price;
                        total_txb.Text = total.ToString();

                        Fill_Part_ComboBox();
                    }
                    break;

                default:
                    newOrderDetails_dataGridView.Rows.Add(new String[]
                    {qty_txb.Text,
                    unit_combo.Text,
                    part_combo.SelectedValue.ToString(),
                    part_combo.Text,
                    desc_txb.Text,
                    price_txb.Text,
                    per_combo.Text,
                    DBNull.Value.ToString(),
                    "False",
                    total_txb.Text,
                    });

                    newOrderDetails_dataGridView.Sort(part, ListSortDirection.Ascending);
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

        private void PartSetupClosed(object sender, EventArgs e)
        {
            this.Show();
        }

        private void Vend_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Get_VendorID(vend_combo.Text);

            switch (vendorId)
            {
                case 0:
                    VendorSetup popup = new VendorSetup(ms);
                    popup.label1.Text = "Vendor does not exist! Do you want to Add " + vend_combo.Text +
                    " to the Vendor table?";
                    popup.venName_textBox.Text = vend_combo.Text;
                    popup.venNum_textBox.Text = "";
                    popup.contact_textBox.Text = "";
                    popup.phone_textBox.Text = "";
                    popup.email_textBox.Text = "";
                    popup.ShowDialog();



                    break;

                default:

                    break;

            }
        }
    }
}
