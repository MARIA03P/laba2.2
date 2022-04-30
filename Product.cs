using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2._2
{
    class Product
    {
        public Product(string productId, int price, string tag)
        {
            ProductId = productId;
            Price = price;
            Tag = tag;
        }

        public string ProductId { get; set; }
        public int Price { get; set; }
        public string Tag { get; set; }
        

        internal void Add(Product product)
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            string item = string.Empty;
            item = this.ProductId + " " + this.Tag + " " + this.Price;
            return item;
        }
    }
}
