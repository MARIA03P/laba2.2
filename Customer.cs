using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2._2
{
    class Customer
    {
        public string id { get; set; }
        public Person People { get; set; }
        public Product Product { get; set; }

        public override string ToString()
        {
            return id + " " + People.ToString() + " " + Product.ToString();
        }
    }
}
