using System;
using System.Collections.Generic;
// Интерфейс для склада
public interface IWarehouse
{
    void AddProduct(IProduct product);
    void RemoveProduct(string name);
    List<IProduct> FindProductsByName(string name);
    List<IProduct> FindProductsByCategory(string category);
    List<IProduct> FindProductsByQuantity(int quantity);
    List<IProduct> GetAllProducts();
}
