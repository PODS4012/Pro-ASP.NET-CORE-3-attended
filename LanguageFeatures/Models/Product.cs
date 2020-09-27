using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public class Product
    {
        //The InStock property is initialized to true and cannot be changed; however, the value can be assigned to in the type’s constructor.
        public Product(bool stock = true)
        {
            InStock = stock;
        }
        public string Name { get; set; }

        //Automatically implemented properties have been supported since C# 3.0. The latest version of C# supports initializers for automatically implemented properties, which allows an initial value to be set without having to use the constructor.
        public string Category { get; set; } = "Watersports";
        public decimal? Price { get; set; }

        //You can create a read-only property by using an initializer and omitting the set keyword from an auto-implemented property that has an initializer.
        public bool InStock { get; } //= true;
        //The null conditional operator can be chained to navigate through a hierarchy of objects, which is where it becomes an effective tool for simplifying code and allowing safe navigation. I have added a property to the Product class that creates a more complex object hierarchy.
        public Product Related { get; set; }
        public static Product[] GetProducts()
        {
            Product kayak = new Product
            {
                Name = "Kayak",
                Category = "Water Craft",
                Price = 275M
            };

            //The constructor allows the value for the read-only property to be specified as an argument and defaults to true if no value is provided.The property value cannot be changed once set by the constructor.
            Product lifejacket = new Product(false)
            {
                Name = "Lifejacket",
                Price = 48.95M
            };

            //Each Product object has a Related property that can refer to another Product object. In the GetProducts method, I set the Related property for the Product object that represents a kayak.Listing shows how I can chain the null conditional operator to navigate through the object properties without causing an exception.
            kayak.Related = lifejacket;


        //            The result is that the relatedName variable will be null when p is null or when p.Related is null.Otherwise, the variable will
        //            be assigned the value of the p.Related.Name property. Restart ASP.NET Core and request http://localhost:5000, and you will see
        //            the following output in the browser window:

        //          Name: Kayak, Price: 275, Related: Lifejacket
        //          Name: Lifejacket, Price: 48.95, Related: < None >
        //          Name: < No Name >, Price: 0, Related: < None >

            return new Product[] { kayak, lifejacket, null };
        }
    }
}
