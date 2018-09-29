using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
        List<Department> departmentList = new List<Department>();
        List<Machine> machineList = new List<Machine>(); 
        List<Part> partList = new List<Part>();
        List<Vendor> vendorList = new List<Vendor>();
        List<Employee> employeeList = new List<Employee>();
        List<PR> prList = new List<PR>();
        List<PR_Details> pr_detailsList = new List<PR_Details>();
        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public string fname = ""; 
        public string q;
        public string conn_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\MEL\MEL.mdf;Integrated Security=True";
        SqlConnection conn = null;

        public Import(MainScreen ms)
        {
            InitializeComponent();
        }
        public void ImportScreen_Load(object sender, EventArgs e)
        {
            
        }
        private void LoadDepartmentFromExcel()
        {
            removeConstraint_button.PerformClick();
            //MessageBox.Show("Please select the file that contains the Departments you want to import");
            //string fname = "";
           // OpenFileDialog fdlg = new OpenFileDialog
            //{
            //    Title = "Excel File Dialog",
            //    InitialDirectory = @"c:\Documents\",
            //    Filter = "All files (*.*)|*.*|All files (*.*)|*.*",
            //    FilterIndex = 2,
            //    RestoreDirectory = true
           // };
            //if (fdlg.ShowDialog() == DialogResult.OK)
            //{
            //    fname = fdlg.FileName;
            //}
            this.Cursor = Cursors.WaitCursor;
            fname = @"C:\MEL\Department.xlsx";
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fname);
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;
            
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            for (int i = 2; i <= rowCount; i++)
            {
                Department dep = new Department
                {
                    DepartmentID = Convert.ToInt16(xlWorksheet.Cells[i, 1].Value),
                    DepartmentName = Convert.ToString(xlWorksheet.Cells[i, 2].Value),
                };
                departmentList.Add(dep);

                //listView1.View = View.Details;
                //listView1.HeaderStyle = ColumnHeaderStyle.None;

                //ColumnHeader header = new ColumnHeader();
                //header.Text = "";
                //header.Name = "Department";
                //listView1.Columns.Add(header);

                //listView1.Items.Add(dep.DepartmentName);
                //listView1.EnsureVisible(listView1.Items.Count - 1);
                label1.Text = "Loading: " + dep.DepartmentID + " " + dep.DepartmentName;
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

            //saveDepartment_button.Enabled = true;
            SaveDepartmentToDB();
            //this.Cursor = Cursors.Default;
        }
        private void SaveDepartmentToDB()
        {
            this.Cursor = Cursors.WaitCursor;
            string truncateDepartment = "TRUNCATE TABLE Department";

            SqlConnection conn = new SqlConnection(conn_string);
            conn.Open();

            SqlCommand truncatedepartment = new SqlCommand(truncateDepartment, conn);
            truncatedepartment.ExecuteNonQuery();
            conn.Close();

            foreach (Department dep in departmentList)
            {
                using (SqlConnection connection = new SqlConnection(conn_string))
                {
                    String query = "SET IDENTITY_INSERT Department ON; INSERT INTO Department (DepartmentID,DepartmentName) " +
                        "VALUES (@DepartmentID,@DepartmentName); SET IDENTITY_INSERT Department OFF";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        label1.Text = "Writing: " + dep.DepartmentID + " " + dep.DepartmentName;
                        command.Parameters.AddWithValue("@DepartmentID", dep.DepartmentID);
                        command.Parameters.AddWithValue("@DepartmentName", dep.DepartmentName);

                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                            Console.WriteLine("Error inserting data into Database!");
                    }
                }
            }
            this.Cursor = Cursors.Default;
            LoadMachinesFromExcel();
            
        }

        private void LoadEmployeeFromExcel()
        {
            //MessageBox.Show("Please select the file that contains the Employees you want to import");
            fname = @"C:\MEL\OrderedBy.xlsx";
            //OpenFileDialog fdlg = new OpenFileDialog
            //{
            //    Title = "Excel File Dialog",
            //    InitialDirectory = @"c:\Documents\",
            //    Filter = "All files (*.*)|*.*|All files (*.*)|*.*",
            //    FilterIndex = 2,
            //    RestoreDirectory = true
            //};
            //if (fdlg.ShowDialog() == DialogResult.OK)
            //{
            //    fname = fdlg.FileName;
            //}

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fname);
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;
            this.Cursor = Cursors.WaitCursor;
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            for (int i = 2; i <= rowCount; i++)
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

                label1.Text = "Loading: " + emp.EmployeeID + " " + emp.Tech + " "
                    + emp.Craft + " " + emp.EmployeePhone + " " + emp.EmployeeEmail;
                //listView1.View = View.Details;
                //listView1.HeaderStyle = ColumnHeaderStyle.None;

                //ColumnHeader header = new ColumnHeader();
                //header.Text = "";
                //header.Name = "Tech";
                //listView1.Columns.Add(header);

                //listView1.Items.Add(emp.Tech);
                //listView1.EnsureVisible(listView1.Items.Count - 1);
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

            SaveEmployeeToDB();
            //this.Cursor = Cursors.Default;
        }
        private void SaveEmployeeToDB()
        {
            this.Cursor = Cursors.WaitCursor;
            string truncateEmployee = "TRUNCATE TABLE Employee";

            SqlConnection conn = new SqlConnection(conn_string);
            conn.Open();

            SqlCommand truncateemployee = new SqlCommand(truncateEmployee, conn);
            truncateemployee.ExecuteNonQuery();
            conn.Close();

            foreach (Employee emp in employeeList)
            {
                using (SqlConnection connection = new SqlConnection(conn_string))
                {
                    String query = "SET IDENTITY_INSERT Employee ON; INSERT INTO Employee (EmployeeID,Tech,Craft,EmployeePhone,EmployeeEmail) " +
                        "VALUES (@EmployeeID,@EmployeeName,@Craft,@Phone,@Email); SET IDENTITY_INSERT Employee OFF";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        label1.Text = "Writing: " + emp.EmployeeID + " " + emp.Tech + " "
                            + emp.Craft + " " + emp.EmployeePhone + " " + emp.EmployeeEmail;
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

            this.Cursor = Cursors.Default;
            LoadPRFromExcel();
        }

        private void LoadMachinesFromExcel()
        {
            //MessageBox.Show("Please select the file that contains the Machines you want to import");
            fname = @"C:\MEL\Machines.xlsx";
            //OpenFileDialog fdlg = new OpenFileDialog
            //{
            //    Title = "Excel File Dialog",
            //    InitialDirectory = @"c:\Documents\",
            //    Filter = "All files (*.*)|*.*|All files (*.*)|*.*",
            //    FilterIndex = 2,
            //    RestoreDirectory = true
            //};
            //if (fdlg.ShowDialog() == DialogResult.OK)
            //{
            //    fname = fdlg.FileName;
            //}

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fname);
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;
            this.Cursor = Cursors.WaitCursor;
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            for (int i = 2; i <= rowCount; i++)
            {
                Machine m = new Machine
                {
                    MachineID = Convert.ToInt16(xlWorksheet.Cells[i, 1].Value),
                    BTNumber = Convert.ToString(xlWorksheet.Cells[i, 2].Value),
                    CommonName = Convert.ToString(xlWorksheet.Cells[i, 3].Value),
                    Make = Convert.ToString(xlWorksheet.Cells[i, 4].Value),
                    Model = Convert.ToString(xlWorksheet.Cells[i, 5].Value),
                    Serial = Convert.ToString(xlWorksheet.Cells[i, 6].Value),
                    DepartmentID_Machine = Convert.ToInt16(xlWorksheet.Cells[i, 11].Value),
                };
                machineList.Add(m);
                label1.Text = "Loading: " + m.MachineID + " " + m.BTNumber + " "
                    + m.CommonName + " " + m.Make + " " + m.Model + " " + m.Serial + " " + m.DepartmentID_Machine;

                //listView1.View = View.Details;
                //listView1.HeaderStyle = ColumnHeaderStyle.None;

                //ColumnHeader header = new ColumnHeader();
                //header.Text = "";
                //header.Name = "BTNumber";
                //listView1.Columns.Add(header);

                //listView1.Items.Add(m.BTNumber);
                //listView1.EnsureVisible(listView1.Items.Count - 1);
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

            SaveMachinesToDB();
            //this.Cursor = Cursors.Default;
        }
        private void SaveMachinesToDB()
        {
            this.Cursor = Cursors.WaitCursor;
            string truncateMachines = "TRUNCATE TABLE Machines";

            SqlConnection conn = new SqlConnection(conn_string);
            conn.Open();

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
                        label1.Text = "Writing: " + m.MachineID + " " + m.BTNumber + " "
                            + m.CommonName + " " + m.Make + " " + m.Model + " " + m.Serial + " " + m.DepartmentID_Machine;
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

            this.Cursor = Cursors.Default;
            LoadPartsFromExcel();
        }

        private void LoadPartsFromExcel()
        {
            //MessageBox.Show("Please select the file that contains the Parts you want to import");
            fname = @"C:\MEL\Parts.xlsx";
            //OpenFileDialog fdlg = new OpenFileDialog
            //{
            //    Title = "Excel File Dialog",
            //    InitialDirectory = @"c:\Documents\",
            //    Filter = "All files (*.*)|*.*|All files (*.*)|*.*",
            //    FilterIndex = 2,
            //    RestoreDirectory = true
            //};
            //if (fdlg.ShowDialog() == DialogResult.OK)
            //{
            //    fname = fdlg.FileName;
            //}

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fname);
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;
            this.Cursor = Cursors.WaitCursor;
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            for (int i = 2; i <= rowCount; i++)
            {
                Part p = new Part
                {
                    PartID = Convert.ToInt16(xlWorksheet.Cells[i, 1].Value),
                    PartNumber = Convert.ToString(xlWorksheet.Cells[i, 2].Value),
                    PartDescription = Convert.ToString(xlWorksheet.Cells[i, 3].Value),
                    UnitPrice = Convert.ToDecimal(xlWorksheet.Cells[i, 4].Value),

                };
                partList.Add(p);

                label1.Text = "Loading: " + p.PartID + " " + p.PartNumber + " "
                    + p.PartDescription + " " + p.UnitPrice;

                //listView1.View = View.Details;
                //listView1.HeaderStyle = ColumnHeaderStyle.None;

                //ColumnHeader header = new ColumnHeader();
                //header.Text = "";
                //header.Name = "PartNumber";
                //listView1.Columns.Add(header);

                //listView1.Items.Add(p.PartNumber);
                //listView1.EnsureVisible(listView1.Items.Count - 1);
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

            SavePartsToDB();
            //this.Cursor = Cursors.Default;
        }
        private void SavePartsToDB()
        {
            this.Cursor = Cursors.WaitCursor;
            string truncateParts = "TRUNCATE TABLE Parts";

            SqlConnection conn = new SqlConnection(conn_string);
            conn.Open();

            SqlCommand truncateparts = new SqlCommand(truncateParts, conn);
            truncateparts.ExecuteNonQuery();
            conn.Close();

            foreach (Part p in partList)
            {
                using (SqlConnection connection = new SqlConnection(conn_string))
                {
                    String query = "SET IDENTITY_INSERT Parts ON; INSERT INTO Parts (PartID,PartNumber,PartDescription,UnitPrice) " +
                        "VALUES (@PartID,@PartNumber,@PartDescription,@UnitPrice); SET IDENTITY_INSERT Parts OFF";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        label1.Text = "Writing: " + p.PartID + " " + p.PartNumber + " "
                            + p.PartDescription + " " + p.UnitPrice;

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
            this.Cursor = Cursors.Default;
            LoadVendorsFromExcel();
        }

        private void LoadPRFromExcel()
        {
            //MessageBox.Show("Please select the file that contains the Purchase Requisitions you want to import");
            fname = @"C:\MEL\Purchase_Requisition.xlsx";
            //OpenFileDialog fdlg = new OpenFileDialog
            //{
            //    Title = "Excel File Dialog",
            //    InitialDirectory = @"c:\Documents\",
            //    Filter = "All files (*.*)|*.*|All files (*.*)|*.*",
            //    FilterIndex = 2,
            //    RestoreDirectory = true
            //};
            //if (fdlg.ShowDialog() == DialogResult.OK)
            //{
            //    fname = fdlg.FileName;
            //}

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fname);
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;
            this.Cursor = Cursors.WaitCursor;
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            for (int i = 2; i <= rowCount; i++)
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

                label1.Text = "Loading: " + pr.OrderID + " " + pr.VendorID_PR + " " + pr.DateIssued + " "
                    + pr.DepartmentID_PR + " " + pr.MachineID_PR + " " + pr.EmployeeID_PR + " " + pr.DeliverTo + " "
                    + pr.PONumber;

                //listView1.View = View.Details;
                //listView1.HeaderStyle = ColumnHeaderStyle.None;

                //ColumnHeader header = new ColumnHeader();
                //header.Text = "";
                //header.Name = "PR";
                //listView1.Columns.Add(header);

                //listView1.Items.Add(pr.PONumber);
                //listView1.EnsureVisible(listView1.Items.Count - 1);
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

            SavePRToDB();
            //DateHelp();
            //this.Cursor = Cursors.Default;
        }
        private void SavePRToDB()
        {
            this.Cursor = Cursors.WaitCursor;
            string truncatePR = "TRUNCATE TABLE PR";

            SqlConnection conn = new SqlConnection(conn_string);
            conn.Open();

            SqlCommand truncatepr = new SqlCommand(truncatePR, conn);
            truncatepr.ExecuteNonQuery();

            conn.Close();

            foreach (PR pr in prList)
            {
                using (SqlConnection connection = new SqlConnection(conn_string))
                {
                    String query = "SET IDENTITY_INSERT PR ON; INSERT INTO PR (OrderID,VendorID,DateIssued,DepartmentID,MachineID,EmployeeID,DeliverTo,PONumber) " +
                        "VALUES (@OrderID,@VendorID,@DateIsssued,@DepartmentID,@MachineID,@EmployeeID,@DeliverTo,@PONumber); SET IDENTITY_INSERT PR OFF";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        label1.Text = "Writing: " + pr.OrderID + " " + pr.VendorID_PR + " " + pr.DateIssued + " "
                        + pr.DepartmentID_PR + " " + pr.MachineID_PR + " " + pr.EmployeeID_PR + " " + pr.DeliverTo + " "
                        + pr.PONumber;

                        command.Parameters.AddWithValue("@OrderID", pr.OrderID); 
                        command.Parameters.AddWithValue("@VendorID", pr.VendorID_PR);
                        if (String.IsNullOrEmpty(pr.DateIssued))
                        {
                            command.Parameters.AddWithValue("@DateIsssued", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@DateIsssued", pr.DateIssued); 
                        }
                        command.Parameters.AddWithValue("@DepartmentID", pr.DepartmentID_PR);
                        if (pr.MachineID_PR == 0 )
                        {
                            command.Parameters.AddWithValue("@MachineID", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@MachineID", pr.MachineID_PR);
                        }                       
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

            this.Cursor = Cursors.Default;
            LoadPR_DetaisFromExcel();
        }

        private void LoadPR_DetaisFromExcel()
        {
            //MessageBox.Show("Please select the file that contains the Order Details you want to import");
            fname = @"C:\MEL\OrderDetails.xlsx";
            //OpenFileDialog fdlg = new OpenFileDialog
            //{
            //    Title = "Excel File Dialog",
            //    InitialDirectory = @"c:\Documents\",
            //    Filter = "All files (*.*)|*.*|All files (*.*)|*.*",
            //    FilterIndex = 2,
            //    RestoreDirectory = true
            //};
            //if (fdlg.ShowDialog() == DialogResult.OK)
            //{
            //    fname = fdlg.FileName;
            //}

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fname);
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;
            this.Cursor = Cursors.WaitCursor;
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            for (int i = 2; i <= rowCount; i++)
            {
                PR_Details pd = new PR_Details
                {
                    OrderDetailsID = Convert.ToInt16(xlWorksheet.Cells[i, 1].Value)
                    //OrderID = Convert.ToInt16(xlWorksheet.Cells[i, 2].Value),
                    //Quantity = Convert.ToInt16(xlWorksheet.Cells[i, 3].Value),
                    //Unit = Convert.ToString(xlWorksheet.Cells[i, 4].Value),
                    //PartID_PRD = Convert.ToInt16(xlWorksheet.Cells[i, 5].Value),
                    //Per = Convert.ToString(xlWorksheet.Cells[i, 6].Value),
                    //DueDate = Convert.ToString(xlWorksheet.Cells[i, 7].Value),
                    //Received = Convert.ToBoolean(xlWorksheet.Cells[i, 8].Value),
                };
                pr_detailsList.Add(pd);

                label1.Text = "Loading: " + pd.OrderDetailsID + " " + pd.OrderID + " " + pd.Quantity + " "
                    + pd.Unit + " " + pd.PartID_PRD + " " + pd.Per + " " + pd.DueDate + " "
                    + pd.Received;

                //listView1.View = View.Details;
                //listView1.HeaderStyle = ColumnHeaderStyle.None;

                //ColumnHeader header = new ColumnHeader();
                //header.Text = "";
                //header.Name = "PD";
                //listView1.Columns.Add(header);

                //listView1.Items.Add(pd.OrderID.ToString());
                //listView1.EnsureVisible(listView1.Items.Count - 1);

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

            SavePR_DetaisToDB();
            //this.Cursor = Cursors.Default;
        }
        private void SavePR_DetaisToDB()
        {
            this.Cursor = Cursors.WaitCursor;

            SqlConnection conn = new SqlConnection(conn_string);
            conn.Open();

            string truncatePRDetails = "TRUNCATE TABLE PR_Details";

            SqlCommand truncateprdetails = new SqlCommand(truncatePRDetails, conn);
            truncateprdetails.ExecuteNonQuery();

            conn.Close();

            foreach (PR_Details pd in pr_detailsList)
            {
                using (SqlConnection connection = new SqlConnection(conn_string))
                {
                    String query = "INSERT INTO PR_Details (OrderID,Quantity,Unit,PartID,Per,DueDate,Received) " +
                        "VALUES (@OrderID,@Quantity,@Unit,@PartID,@Per,@DueDate,@Received)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        label1.Text = "Writing: " + pd.OrderDetailsID + " " + pd.OrderID + " " + pd.Quantity + " "
                        + pd.Unit + " " + pd.PartID_PRD + " " + pd.Per + " " + pd.DueDate + " "
                        + pd.Received;
                        //command.Parameters.AddWithValue("@OrderDetailsID", pd.OrderDetailsID);
                        command.Parameters.AddWithValue("@OrderID", pd.OrderID);
                        command.Parameters.AddWithValue("@Quantity", pd.Quantity);
                        if (String.IsNullOrEmpty(pd.Unit))
                        {
                            command.Parameters.AddWithValue("@Unit", "PC");
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Unit", pd.Unit);
                        }
                        command.Parameters.AddWithValue("@PartID", pd.PartID_PRD);
                        if (String.IsNullOrEmpty(pd.Per))
                        {
                            command.Parameters.AddWithValue("@Per", "ea");
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Per", pd.Per);
                        }
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
            addContraint_button.PerformClick();
            this.Close();
        }

        private void LoadVendorsFromExcel()
        {
            //MessageBox.Show("Please select the file that contains the Vendors you want to import");
            fname = @"C:\MEL\Vendors.xlsx";
            //OpenFileDialog fdlg = new OpenFileDialog
            //{
            //    Title = "Excel File Dialog",
            //    InitialDirectory = @"c:\Documents\",
            //    Filter = "All files (*.*)|*.*|All files (*.*)|*.*",
            //    FilterIndex = 2,
            //    RestoreDirectory = true
            //};
            //if (fdlg.ShowDialog() == DialogResult.OK)
            //{
            //    fname = fdlg.FileName;
            //}

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fname);
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;
            this.Cursor = Cursors.WaitCursor;
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            for (int i = 2; i <= rowCount; i++)
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

                label1.Text = "Loading: " + v.VendorID + " " + v.VendorNumber + " " + v.VendorName + " "
                    + v.Contact + " " + v.VendorEmail + " " + v.VendorPhone;

                //listView1.View = View.Details;
                //listView1.HeaderStyle = ColumnHeaderStyle.None;

                //ColumnHeader header = new ColumnHeader();
                //header.Text = "";
                //header.Name = "VendorName";
                //listView1.Columns.Add(header);

                //listView1.Items.Add(v.VendorName);
                //listView1.EnsureVisible(listView1.Items.Count - 1);
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

            SaveVendorsToDB();
            //this.Cursor = Cursors.Default;
        }
        private void SaveVendorsToDB()
        {
            this.Cursor = Cursors.WaitCursor;
            string truncateVendors = "TRUNCATE TABLE Vendors";

            SqlConnection conn = new SqlConnection(conn_string);
            conn.Open();

            SqlCommand truncatevendors = new SqlCommand(truncateVendors, conn);
            truncatevendors.ExecuteNonQuery();
            conn.Close();

            foreach (Vendor v in vendorList)
            {
                using (SqlConnection connection = new SqlConnection(conn_string))
                {
                    String query = "SET IDENTITY_INSERT Vendors ON; INSERT INTO Vendors (VendorID,VendorNumber,VendorName,Contact,VendorEmail,VendorPhone) " +
                        "VALUES (@VendorID,@VendorNumber,@VendorName,@Contact,@Email,@Phone); SET IDENTITY_INSERT Vendors OFF";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        label1.Text = "Loading: " + v.VendorID + " " + v.VendorNumber + " " + v.VendorName + " "
                            + v.Contact + " " + v.VendorEmail + " " + v.VendorPhone;

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

            this.Cursor = Cursors.Default;
            LoadEmployeeFromExcel();
        }

        private void Reset(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(conn_string);
            conn.Open();

            //Vendor Contraint strings
            string query_add_PK_Vendors = "IF OBJECT_ID('dbo.[PK_Vendors]') IS NULL ALTER TABLE dbo.Vendors ADD CONSTRAINT [PK_Vendors] PRIMARY KEY CLUSTERED ([VendorID] ASC)";

            //Add Vendor Constraints
            SqlCommand add_PK_Vendors = new SqlCommand(query_add_PK_Vendors, conn);
            add_PK_Vendors.ExecuteNonQuery();

            //Department Contraint strings
            string query_add_PK_Department = "IF OBJECT_ID('dbo.[PK_Department]') IS NULL ALTER TABLE dbo.Department ADD CONSTRAINT[PK_Department] PRIMARY KEY CLUSTERED([DepartmentID] ASC)";

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
            string query_add_FK_PR_Machine = "IF OBJECT_ID('dbo.[FK_PR_Machines]') IS NULL ALTER TABLE dbo.PR ADD CONSTRAINT [FK_PR_Machines] FOREIGN KEY ([MachineID]) REFERENCES [dbo].[Machines] ([MachineID])";
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
            string query_add_PK_PRDetails = "IF OBJECT_ID('dbo.[PK_PR_Details]') IS NULL ALTER TABLE dbo.PR_Details ADD CONSTRAINT [PK_PR_Details] PRIMARY KEY CLUSTERED ([OrderDetailsID] ASC)";
            string query_add_FK_PR_Details_Parts = "IF OBJECT_ID('dbo.[FK_PR_Details_Parts]') IS NULL ALTER TABLE dbo.PR_Details ADD CONSTRAINT [FK_PR_Details_Parts] FOREIGN KEY ([PartID]) REFERENCES [dbo].[Parts] ([PartID])";
            string query_add_FK_Table_PR = "IF OBJECT_ID('dbo.[FK_Table_PR]') IS NULL ALTER TABLE dbo.PR_Details ADD CONSTRAINT [FK_Table_PR] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[PR] ([OrderID])";

            //Add PR_Details Constraints
            SqlCommand add_PK_PRDetails = new SqlCommand(query_add_PK_PRDetails, conn);
            add_PK_PRDetails.ExecuteNonQuery();
            SqlCommand add_FK_PR_Details_Parts = new SqlCommand(query_add_FK_PR_Details_Parts, conn);
            add_FK_PR_Details_Parts.ExecuteNonQuery();
            SqlCommand add_FK_Table_PR = new SqlCommand(query_add_FK_Table_PR, conn);
            add_FK_Table_PR.ExecuteNonQuery();
 
            conn.Close();
        }
        private void RemoveContraints(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(conn_string);
            conn.Open();

            //PR_Details Contraint strings
            string query_remove_PK_PRDetails = "IF OBJECT_ID('dbo.[PK_PRDetails]') IS NOT NULL ALTER TABLE dbo.PR_Details DROP CONSTRAINT [PK_PRDetails]";
            string query_remove_FK_PR_Details_Parts = "IF OBJECT_ID('dbo.[FK_PR_Details_Parts]') IS NOT NULL ALTER TABLE dbo.PR_Details DROP CONSTRAINT [FK_PR_Details_Parts]";
            string query_remove_FK_Table_PR = "IF OBJECT_ID('dbo.[FK_Table_PR]') IS NOT NULL ALTER TABLE dbo.PR_Details DROP CONSTRAINT [FK_Table_PR]";

            //Remove PR_Details Constraints
            SqlCommand remove_PK_PRDetails = new SqlCommand(query_remove_PK_PRDetails, conn);
            remove_PK_PRDetails.ExecuteNonQuery();
            SqlCommand remove_FK_PR_Details_Parts = new SqlCommand(query_remove_FK_PR_Details_Parts, conn);
            remove_FK_PR_Details_Parts.ExecuteNonQuery();
            SqlCommand remove_FK_Table_PR = new SqlCommand(query_remove_FK_Table_PR, conn);
            remove_FK_Table_PR.ExecuteNonQuery();

            //PR Contraint strings
            string query_remove_PK_PR = "IF OBJECT_ID('dbo.[PK_PR]') IS NOT NULL ALTER TABLE dbo.PR DROP CONSTRAINT[PK_PR]";
            string query_remove_FK_PR_Employee = "IF OBJECT_ID('dbo.[FK_PR_Employee]') IS NOT NULL ALTER TABLE dbo.PR DROP CONSTRAINT [FK_PR_Employee]";
            string query_remove_FK_PR_Machine = "IF OBJECT_ID('dbo.[FK_PR_Machines]') IS NOT NULL ALTER TABLE dbo.PR DROP CONSTRAINT [FK_PR_Machines]";
            string query_remove_FK_PR_Department = "IF OBJECT_ID('dbo.[FK_PR_Department]') IS NOT NULL ALTER TABLE dbo.PR DROP CONSTRAINT [FK_PR_Department]";
            string query_remove_FK_PR_Vendor = "IF OBJECT_ID('dbo.[FK_PR_Vendor]') IS NOT NULL ALTER TABLE dbo.PR DROP CONSTRAINT [FK_PR_Vendor]";

            //Remove PR Constraints          
            SqlCommand remove_PK_PR = new SqlCommand(query_remove_PK_PR, conn);
            remove_PK_PR.ExecuteNonQuery();
            SqlCommand remove_FK_PR_Employee = new SqlCommand(query_remove_FK_PR_Employee, conn);
            remove_FK_PR_Employee.ExecuteNonQuery();
            SqlCommand remove_FK_PR_Machine = new SqlCommand(query_remove_FK_PR_Machine, conn);
            remove_FK_PR_Machine.ExecuteNonQuery();
            SqlCommand remove_FK_PR_Department = new SqlCommand(query_remove_FK_PR_Department, conn);
            remove_FK_PR_Department.ExecuteNonQuery();
            SqlCommand remove_FK_PR_Vendor = new SqlCommand(query_remove_FK_PR_Vendor, conn);
            remove_FK_PR_Vendor.ExecuteNonQuery();

            //Department Contraint Strings
            string query_remove_PK_Department = "IF OBJECT_ID('dbo.[PK_Department]') IS NOT NULL ALTER TABLE dbo.Department DROP CONSTRAINT [PK_Department]";

            //Remove Department Contraints
            SqlCommand remove_PK_Department = new SqlCommand(query_remove_PK_Department, conn);
            remove_PK_Department.ExecuteNonQuery();

            //Employee Contraint strings
            string query_remove_PK_Employee = "IF OBJECT_ID('dbo.[PK_Employee]') IS NOT NULL ALTER TABLE dbo.Employee DROP CONSTRAINT [PK_Employee]";

            //Remove Employee Constraints
            SqlCommand remove_PK_Employee = new SqlCommand(query_remove_PK_Employee, conn);
            remove_PK_Employee.ExecuteNonQuery();

            //Machines Contraint strings
            string query_remove_PK_Machines = "IF OBJECT_ID('dbo.[PK_Machines]') IS NOT NULL ALTER TABLE dbo.Machines DROP CONSTRAINT [PK_Machines]";

            //Remove Machine Constraints
            SqlCommand remove_PK_Machines = new SqlCommand(query_remove_PK_Machines, conn);
            remove_PK_Machines.ExecuteNonQuery();

            //Parts Contraint strings
            string query_remove_PK_Part = "IF OBJECT_ID('dbo.[PK_Part]') IS NOT NULL ALTER TABLE dbo.Parts DROP CONSTRAINT [PK_Part]";

            //Remove Parts Constraints
            SqlCommand remove_PK_Part = new SqlCommand(query_remove_PK_Part, conn);
            remove_PK_Part.ExecuteNonQuery();

            //Vendor Contraint strings
            string query_remove_PK_Vendors = "IF OBJECT_ID('dbo.[PK_Vendors]') IS NOT NULL ALTER TABLE dbo.Vendors DROP CONSTRAINT [PK_Vendors]";

            //Remove Vendor Constraints
            SqlCommand remove_PK_Vendors = new SqlCommand(query_remove_PK_Vendors, conn);
            remove_PK_Vendors.ExecuteNonQuery();

            conn.Close();
        }

        private void import_button_Click(object sender, EventArgs e)
        {
            LoadDepartmentFromExcel();
            //LoadPRFromExcel();
        }

        private void DateHelp()
        {
            foreach (PR pr in prList)
            {
                Debug.WriteLine(pr.DateIssued);
            }
        }
    }
    
}
