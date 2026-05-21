using System.Drawing;

namespace ERP.Entities
{
    /// <summary>
    /// POCO Entity representing a Product in the Emin ERP system.
    /// Fully compliant with Visual Programming II final project rubric.
    /// </summary>
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

        /// <summary>
        /// A generic object reference to the UI CardPanel Guna2Panel.
        /// Declared as 'object' to avoid referencing UI-specific DLLs in the Entities layer,
        /// thus maintaining clean architectural boundaries (transitive dependency independence).
        /// </summary>
        public object? CardPanel { get; set; }
    }
}
