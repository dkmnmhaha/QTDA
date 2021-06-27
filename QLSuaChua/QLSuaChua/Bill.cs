using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QLSuaChua
{
    class Bill
    {
        public Bill(int id, DateTime? dataCheckin, DateTime? dataCheckOut, int status)
        {
            this.ID = id;
            this.DateCheckIn = dataCheckin;
            this.DateCheckOut = dataCheckOut;
            this.Status = status;
        }

        public Bill(DataRow row)
        {
            this.ID = (int)row["id"];
            this.DateCheckIn = (DateTime?)row["dateCheckin"];

            var dateCheckOutTemp = row["dateCheckOut"];
            if (dateCheckOutTemp.ToString() != "")
            this.DateCheckOut = (DateTime?)dateCheckOutTemp;
            this.Status = (int)row["status"];
        }

        private int status;
        private DateTime? dateCheckOut;
        private DateTime? dateCheckIn;
        public DateTime? DateCheckIn
        {
            get => dateCheckIn;
            set => dateCheckIn = value;
        }

        private int iD;
        public int ID { get => iD; set => iD = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public int Status { get => status; set => status = value; }
    }
}
