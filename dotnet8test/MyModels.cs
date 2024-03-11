using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet8test
{

    // Primary constructor
    public class Money(decimal value, string symbol)
    {
        public int Id { get; set; }
        public decimal Value { get; private set; } = value;
        public string Symbol { get; private set; } = symbol;

        public void SomeMethod()
        {
            Console.WriteLine(value);
        }

    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        // EF core and SqlServer suport time types properly
        public TimeOnly TimeOfCreation { get; set; }
        public DateOnly DateOfCreation { get; set; }
        public DateTime CreationTimeStamp { get; set; }

        //Complex types
        public Address OrginAddress { get; set; }

        // Primitive collections
        public List<string> Categories { get; set; }

    }

    [ComplexType]
    public class Address(string street, string city)
    {
        public string Street { get; set; } = street;
        public string City { get; set; } = city;

    }

    public class AddressMoney
    {
        public string  City { get; set; }
        public string Symbol { get; set; }
    }
}
