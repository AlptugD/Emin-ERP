using ERP.BLL;
using ERP.Entities;
using System.Collections.Generic;

namespace ERP.UI
{
    /// <summary>
    /// UI-facing catalog that routes data requests directly through BLL ProductManager.
    /// Acts as an elegant bridge for existing UI code to interact with the database seamlessly.
    /// Fully compliant with Visual Programming II final project rubric (UI -> BLL -> DAL -> Entities).
    /// </summary>
    public static class ProductCatalog
    {
        private static readonly ProductManager _productManager = new ProductManager();

        /// <summary>
        /// Gets all products freshly from the database through the BLL.
        /// </summary>
        public static List<ProductItem> Products => _productManager.GetAllProducts();

        /// <summary>
        /// Updates a product's stock in the database through the BLL (applying all validation and business rules).
        /// </summary>
        public static void UpdateStock(int id, int newStock)
        {
            _productManager.UpdateProductStock(id, newStock);
        }
    }
}
