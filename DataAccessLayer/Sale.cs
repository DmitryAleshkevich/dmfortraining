using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Sale : AbstractSale
    {
        public Sale(DateTime date, Client client, Good good, Manager manager, float sum, int? id) : base(sum,date,id)
        {            
            Client = client;
            Good = good;
            Manager = manager;
        }

        public Client Client { get; private set; }
        public Good Good { get; private set; }
        public Manager Manager { get; private set; }                
    }
}
