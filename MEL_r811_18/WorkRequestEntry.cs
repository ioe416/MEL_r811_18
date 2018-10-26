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

        public string machToAdd;

        public int departmentId;
        public int machineId;
        public int typeId;
        public int priorityId;
        public int requestID;
        public int partID;
        public int index;
        public int id;

        public bool converted;

        public WorkRequestEntry(int index)
        {
            InitializeComponent();
            id = index;
        }
        public void WorkRequestEntry_Load(object sender, EventArgs e)
        {
            if (id == 0)
            {
                Fill_RequestType_ComboBox();
                Fill_Priority_ComboBox();
                Fill_Department_ComboBox();
                Fill_Machine_ComboBox();
            }
            else if (id != 0)
            {
                using (SqlConnection conn = new SqlConnection(conn_string))
                {
                    conn.Open();

                    string q = "SELECT[WorkRequest].[RequestID], [Machines].[BTNumber], [WorkRequest].[RequestDate], " +
                        "[Type].[Type] ,[Priority].[Priority], [WorkRequest].[WorkRequested], [Department].[DepartmentName] " +
                        "FROM[WorkRequest] INNER JOIN[Machines] ON[Machines].[MachineID] = [WorkRequest].[MachineID] " +
                        "INNER JOIN[Type] ON[Type].[TypeID] = [WorkRequest].[RequestType] " +
                        "INNER JOIN[Priority] ON[Priority].[PriorityID] = [WorkRequest].[RequestPriority] " +
                        "INNER JOIN[Department] ON [Department].[DepartmentID] = [WorkRequest].[DepartmentID] " +
                        "WHERE[WorkRequest].[RequestID] = '" + id + "'";

                    SqlCommand command = new SqlCommand(q, conn);

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        requestDate_datePicker.Text = (string)dr["RequestDate"];
                        machine_comboBox.Text = (string)dr["BTNumber"];
                        requestType_comboBox.Text = (string)dr["Type"];
                        requestPriority_comboBox.Text = (string)dr["Priority"];
                        workRequested_textBox.Text = (string)dr["WorkRequested"];
                        department_comboBox.Text = (string)dr["DepartmentName"];
                    }

                }

            }

        }

        private void Department_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_Machine_ComboBox();
        }

        private void Fill_Department_ComboBox()
        {
            string q = "SELECT DepartmentID, DepartmentName FROM Department";
            DataTable table = new DataTable("DepartmentData");
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(q, conn))
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
            string q = "SELECT MachineID, BTNumber FROM Machines WHERE DepartmentID = '"
                    + (department_comboBox.SelectedValue.ToString()) + "'";
            DataTable table = new DataTable("MachineData");
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(q, conn))
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
            string q = "SELECT TypeID, Type FROM Type";
            DataTable table = new DataTable("TypeData");
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(q, conn))
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
            string q = "SELECT PriorityID, Priority FROM Priority";
            DataTable table = new DataTable("PriorityData");
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(q, conn))
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
                string q = "SELECT DepartmentID FROM Department WHERE DepartmentName = '" + department + "'";
                conn.Open();

                SqlCommand command = new SqlCommand(q, conn);
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
                string q = "SELECT MachineID FROM Machines WHERE BTNumber = '" + mach + "'";
                conn.Open();

                SqlCommand command = new SqlCommand(q, conn);
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
                string q = "SELECT TypeID FROM Type WHERE Type = '" + type + "'";
                conn.Open();

                SqlCommand command = new SqlCommand(q, conn);
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
                string q = "SELECT PriorityID FROM Priority WHERE Priority = '" + priority + "'";
                conn.Open();

                SqlCommand command = new SqlCommand(q, conn);
                SqlDataReader myReader = command.ExecuteReader();
                while (myReader.Read())
                {
                    priorityId = Convert.ToInt16(myReader["PriorityID"].ToString());
                }
                myReader.Close();
            }
            return priorityId;
        }

        private void Save_Request(object Sender, EventArgs e)
        {
            if (id == 0)
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
                converted = false;
                using (SqlConnection conn = new SqlConnection(conn_string))
                {
                    string q = "INSERT INTO WorkRequest (DepartmentID, MachineID, RequestDate, RequestType, RequestPriority, WorkRequested, RequestConverted) OUTPUT INSERTED.RequestID " +
                        "VALUES (@DepartmentID, @MachineID, @RequestDate, @TypeID, @PriorityID, @WorkPerformed, @RequestConverted)";

                    using (SqlCommand command = new SqlCommand(q, conn))
                    {
                        command.Parameters.AddWithValue("@DepartmentID", Get_DepartmentID(department));
                        command.Parameters.AddWithValue("@TypeID", Get_TypeID(type));
                        command.Parameters.AddWithValue("@RequestDate", requestDate_datePicker.Text);
                        command.Parameters.AddWithValue("@MachineID", Get_MachineID(machToAdd));
                        command.Parameters.AddWithValue("@PriorityID", Get_PriorityID(priority));
                        command.Parameters.AddWithValue("@WorkPerformed", workRequested_textBox.Text);
                        command.Parameters.AddWithValue("@RequestConverted", converted);

                        conn.Open();
                        requestID = (int)command.ExecuteScalar();

                    }
                }
                this.Close();


            }
            else if (id != 0)
            {
                if (requestConverted_radioButton.Checked == true)
                {
                    converted = true;
                    using (SqlConnection conn = new SqlConnection(conn_string))
                    {
                        using (SqlCommand command = conn.CreateCommand())
                        {
                            command.CommandText = "UPDATE WorkRequest SET RequestConverted = @Converted WHERE RequestID = " + id;

                            command.Parameters.AddWithValue("@Converted", converted);

                            conn.Open();
                            command.ExecuteNonQuery();
                        }                    
                    }
                    WorkOrder popup = new WorkOrder(id);
                    popup.workRequestID_textBox.Text = id.ToString();
                    //popup.venNum_textBox.Text = "";
                    //popup.contact_textBox.Text = "";
                    //popup.phone_textBox.Text = "";
                    //popup.email_textBox.Text = "";
                    popup.ShowDialog();
                }
                else
                {
                    
                }
                this.Close();
            }
        }

        private void RequestConverted_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (requestConverted_radioButton.Checked == true)
            {
                requestConverted_radioButton.Text = "Work Order";
            }
            else
            {
                requestConverted_radioButton.Text = "Work Request";
            }
            
        }
    }
}
