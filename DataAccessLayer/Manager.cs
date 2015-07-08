using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Manager
    {
        public Manager(string secondName)
        {
            SecondName = secondName;
        }
        public string SecondName { get; private set; }        
    }
}
