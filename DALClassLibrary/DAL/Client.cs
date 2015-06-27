using System.Linq;
using AutoMapper;
using Checkpoint4Service;

namespace DALClassLibrary.DAL
{
    public class Client
    {
        public Client(string name, int? account)
        {
            Name = name;
            Account = account;
        }

        private readonly SellsServiceDataEntities _contextServiceDataEntities = new SellsServiceDataEntities();

        public string Name { get; private set; }
        public int? Account { get; private set; }

        public Clients ConvertToEntity()
        {
            if (_contextServiceDataEntities != null)
            {
                var entity = _contextServiceDataEntities.Clients.FirstOrDefault(x => x.name == Name && x.account == Account);
                if (entity != null)
                {
                    return entity;
                }
            }
            Mapper.CreateMap<Client, Clients>();
            return Mapper.Map<Client, Clients>(this);
        }
    }
}
