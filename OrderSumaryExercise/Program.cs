using System.Globalization;
using OrderSumaryExercise.Entities;
using OrderSumaryExercise.Entities.Enums;

namespace OrderSumaryExercise;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter cliente data: ");
        Console.Write("Name: ");
        string clientName = Console.ReadLine();
        
        Console.Write("Email: ");
        string clientEmail = Console.ReadLine();

        Console.Write("Birth date (DD/MM/YYYY): ");
        DateOnly clientBirthDate = DateOnly.Parse(Console.ReadLine());

        Client client = new Client(clientName, clientEmail, clientBirthDate);
        
        Console.WriteLine("----------------------------------------------------------------");

        Console.WriteLine("Enter order data: ");
        
        Console.Write("Status: ");
        OrderStatus orderStatus = Enum.Parse<OrderStatus>(Console.ReadLine());

        Order order = new Order(DateTime.Now, orderStatus, client);

        Console.Write("How many items to this order? ");
        int itemsQty = int.Parse(Console.ReadLine());

        for (int i = 0; i < itemsQty; i++)
        {
            Console.WriteLine($"Enter #{i + 1} item data:");
            Console.Write("Product name: ");
            string productName = Console.ReadLine();
            
            Console.Write("Product price: ");
            double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            
            Product product = new Product(productName, productPrice);
            OrderItem orderItem = new OrderItem(quantity, productPrice, product);
            
            order.AddItem(orderItem);
        }

        Console.WriteLine(order.ToString());
        
    }
}