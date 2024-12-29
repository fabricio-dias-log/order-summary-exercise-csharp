using System.Globalization;
using System.Text;
using OrderSumaryExercise.Entities.Enums;

namespace OrderSumaryExercise.Entities;

public class Order
{
    public DateTime Moment { get; set; }
    public OrderStatus Status { get; set; }
    public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    
    public Client Client { get; set; } = new Client();

    public Order()
    {
        
    }

    public Order(DateTime moment, OrderStatus status, Client client)
    {
        Moment = moment;
        Status = status;
        Client = client;
    }

    public void AddItem(OrderItem item)
    {
        Items.Add(item);
    }

    public void RemoveItem(OrderItem item)
    {
        Items.Remove(item);
    }

    public double Total()
    {
        double total = 0;

        foreach (OrderItem item in Items)
        {
            total += item.SubTotal();
        }
        
        return total;  
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"!!-------------------------ORDER SUMMARY----------------------!!");
        sb.AppendLine($"Order moment: {Moment}");
        sb.AppendLine($"Order status: {Status}");
        sb.AppendLine($"Client: {Client.Name} ({Client.BirthDate}) - {Client.Email}");
        sb.AppendLine($"!!-------------------------Order Items------------------------!!");
        foreach (OrderItem item in Items)
        {
            sb.AppendLine(
                $"{item.Product.Name}, ${item.Product.Price.ToString("F2", CultureInfo.InvariantCulture)}, Quantity: {item.Quantity}, SubTotal: ${item.SubTotal().ToString("F2", CultureInfo.InvariantCulture)}");
        }
        
        sb.AppendLine($"Total price: ${Total().ToString("F2", CultureInfo.InvariantCulture)}");
        
        return sb.ToString();
    }
}