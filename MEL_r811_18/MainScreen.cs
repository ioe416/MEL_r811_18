using System;
//using System.Collections.Generic;
//using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
//using System.Runtime.InteropServices;
using System.Text;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
//using Microsoft.Office.Interop.Excel;

namespace MEL_r811_18
{
    public partial class MainScreen : Form
    {
        public string q;
        public string conn_string = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Joe\source\repos\MEL_r811_18\MEL_r811_18\MEL.mdf; Integrated Security = True";
        public string open_po_count;
        SqlConnection conn = null;
        public string today = DateTime.Today.ToString();

        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public string machineID;
        public string bTNumber;
        public string commonName;
        public string make;
        public string model;
        public string serial;
        public string departmentID_Machine;
        public int partID;
        public string partNumber;
        public string partDescription;
        public decimal unitPrice;
        public string partImage;
        public int vendorID;
        public string vendorNumber;
        public string vendorName;
        public string contact;
        public string vendorEmail;
        public string vendorPhone;
        public int employeeID;
        public string tech;
        public string craft;
        public string employeePhone;
        public string employeeEmail;
        public int orderID;
        public int vendorID_PR;
        public string dateIssued;
        public int departmentID_PR;
        public int machineID_PR;
        public int employeeID_PR;
        public string deliverTo;
        public string pONumber;
        public int quantity;
        public string unit;
        public int partID_PRD;
        public string per;
        public string dueDate;
        public bool received;



        public MainScreen()
        {
            InitializeComponent();
        }

        private void NewMachineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MachineSetup mss = new MachineSetup(this);
            mss.FormClosed += new FormClosedEventHandler(MachineSetup_FormClosed);
            mss.Show();
        }
        private void MachineSetup_FormClosed(object sender, EventArgs e)
        {
            this.Show();
        }
        private void ImportMachine_FormClosed(object sender, EventArgs e)
        {
            this.Show();
        }
        private void MainScreen_load(object sender, EventArgs e)
        {
            if (!Directory.Exists(path + "\\MEL"))
                Directory.CreateDirectory(path + "\\MEL");

            if (!File.Exists(path + "\\MEL\\machine.xml"))
            {
                XmlTextWriter xw = new XmlTextWriter(path + "\\MEL\\machine.xml", Encoding.UTF8);
                xw.WriteStartElement("Machines");
                xw.WriteEndElement();
                xw.Close();
            }
            if (!File.Exists(path + "\\MEL\\vendor.xml"))
            {
                XmlTextWriter xw = new XmlTextWriter(path + "\\MEL\\vendor.xml", Encoding.UTF8);
                xw.WriteStartElement("Vendors");
                xw.WriteEndElement();
                xw.Close();
            }
            if (!File.Exists(path + "\\MEL\\part.xml"))
            {
                XmlTextWriter xw = new XmlTextWriter(path + "\\MEL\\part.xml", Encoding.UTF8);
                xw.WriteStartElement("Parts");
                xw.WriteEndElement();
                xw.Close();
            }
            if (!File.Exists(path + "\\MEL\\employee.xml"))
            {
                XmlTextWriter xw = new XmlTextWriter(path + "\\MEL\\employee.xml", Encoding.UTF8);
                xw.WriteStartElement("Employees");
                xw.WriteEndElement();
                xw.Close();
            }
            if (!File.Exists(path + "\\MEL\\pr.xml"))
            {
                XmlTextWriter xw = new XmlTextWriter(path + "\\MEL\\pr.xml", Encoding.UTF8);
                xw.WriteStartElement("PurchaseRequisitions");
                xw.WriteEndElement();
                xw.Close();
            }
            if (!File.Exists(path + "\\MEL\\pr_details.xml"))
            {
                XmlTextWriter xw = new XmlTextWriter(path + "\\MEL\\pr_details.xml", Encoding.UTF8);
                xw.WriteStartElement("OrderDetails");
                xw.WriteEndElement();
                xw.Close();
            }

            OpenPO_Fill();
            OverduePO_Fill();
            OpenPR_Fill();
        }
        private void OpenPO_Fill()
        {
            try
            {
                conn = new SqlConnection(conn_string);
                conn.Open();

                q = "SELECT PR_Details.Quantity, PR_Details.Unit, Parts.PartNumber, Parts.PartDescription, PR_Details.Per, PR_Details.DueDate, PR_Details.Received " +
                    "FROM(Parts INNER JOIN PR_Details ON Parts.PartID = PR_Details.PartID)" +
                    "WHERE PR_Details.Received = 0";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(q, conn);

                SqlCommandBuilder scb = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                openPO_dataGridView.ReadOnly = true;
                openPO_dataGridView.DataSource = ds.Tables[0];

                openPO_dataGridView.Columns[0].FillWeight = 50;
                openPO_dataGridView.Columns[1].FillWeight = 40;
                openPO_dataGridView.Columns[2].FillWeight = 100;
                openPO_dataGridView.Columns[3].FillWeight = 200;
                openPO_dataGridView.Columns[4].FillWeight = 50;
                openPO_dataGridView.Columns[5].FillWeight = 50;
                openPO_dataGridView.Columns[6].FillWeight = 50;
                //OpenPOs_DataGridView.Columns[7].FillWeight = 200;

                open_po_count = openPO_dataGridView.Rows.Count.ToString();
                totalRecords_toolStripLabel.Text = open_po_count;

                conn.Close();
            }
            catch
            {

            }
            
        }
        private void OverduePO_Fill()
        {
            try
            {
                conn = new SqlConnection(conn_string);
                conn.Open();

                q = "SELECT PR_Details.Quantity, PR_Details.Unit, Parts.PartNumber, Parts.PartDescription, PR_Details.Per, PR_Details.DueDate, PR_Details.Received " +
                    "FROM(Parts INNER JOIN PR_Details ON Parts.PartID = PR_Details.PartID)" +
                    "WHERE PR_Details.DueDate < '" + today + "'";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(q, conn);

                SqlCommandBuilder scb = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                overduePO_dataGridView.ReadOnly = false;
                overduePO_dataGridView.DataSource = ds.Tables[0];

                overduePO_dataGridView.Columns[0].FillWeight = 50;
                overduePO_dataGridView.Columns[1].FillWeight = 40;
                overduePO_dataGridView.Columns[2].FillWeight = 100;
                overduePO_dataGridView.Columns[3].FillWeight = 200;
                overduePO_dataGridView.Columns[4].FillWeight = 50;
                overduePO_dataGridView.Columns[5].FillWeight = 50;
                overduePO_dataGridView.Columns[6].FillWeight = 50;
                //OpenPOs_DataGridView.Columns[7].FillWeight = 200;

                //open_po_count = openPO_dataGridView.Rows.Count.ToString();
                //totalRecords_toolStripLabel.Text = open_po_count;

                conn.Close();
            }
            catch
            {

            }

        }
        private void OpenPR_Fill()
        {
            try
            {
                conn = new SqlConnection(conn_string);
                conn.Open();

                q = "SELECT PR.PONumber, PR_Details.Quantity, Parts.PartNumber, Parts.PartDescription, PR_Details.DueDate, Vendors.VendorName " +
                    "FROM (((Parts INNER JOIN PR_Details ON Parts.PartID = PR_Details.PartID)" +
                    "INNER JOIN PR ON PR_Details.OrderID = PR.OrderID)" +
                    "INNER JOIN Vendors ON PR.VendorID = Vendors.VendorID)" +
                    "WHERE PR.PONumber IS NULL AND PR_Details.Received = 0";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(q, conn);

                SqlCommandBuilder scb = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                openPR_dataGridView.ReadOnly = false;
                openPR_dataGridView.DataSource = ds.Tables[0];

                openPR_dataGridView.Columns[0].FillWeight = 75;
                openPR_dataGridView.Columns[1].FillWeight = 40;
                openPR_dataGridView.Columns[2].FillWeight = 80;
                openPR_dataGridView.Columns[3].FillWeight = 125;
                openPR_dataGridView.Columns[4].FillWeight = 50;
                openPR_dataGridView.Columns[5].FillWeight = 125;

                //open_po_count = openPO_dataGridView.Rows.Count.ToString();
                //totalRecords_toolStripLabel.Text = open_po_count;

                conn.Close();
            }
            catch
            {

            }

        }

        private void MachineToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Import im = new Import(this);
            im.FormClosed += new FormClosedEventHandler(ImportMachine_FormClosed);
            im.Show();
            Hide();
        }

    }


    class Machine
    {
        public int MachineID
        {
            set;
            get;
        }
        public string BTNumber
        {
            set;
            get;
        }
        public string CommonName
        {
            set;
            get;
        }
        public string Make
        {
            set;
            get;
        }
        public string Model
        {
            set;
            get;
        }
        public string Serial
        {
            set;
            get;
        }
        public int DepartmentID_Machine
        {
            set;
            get;
        }
    }
    class Part
    {
        public int PartID
        {
            set;
            get;
        }
        public string PartNumber
        {
            set;
            get;
        }
        public string PartDescription
        {
            set;
            get;
        }
        public decimal UnitPrice
        {
            set;
            get;
        }
        public string PartImage
        {
            set;
            get;
        }
    }
    class Vendor
    {
        public int VendorID
        {
            set;
            get;
        }
        public string VendorNumber
        {
            set;
            get;
        }
        public string VendorName
        {
            set;
            get;
        }
        public string Contact
        {
            set;
            get;
        }
        public string VendorEmail
        {
            set;
            get;
        }
        public string VendorPhone
        {
            set;
            get;
        }
    }
    class Employee
    {
        public int EmployeeID
        {
            set;
            get;
        }
        public string Tech
        {
            set;
            get;
        }
        public string Craft
        {
            set;
            get;
        }
        public string EmployeePhone
        {
            set;
            get;
        }
        public string EmployeeEmail
        {
            set;
            get;
        }
    }
    class PR
    {
        public int OrderID
        {
            set;
            get;
        }
        public int VendorID_PR
        {
            set;
            get;
        }
        public string DateIssued
        {
            set;
            get;
        }
        public int DepartmentID_PR
        {
            set;
            get;
        }
        public int MachineID_PR
        {
            set;
            get;
        }
        public int EmployeeID_PR
        {
            set;
            get;
        }
        public string DeliverTo
        {
            set;
            get;
        }
        public string PONumber
        {
            set;
            get;
        }
    }
    class PR_Details
    {
        public int OrderID
        {
            set;
            get;
        }
        public int Quantity
        {
            set;
            get;
        }
        public string Unit
        {
            set;
            get;
        }
        public int PartID_PRD
        {
            set;
            get;
        }
        public string Per
        {
            set;
            get;
        }
        public string DueDate
        {
            set;
            get;
        }
        public bool Received
        {
            set;
            get;
        }
    }
    class Department
    {
        public int DepartmentID
        {
            set;
            get;
        }
        public string DepartmentName
        {
            set;
            get;
        }
    }
}
                                  