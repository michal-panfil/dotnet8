using System.Collections.Frozen;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet8test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> myList = ["a", "b", "c"];
            List<string> myList2 = ["c", "d", "e"];

            List<string> mergedLists = [.. myList, .. myList2];

            Console.WriteLine(string.Join(", ", mergedLists));

            
            var curr = new Currency(11.11M, "USD");
            curr.SomeMethod();


            var frozenList = mergedLists.ToFrozenSet();
            frozenList.TryGetValue("x", out var value);
            Console.WriteLine(value);

            List<Product> prodList = [
               new () {Id = 5},
                new () {Id = 6},
                new () {Id = 7}
               ];

            var frozenProdList = prodList.ToFrozenSet();
            frozenProdList.TryGetValue(prodList.First(), out var prod);

        }
    }

    

    public class MyService(AppContext context)
    {
        private readonly AppContext ctx = context;
        
        
    }
}
