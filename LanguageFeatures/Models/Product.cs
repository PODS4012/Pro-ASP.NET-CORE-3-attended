using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
        //The null conditional operator can be chained to navigate through a hierarchy of objects, which is where it becomes an effective tool for simplifying code and allowing safe navigation. I have added a property to the Product class that creates a more complex object hierarchy.
        public Product Related { get; set; }
        public static Product[] GetProducts()
        {
            Product kayak = new Product
            {
                Name = "Kayak",
                Price = 275M
            };
            Product lifejacket = new Product
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
