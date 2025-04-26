
namespace EasyPDV.Entities
{
    public class Product
    {
        public int ID { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int StockQuantity { get; set; }
        public int StockSecurity { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public Product()
        {
        }
    }
}
