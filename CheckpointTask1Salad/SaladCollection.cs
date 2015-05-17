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
            var tempitem = item as ISaladAddable;
            if (tempitem != null) tempitem.AddToSalad();
            else Console.WriteLine("The component {0} can`t be added to salad!");
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

        public void SortByWeight()
        {
            componentItems = componentItems.OrderBy(x => x.Weight).ToList<IComponent>();
        }

        public IEnumerable<IComponent> GetItemsDiapasoneForCalories(double lowvalue, double highvalue)
        {
            return componentItems.Where(x => (x.Calories >= lowvalue && x.Calories <= highvalue));
        }
        #endregion
    }
}
