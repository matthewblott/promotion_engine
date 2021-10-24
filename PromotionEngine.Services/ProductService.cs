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
      Products = new List<Product>
      {
        new() {Sku = "A", Price = 50.00M},
        new() {Sku = "B", Price = 30.00M},
        new() {Sku = "C", Price = 20.00M},
        new() {Sku = "D", Price = 15.00M},
      };
    }

    public Product GetBySku(string sku) => Products.SingleOrDefault(p => p.Sku == sku);
    
  }
  
}