namespace PromotionEngine.Services
{
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Linq;
  using System.Text.Json;
  using System.Threading.Tasks;
  using Domain;
  using Jering.Javascript.NodeJS;

  public class OrderService : IOrderService
  {
    private readonly INodeJSService _nodeService;

    public OrderService(INodeJSService nodeService) => _nodeService = nodeService;

    public IList<Order> Orders { get; set; } = new List<Order>();

    public void Add(Order order) => Orders.Add(order);

    public void Remove(int id) => Orders.Remove(Orders.Single(o => o.Id == id));

    public Order GetById(int id) => Orders.FirstOrDefault(o => o.Id == id);

    public async Task ApplyDiscount(Order order)
    {
      var path = Path.Combine(AppContext.BaseDirectory, "Scripts", "promotions.js");
      
      // Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
      
      var kvp = order.Products
        .Select(x=> new KeyValuePair<string, decimal>(x.Sku, x.Price))
        .ToList();

      var combinations = UniquePairingCombinations(kvp);

      var discounts = new List<decimal>();
      
      foreach (var combination in combinations)
      {
        var resultA = await _nodeService 
          .InvokeFromFileAsync<JsonElement>(path, "discountA", args: new object[] { combination });

        var a = resultA.GetDecimal();
          
        discounts.Add(a);
        
        var resultB = await _nodeService 
          .InvokeFromFileAsync<JsonElement>(path, "discountB", args: new object[] { combination });

        var b = resultB.GetDecimal();
        
        discounts.Add(b);

        var resultC = await _nodeService 
          .InvokeFromFileAsync<JsonElement>(path, "discountC", args: new object[] { combination });

        var c = resultC.GetDecimal();
        
        discounts.Add(c);
        
      }

      var max = discounts.Max();
      
      order.Discount = max;

    }
   
    // Function to determine the unique combinations of key value pairings in the original list.
    // For example a list of ['A', 'B'] can produce 3 lists ['A'], ['B'] and ['A', 'B']
    // The code was based on the following example:
    // https://www.c-sharpcorner.com/blogs/getting-all-combinations-of-an-array-of-elements
    private static List<List<KeyValuePair<string, decimal>>> UniquePairingCombinations(List<KeyValuePair<string, decimal>> list)
    {
      if (list.Count == 1)
      {
        return new List<List<KeyValuePair<string, decimal>>> { list };
      }

      var kvp = list.Last();
      var lastItem = new List<KeyValuePair<string, decimal>> { kvp };
      var otherItems = list.SkipLast(1).ToList();
      var nextIteration = UniquePairingCombinations(otherItems);
      var finalArray = new List<List<KeyValuePair<string, decimal>>>(nextIteration) { lastItem };
      
      var listToAdd = nextIteration
        .AsEnumerable()
        .Select(newComb => newComb.Append(kvp).ToList());
      
      finalArray.AddRange(listToAdd);

      var distinct = finalArray.Distinct().ToList();

      return distinct;

    }
    
  }
  
}