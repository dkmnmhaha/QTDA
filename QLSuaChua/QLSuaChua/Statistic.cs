using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSuaChua
{
    public partial class Statistic : Form
    {
        public Statistic()
        {
            InitializeComponent();
            Load();
        }

        private void btnquaylai_Click(object sender, EventArgs e)
        {
            Manager f = new Manager();
            this.Hide();
            f.ShowDialog();
        }

        void Load()
        {
            string query = "Select * From Bill";
            dataGridView1.DataSource = Connect.Instance.ExecuteQuery(query);
        }

        private void btnngay_Click(object sender, EventArgs e)
        {
            string query = "Select * From Bill Where Day(DateCheckOut) = Day(GetDate())";
            dataGridView1.DataSource = Connect.Instance.ExecuteQuery(query);
        }

        private void btnthang_Click(object sender, EventArgs e)
        {
            string query = "Select * From Bill Where Month(DateCheckOut) = Month(GetDate())";
            dataGridView1.DataSource = Connect.Instance.ExecuteQuery(query);
        }

        private void btnnam_Click(object sender, EventArgs e)
        {
            string query = "Select * From Bill Where Year(DateCheckOut) = Year(GetDate())";
            dataGridView1.DataSource = Connect.Instance.ExecuteQuery(query);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try

            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập id hóa đơn cần xóa!");
                }
                else
                {
                    string conn = @"Data Source=.\sqlexpress;Initial Catalog=QLSuaChua;Integrated Security=True";
                    SqlConnection con = new SqlConnection(conn);                    
                    string query = "DELETE From Bill Where id = @id";
                    string query1 = "DELETE From BillInfo Where idBill = @id";
                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    con.Open();
                    cmd1.Parameters.AddWithValue("id", textBox1.Text);
                    cmd1.ExecuteNonQuery();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("id", textBox1.Text);
                    cmd.ExecuteNonQuery();
                    Load();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xảy ra, vui lòng thao tác lại!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
