using System;
using System.Reflection;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            MyFieldClassB myFieldObjectB = new MyFieldClassB();
            Product myFieldObjectA = new Product();

            Type myTypeA = typeof(Product);
            PropertyInfo myFieldInfo = myTypeA.GetProperty("ProductName");
            var s = myFieldInfo.Name;

            Type myTypeB = typeof(MyFieldClassB);
            FieldInfo myFieldInfo1 = myTypeB.GetField("field", BindingFlags.NonPublic | BindingFlags.Instance);

            Console.WriteLine("The value of the public field is: '{0}'", myFieldInfo);
            Console.WriteLine("The value of the private field is: '{0}'",
                myFieldInfo1.GetValue(myFieldObjectB));
        }
    }

    public class Product
    {
        public string ProductName { get; set; }
    }

    public class MyFieldClassB
    {
        private string field = "B Field";
        public string Field
        {
            get
            {
                return field;
            }
            set
            {
                if (field != value)
                {
                    field = value;
                }
            }
        }
    }
}
