namespace OrderManager;

public class Order
{
    public string ProductName { get; private set; }
    public int Quantity { get; private set; }
    public string CustomerName { get; private set; }
    public string Address { get; private set; }
    public DateTime DeliveryDate { get; private set; }

    public Order( string productName, int quantity, string customerName, string address )
    {
        ProductName = productName;
        Quantity = quantity;
        CustomerName = customerName;
        Address = address;
        DeliveryDate = DateTime.UtcNow.AddDays( 3 );
    }
}
