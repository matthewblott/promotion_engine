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
      
      var jsService = provider.GetService<INodeJSService>();

      const string js = "module.exports = (callback, x, y) => callback(null, x + y)";

      var result = await jsService.InvokeFromStringAsync<int>(js, args: new object[] { 3, 5 });
      
      Console.WriteLine(result);

      var orderService = provider.GetService<IOrderService>();
      
      var order = new Order
      {
        Products = new List<Product>
        {
          new() { Sku = "A", Price = 10.99M },
          new() { Sku = "B", Price = 10.99M },
          new() { Sku = "C", Price = 10.99M },
        }
      };

      orderService.Add(order);

      var numberOfOrders = orderService.Orders.Count;
      
      Console.WriteLine(numberOfOrders);

    }
  }
}