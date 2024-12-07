using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;

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

public class Server
{
    private static List<Order> orders = new List<Order>();  // Список заказов

    public static void Main()
    {
        int port = 8080;
        TcpListener server = new TcpListener(IPAddress.Any, port);
        server.Start();
        Console.WriteLine("Сервер ожидает подключения...");

        while (true)
        {
            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("Клиент подключился.");
            NetworkStream stream = client.GetStream();

            // Чтение данных от клиента
            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string orderData = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            // Десериализация данных в объект Order (предположим, что данные передаются в виде строки)
            string[] data = orderData.Split(',');
            int id = int.Parse(data[0]);
            string productName = data[1];
            int quantity = int.Parse(data[2]);
            DateTime orderDate = DateTime.Parse(data[3]);

            Order order = new Order(id, productName, quantity, orderDate);
            orders.Add(order);

            // Отправка подтверждения клиенту
            string responseMessage = $"Заказ №{id} принят.";
            byte[] responseData = Encoding.UTF8.GetBytes(responseMessage);
            stream.Write(responseData, 0, responseData.Length);

            client.Close();
        }
    }
}
