namespace PromotionEngine.Domain
{
  using System.Collections.Generic;

  public class Order
  {
    public int Id { get; set; }
    public IList<Product> Products { get; set; }
    
    public decimal Discount { get; set; }
    
  }
}