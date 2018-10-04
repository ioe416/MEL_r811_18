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
    public partial class PR_Entry : Form
    {
        public string conn_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\MEL\MEL.mdf;Integrated Security=True";
        SqlConnection conn = null;
        public string q;
        public string vendor_q;
        public string department_q;
        public string machine_q;
        public string employee_q;
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

        public int vendorId;
        public int departmentId;
        public int machineId;
        public int employeeId;
        public int orderID;

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
        private void dep_combo_SelectedIndexChanged(object sender, EventArgs e)
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
        private void Save_PR()
        {
            string vendor = vend_combo.Text;
            string orderDate = dateIsued_dtp.Text;
            string dep = dep_combo.Text;
            string mach = mach_combo.Text;
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
                    command.Parameters.AddWithValue("@MachineID", Get_MachineID(mach));
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
            using (SqlConnection conn = new SqlConnection(conn_string))
            using (SqlCommand cmd = new SqlCommand(q, conn))
            {
                q = "INSERT INTO PR_Details (OrderID, Quantity, Unit, PartID, UnitPrice, Per, DueDate, Received) OUTPUT INSERTED.OrderDetailsID" +
                    "VALUES (@OrderID, @Quantity, @Unit, @PartID, @UnitPrice, @Per, @DueDate, @Received)";

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
                    using (SqlCommand command = new SqlCommand(q, conn))
                    {
                        cmd.Parameters["@OrderID"].Value = orderID;
                        cmd.Parameters["@Quantity"].Value = row.Cells[0].Value;
                        cmd.Parameters["@Unit"].Value = row.Cells[1].Value;
                        cmd.Parameters["@PartID"].Value = row.Cells[2].Value;
                        cmd.Parameters["@UnitPrice"].Value = row.Cells[5].Value;
                        cmd.Parameters["@Per"].Value = row.Cells[6].Value;
                        cmd.Parameters["@DueDate"].Value = row.Cells[7].Value;
                        cmd.Parameters["@Received"].Value = row.Cells[8].Value;

                        MessageBox.Show("Order ID: " + row.Cells[0].Value +
                            " Quantity: " + row.Cells[0].Value + 
                            " Unit: " + row.Cells[1].Value +
                            " PartID: " + row.Cells[2].Value +
                            " UnitPrice: " + row.Cells[5].Value +
                            " Per: " + row.Cells[6].Value +
                            " DueDate: " + row.Cells[7].Value +
                            " Received: " + row.Cells[8].Value);

                        cmd.ExecuteNonQuery();
                        command.Parameters.AddWithValue("@OrderID", Get_VendorID(vendor));
                        command.Parameters.AddWithValue("@Quantity", dateIsued_dtp.Text);
                        command.Parameters.AddWithValue("@Unit", Get_DepartmentID(dep));
                        command.Parameters.AddWithValue("@PartID", Get_MachineID(mach));
                        command.Parameters.AddWithValue("@UnitPrice", Get_EmployeeID(emp));
                        command.Parameters.AddWithValue("@Per", deliverTo_txb.Text);
                        command.Parameters.AddWithValue("@DueDate", Get_EmployeeID(emp));
                        command.Parameters.AddWithValue("@Received", deliverTo_txb.Text);

                        conn.Open();
                        int result = command.ExecuteNonQuery();
                        int orderDetailsID = (int)command.ExecuteScalar();
                        MessageBox.Show("Order ID: " + orderID + " Order Detail ID: " + orderDetailsID.ToString());
                        // Check Error
                        //if (result < 0)
                        //    Console.WriteLine("Error inserting data into Database!");
                    }
                }

            }
            this.Close();
        }

        private void Fill_Vendor_ComboBox()
        {
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                vendor_fill_q = "SELECT VendorID, VendorName FROM Vendors";
                conn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(vendor_fill_q, conn);
                da.Fill(ds, "FillVendorDropDown");

                vend_combo.DataSource = ds.Tables["FillVendorDropDown"].DefaultView;
                vend_combo.DisplayMember = "VendorName";
                vend_combo.ValueMember = "VendorID";
            }
                
        }
        private void Fill_Department_ComboBox()
        {
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                department_fill_q = "SELECT DepartmentID, DepartmentName FROM Department";
                conn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(department_fill_q, conn);
                da.Fill(ds, "FillDepartmentDropDown");

                dep_combo.DataSource = ds.Tables["FillDepartmentDropDown"].DefaultView;
                dep_combo.DisplayMember = "DepartmentName";
                dep_combo.ValueMember = "DepartmentID";
            }

        }
        private void Fill_Machine_ComboBox()
        {
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                machine_fill_q = "SELECT MachineID, BTNumber FROM Machines WHERE DepartmentID = '" + Convert.ToInt16(dep_combo.SelectedValue.ToString()) + "'";
                conn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(machine_fill_q, conn);
                da.Fill(ds, "FillMachineDropDown");

                mach_combo.DataSource = ds.Tables["FillMachineDropDown"].DefaultView;
                mach_combo.DisplayMember = "BTNumber";
                mach_combo.ValueMember = "MachineID";
            }

        }
        private void Fill_Employee_ComboBox()
        {
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                employee_fill_q = "SELECT EmployeeID, Tech FROM Employee";
                conn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(employee_fill_q, conn);
                da.Fill(ds, "FillEmployeeDropDown");

                employee_combo.DataSource = ds.Tables["FillEmployeeDropDown"].DefaultView;
                employee_combo.DisplayMember = "Tech";
                employee_combo.ValueMember = "EmployeeID";
            }

        }
        private void Fill_Part_ComboBox()
        {
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                part_fill_q = "SELECT PartID, PartNumber FROM Parts";
                conn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(part_fill_q, conn);
                da.Fill(ds, "FillPartDropDown");

                part_combo.DataSource = ds.Tables["FillPartDropDown"].DefaultView;
                part_combo.DisplayMember = "PartNumber";
                part_combo.ValueMember = "PartID";
            }

        }

        private void AddToOrder_btn_Click(object sender, EventArgs e)
        {
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

        }

        
    }
}
