namespace PromotionEngine.Tests
{
  using System;
  using System.Collections.Generic;
  using System.Threading.Tasks;
  using Domain;
  using Jering.Javascript.NodeJS;
  using Microsoft.Extensions.DependencyInjection;
  using NUnit.Framework;
  using Services;
  using Shouldly;

  public class OrderServiceTests
  {
    private IOrderService _orderService;
    
    [SetUp]
    public void Setup()
    {
      var services = new ServiceCollection();
      
      services.AddScoped<IProductService, ProductService>();
      services.AddScoped<IOrderService, OrderService>();
      services.AddNodeJS();
      
      var provider = services.BuildServiceProvider();
      
      _orderService = provider.GetService<IOrderService>();

    }

    // 3 As discount 20
    [Test]
    public async Task Should_calculate_discount_A_correctly()
    {
      var order = new Order
      {
        Id = 1,
        Products = new List<Product>
        {
          new() {Sku = "A", Price = 50.00M},
          new() {Sku = "B", Price = 30.00M},
          new() {Sku = "C", Price = 20.00M},
          new() {Sku = "D", Price = 15.00M},
          new() {Sku = "A", Price = 50.00M},
          new() {Sku = "A", Price = 50.00M},
        }
      };

      await _orderService.ApplyDiscount(order);

      order.Discount.ShouldBe(20.00M);
      
    }
    
    // 2 Bs discount 15
    [Test]
    public async Task Should_calculate_discount_B_correctly()
    {
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
        }
      };

      await _orderService.ApplyDiscount(order);

      order.Discount.ShouldBe(15.00M);
      
    }
    
    // C & D discount 5
    [Test]
    public async Task Should_calculate_discount_C_correctly()
    {
      var order = new Order
      {
        Id = 1,
        Products = new List<Product>
        {
          new() {Sku = "A", Price = 50.00M},
          new() {Sku = "B", Price = 30.00M},
          new() {Sku = "C", Price = 20.00M},
          new() {Sku = "D", Price = 15.00M},
        }
      };

      await _orderService.ApplyDiscount(order);

      order.Discount.ShouldBe(5.00M);
      
    }
    
    // A x 5, B x 4, C x 3, D x 3
    // Best ofer is B x 2 which gives a discount of 30.0 
    [Test]
    public async Task Should_calculate_complex_discount_correctly()
    {
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

      await _orderService.ApplyDiscount(order);

      Console.WriteLine(order.Discount);
      
      order.Discount.ShouldBe(30.00M);
      
    }
    
  }
  
}