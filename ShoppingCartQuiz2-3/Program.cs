using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShoppingCartQuiz2_3
{
    class Product
    {
        public int Id;
        public string Name;
        public double Price;
        public int Stock;
        public string Category;

        public void Show()
        {
            Console.WriteLine(Id + ". " + Name + " - ₱" + Price + " (Stock: " + Stock + ")");
        }

        public double GetItemTotal(int qty) => qty * Price;
        public bool HasEnoughStock(int qty) => qty <= Stock;
        public void DeductStock(int qty) => Stock -= qty;
    }

    class CartItem
    {
        public Product Product;
        public int Quantity;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Product[] products = {
                new Product { Id = 1, Name = "Laptop", Price = 30000, Stock = 5, Category="Electronics"},
                new Product { Id = 2, Name = "Mouse", Price = 500, Stock = 10, Category="Electronics"}
            };

            CartItem[] cart = new CartItem[5];
            int cartCount = 0;

            Console.WriteLine("=== PRODUCTS ===");
            foreach (var p in products) p.Show();

            Console.Write("Enter product ID: ");
            int id = int.Parse(Console.ReadLine());

            Product selected = products[id - 1];

            Console.Write("Enter quantity: ");
            int qty = int.Parse(Console.ReadLine());

            if (selected.HasEnoughStock(qty))
            {
                cart[cartCount++] = new CartItem { Product = selected, Quantity = qty };
                selected.DeductStock(qty);

                Console.WriteLine("Added to cart!");
            }
            else
            {
                Console.WriteLine("Not enough stock.");
            }
        }
    }
}
