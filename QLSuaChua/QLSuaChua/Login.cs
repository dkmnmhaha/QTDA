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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {

            try
            {
                string conn = @"Data Source=.\sqlexpress;Initial Catalog=QLSuaChua;Integrated Security=True";
                SqlConnection con = new SqlConnection(conn);
                string query = "SELECT COUNT(*) FROM Account WHERE UserName = '" + tbTaikhoan.Text + "' and PassWord = '" + tbMatkhau.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                int kq = int.Parse(cmd.ExecuteScalar().ToString());
                if (kq == 1)
                {                   
                    Manager f = new Manager();
                    this.Hide();
                    f.Show();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!!!");
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOut_Click_1(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Bạn có muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel);
            if (x == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnResign_Click(object sender, EventArgs e)
        {
            Register f = new Register();
            this.Hide();
            f.Show();
        }
    }
}
