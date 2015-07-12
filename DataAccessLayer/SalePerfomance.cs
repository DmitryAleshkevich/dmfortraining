using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SalePerfomance : AbstractSale
    {
        public SalePerfomance(DateTime date, string client, string good, string manager, float sum, int? id) : base(sum,date,id)
        {
            Client = client;
            Good = good;
            Manager = manager;
        }

        public string Client { get; private set; }
        public string Good { get; private set; }
        public string Manager { get; private set; }
         
    }
}
