using System;
using System.Collections.Generic;
using System.Linq;
namespace Lab2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            ExcelReader excelReader = new ExcelReader();
            var peoples = excelReader.GetCustomersFromXlsxFile("text.xlsx");
            var products = peoples.Select(people => people.Product).ToList();

            //CheckUniqueId(peoples);
            //ComputeAverageAge(peoples);
            SortData(ref products);
            var cityes = MoveCity(peoples);
            foreach(var item in cityes)
            {
                Console.WriteLine(item.People.City); 

            }
            AddCustomer(ref peoples);
            foreach (var item in peoples)
            {
                Console.WriteLine(item.ToString());
            }
            
        }
        static void CheckUniqueId(List <Customer> customers)
        {
            Console.WriteLine("Уникальные продукты");
            for (int i = 0; i < customers.Count; i++)
            {
                for (int j = i+1; j < customers.Count; j++)
                {
                    if (customers [i].Product.ProductId.Equals( customers[j].Product.ProductId))
                    {
                        Console.WriteLine((i + 1).ToString() + "=" + (j+1).ToString());
                    }

                }

            }


        }
           
        static void ComputeAverageAge(List<Customer> customers)
        {
            int averege = 0;
            foreach(var item in customers)
            {
                averege += item.People.Age;
            }

            double av = (double)averege / customers.Count;
            Console.WriteLine("Средний возраст = " + av);
        }
        static void SortData(ref List<Product> products)
        {
            products.Sort(CompareProduct);
            foreach (var item in products)
            {
                Console.WriteLine(item.ProductId + "\t" + item.Tag + "\t" + item.Price);
            }

        }

        static int CompareProduct(Product p1, Product p2)
        {
            if (p1.Price > p2.Price) 
            {
                return 1;
            }
            if (p1.Price < p2.Price)
            {
                return -1;
            }
            return 0;
            
        }
        static List<Customer> MoveCity(List<Customer> customers)
        {
            return customers.Where(customer => customer.People.City == "Москва").ToList();
        }
        static void AddCustomer(ref List<Customer> customers)
        {
            int id, age, price;
            string name, phone, email, city, street, tag;

            Console.Write("введите имя: ");
            name = Console.ReadLine();
            while (true)
            {
                Console.Write("введите телефон: ");
                phone = Console.ReadLine();
                var item = customers.FirstOrDefault(t => t.People.Phone == phone);
                if (item != null)
                {
                    Console.WriteLine("Пользователь с таким телефоном уже существует");

                }
                else
                {
                    break;
                }

            }
           while (true)
            {
                Console.Write("введите имейл: ");
                email = Console.ReadLine();
                var item = customers.FirstOrDefault(t => t.People.Email == email);
                if (item != null)
                {
                    Console.WriteLine("Пользователь с таким имейлом уже существует");

                }
                else
                {
                    break;
                }
            }
          
            Console.Write("введите город; ");
            city = Console.ReadLine();
            Console.Write("введите улицу: ");
            street = Console.ReadLine();
            Console.Write("введите ваш возраст: ");
            age = int.Parse(Console.ReadLine());
            Console.Write("введите цену товара: ");
            price = int.Parse(Console.ReadLine());
            Console.Write("введите название товара: ");
            tag = Console.ReadLine();
            id = customers [customers.Count - 1].People.id +1;
            string customerId = GenerateId(26);
            string productId = GenerateId(19);
            Customer customer = new Customer();
            customer.People = new Person(id, name, email, phone, age, street, city);
            customer.id = customerId;
            customer.Product = new Product(productId, price, tag);
            customers.Add(customer);


            
        }
        public static string GenerateId(int len)
        {
            string id = string.Empty;
            string alfabet = "1234567890qwertyuiopasdfghjklzxcvbnm";
            Random rnd = new Random();
            for (int i = 0; i < len; i++)
            {
                id += alfabet[rnd.Next(0, alfabet.Length - 1)];
            }
            return id;
        }

    }

}
