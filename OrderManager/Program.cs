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

    static void OrderDelivery( Order order )
    {
        Console.WriteLine( $"{order.CustomerName}! Ваш заказ {order.ProductName} в количестве {order.Quantity} оформлен! " +
                $"Ожидайте доставку по адресу {order.Address} к {order.DeliveryDate.ToLocalTime().ToShortDateString()}." );
    }

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
        string productName = GetNonEmptyStringFromConsole( "Введите название товара: ", "Неверный ввод. Название товара не может быть пустым. Попробуйте снова." );

        int quantity = GetValidProductQuantity( "Введите количество товара: ", "Неверный ввод. Введите целое положительное число. Попробуйте снова." );

        string customerName = GetNonEmptyStringFromConsole( "Введите Ваше имя: ", "Неверный ввод. Имя не может быть пустым. Попробуйте снова." );

        string address = GetNonEmptyStringFromConsole( "Введите адрес доставки: ", "Неверный ввод. Адрес доставки не может быть пустым. Попробуйте снова." );

        return new Order( productName: productName, quantity: quantity, customerName: customerName, address: address );
    }

    static string GetNonEmptyStringFromConsole( string message, string errorMessage )
    {
        string input;

        while ( true )
        {
            Console.Write( message );
            input = Console.ReadLine();

            if ( !string.IsNullOrWhiteSpace( input ) )
            {
                break;
            }

            Console.WriteLine( errorMessage );
        }

        return input;
    }

    static int GetValidProductQuantity( string message, string errorMessage )
    {
        int quantity;

        while ( true )
        {
            Console.Write( message );
            if ( int.TryParse( Console.ReadLine(), out quantity ) && quantity > 0 )
            {
                break;
            }

            Console.WriteLine( errorMessage );
        }

        return quantity;
    }
}