namespace PromotionEngine.Console
{
  using System;
  using System.Collections.Generic;
  using System.Threading.Tasks;
  using Domain;
  using Jering.Javascript.NodeJS;
  using Microsoft.Extensions.DependencyInjection;
  using Services;

  internal static class Program
  {
    private static async Task Main(string[] args)
    {
      var services = new ServiceCollection();
      
      services.AddScoped<IProductService, ProductService>();
      services.AddScoped<IOrderService, OrderService>();
      services.AddNodeJS();
      
      var provider = services.BuildServiceProvider();
      var orderService = provider.GetService<IOrderService>();
      var productService = provider.GetService<IProductService>();

      // var order = new Order
      // {
      //   Id = 1,
      //   Products = productService.Products
      // };
      //
      // order.Products.Add(new Product{ Sku = "A", Price = 50.00M,});
      // order.Products.Add(new Product{ Sku = "A", Price = 50.00M,});

      var order = new Order
      {
        Id = 1,
        Products = new List<Product>
        {
          new() {Sku = "A", Price = 50.00M},
          new() {Sku = "B", Price = 30.00M},
          new() {Sku = "C", Price = 20.00M},
          new() {Sku = "D", Price = 15.00M},
          new() {Sku = "B", Price = 30.00M},
          new() {Sku = "A", Price = 50.00M},
          new() {Sku = "B", Price = 30.00M},
          new() {Sku = "C", Price = 20.00M},
          new() {Sku = "D", Price = 15.00M},
          new() {Sku = "A", Price = 50.00M},
          new() {Sku = "A", Price = 50.00M},
          new() {Sku = "A", Price = 50.00M},
          new() {Sku = "B", Price = 30.00M},
          new() {Sku = "C", Price = 20.00M},
          new() {Sku = "D", Price = 15.00M},
        }
      };
      
      orderService.Add(order);
      
      await orderService.ApplyDiscount(order);
      
      Console.WriteLine($"Discount: {order.Discount}");
      
    }
    
  }
  
}