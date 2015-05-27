using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckpointTask1Salad
{
    public class SaladCollection : ICollection<IComponent>
    {

        #region Fields
        private string collectionName;
        private ICollection<IComponent> componentItems = new List<IComponent>();
        #endregion

        #region Properties
        public string CollectionName
        {
            get { return collectionName; }
            set { collectionName = value; }
        }
        #endregion

        #region Realization of ICollection
        public void Add(IComponent item)
        {
            componentItems.Add(item);
            item.AddToSalad();            
        }

        public void Clear()
        {
            componentItems.Clear();
        }

        public bool Contains(IComponent item)
        {
            return componentItems.Contains(item);
        }

        public void CopyTo(IComponent[] array, int arrayIndex)
        {
            componentItems.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return componentItems.Count; }
        }

        public bool IsReadOnly
        {
            get { return componentItems.IsReadOnly; }
        }

        public bool Remove(IComponent item)
        {
            return componentItems.Remove(item);
        }

        public IEnumerator<IComponent> GetEnumerator()
        {
            return componentItems.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion

        #region Methods
        public double CountCalories()
        {
            return componentItems.Sum<IComponent>(x => x.Calories);
        }

        public void Sort(Func<IComponent,object> keySelector)
        {
            componentItems = componentItems.OrderBy(keySelector).ToList<IComponent>();
        }

        public IEnumerable<IComponent> GetItemsRangeForCalories(double lowvalue, double highvalue)
        {
            return componentItems.Where(x => (x.Calories >= lowvalue && x.Calories <= highvalue));
        }
        #endregion
    }
}
