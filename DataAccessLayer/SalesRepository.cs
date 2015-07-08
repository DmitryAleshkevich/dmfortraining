using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityModel;

namespace DataAccessLayer
{
    public class SalesRepository
    {
        private readonly SalesDalaEntities _contextSales = new SalesDalaEntities();
        private readonly ToEntityMapper _mapper = new ToEntityMapper();

        public List<Sale> GetSales()
        {
            var saleList = _contextSales.Sales.ToList();
            return saleList.Select(x => _mapper.ConvertEntity(x)).ToList();
        }

        public void SaveSales()
        {
            
        }
    }
}
