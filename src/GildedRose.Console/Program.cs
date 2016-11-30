using System.Collections.Generic;

namespace GildedRose.Console
{
    class Program
    {
        IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI! \n");

            var app = new Program()
            {
                Items = new List<Item>
                                        {
                                            new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                            new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                            new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                            new Item
                                                {
                                                    Name = "Backstage passes to a TAFKAL80ETC concert",
                                                    SellIn = 15,
                                                    Quality = 20
                                                },
                                            new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                        }

            };
            int amountOfDays = 11; // time period
            for (int i = 0; i < amountOfDays; i++)
                app.UpdateQuality();

            System.Console.WriteLine("After " + amountOfDays + " days quality of items is:");
            foreach (Item item in app.Items)
            {
                 System.Console.WriteLine(item.Name + ": "+ item.Quality);
            }
                
            
            System.Console.ReadKey();

        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                if (item.Name != "Sulfuras, Hand of Ragnaros") // decide if do anything
                {
                    if (item.Name == "Aged Brie" || item.Name == "Backstage passes to a TAFKAL80ETC concert") // decide if increment or decrement (increment)
                    {
                        var incrementQualityBy = 1;
                        if (item.Name == "Aged Brie" && item.Quality < 50)  // check if aged brie does not excide 50 
                        {
                            item.Quality += incrementQualityBy;
                        }
                        if (item.Name == "Backstage passes to a TAFKAL80ETC concert") // check if backstage
                        {
                            if (item.SellIn < 0) // set quality to 0 if item expires
                            {
                                item.Quality = 0;
                            }
                            else
                            {
                                if (item.SellIn <= 10 && item.SellIn > 5) // change increment value to 2
                                {
                                    incrementQualityBy = 2;
                                }
                                else if (item.SellIn <= 5) // change increment value to 3
                                {
                                    incrementQualityBy = 3;
                                }
                                if (item.Quality + incrementQualityBy >= 50) // in order not to excide 50
                                {
                                    incrementQualityBy = 50 - item.Quality;
                                }
                                item.Quality += incrementQualityBy;
                            }
                        }
                    }
                    else //decrement
                    {
                        var decrementQualityBy = 1;
                        if (item.SellIn < 0) // check if item not expired
                        {
                            decrementQualityBy *= 2;
                        }
                        if (item.Name.Contains("Conjured")) // Many items can be conjured so check if item is not conjured 
                        {
                            decrementQualityBy *= 2;
                        }
                        if (item.Quality - decrementQualityBy < 0) // check if following number won't excide 0 if so decrement by quality
                        {
                            decrementQualityBy = item.Quality;
                        }
                        item.Quality -= decrementQualityBy;
                    }
                    item.SellIn--;
                }
            }

        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
