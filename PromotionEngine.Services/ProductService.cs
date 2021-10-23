namespace PromotionEngine.Services
{
  using System.Collections.Generic;
  using System.Linq;
  using Domain;

  public class ProductService : IProductService
  {
    public IList<Product> Products { get; set; }

    public ProductService()
    {
      
    }

    public Product GetBySku(string sku) => Products.SingleOrDefault(p => p.Sku == sku);
    
  }
  
}