using System;
using System.Collections.Generic;
// ��������� ��� ������
public interface IProduct
{
    string Name { get; }
    string Category { get; }
    int Quantity { get; }
    void DisplayInfo();
}