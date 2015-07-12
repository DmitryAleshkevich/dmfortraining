using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ToPerfomanceMapper
    {
        public Sale ConvertPerfomanceToSale(SalePerfomance salePerfomance)
        {
            return new Sale(salePerfomance.Date,new Client(salePerfomance.Client,null),new Good(salePerfomance.Good,""),new Manager(salePerfomance.Manager),salePerfomance.Sum,salePerfomance.Id);
        }

        public SalePerfomance ConvertSaleToPerfomance(Sale sale)
        {
            return new SalePerfomance(sale.Date,sale.Client.Name,sale.Good.Name,sale.Manager.SecondName,sale.Sum,sale.Id);
        }
    }
}
