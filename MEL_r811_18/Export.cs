using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEL_r811_18
{
    public partial class Export : Form
    {
        string filename = "";
        public Export(MainScreen ms)
        {
            InitializeComponent();
        }

        private void Department_btn_Click(object sender, EventArgs e)
        {
            string q = "SELECT * FROM Department";
            filename = "department";
            dataGridView1.Fill(q);
        }
        private void Employee_btn_Click(object sender, EventArgs e)
        {
            string q = "SELECT * FROM Employee";
            filename = "employee";
            dataGridView1.Fill(q);
        }
        private void Machines_btn_Click(object sender, EventArgs e)
        {
            string q = "SELECT * FROM Machines";
            filename = "machines";
            dataGridView1.Fill(q);
        }
        private void Notes_btn_Click(object sender, EventArgs e)
        {
            string q = "SELECT * FROM Notes";
            filename = "notes";
            dataGridView1.Fill(q);
        }
        private void Parts_btn_Click(object sender, EventArgs e)
        {
            string q = "SELECT * FROM Parts";
            filename = "parts";
            dataGridView1.Fill(q);
        }
        private void Pr_btn_Click(object sender, EventArgs e)
        {
            string q = "SELECT * FROM PR";
            filename = "pr";
            dataGridView1.Fill(q);
        }
        private void PrDetails_btn_Click(object sender, EventArgs e)
        {
            string q = "SELECT * FROM PR_Details";
            filename = "prdetails";
            dataGridView1.Fill(q);
        }
        private void Priority_btn_Click(object sender, EventArgs e)
        {
            string q = "SELECT * FROM Priority";
            filename = "priority";
            dataGridView1.Fill(q);
        }
        private void Status_btn_Click(object sender, EventArgs e)
        {
            string q = "SELECT * FROM Status";
            filename = "status";
            dataGridView1.Fill(q);
        }
        private void Tasks_btn_Click(object sender, EventArgs e)
        {
            string q = "SELECT * FROM Tasks";
            filename = "tasks";
            dataGridView1.Fill(q);
        }
        private void Type_btn_Click(object sender, EventArgs e)
        {
            string q = "SELECT * FROM Type";
            filename = "type";
            dataGridView1.Fill(q);
        }
        private void Vendors_btn_Click(object sender, EventArgs e)
        {
            string q = "SELECT * FROM Vendors";
            filename = "vendors";
            dataGridView1.Fill(q);
        }
        private void WoDetails_btn_Click(object sender, EventArgs e)
        {
            string q = "SELECT * FROM WODetails";
            filename = "wodetails";
            dataGridView1.Fill(q);
        }
        private void Wo_btn_Click(object sender, EventArgs e)
        {
            string q = "SELECT * FROM WorkOrder";
            filename = "wo";
            dataGridView1.Fill(q);
        }
        private void WorkRequest_btn_Click(object sender, EventArgs e)
        {
            string q = "SELECT * FROM WorkRequest";
            filename = "workrequest";
            dataGridView1.Fill(q);
        }

        private void saveCSV_btn_Click(object sender, EventArgs e)
        {
            dataGridView1.CreateCSV(filename);
        }
    }
}
