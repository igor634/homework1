using System;
using System.Net.Sockets;
using System.Text;

public class Order
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public DateTime OrderDate { get; set; }

    public Order(int id, string productName, int quantity, DateTime orderDate)
    {
        Id = id;
        ProductName = productName;
        Quantity = quantity;
        OrderDate = orderDate;
    }
}

public class Client
{
    public static void Main()
    {
        string serverAddress = "127.0.0.1";  // Адрес сервера
        int port = 8080;

        // Создаем заказ
        Order order = new Order(1, "Продукт 1", 5, DateTime.Now);
        string orderData = $"{order.Id},{order.ProductName},{order.Quantity},{order.OrderDate}";

        TcpClient client = new TcpClient(serverAddress, port);
        NetworkStream stream = client.GetStream();

        // Отправляем заказ
        byte[] data = Encoding.UTF8.GetBytes(orderData);
        stream.Write(data, 0, data.Length);
        Console.WriteLine("Заказ отправлен на сервер.");

        // Получаем ответ от сервера
        byte[] buffer = new byte[1024];
        int bytesRead = stream.Read(buffer, 0, buffer.Length);
        string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
        Console.WriteLine("Ответ от сервера: " + response);

        client.Close();
    }
}