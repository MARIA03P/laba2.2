using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2._2
{
    class ExcelReader
    {


        public ExcelReader()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public List<Customer> GetCustomersFromXlsxFile(string path)
        {
            List<Customer> people = new List<Customer>();
            FileInfo existingFile = new FileInfo(path);
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                //get the first worksheet in the workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                int colCount = worksheet.Dimension.End.Column;  //get Column Count
                int rowCount = worksheet.Dimension.End.Row;     //get row count
                for (int row = 2; row <= rowCount; row++)
                {
                    string name = worksheet.Cells[row, 2].Value?.ToString();
                    string email = worksheet.Cells[row, 3].Value?.ToString();
                    string phone = worksheet.Cells[row, 4].Value?.ToString();
                    int age = int.Parse(worksheet.Cells[row, 5].Value?.ToString());
                    int id = int.Parse(worksheet.Cells[row, 1].Value?.ToString());
                    string city = worksheet.Cells[row, 6].Value?.ToString();
                    string street = worksheet.Cells[row, 7].Value?.ToString();
                    string productId = worksheet.Cells[row, 11].Value?.ToString();
                    int price = int.Parse(worksheet.Cells[row, 9].Value?.ToString());
                    string tag = worksheet.Cells[row, 8].Value?.ToString();
                    string customerId = worksheet.Cells[row, 10].Value?.ToString();
                    Product product = new Product(productId, price, tag);
                    Person person = new Person(id, name, email, phone, age, street, city);
                    Customer customer = new Customer()
                    {
                        id = customerId,
                        Product = product,
                        People = person

                    };
                    people.Add(customer);

                }
            }
            return people;
        }

        public static List<Product> GetProductsFromXlsxFile(string path)
        {
            List<Product> product = new List<Product>();
            FileInfo existingFile = new FileInfo(path);
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                //get the first worksheet in the workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                int colCount = worksheet.Dimension.End.Column; 
                int rowCount = worksheet.Dimension.End.Row;     //get row count
                for (int row = 2; row <= rowCount; row++)
                {
                    string productId = worksheet.Cells[row, 11].Value?.ToString();
                    int price = int.Parse (worksheet.Cells[row, 9].Value?.ToString());
                    string tag = worksheet.Cells[row, 8].Value?.ToString();

                    product.Add(new Product(productId, price, tag));

                }
            }
            return product;

        }
        
        
    }
}

    
