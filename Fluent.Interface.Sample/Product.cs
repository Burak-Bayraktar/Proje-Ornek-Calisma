using System.ComponentModel.DataAnnotations.Schema;

namespace Fluent.Interface.Sample
{
    [Table(name: "Products")]
    public class Product
    {
        public int? ProductID { get; set; }
        public int CategoryID { get; set; }
        public int SupplierID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsOnOrder { get; set; }
        public short UnitsInStock { get; set; }
        public bool? Discontinued { get; set; }
    }
}
