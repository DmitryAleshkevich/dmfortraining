using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EntityModel;

namespace DataAccessLayer
{
    public class ToEntityMapper
    {
        private readonly SalesDalaEntities _contextSales = new SalesDalaEntities();

        public ToEntityMapper()
        {
            Mapper.CreateMap<Client, Clients>();
            Mapper.CreateMap<Good, Goods>();
            Mapper.CreateMap<Manager, Managers>();
            Mapper.CreateMap<Clients, Client>();
            Mapper.CreateMap<Goods, Good>();
            Mapper.CreateMap<Managers, Manager>();
        }

        private Clients SaveClientToEntity(Client client)
        {
            var entity = _contextSales.Clients.FirstOrDefault(x => x.name == client.Name && x.account == client.Account);
            if (entity != null)
            {
                return entity;
            }
            var clients = Mapper.Map<Client, Clients>(client);
            _contextSales.Clients.Add(clients);
            _contextSales.SaveChanges();
            return clients;
        }

        private Goods SaveGoodToEntity(Good good)
        {
            var entity = _contextSales.Goods.FirstOrDefault(x => x.name == good.Name && x.description == good.Description);
            if (entity != null)
            {
                return entity;
            }

            var goods = Mapper.Map<Good, Goods>(good);
            _contextSales.Goods.Add(goods);
            _contextSales.SaveChanges();
            return goods;
        }

        private Managers SaveManagerToEntity(Manager manager)
        {
            var entity = _contextSales.Managers.FirstOrDefault(x => x.SecondName == manager.SecondName);
            if (entity != null)
            {
                return entity;
            }
            var managers = Mapper.Map<Manager, Managers>(manager);
            _contextSales.Managers.Add(managers);
            _contextSales.SaveChanges();
            return managers;
        }

        public void SaveToEntity(Sale sale)
        {
            var sales = new Sales()
            {
                client = SaveClientToEntity(sale.Client).id,
                good = SaveGoodToEntity(sale.Good).id,
                manager = SaveManagerToEntity(sale.Manager).id,
                date = sale.Date,
                sum = sale.Sum
            };
            _contextSales.Sales.Add(sales);
            _contextSales.SaveChanges();
        }

        private Client ConvertEntityToClient(Clients clients)
        {
            var client = Mapper.Map<Clients, Client>(clients);
            return client;
        }

        private Good ConvertEntityToGood(Goods goods)
        {
            var good = Mapper.Map<Goods, Good>(goods);
            return good;
        }

        private Manager ConvertEntityToManager(Managers managers)
        {
            var manager = Mapper.Map<Managers, Manager>(managers);
            return manager;
        }

        public Sale ConvertEntity(Sales sales)
        {
            return new Sale(sales.date, ConvertEntityToClient(sales.Clients), ConvertEntityToGood(sales.Goods), ConvertEntityToManager(sales.Managers), (float)sales.sum);           
        }

    }
}
