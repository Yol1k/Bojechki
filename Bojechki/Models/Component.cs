namespace Bojechki.Models
{
    public class Component
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Retail_Price { get; set; }
        public decimal Purchase_Price { get; set; }
        public int Stock_Quantity { get; set; }
    }
}