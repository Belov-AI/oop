using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseLibrary
{
    public class Enterprise
    {
        Guid guid;

        public Guid getGuid() { return guid; }

        public Enterprise(Guid guid)
        {
            this.guid = guid;
        }

        string name;

        public string GetName() { return name; }

        public void SetName(string name) { this.name = name; }

        string inn;

        public string GetINN() { return inn; }

        public void SetINN(string inn)
        {
            if (inn.Length != 10)
                throw new ArgumentException();

            foreach (var ch in inn)
            {
                if (!char.IsDigit(ch))
                    throw new ArgumentException();
            }

            this.inn = inn;
        }

        DateTime establishDate;

        public DateTime GetEstablishDate()
        {
            return establishDate;
        }

        public void SetEstablishDate(DateTime establishDate)
        {
            this.establishDate = establishDate;
        }

        public TimeSpan GetActiveTimeSpan()
        {
            return DateTime.Now - establishDate;
        }

        public double GetTotalTransactionsAmount()
        {
            DataBase.OpenConnection();

            var amount = 0.0;

            foreach (var t in DataBase.GetTransactions())
                if(t.EnterpriseGuid == guid)
                    amount += t.Amount;

            return amount;
        }
    }
}
