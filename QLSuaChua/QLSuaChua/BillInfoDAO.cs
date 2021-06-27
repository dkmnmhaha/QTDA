using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSuaChua
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance
        {
            get { if (instance == null) instance = new BillInfoDAO(); return BillInfoDAO.instance; }
            private set { BillInfoDAO.instance = value; }
        }

        private BillInfoDAO() { }

        public List<BillInfo> GetListBillInfo(int id)
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();

            DataTable data = Connect.Instance.ExecuteQuery("SELECT * FROM dbo.BillInfo WHERE idBill = " + id);

            foreach (DataRow item in data.Rows)
            {
                BillInfo info = new BillInfo(item);
                listBillInfo.Add(info);
            }

            return listBillInfo;
        }

        public void InsertBillInfo(int idBill, int idFood, int count)
        {
            Connect.Instance.ExecuteNonQuery("InsertBillInfo @idBill , @idFood , @count", new object[] { idBill, idFood, count });
        }

        public void DeleteFood(int id)
        {
            Connect.Instance.ExecuteNonQuery("Delete dbo.BillInfo where idFood = " + id);
        }

        public void DeleteFoodCategory(int id)
        {
            Connect.Instance.ExecuteNonQuery("Delete dbo.FoodCategory where id = " + id);
        }

        public void DeleteAccount(string user)
        {
            Connect.Instance.ExecuteNonQuery("Delete dbo.FoodCategory where UserName = " + user);
        }
    }
}
