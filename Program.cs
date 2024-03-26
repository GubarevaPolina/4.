using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        IWarehouse warehouse = new Warehouse();

        while (true)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1. Добавить товар");
            Console.WriteLine("2. Удалить товар");
            Console.WriteLine("3. Отобразить товары");
            Console.WriteLine("4. Поиск товаров");
            Console.WriteLine("5. Выход");
            Console.Write("Введите номер действия: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Ошибка ввода. Пожалуйста, введите номер.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddProduct(warehouse);
                    break;
                case 2:
                    RemoveProduct(warehouse);
                    break;
                case 3:
                    DisplayProducts(warehouse.GetAllProducts());
                    break;
                case 4:
                    SearchProducts(warehouse);
                    break;
                case 5:
                    Console.WriteLine("Выход...");
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Пожалуйста, выберите действие из списка.");
                    break;
            }
        }
    }

    static void AddProduct(IWarehouse warehouse)
    {
        Console.Write("Введите название товара: ");
        string name = Console.ReadLine();

        if (warehouse.GetAllProducts().Exists(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine($"Товар с названием '{name}' уже существует на складе. Пожалуйста, выберите другое название.");
            return;
        }

        Console.Write("Введите категорию товара: ");
        string category = Console.ReadLine();

        Console.Write("Введите количество товара: ");
        int quantity;
        while (!int.TryParse(Console.ReadLine(), out quantity))
        {
            Console.WriteLine("Ошибка ввода. Пожалуйста, введите корректное количество.");
            Console.Write("Введите количество товара: ");
        }

        warehouse.AddProduct(new Product(name, category, quantity));
    }

    static void RemoveProduct(IWarehouse warehouse)
    {
        Console.Write("Введите название товара для удаления: ");
        string name = Console.ReadLine();
        warehouse.RemoveProduct(name);
    }

    static void SearchProducts(IWarehouse warehouse)
    {
        Console.WriteLine("\nПоиск товаров по:");
        Console.WriteLine("1. Названию");
        Console.WriteLine("2. Категории");
        Console.WriteLine("3. Количеству");
        Console.Write("Введите номер действия: ");

        int choice;
        if (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.WriteLine("Ошибка ввода. Пожалуйста, введите номер.");
            return;
        }

        switch (choice)
        {
            case 1:
                Console.Write("Введите название товара: ");
                string name = Console.ReadLine();
                DisplayProducts(warehouse.FindProductsByName(name));
                break;
            case 2:
                Console.Write("Введите категорию товара: ");
                string category = Console.ReadLine();
                DisplayProducts(warehouse.FindProductsByCategory(category));
                break;
            case 3:
                Console.Write("Введите количество товара: ");
                int quantity;
                while (!int.TryParse(Console.ReadLine(), out quantity))
                {
                    Console.WriteLine("Ошибка ввода. Пожалуйста, введите корректное количество.");
                    Console.Write("Введите количество товара: ");
                }
                DisplayProducts(warehouse.FindProductsByQuantity(quantity));
                break;
            default:
                Console.WriteLine("Неверный выбор. Пожалуйста, выберите действие из списка.");
                break;
        }
    }

    static void DisplayProducts(IEnumerable<IProduct> products)
    {
        Console.WriteLine("\nТовары на складе:");
        foreach (var product in products)
        {
            product.DisplayInfo();
        }
    }
}
