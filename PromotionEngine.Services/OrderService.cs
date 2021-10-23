namespace PromotionEngine.Services
{
  using System.Collections.Generic;
  using System.Linq;
  using Domain;

  public class OrderService : IOrderService
  {
    public IList<Order> Orders { get; set; } = new List<Order>();

    public void Add(Order order) => Orders.Add(order);

    public void Remove(int id) => Orders.Remove(Orders.Single(o => o.Id == id));

    public Order GetById(int id) => Orders.SingleOrDefault(o => o.Id == id);
  }
  
}