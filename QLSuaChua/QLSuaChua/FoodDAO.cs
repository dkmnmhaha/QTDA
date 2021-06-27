using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSuaChua
{
    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return FoodDAO.instance; }
            private set { FoodDAO.instance = value; }
        }

        private FoodDAO() { }

        public List<Foodd> GetFoodByCategoryID(int id)
        {
            List<Foodd> list = new List<Foodd>();

            string query = "select * from Food where idCategory = " + id;

            DataTable data = Connect.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Foodd food = new Foodd(item);
                list.Add(food);
            }

            return list;
        }

        public bool InsertFood(string name, int id, float price)
        {
            string query = string.Format("INSERT dbo.Food ( name, idCategory, price )VALUES  ( N'{0}', {1}, {2})", name, id, price);
            int result = Connect.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool InsertCategory(string name)
        {
            string query = string.Format("INSERT dbo.FoodCategory (name) VALUES  ( N'{0}')", name);
            int result = Connect.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateFood(int idFood, string name, int id, float price)
        {
            string query = string.Format("UPDATE dbo.Food SET name = N'{0}', idCategory = {1}, price = {2} WHERE id = {3}", name, id, price, idFood);
            int result = Connect.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteFood(int idFood)
        {
            BillInfoDAO.Instance.DeleteFood(idFood);

            string query = string.Format("Delete Food where id = {0}", idFood);
            int result = Connect.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteCategory(int id)
        {
            BillInfoDAO.Instance.DeleteFoodCategory(id);

            string query = string.Format("Delete FoodCategory where id = {0}", id);
            int result = Connect.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteAccount(string user)
        {
            BillInfoDAO.Instance.DeleteAccount(user);

            string query = string.Format("Delete Account where UserName = {0}", user);
            int result = Connect.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }

}

