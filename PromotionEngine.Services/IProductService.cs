namespace PromotionEngine.Services
{
  using System.Collections.Generic;
  using Domain;

  public interface IProductService
  {
    IList<Product> Products { get; set; }

    Product GetBySku(string sku);

  }
  
}