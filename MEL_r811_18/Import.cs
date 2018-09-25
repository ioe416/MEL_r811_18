using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Data.SqlClient;
//using System.Diagnostics;
//using System.Drawing;
//using System.Linq;
using System.Runtime.InteropServices;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Xml;

namespace MEL_r811_18
{
    public partial class Import : Form
    {
        List<Machine> machineList = new List<Machine>();
        List<Part> partList = new List<Part>();
        List<Vendor> vendorList = new List<Vendor>();
        List<Employee> employeeList = new List<Employee>();
        List<PR> prList = new List<PR>();
        List<PR_Details> pr_detailsList = new List<PR_Details>();
        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public string q;
        public string conn_string = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Joe\source\repos\MEL_r811_18\MEL_r811_18\MEL.mdf; Integrated Security = True";
        SqlConnection conn = null;

        public Import(MainScreen ms)
        {
            InitializeComponent();
        }

        private void LoadEmployeeFromExcel(object sender, EventArgs e)
        {
            string fname = "";
            OpenFileDialog fdlg = new OpenFileDialog
            {
                Title = "Excel File Dialog",
                InitialDirectory = @"c:\Documents\",
                Filter = "All files (*.*)|*.*|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                fname = fdlg.FileName;
            }

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fname);
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;
            this.Cursor = Cursors.WaitCursor;
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            for (int i = 1; i <= rowCount; i++)
            {
                Employee emp = new Employee
                {
                    EmployeeID = Convert.ToInt16(xlWorksheet.Cells[i, 1].Value),
                    Tech = Convert.ToString(xlWorksheet.Cells[i, 2].Value),
                    Craft = Convert.ToString(xlWorksheet.Cells[i, 3].Value),
                    EmployeePhone = Convert.ToString(xlWorksheet.Cells[i, 4].Value),
                    EmployeeEmail = Convert.ToString(xlWorksheet.Cells[i, 5].Value),
                };
                employeeList.Add(emp);

                listView1.View = View.Details;
                listView1.HeaderStyle = ColumnHeaderStyle.None;

                ColumnHeader header = new ColumnHeader();
                header.Text = "";
                header.Name = "Tech";
                listView1.Columns.Add(header);

                listView1.Items.Add(emp.Tech);

            }

            //cleanup  
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //release com objects to fully kill excel process from running in the background  
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release  
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release  
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);

            saveEmployee_button.Enabled = true;
            this.Cursor = Cursors.Default;
        }
        private void SaveEmployeeToDB(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string removePR_FK = "ALTER TABLE PR DROP CONSTRAINT [FK_PR_EmployeeID]";
            string addPR_FK = "ALTER TABLE PR ADD CONSTRAINT [FK_PR_EmployeeID] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([EmployeeID])";
            string truncateEmployee = "TRUNCATE TABLE Employee";

            SqlConnection conn = new SqlConnection(conn_string);
            conn.Open();
            SqlCommand removepr_fk = new SqlCommand(removePR_FK, conn);
            removepr_fk.ExecuteNonQuery();
            SqlCommand truncateemployee = new SqlCommand(truncateEmployee, conn);
            truncateemployee.ExecuteNonQuery();
            conn.Close();

            foreach (Employee emp in employeeList)
            {
                using (SqlConnection connection = new SqlConnection(conn_string))
                {
                    String query = "SET IDENTITY_INSERT Employee ON; INSERT INTO Employee (EmployeeID,EmployeeName,Craft,Phone,Email) " +
                        "VALUES (@EmployeeID,@EmployeeName,@Craft,@Phone,@Email); SET IDENTITY_INSERT Machines OFF";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", emp.EmployeeID);
                        command.Parameters.AddWithValue("@EmployeeName", emp.Tech);
                        command.Parameters.AddWithValue("@Craft", emp.Craft);
                        if (String.IsNullOrEmpty(emp.EmployeePhone))
                        {
                            command.Parameters.AddWithValue("@Phone", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Phone", emp.EmployeePhone);
                        }
                        if (String.IsNullOrEmpty(emp.EmployeeEmail))
                        {
                            command.Parameters.AddWithValue("@Email", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Email", emp.EmployeeEmail);
                        }

                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                            Console.WriteLine("Error inserting data into Database!");
                    }
                }
            }

            conn.Open();
            SqlCommand addpr_fk = new SqlCommand(addPR_FK, conn);
            addpr_fk.ExecuteNonQuery();

            conn.Close();

            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void LoadMachinesFromExcel(object sender, EventArgs e)
        {
            string fname = "";
            OpenFileDialog fdlg = new OpenFileDialog
            {
                Title = "Excel File Dialog",
                InitialDirectory = @"c:\Documents\",
                Filter = "All files (*.*)|*.*|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                fname = fdlg.FileName;
            }

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fname);
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;
            this.Cursor = Cursors.WaitCursor;
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            for (int i = 1; i <= rowCount; i++)
            {
                Machine m = new Machine
                {
                    MachineID = Convert.ToInt16(xlWorksheet.Cells[i, 1].Value),
                    BTNumber = Convert.ToString(xlWorksheet.Cells[i, 2].Value),
                    CommonName = Convert.ToString(xlWorksheet.Cells[i, 3].Value),
                    Make = Convert.ToString(xlWorksheet.Cells[i, 4].Value),
                    Model = Convert.ToString(xlWorksheet.Cells[i, 5].Value),
                    Serial = Convert.ToString(xlWorksheet.Cells[i, 6].Value),
                    DepartmentID_Machine = Convert.ToInt16(xlWorksheet.Cells[i, 7].Value),
                };
                machineList.Add(m);

                listView1.View = View.Details;
                listView1.HeaderStyle = ColumnHeaderStyle.None;

                ColumnHeader header = new ColumnHeader();
                header.Text = "";
                header.Name = "BTNumber";
                listView1.Columns.Add(header);

                listView1.Items.Add(m.BTNumber);

            }

            //cleanup  
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //release com objects to fully kill excel process from running in the background  
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release  
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release  
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);

            saveMachines_button.Enabled = true;
            this.Cursor = Cursors.Default;
        }
        private void SaveMachinesToDB(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string removeFK = "ALTER TABLE Machines DROP CONSTRAINT[FK_Machines_Department]";
            string removeIDENTITY = "ALTER TABLE Machines DROP CONSTRAINT[PK_Machines]";
            string removePR_FK = "ALTER TABLE PR DROP CONSTRAINT [FK_PR_Machines]";
            string addFK = "ALTER TABLE Machines ADD CONSTRAINT[FK_Machines_Department] FOREIGN KEY([DepartmentID]) REFERENCES[dbo].[Department]([DepartmentID])";
            string addPR_FK = "ALTER TABLE PR ADD CONSTRAINT [FK_PR_Machines] FOREIGN KEY ([MachineID]) REFERENCES [dbo].[Machines] ([MachineID])";
            string addIDENTITY = "ALTER TABLE Machines ADD CONSTRAINT[PK_Machines] PRIMARY KEY CLUSTERED([MachineID] ASC)";
            string truncateMachines = "TRUNCATE TABLE Machines";

            SqlConnection conn = new SqlConnection(conn_string);
            conn.Open();
            SqlCommand removefk = new SqlCommand(removeFK, conn);
            removefk.ExecuteNonQuery();
            SqlCommand removepr_fk = new SqlCommand(removePR_FK, conn);
            removepr_fk.ExecuteNonQuery();
            SqlCommand removeidentity = new SqlCommand(removeIDENTITY, conn);
            removeidentity.ExecuteNonQuery();
            SqlCommand truncatemachines = new SqlCommand(truncateMachines, conn);
            truncatemachines.ExecuteNonQuery();
            conn.Close();

            foreach (Machine m in machineList)
            {
                using (SqlConnection connection = new SqlConnection(conn_string))
                {
                    String query = "SET IDENTITY_INSERT Machines ON; INSERT INTO Machines (MachineID,BTNumber,CommonName,Make,Model,Serial,DepartmentID) " +
                        "VALUES (@MachineID,@BTNumber,@CommonName,@Make,@Model,@Serial,@DepartmentID); SET IDENTITY_INSERT Machines OFF";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MachineID", m.MachineID);
                        command.Parameters.AddWithValue("@BTNumber", m.BTNumber);
                        if (String.IsNullOrEmpty(m.CommonName))
                        {
                            command.Parameters.AddWithValue("@CommonName", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@CommonName", m.CommonName);
                        }
                        if (String.IsNullOrEmpty(m.Make))
                        {
                            command.Parameters.AddWithValue("@Make", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Make", m.Make);
                        }
                        if (String.IsNullOrEmpty(m.Model))
                        {
                            command.Parameters.AddWithValue("@Model", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Model", m.Model);
                        }
                        if (String.IsNullOrEmpty(m.Serial))
                        {
                            command.Parameters.AddWithValue("@Serial", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Serial", m.Serial);
                        }
                        command.Parameters.AddWithValue("@DepartmentID", m.DepartmentID_Machine);

                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                            Console.WriteLine("Error inserting data into Database!");
                    }
                }
            }

            conn.Open();
            SqlCommand addfk = new SqlCommand(addFK, conn);
            addfk.ExecuteNonQuery();
            SqlCommand addidentity = new SqlCommand(addIDENTITY, conn);
            addidentity.ExecuteNonQuery();
            SqlCommand addpr_fk = new SqlCommand(addPR_FK, conn);
            addpr_fk.ExecuteNonQuery();

            conn.Close();

            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void LoadPartsFromExcel(object sender, EventArgs e)
        {
            string fname = "";
            OpenFileDialog fdlg = new OpenFileDialog
            {
                Title = "Excel File Dialog",
                InitialDirectory = @"c:\Documents\",
                Filter = "All files (*.*)|*.*|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                fname = fdlg.FileName;
            }

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fname);
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;
            this.Cursor = Cursors.WaitCursor;
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            for (int i = 1; i <= rowCount; i++)
            {
                Part p = new Part
                {
                    PartID = Convert.ToInt16(xlWorksheet.Cells[i, 1].Value),
                    PartNumber = Convert.ToString(xlWorksheet.Cells[i, 2].Value),
                    PartDescription = Convert.ToString(xlWorksheet.Cells[i, 3].Value),
                    UnitPrice = Convert.ToDecimal(xlWorksheet.Cells[i, 4].Value),

                };
                partList.Add(p);

                listView1.View = View.Details;
                listView1.HeaderStyle = ColumnHeaderStyle.None;

                ColumnHeader header = new ColumnHeader();
                header.Text = "";
                header.Name = "PartNumber";
                listView1.Columns.Add(header);

                listView1.Items.Add(p.PartNumber);

            }

            //cleanup  
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //release com objects to fully kill excel process from running in the background  
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release  
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release  
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);

            saveParts_button.Enabled = true;
            this.Cursor = Cursors.Default;
        }
        private void SavePartsToDB(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            string removePR_Details_FK = "ALTER TABLE PR_Details DROP CONSTRAINT [FK_PR_Details_Parts]";

            string addPR_FK = "ALTER TABLE PR_Details ADD CONSTRAINT [FK_PR_Details_Parts] FOREIGN KEY ([PartID]) REFERENCES [dbo].[Parts]([PartID])";

            string truncateParts = "TRUNCATE TABLE Parts";

            SqlConnection conn = new SqlConnection(conn_string);
            conn.Open();

            SqlCommand removepr_fk = new SqlCommand(removePR_Details_FK, conn);
            removepr_fk.ExecuteNonQuery();

            SqlCommand truncatemachines = new SqlCommand(truncateParts, conn);
            truncatemachines.ExecuteNonQuery();
            conn.Close();

            foreach (Part p in partList)
            {
                using (SqlConnection connection = new SqlConnection(conn_string))
                {
                    String query = "SET IDENTITY_INSERT Parts ON; INSERT INTO Parts (PartID,PartNumber,PartDescription,UnitPrice) " +
                        "VALUES (@PartID,@PartNumber,@PartDescription,@UnitPrice); SET IDENTITY_INSERT Parts OFF";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PartID", p.PartID);
                        if (String.IsNullOrEmpty(p.PartNumber))
                        {
                            command.Parameters.AddWithValue("@PartNumber", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@PartNumber", p.PartNumber);
                        }
                        if (String.IsNullOrEmpty(p.PartDescription))
                        {
                            command.Parameters.AddWithValue("@PartDescription", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@PartDescription", p.PartDescription);
                        }
                        if (p.PartID.Equals(null))
                        {
                            command.Parameters.AddWithValue("@UnitPrice", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@UnitPrice", p.UnitPrice);
                        }

                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                            Console.WriteLine("Error inserting data into Database!");
                    }
                }
            }

            conn.Open();

            SqlCommand addpr_fk = new SqlCommand(addPR_FK, conn);
            addpr_fk.ExecuteNonQuery();

            conn.Close();

            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void LoadPRFromExcel(object sender, EventArgs e)
        {
            string fname = "";
            OpenFileDialog fdlg = new OpenFileDialog
            {
                Title = "Excel File Dialog",
                InitialDirectory = @"c:\Documents\",
                Filter = "All files (*.*)|*.*|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                fname = fdlg.FileName;
            }

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fname);
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;
            this.Cursor = Cursors.WaitCursor;
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            for (int i = 1; i <= rowCount; i++)
            {
                PR pr = new PR
                {
                    OrderID = Convert.ToInt16(xlWorksheet.Cells[i, 1].Value),
                    VendorID_PR = Convert.ToInt16(xlWorksheet.Cells[i, 2].Value),
                    DateIssued = Convert.ToString(xlWorksheet.Cells[i, 3].Value),
                    DepartmentID_PR = Convert.ToInt16(xlWorksheet.Cells[i, 4].Value),
                    MachineID_PR = Convert.ToInt16(xlWorksheet.Cells[i, 5].Value),
                    EmployeeID_PR = Convert.ToInt16(xlWorksheet.Cells[i, 6].Value),
                    DeliverTo = Convert.ToString(xlWorksheet.Cells[i, 7].Value),
                    PONumber = Convert.ToString(xlWorksheet.Cells[i, 8].Value),
                };
                prList.Add(pr);

                listView1.View = View.Details;
                listView1.HeaderStyle = ColumnHeaderStyle.None;

                ColumnHeader header = new ColumnHeader();
                header.Text = "";
                header.Name = "PR";
                listView1.Columns.Add(header);

                listView1.Items.Add(pr.PONumber);

            }

            //cleanup  
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //release com objects to fully kill excel process from running in the background  
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release  
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release  
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);

            savePR_button.Enabled = true;
            this.Cursor = Cursors.Default;
        }
        private void SavePRToDB(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string removeEmployeeIdFK = "ALTER TABLE PR DROP CONSTRAINT[FK_PR_EmployeeID]";
            string removeMachinesFK = " ALTER TABLE PR DROP CONSTRAINT[FK_PR_Machines]";
            string removeDepartmentFK = " ALTER TABLE PR DROP CONSTRAINT[FK_PR_Department]";
            string removeVendorsFK = " ALTER TABLE PR DROP CONSTRAINT[FK_PR_Vendors]";

            string addEmployeeIdFK = "ALTER TABLE PR ADD CONSTRAINT [FK_PR_EmployeeID] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([EmployeeID])";
            string addMachinesFK = "ALTER TABLE PR ADD CONSTRAINT [FK_PR_Machines] FOREIGN KEY ([MachineID]) REFERENCES [dbo].[Machines] ([MachineID])";
            string addDepartmentFK = "ALTER TABLE PR ADD CONSTRAINT [FK_PR_Department] FOREIGN KEY ([DepartmentID]) REFERENCES [dbo].[Department] ([DepartmentID])";
            string addVendorsFK = "ALTER TABLE PR ADD CONSTRAINT [FK_PR_Vendors] FOREIGN KEY ([VendorID]) REFERENCES [dbo].[Vendors] ([VendorID])";

            //string addIDENTITY = "ALTER TABLE Machines ADD CONSTRAINT[PK_Machines] PRIMARY KEY CLUSTERED([OrderID] ASC)";

            string truncateMachines = "TRUNCATE TABLE Machines";

            SqlConnection conn = new SqlConnection(conn_string);
            conn.Open();
            SqlCommand removefk = new SqlCommand(removeEmployeeIdFK, conn);
            removefk.ExecuteNonQuery();
            SqlCommand removefk2 = new SqlCommand(removeMachinesFK, conn);
            removefk2.ExecuteNonQuery();
            SqlCommand removefk3 = new SqlCommand(removeDepartmentFK, conn);
            removefk3.ExecuteNonQuery();
            SqlCommand removefk4 = new SqlCommand(removeVendorsFK, conn);
            removefk4.ExecuteNonQuery();
            SqlCommand truncatePR = new SqlCommand(truncateMachines, conn);
            truncatePR.ExecuteNonQuery();

            conn.Close();

            foreach (PR pr in prList)
            {
                using (SqlConnection connection = new SqlConnection(conn_string))
                {
                    String query = "SET IDENTITY_INSERT PR ON; INSERT INTO PR (OrderID,VendorID,DateIssued,DepartmentID,MachineID,EmployeeID,DeliverTo,PONumber) " +
                        "VALUES (@OrderID,@VendorID,@DateIsssued,@DepartmentID,@MachineID,@EmployeeID,@DeliverTo,@PONumber); SET IDENTITY_INSERT PR OFF";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@OrderID", pr.OrderID);
                        command.Parameters.AddWithValue("@VendorID", pr.VendorID_PR);
                        command.Parameters.AddWithValue("@DateIsssued", pr.DateIssued);
                        command.Parameters.AddWithValue("@DepartmentID", pr.DepartmentID_PR);
                        command.Parameters.AddWithValue("@MachineID", pr.MachineID_PR);
                        command.Parameters.AddWithValue("@EmployeeID", pr.EmployeeID_PR);
                        command.Parameters.AddWithValue("@DeliverTo", pr.DeliverTo);
                        if (String.IsNullOrEmpty(pr.PONumber))
                        {
                            command.Parameters.AddWithValue("@PONumber", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@PONumber", pr.PONumber);
                        }

                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                            Console.WriteLine("Error inserting data into Database!");
                    }
                }
            }

            conn.Open();

            SqlCommand addEmployeeFK = new SqlCommand(addEmployeeIdFK, conn);
            addEmployeeFK.ExecuteNonQuery();
            SqlCommand addMachineFK = new SqlCommand(addMachinesFK, conn);
            addMachineFK.ExecuteNonQuery();
            SqlCommand addDepartFK = new SqlCommand(addDepartmentFK, conn);
            addDepartFK.ExecuteNonQuery();
            SqlCommand addVendorFK = new SqlCommand(addVendorsFK, conn);
            addVendorFK.ExecuteNonQuery();

            conn.Close();

            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void LoadPR_DetaisFromExcel(object sender, EventArgs e)
        {
            string fname = "";
            OpenFileDialog fdlg = new OpenFileDialog
            {
                Title = "Excel File Dialog",
                InitialDirectory = @"c:\Documents\",
                Filter = "All files (*.*)|*.*|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                fname = fdlg.FileName;
            }

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fname);
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;
            this.Cursor = Cursors.WaitCursor;
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            for (int i = 1; i <= rowCount; i++)
            {
                PR_Details pd = new PR_Details
                {
                    OrderID = Convert.ToInt16(xlWorksheet.Cells[i, 1].Value),
                    Quantity = Convert.ToInt16(xlWorksheet.Cells[i, 2].Value),
                    Unit = Convert.ToString(xlWorksheet.Cells[i, 3].Value),
                    PartID_PRD = Convert.ToInt16(xlWorksheet.Cells[i, 4].Value),
                    Per = Convert.ToString(xlWorksheet.Cells[i, 5].Value),
                    DueDate = Convert.ToString(xlWorksheet.Cells[i, 6].Value),
                    Received = Convert.ToBoolean(xlWorksheet.Cells[i, 7].Value),
                };
                pr_detailsList.Add(pd);

                listView1.View = View.Details;
                listView1.HeaderStyle = ColumnHeaderStyle.None;

                ColumnHeader header = new ColumnHeader();
                header.Text = "";
                header.Name = "PD";
                listView1.Columns.Add(header);

                listView1.Items.Add(pd.OrderID.ToString());


            }

            //cleanup  
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //release com objects to fully kill excel process from running in the background  
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release  
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release  
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);

            savePR_Details_button.Enabled = true;
            this.Cursor = Cursors.Default;
        }
        private void SavePR_DetaisToDB(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            SqlConnection conn = new SqlConnection(conn_string);
            conn.Open();

            //PR_Details Contraint strings
            string query_del_PK_PRDetails = "IF OBJECT_ID('dbo.[PK_PRDetails]') IS NOT NULL ALTER TABLE dbo.PR_Details DROP CONSTRAINT [PK_PRDetails]";// PRIMARY KEY CLUSTERED ([OrderID] ASC)";
            string query_del_FK_PR_Details_Parts = "IF OBJECT_ID('dbo.[FK_PR_Details_Parts]') IS NOT NULL ALTER TABLE dbo.PR_Details DROP CONSTRAINT [FK_PR_Details_Parts]";// FOREIGN KEY ([PartID]) REFERENCES [dbo].[Parts] ([PartID])";
            string query_del_FK_Table_PR = "IF OBJECT_ID('dbo.[FK_Table_PR]') IS NOT NULL ALTER TABLE dbo.PR_Details DROP CONSTRAINT [FK_Table_PR]";// FOREIGN KEY ([OrderID]) REFERENCES [dbo].[PR] ([OrderID])";

            //Drop PR_Details Constraints
            SqlCommand drop_PK_PRDetails = new SqlCommand(query_del_PK_PRDetails, conn);
            drop_PK_PRDetails.ExecuteNonQuery();
            SqlCommand drop_FK_PR_Details_Parts = new SqlCommand(query_del_FK_PR_Details_Parts, conn);
            drop_FK_PR_Details_Parts.ExecuteNonQuery();
            SqlCommand drop_FK_Table_PR = new SqlCommand(query_del_FK_Table_PR, conn);
            drop_FK_Table_PR.ExecuteNonQuery();

            string truncatePRDetails = "TRUNCATE TABLE PR_Details";

            SqlCommand truncatePR = new SqlCommand(truncatePRDetails, conn);
            truncatePR.ExecuteNonQuery();

            conn.Close();

            foreach (PR_Details pd in pr_detailsList)
            {
                using (SqlConnection connection = new SqlConnection(conn_string))
                {
                    String query = "SET IDENTITY_INSERT PR_Details ON; INSERT INTO PR_Details (OrderID,Quantity,Unit,PartID,Per,DueDate,Received) " +
                        "VALUES (@OrderID,@Quantity,@Unit,@PartID,@Per,@DueDate,@Received); SET IDENTITY_INSERT PR_Details OFF";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@OrderID", pd.OrderID);
                        command.Parameters.AddWithValue("@Quantity", pd.Quantity);
                        command.Parameters.AddWithValue("@Unit", pd.Unit);
                        command.Parameters.AddWithValue("@PartID", pd.PartID_PRD);
                        command.Parameters.AddWithValue("@Per", pd.Per);
                        if (String.IsNullOrEmpty(pd.DueDate))
                        {
                            command.Parameters.AddWithValue("@DueDate", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@DueDate", pd.DueDate);
                        }
                        command.Parameters.AddWithValue("@Received", pd.Received);

                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                            Console.WriteLine("Error inserting data into Database!");
                    }
                }
            }

            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void LoadVendorsFromExcel(object sender, EventArgs e)
        {
            string fname = "";
            OpenFileDialog fdlg = new OpenFileDialog
            {
                Title = "Excel File Dialog",
                InitialDirectory = @"c:\Documents\",
                Filter = "All files (*.*)|*.*|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                fname = fdlg.FileName;
            }

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fname);
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;
            this.Cursor = Cursors.WaitCursor;
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            for (int i = 1; i <= rowCount; i++)
            {
                Vendor v = new Vendor
                {
                    VendorID = Convert.ToInt16(xlWorksheet.Cells[i, 1].Value),
                    VendorNumber = Convert.ToString(xlWorksheet.Cells[i, 2].Value),
                    VendorName = Convert.ToString(xlWorksheet.Cells[i, 3].Value),
                    Contact = Convert.ToString(xlWorksheet.Cells[i, 4].Value),
                    VendorEmail = Convert.ToString(xlWorksheet.Cells[i, 5].Value),
                    VendorPhone = Convert.ToString(xlWorksheet.Cells[i, 6].Value),
                };
                vendorList.Add(v);

                listView1.View = View.Details;
                listView1.HeaderStyle = ColumnHeaderStyle.None;

                ColumnHeader header = new ColumnHeader();
                header.Text = "";
                header.Name = "VendorName";
                listView1.Columns.Add(header);

                listView1.Items.Add(v.VendorName);

            }

            //cleanup  
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //release com objects to fully kill excel process from running in the background  
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release  
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release  
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);

            saveVendors_button.Enabled = true;
            this.Cursor = Cursors.Default;
        }
        private void SaveVendorsToDB(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string removePR_FK = "ALTER TABLE PR DROP CONSTRAINT [FK_PR_Vendors]";
            string addPR_FK = "ALTER TABLE PR ADD CONSTRAINT [FK_PR_Vendors] FOREIGN KEY ([VendorID]) REFERENCES [dbo].[Vendors] ([VendorID])";
            string truncateVendors = "TRUNCATE TABLE Vendors";

            SqlConnection conn = new SqlConnection(conn_string);
            conn.Open();
            SqlCommand removepr_fk = new SqlCommand(removePR_FK, conn);
            removepr_fk.ExecuteNonQuery();
            SqlCommand truncatevendors = new SqlCommand(truncateVendors, conn);
            truncatevendors.ExecuteNonQuery();
            conn.Close();

            foreach (Vendor v in vendorList)
            {
                using (SqlConnection connection = new SqlConnection(conn_string))
                {
                    String query = "SET IDENTITY_INSERT Vendors ON; INSERT INTO Vendors (VendorID,VendorNumber,VendorName,Contact,Email,Phone) " +
                        "VALUES (@VendorID,@VendorNumber,@VendorName,@Contact,@Email,@Phone); SET IDENTITY_INSERT Machines OFF";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@VendorID", v.VendorID);
                        if (String.IsNullOrEmpty(v.VendorNumber))
                        {
                            command.Parameters.AddWithValue("@VendorNumber", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@VendorNumber", v.VendorNumber);
                        }
                        command.Parameters.AddWithValue("@VendorName", v.VendorName);
                        if (String.IsNullOrEmpty(v.Contact))
                        {
                            command.Parameters.AddWithValue("@Contact", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Contact", v.Contact);
                        }
                        if (String.IsNullOrEmpty(v.VendorEmail))
                        {
                            command.Parameters.AddWithValue("@Email", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Email", v.VendorEmail);
                        }
                        if (String.IsNullOrEmpty(v.VendorPhone))
                        {
                            command.Parameters.AddWithValue("@Phone", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Phone", v.VendorPhone);
                        }

                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                            Console.WriteLine("Error inserting data into Database!");
                    }
                }
            }

            conn.Open();
            SqlCommand addpr_fk = new SqlCommand(addPR_FK, conn);
            addpr_fk.ExecuteNonQuery();

            conn.Close();

            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void Reset(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(conn_string);
            conn.Open();

            //Department Contraint strings
            string query_add_PK_Department = "IF OBJECT_ID('dbo.[PK_Department]') IS NULL ALTER TABLE dbo.Employee ADD CONSTRAINT[PK_Department] PRIMARY KEY CLUSTERED([DepartmentID] ASC)";

            //Add Department Constraints
            SqlCommand add_PK_Department = new SqlCommand(query_add_PK_Department, conn);
            add_PK_Department.ExecuteNonQuery();
            
            //Employee Contraint strings
            string query_add_PK_Employee = "IF OBJECT_ID('dbo.[PK_Employee]') IS NULL ALTER TABLE dbo.Employee ADD CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([EmployeeID] ASC)";

            //Add Employee Constraints
            SqlCommand add_PK_Employee = new SqlCommand(query_add_PK_Employee, conn);
            add_PK_Employee.ExecuteNonQuery();

            //Machines Contraint strings
            string query_add_PK_Machines = "IF OBJECT_ID('dbo.[PK_Machines]') IS NULL ALTER TABLE dbo.Machines ADD CONSTRAINT [PK_Machines] PRIMARY KEY CLUSTERED ([MachineID] ASC)";

            //Add Machine Constraints
            SqlCommand add_PK_Machines = new SqlCommand(query_add_PK_Machines, conn);
            add_PK_Machines.ExecuteNonQuery();

            //Parts Contraint strings
            string query_add_PK_Part = "IF OBJECT_ID('dbo.[PK_Part]') IS NULL ALTER TABLE dbo.Parts ADD CONSTRAINT [PK_Part] PRIMARY KEY CLUSTERED ([PartID] ASC)";

            //Add PR Constraints
            SqlCommand add_PK_Part = new SqlCommand(query_add_PK_Part, conn);
            add_PK_Part.ExecuteNonQuery();

            //PR Contraint strings
            string query_add_PK_PR = "IF OBJECT_ID('dbo.[PK_PR]') IS NULL ALTER TABLE dbo.PR ADD CONSTRAINT[PK_PR] PRIMARY KEY CLUSTERED([OrderID] ASC)";
            string query_add_FK_PR_Employee = "IF OBJECT_ID('dbo.[FK_PR_Employee]') IS NULL ALTER TABLE dbo.PR ADD CONSTRAINT [FK_PR_Employee] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([EmployeeID])";
            string query_add_FK_PR_Machine = "IF OBJECT_ID('dbo.[FK_PR_Machine]') IS NULL ALTER TABLE dbo.PR ADD CONSTRAINT [FK_PR_Machine] FOREIGN KEY ([MachineID]) REFERENCES [dbo].[Machines] ([MachineID])";
            string query_add_FK_PR_Department = "IF OBJECT_ID('dbo.[FK_PR_Department]') IS NULL ALTER TABLE dbo.PR ADD CONSTRAINT [FK_PR_Department] FOREIGN KEY ([DepartmentID]) REFERENCES [dbo].[Department] ([DepartmentID])";
            string query_add_FK_PR_Vendor = "IF OBJECT_ID('dbo.[FK_PR_Vendor]') IS NULL ALTER TABLE dbo.PR ADD CONSTRAINT [FK_PR_Vendor] FOREIGN KEY ([VendorID]) REFERENCES [dbo].[Vendors] ([VendorID])";

            //Add PR Constraints
            SqlCommand add_PK_PR = new SqlCommand(query_add_PK_PR, conn);
            add_PK_PR.ExecuteNonQuery();
            SqlCommand add_FK_PR_Employee = new SqlCommand(query_add_FK_PR_Employee, conn);
            add_FK_PR_Employee.ExecuteNonQuery();
            SqlCommand add_FK_PR_Machine = new SqlCommand(query_add_FK_PR_Machine, conn);
            add_FK_PR_Machine.ExecuteNonQuery();
            SqlCommand add_FK_PR_Department = new SqlCommand(query_add_FK_PR_Department, conn);
            add_FK_PR_Department.ExecuteNonQuery();
            SqlCommand add_FK_PR_Vendor = new SqlCommand(query_add_FK_PR_Vendor, conn);
            add_FK_PR_Vendor.ExecuteNonQuery();

            //PR_Details Contraint strings
            string query_add_PK_PRDetails = "IF OBJECT_ID('dbo.[PK_PRDetails]') IS NULL ALTER TABLE dbo.PR_Details ADD CONSTRAINT [PK_PRDetails] PRIMARY KEY CLUSTERED ([OrderID] ASC)";
            string query_add_FK_PR_Details_Parts = "IF OBJECT_ID('dbo.[FK_PR_Details_Parts]') IS NULL ALTER TABLE dbo.PR_Details ADD CONSTRAINT [FK_PR_Details_Parts] FOREIGN KEY ([PartID]) REFERENCES [dbo].[Parts] ([PartID])";
            string query_add_FK_Table_PR = "IF OBJECT_ID('dbo.[FK_Table_PR]') IS NULL ALTER TABLE dbo.PR_Details ADD CONSTRAINT [FK_Table_PR] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[PR] ([OrderID])";

            //Add PR_Details Constraints
            SqlCommand add_PK_PRDetails = new SqlCommand(query_add_PK_PRDetails, conn);
            add_PK_PRDetails.ExecuteNonQuery();
            SqlCommand add_FK_PR_Details_Parts = new SqlCommand(query_add_FK_PR_Details_Parts, conn);
            add_FK_PR_Details_Parts.ExecuteNonQuery();
            SqlCommand add_FK_Table_PR = new SqlCommand(query_add_FK_Table_PR, conn);
            add_FK_Table_PR.ExecuteNonQuery();

            //Vendor Contraint strings
            string query_add_PK_Vendors = "IF OBJECT_ID('dbo.[PK_Vendors]') IS NULL ALTER TABLE dbo.Vendors ADD CONSTRAINT [PK_Vendors] PRIMARY KEY CLUSTERED ([VendorID] ASC)";

            //Add Vendor Constraints
            SqlCommand add_PK_Vendors = new SqlCommand(query_add_PK_Vendors, conn);
            add_PK_PR.ExecuteNonQuery();

            conn.Close();
        }
    }
    
}
