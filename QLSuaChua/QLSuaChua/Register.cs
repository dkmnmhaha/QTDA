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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login f = new Login();
            this.Hide();
            f.Show();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Bạn có muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel);
            if (x == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnResign_Click(object sender, EventArgs e)
        {
            if(tbTaikhoan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tài khoản");
                tbTaikhoan.Focus();
            }
            else if (tbMatkhau1.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu");
                tbMatkhau1.Focus();
            }
            else if(tbMatkhau2.Text == "")
            {
                MessageBox.Show("Bạn chưa xác nhận mật khẩu");
                tbMatkhau2.Focus();
            }
            else if(tbMatkhau1.Text != tbMatkhau2.Text)
            {
                MessageBox.Show("Mật khẩu không trùng khớp");
                tbMatkhau2.Focus();
            }
            else
            {
                try
                {
                    string conn = @"Data Source=.\sqlexpress;Initial Catalog=QLSuaChua;Integrated Security=True";
                    SqlConnection con = new SqlConnection(conn);
                    con.Open();
                    string query = "insert into Account values(@UserName, @DisplayName, @PassWord, @Type)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("UserName", tbTaikhoan.Text);
                    cmd.Parameters.AddWithValue("DisplayName", tbTaikhoan.Text);
                    cmd.Parameters.AddWithValue("PassWord", tbMatkhau1.Text);
                    cmd.Parameters.AddWithValue("Type", 0);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Đăng ký thành công!");
                    Login f = new Login();
                    this.Hide();
                    f.Show();
                }
                catch (Exception)
                {
                    MessageBox.Show("Tài khoản đã tồn tại, vui lòng nhập tài khoản khác!!");
                    tbTaikhoan.Focus();
                }            
            }
        }
    }
}
