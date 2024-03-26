using System;
using System.Collections.Generic;

// Класс товара
public class Product : IProduct
{
    public string Name { get; }
    public string Category { get; }
    public int Quantity { get; }

    public Product(string name, string category, int quantity)
    {
        Name = name;
        Category = category;
        Quantity = quantity;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Название: {Name}, Категория: {Category}, Количество: {Quantity}");
    }
}
