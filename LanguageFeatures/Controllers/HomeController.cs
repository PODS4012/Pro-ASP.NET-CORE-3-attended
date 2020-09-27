using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
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

                results.Add(string.Format("Name: {0}, Price: {1}, Related: {2}", name, price, relatedName));
            }
            return View(results);
        }
    }
}
