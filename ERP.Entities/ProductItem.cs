using System.Drawing;

namespace ERP.Entities
{




    public class ProductItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Category { get; set; } = string.Empty;
        public string ImageFileName { get; set; } = string.Empty;
        public Color PrimaryColor { get; set; }
        public int Stock { get; set; } = 10;






        public object? CardPanel { get; set; }
    }
}
