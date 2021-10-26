using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    public enum ExpirationDatePercent { LessThanTenDays = 30, MoreThanTenDays = 10 }
    internal class DiaryProducts : Product
    {
        private ExpirationDatePercent datePercent;

        public DiaryProducts(string name, double price, double weight, int expirationDate, DateTime creationDate)
            : base(name, price, weight, expirationDate, creationDate)
        {
            this.datePercent = expirationDate > 10 ? ExpirationDatePercent.MoreThanTenDays
               : ExpirationDatePercent.LessThanTenDays;
        }

        public DiaryProducts()
        {
            this.datePercent = ExpirationDatePercent.LessThanTenDays;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return base.ToString();

        }

        public override void ChangePrice(int percent)
        {
            if (percent < -100 || percent > 100)
            {
                throw new ArgumentException("Incorrect value of percent");
            }
            Price += Price * (percent / 100.0) * ((int)datePercent / 100.0);
        }
    }
}
