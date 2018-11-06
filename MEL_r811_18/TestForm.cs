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
    public partial class TestForm : Form
    {
        public string conn_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\MEL\MEL.mdf;Integrated Security=True";

        public TestForm()
        {
            InitializeComponent();
        }
        private void TestForm_Load(object sender, EventArgs e)
        {
            Fill_comboBox();
        }

        private void Fill_comboBox()
        {
            string q = "SELECT DepartmentID, DepartmentName FROM Department";
            comboBox1.Load(q, "DepartmentID", "DepartmentName", "Department");
        }

    }
}
