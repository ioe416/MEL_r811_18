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
    public static class DataGridViewExtensions
    {
        public static void Fill(this DataGridView dataGridView, string sql)
        {
            string conn_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\MEL\MEL.mdf;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conn.Close();

                    dataGridView.DataSource = dt;
                }
            }
        }
    }
}
