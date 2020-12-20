namespace Bag_problem
{
    using System;

    public class Product
    {
        public Product(int weight, int value)
        {
            Weight = weight;
            Value = value;
        }

        public int Weight { get; set; }

        public int Value { get; set; }
    }
}
