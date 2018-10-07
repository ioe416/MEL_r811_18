using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MEL_r811_18
{
    public partial class NewPart : Form
    {
        public NewPart(MainScreen ms)
        {
            InitializeComponent();
        }
        public string conn_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\MEL\MEL.mdf;Integrated Security=True";
        SqlConnection conn = null;
        public string q;

        public int partID;

        public string part;
        public string desc;
        public decimal price;

        private void NewPart_Load(object sender, EventArgs e)
        {
            partNumber_txb.Text = part;
            partDescription_txb.Text = desc;
            unitPrice_txb.Text = price.ToString();
        }

        private void UnitPrice_txb_TextChanged(object sender, EventArgs e)
        {
            {
                //Remove previous formatting, or the decimal check will fail including leading zeros
                string value = unitPrice_txb.Text.Replace(",", "")
                    .Replace("$", "").Replace(".", "").TrimStart('0');
                //Check we are indeed handling a number
                if (decimal.TryParse(value, out decimal ul))
                {
                    ul /= 100;
                    //Unsub the event so we don't enter a loop
                    unitPrice_txb.TextChanged -= UnitPrice_txb_TextChanged;
                    //Format the text as currency
                    unitPrice_txb.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C2}", ul);
                    unitPrice_txb.TextChanged += UnitPrice_txb_TextChanged;
                    unitPrice_txb.Select(unitPrice_txb.Text.Length, 0);
                }
                bool goodToGo = TextisValid(unitPrice_txb.Text);
                //enterButton.Enabled = goodToGo;
                if (!goodToGo)
                {
                    unitPrice_txb.Text = "$0.00";
                    unitPrice_txb.Select(unitPrice_txb.Text.Length, 0);
                }
            }
        }
        private bool TextisValid(string text)
        {
            Regex money = new Regex(@"^\$(\d{1,3}(\,\d{3})*|(\d+))(\.\d{2})?$");
            return money.IsMatch(text);
        }

        private void UnitPrice_txb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SaveExit_btn_Click(object sender, EventArgs e)
        {
            Save_Part();
            this.Close();
        }
        private void SaveNew_btn_Click(object sender, EventArgs e)
        {
            Save_Part();
            Reset_Form();
        }
        private void SaveReturn_btn_Click(object sender, EventArgs e)
        {
            Save_Part();
            Reset_Form();
        }

        public int Save_Part_With_Return(string partnumber, string partdescription, decimal unitprice)
        {
            string partNumber = partnumber;
            string description = partdescription;
            decimal unitPrice = unitprice;

            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                q = "INSERT INTO Parts (PartNumber, PartDescription, UnitPrice) OUTPUT INSERTED.PartID " +
                    "VALUES (@PartNumber, @PartDescription, @UnitPrice)";

                using (SqlCommand command = new SqlCommand(q, conn))
                {
                    command.Parameters.AddWithValue("@PartNumber", partNumber);
                    command.Parameters.AddWithValue("@PartDescription", description);
                    command.Parameters.AddWithValue("@UnitPrice", unitPrice);
                    //command.Parameters.AddWithValue("@PartImage", DBNull.Value);

                    conn.Open();
                    partID = (int)command.ExecuteScalar();
                    return partID;
                }
            }
        }
        private void Save_Part()
        {
            string partNumber = partNumber_txb.Text;
            string description = partDescription_txb.Text;
            decimal unitPrice = Convert.ToDecimal(unitPrice_txb.Text.Replace("$", ""));

            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                q = "INSERT INTO Parts (PartNumber, PartDescription, UnitPrice) OUTPUT INSERTED.PartID " +
                    "VALUES (@PartNumber, @PartDescription, @UnitPrice)";

                using (SqlCommand command = new SqlCommand(q, conn))
                {
                    command.Parameters.AddWithValue("@PartNumber", partNumber);
                    command.Parameters.AddWithValue("@PartDescription", description);
                    command.Parameters.AddWithValue("@UnitPrice", unitPrice);

                    conn.Open();
                    partID = (int)command.ExecuteScalar();
;
                }
            }
        }
            
        
        private void Reset_Form()
        {
            partNumber_txb.Clear();
            partDescription_txb.Clear();
            unitPrice_txb.Clear();
            partImage_picBx.Image = null;
        }

        
    }
}
