using System;
using System.Linq;
using Checkpoint4Service;

namespace DALClassLibrary.DAL
{
    public class Sell
    {
        private readonly SellsServiceDataEntities _contextServiceDataEntities = new SellsServiceDataEntities();

        public Sell(DateTime date, Client client, Good good, Manager manager, float sum)
        {
            Date = date;
            Client = client;
            Good = good;
            Manager = manager;
            Sum = sum;
        }

        public DateTime Date { get; private set; }
        public Client Client { get; private set; }
        public Good Good { get; private set; }
        public Manager Manager { get; private set; }
        public float Sum { get; private set; }

        public Sells ConvertToEntity()
        {            
            var sells = new Sells()
            {
                client = Client.ConvertToEntity().id,
                good = Good.ConvertToEntity().id,
                manager = Manager.ConvertToEntity().id,
                date = Date,
                sum = Sum
            };
            return sells;
        }

    }
}
