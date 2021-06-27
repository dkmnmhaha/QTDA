using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QLSuaChua
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }

        public static int x = 80;

        private TableDAO() { }

        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table>();

            DataTable data = Connect.Instance.ExecuteQuery("Tablelist");

            foreach (DataRow item in data.Rows)
            {
                Table tb = new Table(item);
                tableList.Add(tb);
            }

            return tableList;
        }
    }
}
