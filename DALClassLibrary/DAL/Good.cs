using System.Linq;
using AutoMapper;
using Checkpoint4Service;

namespace DALClassLibrary.DAL
{
    public class Good
    {
        private readonly SellsServiceDataEntities _contextServiceDataEntities = new SellsServiceDataEntities();

        public Good(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }

        public Goods ConvertToEntity()
        {
            if (_contextServiceDataEntities != null)
            {
                var entity =
                    _contextServiceDataEntities.Goods.FirstOrDefault(x => x.name == Name && x.description == Description);
                if (entity != null)
                {
                    return entity;
                }
            }
            Mapper.CreateMap<Good, Goods>();
            var good = Mapper.Map<Good, Goods>(this);
            if (_contextServiceDataEntities == null) return good;
            _contextServiceDataEntities.Goods.Add(good);
            _contextServiceDataEntities.SaveChanges();
            return good;
        }

    }
}
