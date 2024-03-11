using Microsoft.EntityFrameworkCore;
using System.Collections.Frozen;

namespace dotnet8test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Collection experssions
            List<string> myList = ["a", "b", "c"];
            List<string> myList2 = ["c", "d", "e"];

            List<string> mergedLists = [.. myList, .. myList2];

            Console.WriteLine(string.Join(", ", mergedLists));

            // 
            var curr = new Money(11.11M, "USD");
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
        
        public async Task<IEnumerable<AddressMoney>> GetAddressMoney(DateOnly createdAfter)
        {
            System.FormattableString formatableString = 
                @$"SELECT * 
                   FROM Products AS p
                   JOIN Money AS m ON m.value == p.price
                   WHERE p.creationTime > {createdAfter}";

            return await this.ctx.Database.SqlQuery<AddressMoney>(formatableString)
                .Where(x => x.City != "New York")
                .ToListAsync();
        }

        public async Task BulkActions()
        {
            await this.ctx.Currencies.Where(x => x.Symbol == "USD").ExecuteDeleteAsync();

            List<Product> products = [
                new() { Id = 5, Price = 11M },
                new () { Id = 6, Price = 11M },
                new () { Id = 7, Price = 11M }
            ];

             this.ctx.Products.
                Where(x => x.Price > 100).
                ExecuteUpdate(s => s.SetProperty( 
                    p => p.Price,
                    p => products.FirstOrDefault(x => x.Id == p.Id).Price))
                ;

        }

    }
}
