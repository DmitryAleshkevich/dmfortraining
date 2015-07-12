using System;

namespace DataAccessLayer
{
    public abstract class AbstractSale
    {
        protected AbstractSale(float sum, DateTime date, int? id)
        {
            Sum = sum;
            Date = date;
            Id = id;
        }

        public int? Id { get; private set; }
        public DateTime Date { get; private set; }
        public float Sum { get; private set; }
    }
}