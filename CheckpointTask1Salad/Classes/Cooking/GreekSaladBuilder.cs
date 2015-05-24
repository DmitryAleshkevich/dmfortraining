using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckpointTask1Salad
{
    public class GreekSaladBuilder : ISaladBuilder
    {
        private SaladCollection greekSalad = new SaladCollection() { CollectionName = "Greek" };

        public void CookVegetables()
        {
            Console.WriteLine("Cooking vegetables...");
            IFabricComponents productfabric = new VegetableCreator();
            IComponent[] vegetables = new IComponent[]
                                        { 
                                            productfabric.CreateComponent(),
                                            productfabric.CreateComponent(),
                                            productfabric.CreateComponent(),
                                            productfabric.CreateComponent(),
                                            productfabric.CreateComponent()
                                        };

            SaladItemProperties[] properties = new SaladItemProperties[] 
                                                { new SaladItemProperties()
                                                    {   Calories = 840, 
                                                        Carbohydrates = 0.6, 
                                                        Proteins = 0.2, 
                                                        Name = "potato", 
                                                        Fats = 4.2, 
                                                        Taste = Tastes.Sweet, 
                                                        Vitamins = new List<Vitamins>() { Vitamins.A }, 
                                                        Weight = 840, 
                                                        Color = "Red" },
                                                 new SaladItemProperties()
                                                    {   Calories = 20.5, 
                                                        Carbohydrates = 0.7, 
                                                        Proteins = 0.1, 
                                                        Name = "red onion", 
                                                        Fats = 4.1, 
                                                        Taste = Tastes.Bitter, 
                                                        Vitamins = new List<Vitamins>() { Vitamins.B }, 
                                                        Weight = 36, 
                                                        Color = "Red" },
                                                 new SaladItemProperties()
                                                    {   Calories = 15, 
                                                        Carbohydrates = 0.65, 
                                                        Proteins = 0.11, 
                                                        Name = "cucumber", 
                                                        Fats = 3.13, 
                                                        Taste = Tastes.Salty, 
                                                        Vitamins = new List<Vitamins>() { Vitamins.D }, 
                                                        Weight = 100, 
                                                        Color = "Green" },
                                                 new SaladItemProperties()
                                                    {   Calories = 26, 
                                                        Carbohydrates = 1.3, 
                                                        Proteins = 0.1, 
                                                        Name = "yellow pepper", 
                                                        Fats = 4.9, 
                                                        Taste = Tastes.Sweet, 
                                                        Vitamins = new List<Vitamins>() { Vitamins.C }, 
                                                        Weight = 800, 
                                                        Color = "Yellow" },
                                                 new SaladItemProperties()
                                                    {   Calories = 296, 
                                                        Carbohydrates = 1.6, 
                                                        Proteins = 23.7, 
                                                        Name = "olive", 
                                                        Fats = 19, 
                                                        Taste = Tastes.Salty, 
                                                        Vitamins = new List<Vitamins>() { Vitamins.U }, 
                                                        Weight = 800, 
                                                        Color = "Green" }
                                                };
            for (int i = 0; i < 5; i++)
            {
                productfabric.InitializeComponent(ref vegetables[i], properties[i]);
                var chopedproduct = vegetables[i] as IChopable;
                if (chopedproduct != null) chopedproduct.Chope();

                this.greekSalad.Add(vegetables[i]);
            }            
        }

        public void CookCannedFood()
        {            
        }

        public void CookCheeses()
        {
            Console.WriteLine("Cooking cheeses...");
            IFabricComponents cheesesfabric = new CheesesCreator();
            IComponent fetaproduct = cheesesfabric.CreateComponent();
            SaladItemProperties properties = new SaladItemProperties()
                                                   {
                                                       Calories = 215,
                                                       Carbohydrates = 1.6,
                                                       Proteins = 4.2,
                                                       Name = "feta cheese",
                                                       Fats = 8.1,
                                                       Taste = Tastes.Sour,
                                                       Vitamins = new List<Vitamins>() { Vitamins.P },
                                                       Weight = 150
                                                   };
            cheesesfabric.InitializeComponent(ref fetaproduct, properties);
            var chopedproduct = fetaproduct as IChopable;
            if (chopedproduct != null) chopedproduct.Chope();
            this.greekSalad.Add(fetaproduct);
        }
       
        public void CookFish()
        {
        }

        public void CookGreens()
        {
            Console.WriteLine("Cooking greens...");
            IFabricComponents greenfabric = new GreensCreator();
            IComponent dillproduct = greenfabric.CreateComponent();
            SaladItemProperties properties = new SaladItemProperties()
                                                    {
                                                        Calories = 40,
                                                        Carbohydrates = 2.5,
                                                        Proteins = 0.5,
                                                        Name = "dill",
                                                        Fats = 6.3,
                                                        Taste = Tastes.Sour,
                                                        Vitamins = new List<Vitamins>() { Vitamins.P },
                                                        Weight = 100
                                                    };
            greenfabric.InitializeComponent(ref dillproduct, properties);
            var chopedproduct = dillproduct as IChopable;
            if (chopedproduct != null) chopedproduct.Chope();
            this.greekSalad.Add(dillproduct);            
        }

        public void CookGroats()
        {
        }

        public void CookMeat()
        {
        }

        public void CookSpices()
        {
            Console.WriteLine("Cooking spices...");
            IFabricComponents spicesfabric = new SpicesCreator();
            IComponent oliveoil = spicesfabric.CreateComponent();
            SaladItemProperties properties = new SaladItemProperties()
            {
                Calories = 153,
                Carbohydrates = 0,
                Proteins = 153,
                Name = "olive oil extra virgin",
                Fats = 0,
                Taste = Tastes.Sour,
                Vitamins = new List<Vitamins>() { Vitamins.P },
                Weight = 17
            };
            spicesfabric.InitializeComponent(ref oliveoil, properties);
            this.greekSalad.Add(oliveoil);  
        }

        public SaladCollection ReturnSalad()
        {
            Console.WriteLine("The salad is ready!");
            return greekSalad;
        }
    }
}
