using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {

        #region Index
        public ViewResult Index()
        {
            //return View(new string[] { "C#", "Language", "Features"});

            List<string> results = new List<string>();

            foreach(Product p in Product.GetProducts())
            {
                //The static GetProducts method defined by the Product class returns an array of objects that I inspect in the Index action method to get a list of the Name and Price values. The problem is that both the object in the array and the value of the properties could be null, which means I can’t just refer to p.Name or p.Price within the foreach loop without causing a NullReferenceException.To avoid this, I used the null conditional operator.

                //The null conditional operator is a single question mark (the ? character). If p is null, then name will be set to null as well. If p is not null, then name will be set to the value of the Person.Name property. The Price property is subject to the same test.Notice that the variable you assign to when using the null conditional operator must be able to be assigned null, which is why the price variable is declared as a nullable decimal(decimal ?).

                //The null conditional operator ensures that I don’t get a NullReferenceException when navigating through the object properties, and the null coalescing operator ensures that I don’t include null values in the results displayed in the browser.

                string name = p?.Name ?? "<No Name>";
                decimal? price = p?.Price ?? 0;

                //The null conditional operator can be applied to each part of a chain of properties.
                string relatedName = p?.Related?.Name ?? "<None>";

                //C# also supports a different approach, known as string interpolation, that avoids the need to ensure that the {0} references in the string template match up with the variables specified as arguments.Instead, string interpolation uses the variable names directly.
                //results.Add(string.Format("Name: {0}, Price: {1}, Related: {2}", name, price, relatedName));
                results.Add($"Name: {name}, Price: {price}, Related: {relatedName}");
            }
            return View(results);
        }
        #endregion

        #region Using an Index Initializer
        //public ViewResult Index()
        //{
        //    /*Using an Index Initializer*/
        //    //Recent versions of C# tidy up the way collections that use indexes, such as dictionaries

        //    Dictionary<string, Product> products = new Dictionary<string, Product> {
        //        { "Kayak", new Product { Name = "Kayak", Price = 275M } },
        //        { "Lifejacket", new Product{ Name = "Lifejacket", Price = 48.95M } }
        //    };
        //    return View("Index", products.Keys);

        //    //The syntax for initializing this type of collection relies too much on the { and } characters, especially when the collection values are created using object initializers. The latest versions of C# support a more natural approach to initializing indexed collections that is consistent with the way that values are retrieved or modified once the collection has been initialized.
        //    Dictionary<string, Product> products = new Dictionary<string, Product>
        //    {
        //        ["Kayak"] = new Product { Name = "Kayak", Price = 275M },
        //        ["Lifejacket"] = new Product { Name = "Lifejacket", Price = 48.95M }
        //    };
        //    return View("Index", products.Keys);
        //}
        #endregion

        #region Pattern Matching
        //public ViewResult Index()
        //{
        //    /*Pattern Matching*/
        //    //One of the most useful recent additions to C# is support for pattern matching, which can be used to test that an object is of a specific type or has specific characteristics.This is another form of syntactic sugar, and it can dramatically simplify complex blocks of conditional statements. The is keyword is used to perform a type test.

        //    object[] data = new object[] { 275M, 29.95M, "apple", "orange", 100, 10 };
        //    decimal total = 0;
        //    for (int i = 0; i < data.Length; i++)
        //    {
        //        //The is keyword performs a type check and, if a value is of the specified type, will assign the value to a new variable
        //        if (data[i] is decimal d)
        //        {
        //            total += d;
        //        }
        //    }
        //    return View("Index", new string[] { $"Total: {total:C2}" });

        //    //This expression evaluates as true if the value stored in data[i] is a decimal. The value of data[i] will be assigned to the variable d, which allows it to be used in subsequent statements without needing to perform any type conversions.The is keyword will match only the specified type, which means that only two of the values in the data array will be processed(the other items in the array are string and int values). If you run the application, you will see the following output in the browser window:

        //    // Total: $304.95
        //}
        #endregion
    }
}
