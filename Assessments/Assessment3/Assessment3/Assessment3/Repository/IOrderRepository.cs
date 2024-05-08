using Assessment3.Models;

namespace Assessment3.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int orderId);
        void PlaceOrder(Order order);

        Customer GetCustomerWithHighestOrder();
    }
}
