namespace PromotionEngine.Services
{
  using System.Collections.Generic;
  using Domain;

  public interface IOrderService
  {
    IList<Order> Orders { get; set; }

    void Add(Order order);
    
    void Remove(int id);

    Order GetById(int id);

  }

}