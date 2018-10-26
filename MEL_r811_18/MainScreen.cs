using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;


namespace MEL_r811_18
{
    public partial class MainScreen : Form
    {
        public string q;
        public string conn_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\MEL\MEL.mdf;Integrated Security=True";
        public string open_po_count;
        SqlConnection conn = null;
        public string today = DateTime.Today.ToShortDateString();

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
        public int id;
        public bool updatedValue;

        public MainScreen()
        {
            InitializeComponent();
        }

        private void OpenPO_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = Convert.ToInt16(openPO_dataGridView.Rows[e.RowIndex].Cells[0].Value); // get the Row Index
            PR_Review po = new PR_Review(Convert.ToInt16(openPO_dataGridView.Rows[e.RowIndex].Cells[0].Value));
            po.FormClosed += new FormClosedEventHandler(PO_FormClosed);
            po.Show();

        }
        private void OverDuePO_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = Convert.ToInt16(overduePO_dataGridView.Rows[e.RowIndex].Cells[0].Value); // get the Row Index
            PR_Review po = new PR_Review(Convert.ToInt16(overduePO_dataGridView.Rows[e.RowIndex].Cells[0].Value));
            po.FormClosed += new FormClosedEventHandler(PO_FormClosed);
            po.Show();

        }
        private void OpenWR_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = Convert.ToInt16(openWR_dataGridView.Rows[e.RowIndex].Cells[0].Value); // get the Row Index
            WorkRequestEntry wre = new WorkRequestEntry(Convert.ToInt16(openWR_dataGridView.Rows[e.RowIndex].Cells[0].Value));
            wre.FormClosed += new FormClosedEventHandler(WorkRequestEntryClosed);
            wre.Show();
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
        private void PO_FormClosed(object sender, EventArgs e)
        {
            this.Show();
            OpenPO_Fill();
            OverduePO_Fill();
            OpenPR_Fill();
        }
        private void PR_EntryClosed(object sender, EventArgs e)
        {
            this.Show();
            OpenPO_Fill();
            OverduePO_Fill();
            OpenPR_Fill();
        }
        private void EditMachineClosed(object sender, EventArgs e)
        {
            this.Show();
        }
        private void VendorSetupClosed(object sender, EventArgs e)
        {
            this.Show();
        }
        private void EditVendorClosed(object sender, EventArgs e)
        {
            this.Show();
        }
        private void WorkRequestEntryClosed(object sender, EventArgs e)
        {
            this.Show();
            OpenWR_Fill();
        }

        private void MainScreen_load(object sender, EventArgs e)
        {
            OpenPO_Fill();
            OverduePO_Fill();
            OpenPR_Fill();
            OpenWR_Fill();
            Fill_SelectDepartment_ComboBox();
            Fill_SelectMachine_ComboBox();
            Fill_SelectVendor_ComboBox();
            Fill_SelectTech_ComboBox();
        }

        private void OpenPO_Fill()
        {
            try
            {
                conn = new SqlConnection(conn_string);
                conn.Open();

                q = "SELECT PR.OrderID, Vendors.VendorName, PR.PONumber, PR_Details.Quantity,  PR_Details.Unit, Parts.PartNumber, Parts.PartDescription, PR_Details.Per, PR_Details.DueDate, PR_Details.Received " +
                    "FROM Parts INNER JOIN PR_Details ON Parts.PartID = PR_Details.PartID " +
                    "INNER JOIN PR ON PR.OrderID = PR_Details.OrderID INNER JOIN Vendors ON PR.VendorID = Vendors.VendorID " +
                    "WHERE (PR_Details.DueDate IS NULL OR PR_Details.DueDate >= '" + today + "') AND (PR_Details.Received = 'False') AND (PR.PONumber IS NOT NULL)";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(q, conn);

                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                openPO_dataGridView.DataSource = dt;

                openPO_dataGridView.Columns[0].FillWeight = 30;
                openPO_dataGridView.Columns[0].HeaderText = "ID";
                openPO_dataGridView.Columns[0].ReadOnly = true;
                openPO_dataGridView.Columns[0].Visible = false;

                openPO_dataGridView.Columns[1].FillWeight = 80;
                openPO_dataGridView.Columns[1].HeaderText = "Vendor";
                openPO_dataGridView.Columns[1].ReadOnly = true;

                openPO_dataGridView.Columns[2].FillWeight = 50;
                openPO_dataGridView.Columns[2].HeaderText = "PO Number";
                openPO_dataGridView.Columns[2].ReadOnly = true;

                openPO_dataGridView.Columns[3].FillWeight = 50;
                openPO_dataGridView.Columns[3].HeaderText = "Qty";
                openPO_dataGridView.Columns[3].ReadOnly = true;

                openPO_dataGridView.Columns[4].FillWeight = 40;
                openPO_dataGridView.Columns[4].Visible = false;

                openPO_dataGridView.Columns[5].FillWeight = 100;
                openPO_dataGridView.Columns[5].HeaderText = "Part Number";
                openPO_dataGridView.Columns[5].ReadOnly = true;

                openPO_dataGridView.Columns[6].FillWeight = 200;
                openPO_dataGridView.Columns[6].HeaderText = "Description";
                openPO_dataGridView.Columns[6].ReadOnly = true;

                openPO_dataGridView.Columns[7].FillWeight = 50;
                openPO_dataGridView.Columns[7].Visible = false;

                openPO_dataGridView.Columns[8].FillWeight = 50;
                openPO_dataGridView.Columns[8].HeaderText = "DUE";
                openPO_dataGridView.Columns[8].ReadOnly = true;

                openPO_dataGridView.Columns[9].FillWeight = 50;
                openPO_dataGridView.Columns[9].HeaderText = "Rec'd";
                openPO_dataGridView.Columns[9].ReadOnly = false;

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

                q = "SELECT PR.OrderID, Vendors.VendorName, PR.PONumber, PR_Details.Quantity,  PR_Details.Unit, Parts.PartNumber, Parts.PartDescription, PR_Details.Per, PR_Details.DueDate, PR_Details.Received " +
                    "FROM Parts INNER JOIN PR_Details ON Parts.PartID = PR_Details.PartID " +
                    "INNER JOIN PR ON PR.OrderID = PR_Details.OrderID INNER JOIN Vendors ON PR.VendorID = Vendors.VendorID " +
                    "WHERE (PR_Details.Received = 'False') AND (PR_Details.DueDate < '" + today + "')";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(q, conn);

                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                overduePO_dataGridView.DataSource = dt;

                overduePO_dataGridView.Columns[0].FillWeight = 30;
                overduePO_dataGridView.Columns[0].HeaderText = "ID";
                overduePO_dataGridView.Columns[0].ReadOnly = true;
                overduePO_dataGridView.Columns[0].Visible = false;

                overduePO_dataGridView.Columns[1].FillWeight = 80;
                overduePO_dataGridView.Columns[1].HeaderText = "Vendor";
                overduePO_dataGridView.Columns[1].ReadOnly = true;

                overduePO_dataGridView.Columns[2].FillWeight = 50;
                overduePO_dataGridView.Columns[2].HeaderText = "PO Number";
                overduePO_dataGridView.Columns[2].ReadOnly = true;

                overduePO_dataGridView.Columns[3].FillWeight = 50;
                overduePO_dataGridView.Columns[3].HeaderText = "Qty";
                overduePO_dataGridView.Columns[3].ReadOnly = true;

                overduePO_dataGridView.Columns[4].FillWeight = 40;
                overduePO_dataGridView.Columns[4].Visible = false;

                overduePO_dataGridView.Columns[5].FillWeight = 100;
                overduePO_dataGridView.Columns[5].HeaderText = "Part Number";
                overduePO_dataGridView.Columns[5].ReadOnly = true;

                overduePO_dataGridView.Columns[6].FillWeight = 200;
                overduePO_dataGridView.Columns[6].HeaderText = "Description";
                overduePO_dataGridView.Columns[6].ReadOnly = true;

                overduePO_dataGridView.Columns[7].FillWeight = 50;
                overduePO_dataGridView.Columns[7].Visible = false;

                overduePO_dataGridView.Columns[8].FillWeight = 50;
                overduePO_dataGridView.Columns[8].HeaderText = "DUE";
                overduePO_dataGridView.Columns[8].ReadOnly = true;

                overduePO_dataGridView.Columns[9].FillWeight = 50;
                overduePO_dataGridView.Columns[9].HeaderText = "Rec'd";
                overduePO_dataGridView.Columns[9].ReadOnly = false;

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

                q = "SELECT PR.OrderID, Vendors.VendorName, PR.PONumber, PR_Details.Quantity,  PR_Details.Unit, Parts.PartNumber, Parts.PartDescription, PR_Details.Per, PR_Details.DueDate, PR_Details.Received " +
                    "FROM Parts INNER JOIN PR_Details ON Parts.PartID = PR_Details.PartID " +
                    "INNER JOIN PR ON PR.OrderID = PR_Details.OrderID INNER JOIN Vendors ON PR.VendorID = Vendors.VendorID " +
                    "WHERE (PR.PONumber IS NULL) AND (PR_Details.Received = 'False')";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(q, conn);

                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                openPR_dataGridView.DataSource = dt;

                openPR_dataGridView.Columns[0].FillWeight = 80;
                openPR_dataGridView.Columns[0].HeaderText = "ID";
                openPR_dataGridView.Columns[0].ReadOnly = true;
                openPR_dataGridView.Columns[0].Visible = false;

                openPR_dataGridView.Columns[1].FillWeight = 80;
                openPR_dataGridView.Columns[1].HeaderText = "Vendor";
                openPR_dataGridView.Columns[1].ReadOnly = true;

                openPR_dataGridView.Columns[2].FillWeight = 50;
                openPR_dataGridView.Columns[2].HeaderText = "PO Number";
                openPR_dataGridView.Columns[2].ReadOnly = true;
                openPR_dataGridView.Columns[2].Visible = true;

                openPR_dataGridView.Columns[3].FillWeight = 50;
                openPR_dataGridView.Columns[3].HeaderText = "Qty";
                openPR_dataGridView.Columns[3].ReadOnly = true;

                openPR_dataGridView.Columns[4].FillWeight = 40;
                openPR_dataGridView.Columns[4].Visible = false;

                openPR_dataGridView.Columns[5].FillWeight = 100;
                openPR_dataGridView.Columns[5].HeaderText = "Part Number";
                openPR_dataGridView.Columns[5].ReadOnly = true;

                openPR_dataGridView.Columns[6].FillWeight = 200;
                openPR_dataGridView.Columns[6].HeaderText = "Description";
                openPR_dataGridView.Columns[6].ReadOnly = true;

                openPR_dataGridView.Columns[7].FillWeight = 50;
                openPR_dataGridView.Columns[7].Visible = false;

                openPR_dataGridView.Columns[8].FillWeight = 50;
                openPR_dataGridView.Columns[8].HeaderText = "DUE";
                openPR_dataGridView.Columns[8].ReadOnly = true;

                openPR_dataGridView.Columns[9].FillWeight = 50;
                openPR_dataGridView.Columns[9].HeaderText = "Rec'd";
                openPR_dataGridView.Columns[9].ReadOnly = false;

                conn.Close();
            }
            catch
            {

            }

        }
        private void OpenWR_Fill()
        {
            try
            {
                conn = new SqlConnection(conn_string);
                conn.Open();

                q = "SELECT[WorkRequest].[RequestID], [Machines].[BTNumber], [WorkRequest].[RequestDate], [Type].[Type], " +
                    "[Priority].[Priority], [WorkRequest].[WorkRequested], [WorkRequest].[RequestConverted] " +
                    "FROM[WorkRequest] INNER JOIN[Machines] ON[Machines].[MachineID] = [WorkRequest].[MachineID] " +
                    "INNER JOIN[Type] ON[Type].[TypeID] = [WorkRequest].[RequestType] " +
                    "INNER JOIN[Priority] ON[Priority].[PriorityID] = [WorkRequest].[RequestPriority]" +
                    "WHERE [WorkRequest].[RequestConverted] = 'False'";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(q, conn);

                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                openWR_dataGridView.DataSource = dt;

                openWR_dataGridView.Columns[0].FillWeight = 30;
                openWR_dataGridView.Columns[0].HeaderText = "ID";
                openWR_dataGridView.Columns[0].ReadOnly = true;
                openWR_dataGridView.Columns[0].Visible = true;

                openWR_dataGridView.Columns[1].FillWeight = 120;
                openWR_dataGridView.Columns[1].HeaderText = "Machine";
                openWR_dataGridView.Columns[1].ReadOnly = true;

                openWR_dataGridView.Columns[2].FillWeight = 100;
                openWR_dataGridView.Columns[2].HeaderText = "Request Date";
                openWR_dataGridView.Columns[2].ReadOnly = true;

                openWR_dataGridView.Columns[3].FillWeight = 150;
                openWR_dataGridView.Columns[3].HeaderText = "Type";
                openWR_dataGridView.Columns[3].ReadOnly = true;

                openWR_dataGridView.Columns[4].FillWeight = 250;
                openWR_dataGridView.Columns[4].HeaderText = "Priority";
                openWR_dataGridView.Columns[4].ReadOnly = true;

                openWR_dataGridView.Columns[5].FillWeight = 800;
                openWR_dataGridView.Columns[5].HeaderText = "Work Requested";
                openWR_dataGridView.Columns[5].ReadOnly = true;

                conn.Close();
            }
            catch
            {

            }

        }
        private void HistoricalPO_Fill(string q)
        {
            try
            {
                conn = new SqlConnection(conn_string);
                conn.Open();

                //q = "SELECT PR.OrderID, Vendors.VendorName, PR.PONumber, PR_Details.Quantity,  PR_Details.Unit, Parts.PartNumber, Parts.PartDescription, PR_Details.Per, PR_Details.DueDate, PR_Details.Received " +
                //    "FROM Parts INNER JOIN PR_Details ON Parts.PartID = PR_Details.PartID " +
                //    "INNER JOIN PR ON PR.OrderID = PR_Details.OrderID INNER JOIN Vendors ON PR.VendorID = Vendors.VendorID " +
                //    "WHERE (PR_Details.DueDate IS NULL OR PR_Details.DueDate >= '" + today + "') AND (PR_Details.Received = 'True') AND (PR.PONumber IS NOT NULL)";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(q, conn);

                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                historicalPO_datagridView.DataSource = dt;

                historicalPO_datagridView.Columns[0].FillWeight = 30;
                historicalPO_datagridView.Columns[0].HeaderText = "ID";
                historicalPO_datagridView.Columns[0].ReadOnly = true;
                historicalPO_datagridView.Columns[0].Visible = false;

                historicalPO_datagridView.Columns[1].FillWeight = 80;
                historicalPO_datagridView.Columns[1].HeaderText = "Vendor";
                historicalPO_datagridView.Columns[1].ReadOnly = true;

                historicalPO_datagridView.Columns[2].FillWeight = 50;
                historicalPO_datagridView.Columns[2].HeaderText = "PO Number";
                historicalPO_datagridView.Columns[2].ReadOnly = true;

                historicalPO_datagridView.Columns[3].FillWeight = 50;
                historicalPO_datagridView.Columns[3].HeaderText = "Qty";
                historicalPO_datagridView.Columns[3].ReadOnly = true;

                historicalPO_datagridView.Columns[4].FillWeight = 40;
                historicalPO_datagridView.Columns[4].Visible = false;

                historicalPO_datagridView.Columns[5].FillWeight = 100;
                historicalPO_datagridView.Columns[5].HeaderText = "Part Number";
                historicalPO_datagridView.Columns[5].ReadOnly = true;

                historicalPO_datagridView.Columns[6].FillWeight = 200;
                historicalPO_datagridView.Columns[6].HeaderText = "Description";
                historicalPO_datagridView.Columns[6].ReadOnly = true;

                historicalPO_datagridView.Columns[7].FillWeight = 50;
                historicalPO_datagridView.Columns[7].Visible = false;

                historicalPO_datagridView.Columns[8].FillWeight = 50;
                historicalPO_datagridView.Columns[8].HeaderText = "DUE";
                historicalPO_datagridView.Columns[8].ReadOnly = true;

                historicalPO_datagridView.Columns[9].FillWeight = 50;
                historicalPO_datagridView.Columns[9].HeaderText = "Rec'd";
                historicalPO_datagridView.Columns[9].ReadOnly = false;

                open_po_count = historicalPO_datagridView.Rows.Count.ToString();
                totalRecords_toolStripLabel.Text = open_po_count;

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
        private void EditMachineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MachineUpdate mu = new MachineUpdate(this);
            mu.FormClosed += new FormClosedEventHandler(EditMachineClosed);
            mu.Show();
        }
        private void NewPurchaseRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PR_Entry po = new PR_Entry(this);
            po.FormClosed += new FormClosedEventHandler(PR_EntryClosed);
            po.Show();
        }
        private void NewVendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VendorSetup vs = new VendorSetup(this);
            vs.label1.Text = "Add New Vendor To Vendor Table";
            vs.FormClosed += new FormClosedEventHandler(VendorSetupClosed);
            vs.Show();
        }
        private void EditVendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditVendor ev = new EditVendor(this);
            ev.FormClosed += new FormClosedEventHandler(VendorSetupClosed);
            ev.Show();
        }
        private void NewPartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewPart np = new NewPart(this);
            np.FormClosed += new FormClosedEventHandler(VendorSetupClosed);
            np.Show();
        }
        private void EditPartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditPart ep = new EditPart(this);
            ep.FormClosed += new FormClosedEventHandler(VendorSetupClosed);
            ep.Show();
        }
        private void WorkRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkRequestEntry wre = new WorkRequestEntry(0);
            wre.FormClosed += new FormClosedEventHandler(WorkRequestEntryClosed);
            wre.Show();
            Hide();
        }

        public void OpenPR_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = Convert.ToInt16(openPR_dataGridView.Rows[e.RowIndex].Cells[0].Value); // get the Row Index
            PR_Review po = new PR_Review(Convert.ToInt16(openPR_dataGridView.Rows[e.RowIndex].Cells[0].Value));
            po.FormClosed += new FormClosedEventHandler(PO_FormClosed);
            po.Show();

        }

        private void TabControl1_Selected(object sender, TabControlEventArgs e)
        {
            open_po_count = openPO_dataGridView.Rows.Count.ToString();
            totalRecords_toolStripLabel.Text = open_po_count;
        }

        private void SelectDepartemnt_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            q = "SELECT PR.OrderID, Vendors.VendorName, PR.PONumber, PR_Details.Quantity, " + 
                "PR_Details.Unit, Parts.PartNumber, Parts.PartDescription, PR_Details.Per, " +
                "PR_Details.DueDate, PR_Details.Received, Department.DepartmentName " +
                "FROM Parts INNER JOIN PR_Details ON Parts.PartID = PR_Details.PartID " +
                "INNER JOIN PR ON PR.OrderID = PR_Details.OrderID " +
                "INNER JOIN Vendors ON PR.VendorID = Vendors.VendorID " +
                "INNER JOIN Department ON PR.DepartmentID = Department.DepartmentID " +
                "WHERE(PR_Details.DueDate IS NULL OR PR_Details.DueDate >= '" + today + "') " +
                "AND(PR_Details.Received = 'True') AND(PR.PONumber IS NOT NULL) AND " +
                "(Department.DepartmentName = '" + comboBox1.Text + "')";

            HistoricalPO_Fill(q);
            comboBox3.Text = "-Select Vendor-";
            comboBox2.Text = "-Select Machine-";
            comboBox4.Text = "-Select Tech-";
        }
        private void SelectMachine_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            q = "SELECT PR.OrderID, Vendors.VendorName, PR.PONumber, PR_Details.Quantity, " +
                "PR_Details.Unit, Parts.PartNumber, Parts.PartDescription, PR_Details.Per, " +
                "PR_Details.DueDate, PR_Details.Received, Machines.BTNumber " +
                "FROM Parts INNER JOIN PR_Details ON Parts.PartID = PR_Details.PartID " +
                "INNER JOIN PR ON PR.OrderID = PR_Details.OrderID " +
                "INNER JOIN Vendors ON PR.VendorID = Vendors.VendorID " +
                "INNER JOIN Machines ON PR.MachineID = Machines.MachineID " +
                "WHERE(PR_Details.DueDate IS NULL OR PR_Details.DueDate >= '" + today + "') " +
                "AND(PR_Details.Received = 'True') AND(PR.PONumber IS NOT NULL) AND " +
                "(Machines.BTNumber = '" + comboBox2.Text + "')";

            HistoricalPO_Fill(q);
            comboBox1.Text = "-Select Department-";
            comboBox3.Text = "-Select Vendor-";
            comboBox4.Text = "-Select Tech-";
        }
        private void SelectVendor_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            q = "SELECT PR.OrderID, Vendors.VendorName, PR.PONumber, PR_Details.Quantity, " +
                "PR_Details.Unit, Parts.PartNumber, Parts.PartDescription, PR_Details.Per, " +
                "PR_Details.DueDate, PR_Details.Received " +
                "FROM Parts INNER JOIN PR_Details ON Parts.PartID = PR_Details.PartID " +
                "INNER JOIN PR ON PR.OrderID = PR_Details.OrderID " +
                "INNER JOIN Vendors ON PR.VendorID = Vendors.VendorID " +
                "WHERE(PR_Details.DueDate IS NULL OR PR_Details.DueDate >= '" + today + "') " +
                "AND(PR_Details.Received = 'True') AND(PR.PONumber IS NOT NULL) AND " +
                "(Vendors.VendorName = '" + comboBox3.Text + "')";

            HistoricalPO_Fill(q);
            comboBox1.Text = "-Select Department-";
            comboBox2.Text = "-Select Machine-";
            comboBox4.Text = "-Select Tech-";
        }
        private void SelectTech_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            q = "SELECT PR.OrderID, Vendors.VendorName, PR.PONumber, PR_Details.Quantity, " +
                "PR_Details.Unit, Parts.PartNumber, Parts.PartDescription, PR_Details.Per, " +
                "PR_Details.DueDate, PR_Details.Received, Employee.Tech " +
                "FROM Parts INNER JOIN PR_Details ON Parts.PartID = PR_Details.PartID " +
                "INNER JOIN PR ON PR.OrderID = PR_Details.OrderID " +
                "INNER JOIN Vendors ON PR.VendorID = Vendors.VendorID " +
                "INNER JOIN Employee ON PR.EmployeeID = Employee.EmployeeID " +
                "WHERE(PR_Details.DueDate IS NULL OR PR_Details.DueDate >= '" + today + "') " +
                "AND(PR_Details.Received = 'True') AND(PR.PONumber IS NOT NULL) AND " +
                "(Employee.Tech = '" + comboBox4.Text + "')";

            HistoricalPO_Fill(q);
            comboBox1.Text = "-Select Department-";
            comboBox2.Text = "-Select Machine-";
            comboBox3.Text = "-Select Vendor-";
        }

        private void Fill_SelectDepartment_ComboBox()
        {
            string department_fill_q = "SELECT DepartmentID, DepartmentName FROM Department";
            DataTable table = new DataTable("DepartmentData");
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(department_fill_q, conn))
                {
                    da.Fill(table);

                    DataRow row = table.NewRow();
                    row["DepartmentName"] = "-Select Department-";
                    table.Rows.InsertAt(row, 0);

                    comboBox1.DataSource = table;
                    comboBox1.DisplayMember = "DepartmentName";
                    comboBox1.ValueMember = "DepartmentID";
                }

            }
        }
        private void Fill_SelectMachine_ComboBox()
        {
            string machine_fill_q = "SELECT MachineID, BTNumber FROM Machines";

            DataTable table = new DataTable("MachineData");
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(machine_fill_q, conn))
                {
                    da.Fill(table);

                    DataRow row = table.NewRow();
                    row["BTNumber"] = "-Select Machine-";
                    table.Rows.InsertAt(row, 0);

                    comboBox2.DataSource = table;
                    comboBox2.DisplayMember = "BTNumber";
                    comboBox2.ValueMember = "MachineID";
                }

            }
        }
        private void Fill_SelectVendor_ComboBox()
        {
            string vendor_fill_q = "SELECT VendorID, VendorName FROM Vendors";
            DataTable table = new DataTable("VendorData");
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(vendor_fill_q, conn))
                {
                    da.Fill(table);

                    DataRow row = table.NewRow();
                    row["VendorName"] = "-Select Vendor-";
                    table.Rows.InsertAt(row, 0);

                    comboBox3.DataSource = table;
                    comboBox3.DisplayMember = "VendorName";
                    comboBox3.ValueMember = "VendorID";
                }
            }
        }
        private void Fill_SelectTech_ComboBox()
        {
            string employee_fill_q = "SELECT EmployeeID, Tech FROM Employee";
            DataTable table = new DataTable("EmployeeData");
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(employee_fill_q, conn))
                {
                    da.Fill(table);

                    DataRow row = table.NewRow();
                    row["Tech"] = "-Select Technician-";
                    table.Rows.InsertAt(row, 0);

                    comboBox4.DataSource = table;
                    comboBox4.DisplayMember = "Tech";
                    comboBox4.ValueMember = "EmployeeID";
                }

            }
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
        public int OrderDetailsID
        {
            set;
            get;
        }
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
                                  