using System;
using System.Collections.Generic;

// ����� ������
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
        Console.WriteLine($"��������: {Name}, ���������: {Category}, ����������: {Quantity}");
    }
}
