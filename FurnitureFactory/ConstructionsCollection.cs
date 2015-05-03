using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureFactory
{
    public class ConstructionsCollection<T> : ICollection<T> where T: Constructions
    {
        #region Fields
        private string collectionName;
        private ICollection<T> constructionsItems = new List<T>();
        #endregion

        #region Properties
        public string CollectionName
        {
            get { return collectionName; }
            set { collectionName = value; }
        }
        #endregion

        #region Methods
        public void Add(T item)
        {
            constructionsItems.Add(item);    
        }

        public void Clear()
        {
            constructionsItems.Clear();
        }

        public bool Contains(T item)
        {
            return constructionsItems.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            constructionsItems.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return constructionsItems.Count; }
        }

        public bool IsReadOnly
        {
            get { return constructionsItems.IsReadOnly; }
        }

        public bool Remove(T item)
        {
            return constructionsItems.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return constructionsItems.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void SortByPrice()
        {
            constructionsItems = (constructionsItems.OrderBy(item => item.Price)).ToList<T>();
        }

        public IEnumerable<T> GetItemsForDiapasone(double lowprice, double highprice)
        {
            return constructionsItems.Where(item => (item.Price >= lowprice && item.Price <= highprice));
        }

        #endregion

    }
}
