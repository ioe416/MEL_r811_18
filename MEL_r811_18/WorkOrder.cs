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
            string employee = dateIsued_dtp.Text;
            string status = dep_combo.Text;
            if (checkBox1.Checked == true)
            {
                woclosed = true;
            }
            else
            {
                woclosed = false;
            }
            string dateClosed = dateTimePicker1.Text;
            string work = textBox2.Text;

            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                string q = "INSERT INTO PR (WorkRequestID, EmployeeID, StatusID, WODetailsID, WOCLosed, DateWOCLosed, WorkPerformed) OUTPUT INSERTED.OrderID " +
                    "VALUES (@WorkRequestID, @EmployeeID, @StatusID, @WODetailsID, @WOCLosed, @DateWOCLosed, @WorkPerformed)";

                using (SqlCommand command = new SqlCommand(q, conn))
                {
                    command.Parameters.AddWithValue("@WorkRequestID", requestID);
                    command.Parameters.AddWithValue("@EmployeeID", employee);
                    command.Parameters.AddWithValue("@StatusID", status);
                    command.Parameters.AddWithValue("@WODetailsID", Get_MachineID(machToAdd));
                    command.Parameters.AddWithValue("@WOCLosed", woclosed);
                    command.Parameters.AddWithValue("@DateWOCLosed", dateClosed);
                    command.Parameters.AddWithValue("@WorkPerformed", work);

                    conn.Open();
                    int orderID = (int)command.ExecuteScalar();

                    Save_WorkOrderDetails();

                }
            }
            
        }
        private int Save_WorkOrderDetails()
        {
            string q = "INSERT INTO PR_Details (OrderID, Quantity, Unit, PartID, UnitPrice, Per, DueDate, Received) OUTPUT INSERTED.OrderDetailsID VALUES " +
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
            return detailsID;
        }
    }
    
}
