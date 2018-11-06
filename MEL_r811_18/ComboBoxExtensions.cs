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
    public static class ComboBoxExtensions
    {

        public static void Load(this ComboBox comboBox, string sql, string valueMember, string displayMember, string objectType)
        {
            string conn_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\MEL\MEL.mdf;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                conn.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    DataRow row = dt.NewRow();
                    row[displayMember] = "-Select " + objectType + "-";
                    dt.Rows.InsertAt(row, 0);

                    comboBox.ValueMember = valueMember;
                    comboBox.DisplayMember = displayMember;
                    comboBox.DataSource = dt; 
                }
            }

        }
    }
}

