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
    public partial class Food : Form
    {
        public Food()
        {
            InitializeComponent();
            Load();
            LoadCategory();
        }

        void Load()
        {
            string query = "Select * From FOOD";
            dataGridView1.DataSource = Connect.Instance.ExecuteQuery(query);
        }

        private void btnquaylai_Click(object sender, EventArgs e)
        {
            Manager f = new Manager();
            this.Hide();
            f.ShowDialog();
        }

        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            comboBox1.DataSource = listCategory;
            comboBox1.DisplayMember = "name";
        }

        void Loadid()
        {
            textBox1.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "ID"));
            textBox2.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Name"));
            numericUpDown1.DataBindings.Add(new Binding("Value", dataGridView1.DataSource, "Price"));
        }

        public void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox2.Text;
                int categoryID = (comboBox1.SelectedItem as Category).ID;
                float price = (float)numericUpDown1.Value;
                if(textBox2.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập thông tin món ăn");
                }
                else if(textBox1.Text != "")
                {
                    MessageBox.Show("Mã món ăn sẽ được thêm tự động, vui lòng xóa thông tin khỏi mã món ăn!!!");
                    textBox1.Focus();
                }
                else if (FoodDAO.Instance.InsertFood(name, categoryID, price))
                {
                    MessageBox.Show("Thêm món thành công");
                    Load();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm món!!!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi hệ thống!!");
            }
            
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox2.Text;
                int categoryID = (comboBox1.SelectedItem as Category).ID;
                float price = (float)numericUpDown1.Value;
                int id = Convert.ToInt32(textBox1.Text);

                if (FoodDAO.Instance.UpdateFood(id, name, categoryID, price))
                {
                    MessageBox.Show("Sửa món thành công");
                    Load();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập mã món cho món cần sửa");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập thông tin món cần sửa");
            }
            
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox1.Text);

                if (FoodDAO.Instance.DeleteFood(id))
                {
                    MessageBox.Show("Xóa món thành công");
                    Load();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi xóa thức ăn");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập mã món cho món cần xóa");
            }

        }

        private void btnaddCategory_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text;
            if (textBox3.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên danh mục!");
            }
            else if (FoodDAO.Instance.InsertCategory(name))
            {
                MessageBox.Show("Thêm danh mục thành công");
                Load();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm danh mục!!!");
            }
        }

        private void btndelcategory_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox4.Text);
                if (textBox4.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập tên danh mục!");
                }
                else if (FoodDAO.Instance.DeleteCategory(id))
                {
                    MessageBox.Show("Xóa danh mục thành công");
                    Load();
                }
                else
                {
                    MessageBox.Show("Xóa danh mục thành công");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập mã danh mục cho danh mục cần xóa");
            }
        }
    }
}
