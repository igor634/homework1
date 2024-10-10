using System;
using System.Collections.Generic;

abstract class Order 
{ 
    public int OrderNumber { get; set; }
    public string Name { get; set; }
    public List<(string ItemName, double ItemPrice, int Quantity)> Items { get; set; } = new List<(string, double, int)>();

    public virtual double CalculateTotalPrice() 
    { 
        double totalPrice = 0;
        foreach (var item in Items)
        {
            totalPrice += item.ItemPrice * item.Quantity;
        }
        return totalPrice;

    }
    public abstract void PrintOrder();
}

class Electronics : Order 
{ 
   public string DeviceType { get; set; }

   public Electronics(int orderNumber, string customerName, string deviceType) 
   {
        OrderNumber = orderNumber;
        CustomerName = customerName;
        DeviceType = deviceType;
    }

  
    public override void PrintOrderDetails()
    {
        Console.WriteLine($"Electronics Order: #{OrderNumber}, Customer: {CustomerName}, Device: {DeviceType}");
        foreach (var item in Items)
        {
            Console.WriteLine($"Item: {item.ItemName}, Price: {item.ItemPrice}, Quantity: {item.Quantity}");
        }
        Console.WriteLine($"Total Price: {CalculateTotalPrice():C}\n");
    }
}


class FurnitureOrder : Order
{
    public string FurnitureType { get; set; }

    public FurnitureOrder(int orderNumber, string customerName, string furnitureType)
    {
        OrderNumber = orderNumber;
        CustomerName = customerName;
        FurnitureType = furnitureType;
    }

    public override void PrintOrderDetails()
    {
        Console.WriteLine($"Furniture Order: #{OrderNumber}, Customer: {CustomerName}, Furniture: {FurnitureType}");
        foreach (var item in Items)
        {
            Console.WriteLine($"Item: {item.ItemName}, Price: {item.ItemPrice}, Quantity: {item.Quantity}");
        }
        Console.WriteLine($"Total Price: {CalculateTotalPrice():C}\n");
    }
}


class ClothingOrder : Order
{
    public string Size { get; set; }

    public ClothingOrder(int orderNumber, string customerName, string size)
    {
        OrderNumber = orderNumber;
        CustomerName = customerName;
        Size = size;
    }

    public override void PrintOrderDetails()
    {
        Console.WriteLine($"Clothing Order: #{OrderNumber}, Customer: {CustomerName}, Size: {Size}");
        foreach (var item in Items)
        {
            Console.WriteLine($"Item: {item.ItemName}, Price: {item.ItemPrice}, Quantity: {item.Quantity}");
        }
        Console.WriteLine($"Total Price: {CalculateTotalPrice():C}\n");
    }
}


class Program
{
    static void Main(string[] args)
    {
   
        ElectronicsOrder electronicsOrder = new ElectronicsOrder(1, "Alice", "Phone");
        electronicsOrder.Items.Add(("iPhone", 999.99, 2));

        FurnitureOrder furnitureOrder = new FurnitureOrder(2, "Bob", "Table");
        furnitureOrder.Items.Add(("Wooden Table", 299.99, 1));

        ClothingOrder clothingOrder = new ClothingOrder(3, "Charlie", "L");
        clothingOrder.Items.Add(("T-shirt", 19.99, 5));

        
        List<Order> orders = new List<Order> { electronicsOrder, furnitureOrder, clothingOrder };

        
        foreach (var order in orders)
        {
            order.PrintOrderDetails();
        }
    }
}