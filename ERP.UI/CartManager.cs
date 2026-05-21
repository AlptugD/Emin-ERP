using System;
using System.Collections.Generic;
using ERP.Entities;

namespace ERP.UI
{
    public static class CartManager
    {
        public static List<CartItem> Items { get; } = new List<CartItem>();
        public static event Action? CartChanged;

        public static bool Add(ProductItem product)
        {
            var existing = Items.Find(i => i.Product.Name == product.Name);
            if (existing != null)
            {
                if (existing.Quantity >= product.Stock)
                {
                    return false;
                }
                existing.Quantity++;
            }
            else
            {
                if (product.Stock <= 0)
                {
                    return false;
                }
                Items.Add(new CartItem { Product = product, Quantity = 1 });
            }
            CartChanged?.Invoke();
            return true;
        }

        public static void Remove(ProductItem product)
        {
            var existing = Items.Find(i => i.Product.Name == product.Name);
            if (existing != null)
            {
                existing.Quantity--;
                if (existing.Quantity <= 0)
                {
                    Items.Remove(existing);
                }
            }
            CartChanged?.Invoke();
        }

        public static void Clear()
        {
            Items.Clear();
            CartChanged?.Invoke();
        }

        public static void TriggerChanged()
        {
            CartChanged?.Invoke();
        }
    }

    public class CartItem
    {
        public ProductItem Product { get; set; } = new ProductItem();
        public int Quantity { get; set; }
    }
}
