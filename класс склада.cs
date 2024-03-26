using System;
using System.Collections.Generic;
// Класс склада
public class Warehouse : IWarehouse
{
    private List<IProduct> products = new List<IProduct>();

    public void AddProduct(IProduct product)
    {
        if (products.Exists(p => p.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine($"Товар с названием '{product.Name}' уже существует на складе. Пожалуйста, выберите другое название.");
            return;
        }

        products.Add(product);
        Console.WriteLine($"Товар '{product.Name}' добавлен на склад.");
    }

    public void RemoveProduct(string name)
    {
        var productToRemove = products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (productToRemove != null)
        {
            products.Remove(productToRemove);
            Console.WriteLine($"Товар '{name}' удален со склада.");
        }
        else
        {
            Console.WriteLine($"Товар '{name}' не найден на складе.");
        }
    }

    public List<IProduct> FindProductsByName(string name)
    {
        return products.FindAll(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public List<IProduct> FindProductsByCategory(string category)
    {
        return products.FindAll(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
    }

    public List<IProduct> FindProductsByQuantity(int quantity)
    {
        return products.FindAll(p => p.Quantity == quantity);
    }

    public List<IProduct> GetAllProducts()
    {
        return products;
    }
}