using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Client
    {
        public Client(string name, int? account)
        {
            Name = name;
            Account = account;
        }
        
        public string Name { get; private set; }
        public int? Account { get; private set; }        
    }
}
