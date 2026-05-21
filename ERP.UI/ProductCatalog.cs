using ERP.BLL;
using ERP.Entities;
using System.Collections.Generic;

namespace ERP.UI
{





    public static class ProductCatalog
    {
        private static readonly ProductManager _productManager = new ProductManager();




        public static List<ProductItem> Products => _productManager.GetAllProducts();




        public static void UpdateStock(int id, int newStock)
        {
            _productManager.UpdateProductStock(id, newStock);
        }
    }
}
