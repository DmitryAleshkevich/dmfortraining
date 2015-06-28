using AutoMapper;
using Checkpoint4Service;
using System.Linq;

namespace DALClassLibrary.DAL
{
    public class Manager
    {
        private readonly SellsServiceDataEntities _contextServiceDataEntities = new SellsServiceDataEntities();

        public Manager(string secondName)
        {
            SecondName = secondName;
        }

        public string SecondName { get; private set; }

        public Managers ConvertToEntity()
        {
            if (_contextServiceDataEntities != null)
            {
                var entity = _contextServiceDataEntities.Managers.FirstOrDefault(x => x.SecondName == SecondName);
                if (entity != null)
                {
                    return entity;
                }
            }
            Mapper.CreateMap<Manager, Managers>();
            var manager = Mapper.Map<Manager, Managers>(this);
            if (_contextServiceDataEntities == null) return manager;
            _contextServiceDataEntities.Managers.Add(manager);
            _contextServiceDataEntities.SaveChanges();
            return manager;
        }
    }
}
