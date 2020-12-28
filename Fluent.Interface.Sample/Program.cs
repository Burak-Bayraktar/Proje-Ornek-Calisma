using System;

namespace Fluent.Interface.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            FluentProduct fluentProduct = new FluentProduct();
            var createProduct = fluentProduct
                                    .Name("Bisküvi")
                                    .UnitsInStock(3)
                                    .UnitsOnOrder(5)
                                    .UnitPrice(4.2m)
                                    .Discontinued(false)
                                    .Create();

            ////string[] table = fluentProduct.GetTableNames();

            //string name = FluentProduct.GetTableNameFromAttribute(typeof(Product));

            Console.ReadLine();
            //Console.WriteLine(createProduct);
        }
    }
}
