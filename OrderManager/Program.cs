using System.Threading.Channels;

namespace OrderManager;

internal class Program
{
    static void Main( string[] args )
    {
        Order order = CreateOrder();

        if ( OrderConfirm( order ) )
        {
            OrderDelivery( order );
            return;
        }

        OrderCancelation( order );
    }

    // Вынес в отдельный метод, т.к. в теории тут будет выполняться множество других методов
    static void OrderDelivery( Order order )
    {
        Console.WriteLine( $"{order.CustomerName}! Ваш заказ {order.ProductName} в количестве {order.Quantity} оформлен! " +
                $"Ожидайте доставку по адресу {order.Address} к {DateTime.UtcNow.AddDays( 3 ).ToLocalTime()}" );
    }

    // Вынес в отдельный метод, т.к. в теории тут будет выполняться множество других методов
    static void OrderCancelation( Order order )
    {
        Console.WriteLine( $"{order.CustomerName}, Ваш заказ {order.ProductName} в количестве {order.Quantity} отменен." );
    }

    static bool OrderConfirm( Order order )
    {
        Console.Write( $"Здравствуйте, {order.CustomerName}, вы заказали {order.Quantity} {order.ProductName} на адрес {order.Address}, все верно? Y/N: " );
        return Console.ReadLine().ToLower() == "y";
    }

    static Order CreateOrder()
    {
        Console.Write( "Введите название товара: " );
        string productName = Console.ReadLine();

        Console.Write( "Введите количество товара: " );
        int quantity;
        while ( !int.TryParse( Console.ReadLine(), out quantity ) || quantity <= 0 )
            Console.WriteLine( $"Неверный ввод. Введите целое положительное число: " );

        Console.Write( "Введите имя получателя: " );
        string customerName = Console.ReadLine();

        Console.Write( "Введите адрес доставки: " );
        string address = Console.ReadLine();

        return new Order( productName: productName, quantity: quantity, customerName: customerName, address: address );
    }
}

public class Order
{
    public Order( string productName,
                  int quantity,
                  string customerName,
                  string address
    )
    {
        ProductName = productName;
        Quantity = quantity;
        CustomerName = customerName;
        Address = address;
    }

    public string ProductName { get; private set; }
    public int Quantity { get; private set; }
    public string CustomerName { get; private set; }
    public string Address { get; private set; }
}