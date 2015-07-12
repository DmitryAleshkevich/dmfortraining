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
        private readonly ToPerfomanceMapper _perfomanceMapper = new ToPerfomanceMapper();

        public List<Sale> GetSales()
        {
            var saleList = _contextSales.Sales.ToList();
            return saleList.Select(x => _mapper.ConvertEntity(x)).ToList();
        }

        public List<SalePerfomance> GetSalePerfomances()
        {
            return GetSales().Select(x => _perfomanceMapper.ConvertSaleToPerfomance(x)).ToList();
        }

        public void DeleteSale(int id)
        {
            var sale = _contextSales.Sales.FirstOrDefault(x => x.id == id);
            _contextSales.Sales.Remove(sale);
            _contextSales.SaveChanges();
        }        

        public Dictionary<string,double> GetManagerSales()
        {
            var dict = new Dictionary<string, double>();
            var data = _contextSales.Sales.Select(x => new {x.Managers.SecondName, x.sum});
            foreach (var item in data)
            {
                if (dict.ContainsKey(item.SecondName))
                {
                    dict[item.SecondName] += item.sum;
                }
                else
                {
                    dict.Add(item.SecondName, item.sum);
                }
            }
            return dict;
        }
    }
}
