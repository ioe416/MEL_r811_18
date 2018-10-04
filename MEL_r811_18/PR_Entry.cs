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

        public PR_Entry(MainScreen ms)
        {
            InitializeComponent();
        }

        private void PR_Entry_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mELDataSet.Parts' table. You can move, or remove it, as needed.
            this.partsTableAdapter.Fill(this.mELDataSet.Parts);
            // TODO: This line of code loads data into the 'mELDataSet.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.mELDataSet.Employee);
            // TODO: This line of code loads data into the 'mELDataSet.Vendors' table. You can move, or remove it, as needed.
            this.vendorsTableAdapter.Fill(this.mELDataSet.Vendors);
            // TODO: This line of code loads data into the 'mELDataSet.Machines' table. You can move, or remove it, as needed.
            this.machinesTableAdapter.Fill(this.mELDataSet.Machines);
            // TODO: This line of code loads data into the 'mELDataSet.Department' table. You can move, or remove it, as needed.
            this.departmentTableAdapter.Fill(this.mELDataSet.Department);
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

        private void Save_btn_Click(object sender, EventArgs e)
        {
            Save_PR();
            Save_PRDetails();
            this.Close();
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
                q = "INSERT INTO PR (VendorID, DateIssued, DepartmentID, MachineID, EmployeeID, DeliverTo) " +
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
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                }
            }
        }
        private void Save_PRDetails()
        {

        }

        private void AddToOrder_btn_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(new String[]
                {qty_txb.Text, unit_combo.Text,  part_combo.Text, per_combo.Text, DBNull.Value.ToString(), "False"});

            dataGridView1.Sort(part, ListSortDirection.Ascending);
            qty_txb.Clear();

        }
    }
}
