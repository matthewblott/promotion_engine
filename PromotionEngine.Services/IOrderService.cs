namespace PromotionEngine.Services
{
  using System.Collections.Generic;
  using System.Runtime.InteropServices;
  using System.Threading.Tasks;
  using Domain;
  using Jering.Javascript.NodeJS;

  public interface IOrderService
  {
    IList<Order> Orders { get; set; }

    void Add(Order order);
    
    void Remove(int id);

    Order GetById(int id);

    Task ApplyDiscount(Order order);

  }

}