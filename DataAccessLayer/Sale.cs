using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Sale
    {
        public Sale(DateTime date, Client client, Good good, Manager manager, float sum)
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
    }
}
