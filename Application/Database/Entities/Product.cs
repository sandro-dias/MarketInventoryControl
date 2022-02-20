using System.ComponentModel.DataAnnotations;

namespace Application.Database.Entities
{
    public class Product
    {
        public Product(int id, string name, string brand, decimal price, int quantity)
        {
            Id = id;
            Name = name;
            Brand = brand;
            Price = price;
            Quantity = quantity;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
