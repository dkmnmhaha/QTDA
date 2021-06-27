using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSuaChua
{
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
            LoadTable();
            LoadCategory();
        }

        #region Method

        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            comboBox1.DataSource = listCategory;
            comboBox1.DisplayMember = "Name";
        }

        void LoadFoodListByCategoryID(int id)
        {
            List<Foodd> listFood = FoodDAO.Instance.GetFoodByCategoryID(id);
            comboBox2.DataSource = listFood;
            comboBox2.DisplayMember = "Name";
        }

        void LoadTable()
        {
            flp1.Controls.Clear();

            List<Table> tableList = TableDAO.Instance.LoadTableList();

            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.x, Height = TableDAO.x };
                btn.Text = item.Name /* + Environment.NewLine + item.Status*/;
                btn.Click += btnClick;
                btn.Tag = item;

                if (item.Status == "Trống")
                    //btn.BackColor = Color.White;
                    btn.Image = Image.FromFile("C:\\Users\\s0987\\source\\repos\\QLSuaChua\\QLSuaChua\\Resources\\banko.png");
                else
                    btn.Image = Image.FromFile("C:\\Users\\s0987\\source\\repos\\QLSuaChua\\QLSuaChua\\Resources\\banco.png");

                flp1.Controls.Add(btn);
            }
        }

        private void btnClick(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            listView1.Tag = (sender as Button).Tag;
            ShowBill(tableID);
        }

        #endregion

        #region Method
        void ShowBill(int id)
        {
            listView1.Items.Clear();
            List<Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            float totalPrice = 0;
            foreach (Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                listView1.Items.Add(lsvItem);
            }

            CultureInfo culture = new CultureInfo("vi-VN");
            textBox1.Text = totalPrice.ToString("c", culture);

            LoadTable();
        }
        #endregion


        #region Events
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;
                
            Category selected = cb.SelectedItem as Category;
            id = selected.ID;

            LoadFoodListByCategoryID(id);
        }

        private void btnaddfood_Click(object sender, EventArgs e)
        {
            try
            {
                Table tb = listView1.Tag as Table;
                int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(tb.ID);
                int foodID = (comboBox2.SelectedItem as Foodd).ID;
                int count = (int)nud1.Value;

                if (idBill == -1)
                {
                    BillDAO.Instance.InsertBill(tb.ID);
                    BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), foodID, count);
                }
                else
                {
                    BillInfoDAO.Instance.InsertBillInfo(idBill, foodID, count);
                }
                ShowBill(tb.ID);
                LoadTable();
            }
            catch (Exception)
            {

                MessageBox.Show("Vui lòng chọn bàn");
            }

        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            try
            {
                Table table = listView1.Tag as Table;
                int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
                double totalPrice = Convert.ToDouble(textBox1.Text.Split('.')[0])*1000;
                int discount = Convert.ToInt32(textBox2.Text.Split(',')[0]);
                double finalTotalPrice = totalPrice - discount;
                DataTable data = Connect.Instance.ExecuteQuery("Tablelist");
                if(finalTotalPrice==0)
                {
                    MessageBox.Show("Vui Lòng chọn món ăn!!!");
                }
                else if (idBill != -1)
                {
                    if (MessageBox.Show(string.Format("Bạn có chắc thanh toán hóa đơn cho {0}\n Tổng tiền: {1} - Giảm giá: {2} = Thành tiền: {3}", table.Name, totalPrice, discount, finalTotalPrice), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        BillDAO.Instance.CheckOut(idBill, discount, (float)finalTotalPrice);
                        ShowBill(table.ID);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng chọn bàn và món ăn trước khi thanh toán!!!");
            }          
        }
        #endregion

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Bạn có muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel);
            if (x == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void ngườiDùngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            User f = new User();
            this.Hide();
            f.ShowDialog();
        }

        private void thốngKêToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Statistic f = new Statistic();
            this.Hide();
            f.ShowDialog();
        }

        private void mónĂnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Food f = new Food();
            this.Hide();
            f.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
