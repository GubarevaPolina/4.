using System;
using System.Collections.Generic;
// Èםעונפויס הכÿ עמגאנא
public interface IProduct
{
    string Name { get; }
    string Category { get; }
    int Quantity { get; }
    void DisplayInfo();
}