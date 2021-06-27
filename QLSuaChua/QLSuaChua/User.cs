using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLSuaChua
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
            Load();
        }

        void Load()
        {
            string query = "Select * From Account";
            dataGridView1.DataSource = Connect.Instance.ExecuteQuery(query);
        }

        private void bthreturn_Click(object sender, EventArgs e)
        {
            Manager f = new Manager();
            this.Hide();
            f.ShowDialog();
        }

        private void btnout_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Bạn có muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel);
            if (x == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text =="")
                {
                    MessageBox.Show("Vui lòng nhập UserName cần xóa!");
                }
                else
                {
                    string conn = @"Data Source=.\sqlexpress;Initial Catalog=QLSuaChua;Integrated Security=True";
                    SqlConnection con = new SqlConnection(conn);
                    string query = "DELETE From Account Where UserName = @UserName";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("UserName", textBox1.Text);
                    cmd.ExecuteNonQuery();
                    Load();
                }               
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xảy ra, vui lòng thao tác lại!");
            }
        }
    }
}
