namespace Bag_problem
{
    using System.Collections.Generic;

    public class Bag
    {
        public Bag(int maxWeight)
        {
            MaxWeight = maxWeight;
            this.Products = new List<Product>();
        }

        public int MaxWeight { get; set; }

        public List<Product> Products { get; set; }
    }
}
