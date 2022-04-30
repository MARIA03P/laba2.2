using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2._2
{
    class Person
    {
        public int id;
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string street { get; set; }

        private int age;
        public int Age
        {
            get
            {
                return age;

            }
            set
            {

                if (value > 0 && value < 120)
                {
                    age = value;

                }
                else
                {
                    Exception ex = new Exception("age not corrected");
                    throw ex;
                }
            }
        }

        public Person(int id, string name, string email, string phone, int age, string street, string city)
        {
            this.id = id;
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
            this.Age = age;
            this.street = street;
            this.City = city;

        }
        public Person()
        {

        }
        public override string ToString()
        {
            string item = string.Empty;
            item = this.id + " " + this.Name + " " + this.Email + " " + this.Phone + " " + this.Age + " " + this.City + " " + this.street; 

            return item;
        }

    }
}
        

