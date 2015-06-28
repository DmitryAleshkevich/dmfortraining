using System.Collections.Generic;
using System.Linq;
using Checkpoint4Service;

namespace DALClassLibrary.DAL
{
    public class SellsRepository : ICollection<Sell>
    {
        private readonly ICollection<Sell> _sellslist = new List<Sell>();

        private readonly SellsServiceDataEntities _contextServiceDataEntities = new SellsServiceDataEntities();

        #region ICollection Realization
        public void Add(Sell item)
        {
           _sellslist.Add(item);
        }

        public void Clear()
        {
            _sellslist.Clear();
        }

        public bool Contains(Sell item)
        {
            return _sellslist.Contains(item);
        }

        public void CopyTo(Sell[] array, int arrayIndex)
        {
            _sellslist.CopyTo(array,arrayIndex);
        }

        public int Count
        {
            get { return _sellslist.Count; }
        }

        public bool IsReadOnly
        {
            get { return _sellslist.IsReadOnly; }
        }

        public bool Remove(Sell item)
        {
            return _sellslist.Remove(item);
        }

        public IEnumerator<Sell> GetEnumerator()
        {
            return _sellslist.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion

        public void SaveSells()
        {
            var newlist = _sellslist.Select(sell => sell.ConvertToEntity()).ToList();
            _contextServiceDataEntities.Sells.AddRange(newlist);
            _contextServiceDataEntities.SaveChanges();
        }
    }
}
