namespace PromotionEngine.Services
{
  using System;
  using System.Collections;
  using System.Collections.Generic;
  using System.Linq;
  using System.Linq.Expressions;
  using Domain;

  public class PromotionService
  {
    // https://www.c-sharpcorner.com/blogs/getting-all-combinations-of-an-array-of-elements
    public static IEnumerable<string> Combination(string str)
    {
      if (str.Length == 1)
      {
        return new[] { str };
      }
      
      var lastItem = str[^1].ToString();
      var otherItems = str[..^1];
      
      var combination = Combination(otherItems);
      var finalArray = combination.ToList();

      finalArray.Add(lastItem);

      var range = combination.Select(s =>
      {
        var t = s;
        
        return s + lastItem;
      });
      
      finalArray.AddRange(range);

      return finalArray.Distinct();

    }
    
    public static List<List<char>> Combination2(List<char> list)
    {
      if (list.Count == 1)
      {
        return new List<List<char>> { list };
      }

      var ch = list.Last();
      var lastItem = new List<char> { ch };
      var otherItems = list.SkipLast(1).ToList();
      var combination = Combination2(otherItems);
      var finalArray = new List<List<char>>(combination) {lastItem};

      List<List<char>> list0 = new List<List<char>>();

      foreach (var comb in combination)
      {
        var newComb = comb.AsEnumerable();
        var newComb2 = newComb.Append(ch);
        
        list0.Add(newComb2.ToList());
      }

      foreach (var item in list0)
      {
        finalArray.Add(item);
      }
      
      // var range = combination.Select(s =>
      // {
      //   s.Add(ch);
      //   return s;
      // });
      // finalArray.AddRange(range);
      
      var distinct = finalArray.Distinct();

      return distinct.ToList();

    }
    
  }
  
}