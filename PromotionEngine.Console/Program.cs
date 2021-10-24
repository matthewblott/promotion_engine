namespace PromotionEngine.Console
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;
  using Domain;
  using Jering.Javascript.NodeJS;
  using Microsoft.Extensions.DependencyInjection;
  using Services;

  internal static class Program
  {
    private static async Task Main(string[] args)
    {
      // var services = new ServiceCollection();
      //
      // services.AddScoped<IProductService, ProductService>();
      // services.AddScoped<IOrderService, OrderService>();
      // services.AddNodeJS();
      //
      // var provider = services.BuildServiceProvider();
      //
      // var jsService = provider.GetService<INodeJSService>();
      //
      // const string js = "module.exports = (callback, x, y) => callback(null, x + y)";
      //
      // var result = await jsService.InvokeFromStringAsync<int>(js, args: new object[] { 3, 5 });
      //
      // Console.WriteLine(result);
      //
      // var orderService = provider.GetService<IOrderService>();
      
      var order = new Order
      {
        Id = 1,
        Products = new List<Product>
        {
          new() { Sku = "A", Price = 50.00M },
          new() { Sku = "B", Price = 30.00M },
          new() { Sku = "C", Price = 20.00M },
          new() { Sku = "D", Price = 15.00M },
          new() { Sku = "B", Price = 30.00M },
        }
      };
      
      // orderService.Add(order);
      //
      // var numberOfOrders = orderService.Orders.Count;
      //
      // Console.WriteLine(numberOfOrders);

      // var array = new[] { "A", "B", "C", "D" };
      //
      // var arg = string.Join(string.Empty, array);
      // var result = PromotionService.Combination(arg);
      //
      // foreach (var value in result)
      // {
      //   Console.WriteLine(value);
      // }

      // var list = new List<KeyValuePair<string, decimal>>
      // {
      //   new("A", 50.00M),
      //   new("B", 30.00M),
      //   new("C", 20.00M),
      //   new("D", 15.00M),
      // };
      //
      // var products = order.Products;

      var array = new[] { 'A', 'B', 'C', 'D' };
      var result = PromotionService.Combination2(array.ToList());
      
      foreach (var value in result)
      {
        foreach (var v in value)
        {
          Console.Write(v.ToString() + ',');
        }
        
        Console.WriteLine();
        
      }
     
    }
    
  }
  
}