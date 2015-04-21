using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProblem2
{
    public class Item : IAnyItem
    {
        #region Fields

        private string itemName;
        private double price;
        private double quantity;

        #endregion

        #region Properties

        public double Cost
        {
            get { return this.price * this.quantity; }
        }

        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public double Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        #endregion

        #region Methods

        public IAnyItem CreateItem(string name, double price, double quantity)
        {
            return new Item(name, price, quantity);
        }

        #endregion

        #region Constructors

        public Item() { }

        public Item(string itemName, double price, double quantity)
        {
            this.itemName = itemName;
            this.price = price;
            this.quantity = quantity;
        }

        #endregion
    }

    public struct StrItem : IAnyItem
    {
        #region Fields

        private string itemName;
        private double price;
        private double quantity;

        #endregion

        #region Properties

        public double Cost
        {
            get { return this.price * this.quantity; }
        }

        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public double Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        #endregion

        #region Methods

        public IAnyItem CreateItem(string name, double price, double quantity)
        {
            return new StrItem(name, price, quantity);
        }

        #endregion

        #region Constructors

        public StrItem(string itemName, double price, double quantity)
        {
            this.itemName = itemName;
            this.price = price;
            this.quantity = quantity;
        }

        #endregion
    }
}