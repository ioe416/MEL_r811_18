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
    public partial class WorkRequestEntry : Form
    {
        public string conn_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\MEL\MEL.mdf;Integrated Security=True";
        SqlConnection conn = null;
        public string q;
        public string type_q;
        public string priority_q;
        public string department_q;
        public string machine_q;
        public string type_fill_q;
        public string priority_fill_q;
        public string machine_fill_q;
        public string department_fill_q;
        public string machToAdd;

        public int departmentId;
        public int machineId;
        public int typeId;
        public int priorityId;

        public WorkRequestEntry(MainScreen ms)
        {
            InitializeComponent();
        }
        public void WorkRequestEntry_Load(object sender, EventArgs e)
        {
            //// TODO: This line of code loads data into the 'mELDataSet1.Priority' table. You can move, or remove it, as needed.
            //this.priorityTableAdapter.Fill(this.mELDataSet1.Priority);
            //// TODO: This line of code loads data into the 'mELDataSet1.Type' table. You can move, or remove it, as needed.
            //this.typeTableAdapter.Fill(this.mELDataSet1.Type);
            //// TODO: This line of code loads data into the 'mELDataSet.Machines' table. You can move, or remove it, as needed.
            //this.machinesTableAdapter.Fill(this.mELDataSet.Machines);
            //// TODO: This line of code loads data into the 'mELDataSet.Department' table. You can move, or remove it, as needed.
            //this.departmentTableAdapter.Fill(this.mELDataSet.Department);
            Fill_RequestType_ComboBox();
            Fill_Priority_ComboBox();
            Fill_Department_ComboBox();
            Fill_Machine_ComboBox();
        }

        private void Department_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_Machine_ComboBox();
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

                    department_comboBox.DataSource = table;
                    department_comboBox.DisplayMember = "DepartmentName";
                    department_comboBox.ValueMember = "DepartmentID";
                }

            }
            Fill_Machine_ComboBox();
        }
        private void Fill_Machine_ComboBox()
        {
            machine_fill_q = "SELECT MachineID, BTNumber FROM Machines WHERE DepartmentID = '"
                    + (department_comboBox.SelectedValue.ToString()) + "'";
            DataTable table = new DataTable("MachineData");
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(machine_fill_q, conn))
                {
                    da.Fill(table);

                    DataRow row = table.NewRow();
                    row["BTNumber"] = "-Select Machine-";
                    table.Rows.InsertAt(row, 0);

                    machine_comboBox.DataSource = table;
                    machine_comboBox.DisplayMember = "BTNumber";
                    machine_comboBox.ValueMember = "MachineID";
                }

            }
        }
        private void Fill_RequestType_ComboBox()
        {
            type_fill_q = "SELECT TypeID, Type FROM Type";
            DataTable table = new DataTable("TypeData");
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(type_fill_q, conn))
                {
                    da.Fill(table);

                    DataRow row = table.NewRow();
                    row["Type"] = "-Select Request Type-";
                    table.Rows.InsertAt(row, 0);

                    requestType_comboBox.DataSource = table;
                    requestType_comboBox.DisplayMember = "Type";
                    requestType_comboBox.ValueMember = "TypeID";
                }

            }
        }
        private void Fill_Priority_ComboBox()
        {
            priority_fill_q = "SELECT PriorityID, Priority FROM Priority";
            DataTable table = new DataTable("PriorityData");
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(priority_fill_q, conn))
                {
                    da.Fill(table);

                    DataRow row = table.NewRow();
                    row["Priority"] = "-Select Priority-";
                    table.Rows.InsertAt(row, 0);

                    requestPriority_comboBox.DataSource = table;
                    requestPriority_comboBox.DisplayMember = "Priority";
                    requestPriority_comboBox.ValueMember = "PriorityID";
                }

            }
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
        private int Get_TypeID(string type)
        {
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                type_q = "SELECT TypeID FROM Type WHERE Type = '" + type + "'";
                conn.Open();

                SqlCommand command = new SqlCommand(type_q, conn);
                SqlDataReader myReader = command.ExecuteReader();
                while (myReader.Read())
                {
                    typeId = Convert.ToInt16(myReader["TypeID"].ToString());
                }
                myReader.Close();
            }
            return typeId;
        }
        private int Get_PriorityID(string priority)
        {
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                priority_q = "SELECT PriorityID FROM Priority WHERE Priority = '" + priority + "'";
                conn.Open();

                SqlCommand command = new SqlCommand(priority_q, conn);
                SqlDataReader myReader = command.ExecuteReader();
                while (myReader.Read())
                {
                    priorityId = Convert.ToInt16(myReader["PriorityID"].ToString());
                }
                myReader.Close();
            }
            return priorityId;
        }

        private void Save_Request()
        {
            string type = requestType_comboBox.Text;
            string priority = requestPriority_comboBox.Text;
            string department = department_comboBox.Text;
            if (machine_comboBox.Text == "-Select Machine-")
            {
                machToAdd = "No Machine";
            }
            else
            {
                machToAdd = machine_comboBox.Text;
            }

            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                q = "INSERT INTO PR (VendorID, DateIssued, DepartmentID, MachineID, EmployeeID, DeliverTo) OUTPUT INSERTED.OrderID " +
                    "VALUES (@VendorID, @DateIssued, @DepartmentID, @MachineID, @EmployeeID, @DeliverTo)";

                //TODO: 
                //using (SqlCommand command = new SqlCommand(q, conn))
                //{
                //    command.Parameters.AddWithValue("@VendorID", Get_VendorID(type));
                //    command.Parameters.AddWithValue("@DateIssued", dateIsued_dtp.Text);
                //    command.Parameters.AddWithValue("@DepartmentID", Get_DepartmentID(department));
                //    command.Parameters.AddWithValue("@MachineID", Get_MachineID(machToAdd));
                //    command.Parameters.AddWithValue("@EmployeeID", Get_EmployeeID(emp));
                //    command.Parameters.AddWithValue("@DeliverTo", deliverTo_txb.Text);

                //    conn.Open();
                //    orderID = (int)command.ExecuteScalar();

                //    Save_PRDetails();

                //}
            }

        }
    }
}
