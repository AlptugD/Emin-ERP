using ERP.DAL;
using ERP.Entities;
using System;
using System.Collections.Generic;

namespace ERP.BLL
{




    public class ProductManager
    {
        private readonly ProductDal _productDal;

        public ProductManager()
        {
            _productDal = new ProductDal();
        }

        public List<ProductItem> GetAllProducts()
        {
            try
            {
                return _productDal.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Ürün listesi alınırken iş mantığı hatası oluştu: " + ex.Message, ex);
            }
        }

        public ProductItem? GetProductById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Geçersiz ürün kimliği (Id sıfırdan büyük olmalıdır).");
            }

            try
            {
                return _productDal.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Ürün detayı alınırken iş mantığı hatası oluştu: " + ex.Message, ex);
            }
        }

        public void AddProduct(ProductItem product)
        {

            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Ürün nesnesi boş olamaz.");
            }
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                throw new ArgumentException("Ürün adı boş olamaz.");
            }
            if (string.IsNullOrWhiteSpace(product.Brand))
            {
                throw new ArgumentException("Ürün markası boş olamaz.");
            }
            if (product.Price < 0)
            {
                throw new ArgumentException("Ürün fiyatı negatif olamaz.");
            }
            if (product.Stock < 0)
            {
                throw new ArgumentException("Ürün başlangıç stoğu negatif olamaz.");
            }

            try
            {
                _productDal.Insert(product);
            }
            catch (Exception ex)
            {
                throw new Exception("Ürün eklenirken iş mantığı hatası oluştu: " + ex.Message, ex);
            }
        }

        public void UpdateProduct(ProductItem product)
        {

            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Ürün nesnesi boş olamaz.");
            }
            if (product.Id <= 0)
            {
                throw new ArgumentException("Güncellenecek geçerli bir ürün kimliği (Id) belirtilmelidir.");
            }
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                throw new ArgumentException("Ürün adı boş olamaz.");
            }
            if (string.IsNullOrWhiteSpace(product.Brand))
            {
                throw new ArgumentException("Ürün markası boş olamaz.");
            }
            if (product.Price < 0)
            {
                throw new ArgumentException("Ürün fiyatı negatif olamaz.");
            }
            if (product.Stock < 0)
            {
                throw new ArgumentException("Ürün stoğu negatif olamaz.");
            }

            try
            {
                _productDal.Update(product);
            }
            catch (Exception ex)
            {
                throw new Exception("Ürün güncellenirken iş mantığı hatası oluştu: " + ex.Message, ex);
            }
        }

        public void UpdateProductStock(int id, int newStock)
        {

            if (id <= 0)
            {
                throw new ArgumentException("Geçersiz ürün kimliği.");
            }
            if (newStock < 0)
            {
                throw new ArgumentException("Stok miktarı sıfırdan küçük olamaz.");
            }

            try
            {
                _productDal.UpdateStock(id, newStock);
            }
            catch (Exception ex)
            {
                throw new Exception("Ürün stoğu güncellenirken iş mantığı hatası oluştu: " + ex.Message, ex);
            }
        }

        public void RemoveProduct(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Geçersiz ürün kimliği.");
            }

            try
            {
                _productDal.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Ürün silinirken iş mantığı hatası oluştu: " + ex.Message, ex);
            }
        }
    }
}
