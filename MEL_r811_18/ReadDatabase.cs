using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEL_r811_18
{
    class ReadDatabase
    {
        public string conn_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\MEL\MEL.mdf;Integrated Security=True";

        public SqlDataAdapter OpenWO_Fill()
        {
            string q = "SELECT[WorkOrder].[WorkRequestID], [Employee].[Tech], [Status].[Status], [WorkRequest].[WorkRequested] " +
                    "FROM[WorkOrder] INNER JOIN[Employee] ON[Employee].[EmployeeID] = [WorkOrder].[EmployeeID] " +
                    "INNER JOIN[Status] ON [Status].[StatusID] = [WorkOrder].[StatusID] " +
                    "INNER JOIN[WorkRequest] ON[WorkRequest].[RequestID] = [WorkOrder].[WorkRequestID]" +
                    "WHERE [WorkRequest].[RequestConverted] = 'True' AND [WorkOrder].[WOClosed] = 'False'";

            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(q, conn))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conn.Close();
                    return da;
                }
            }
        }
        public DataTable HistoricalPO_Fill(string today)
        {
            string q = "SELECT PR.OrderID, Vendors.VendorName, PR.PONumber, PR_Details.Quantity,  PR_Details.Unit, Parts.PartNumber, Parts.PartDescription, PR_Details.Per, PR_Details.DueDate, PR_Details.Received " +
                "FROM Parts INNER JOIN PR_Details ON Parts.PartID = PR_Details.PartID " +
                "INNER JOIN PR ON PR.OrderID = PR_Details.OrderID INNER JOIN Vendors ON PR.VendorID = Vendors.VendorID " +
                "WHERE (PR_Details.DueDate IS NULL OR PR_Details.DueDate >= '" + today + "') AND (PR_Details.Received = 'True') AND (PR.PONumber IS NOT NULL)";

            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(q, conn))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conn.Close();
                    return dt;
                }
            }
        }
        public DataTable OpenWR_Fill()
        {
            string q = "SELECT[WorkRequest].[RequestID], [Machines].[BTNumber], [WorkRequest].[RequestDate], [Type].[Type], " +
                        "[Priority].[Priority], [WorkRequest].[WorkRequested], [WorkRequest].[RequestConverted] " +
                        "FROM[WorkRequest] INNER JOIN[Machines] ON[Machines].[MachineID] = [WorkRequest].[MachineID] " +
                        "INNER JOIN[Type] ON[Type].[TypeID] = [WorkRequest].[RequestType] " +
                        "INNER JOIN[Priority] ON[Priority].[PriorityID] = [WorkRequest].[RequestPriority]" +
                        "WHERE [WorkRequest].[RequestConverted] = 'False'";
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(q, conn))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conn.Close();
                    return dt;
                }
            }
        }
        public DataTable OpenPR_Fill()
        {
            string q = "SELECT PR.OrderID, Vendors.VendorName, PR.PONumber, PR_Details.Quantity,  PR_Details.Unit, Parts.PartNumber, Parts.PartDescription, PR_Details.Per, PR_Details.DueDate, PR_Details.Received " +
                        "FROM Parts INNER JOIN PR_Details ON Parts.PartID = PR_Details.PartID " +
                        "INNER JOIN PR ON PR.OrderID = PR_Details.OrderID INNER JOIN Vendors ON PR.VendorID = Vendors.VendorID " +
                        "WHERE (PR.PONumber IS NULL) AND (PR_Details.Received = 'False')";

            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(q, conn))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conn.Close();
                    return dt;
                }
            }
        }
        public DataTable OverduePO_Fill(string today)
        {
            string q = "SELECT PR.OrderID, Vendors.VendorName, PR.PONumber, PR_Details.Quantity,  PR_Details.Unit, Parts.PartNumber, Parts.PartDescription, PR_Details.Per, PR_Details.DueDate, PR_Details.Received " +
                    "FROM Parts INNER JOIN PR_Details ON Parts.PartID = PR_Details.PartID " +
                    "INNER JOIN PR ON PR.OrderID = PR_Details.OrderID INNER JOIN Vendors ON PR.VendorID = Vendors.VendorID " +
                    "WHERE (PR_Details.Received = 'False') AND (PR_Details.DueDate < '" + today + "')";

            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(q, conn))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conn.Close();
                    return dt;
                }
            }
        }
        public DataTable OpenPO_Fill(string today)
        {
            string q = "SELECT PR.OrderID, Vendors.VendorName, PR.PONumber, PR_Details.Quantity,  PR_Details.Unit, Parts.PartNumber, Parts.PartDescription, PR_Details.Per, PR_Details.DueDate, PR_Details.Received " +
                        "FROM Parts INNER JOIN PR_Details ON Parts.PartID = PR_Details.PartID " +
                        "INNER JOIN PR ON PR.OrderID = PR_Details.OrderID INNER JOIN Vendors ON PR.VendorID = Vendors.VendorID " +
                        "WHERE (PR_Details.DueDate IS NULL OR PR_Details.DueDate >= '" + today + "') AND (PR_Details.Received = 'False') AND (PR.PONumber IS NOT NULL)";

            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(q, conn))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conn.Close();
                    return dt;
                }
            }
        }

        //public List<Department> SelectDepartment_Fill()
        //{
            //string q = "SELECT DepartmentID, DepartmentName FROM Department";
            //DataTable table = new DataTable("DepartmentData");
            //using (SqlConnection conn = new SqlConnection(conn_string))
            //{
            //    using (SqlDataAdapter da = new SqlDataAdapter(q, conn))
            //    {
            //        da.Fill(table);

            //        DataRow row = table.NewRow();
            //        row["DepartmentName"] = "-Select Department-";
            //        table.Rows.InsertAt(row, 0);

            //        return table.ToString();
            //    }

            //}
        //    List<Department> department = new List<Department>();

        //    try
        //    {
        //        SqlConnection con = new SqlConnection(conn_string);
        //        DataTable dt = new DataTable();
        //        con.Open();
        //        SqlDataReader reader = null;
        //        SqlCommand cmd = new SqlCommand("SELECT DepartmentID, DepartmentName FROM Department", con);

        //        reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            Department d = new Department();
        //            d.DepartmentID = (int)reader["DepartmentID"];
        //            d.DepartmentName = (string)reader["DepartmentName"]; ;
        //            department.Add(d);
        //        }
        //        return department;
        //    }
        //    catch (Exception ex)
        //    {
        //        string error_msg = ex.Message;
        //        MessageBox.Show(error_msg);
        //        return null;
        //    }

        //}
        public DataTable SelectMachine_Fill()
        {
            string q = "SELECT MachineID, BTNumber FROM Machines";
            DataTable table = new DataTable("MachineData");
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(q, conn))
                {
                    da.Fill(table);

                    DataRow row = table.NewRow();
                    row["BTNumber"] = "-Select Machine-";
                    table.Rows.InsertAt(row, 0);

                    return table;
                }

            }
        }
        public DataTable SelectVendor_Fill()
        {
            string q = "SELECT VendorID, VendorName FROM Vendors";
            DataTable table = new DataTable("VendorData");
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(q, conn))
                {
                    da.Fill(table);

                    DataRow row = table.NewRow();
                    row["VendorName"] = "-Select Vendor-";
                    table.Rows.InsertAt(row, 0);

                    return table;
                }
            }
        }
        public DataTable SelectTech_Fill()
        {
            string q = "SELECT EmployeeID, Tech FROM Employee";
            DataTable table = new DataTable("EmployeeData");
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(q, conn))
                {
                    da.Fill(table);

                    DataRow row = table.NewRow();
                    row["Tech"] = "-Select Technician-";
                    table.Rows.InsertAt(row, 0);

                    return table;
                }

            }
        }

        
    }
}
