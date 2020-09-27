using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FirstProject.Models;

namespace FirstProject.Controllers
{
    public class HomeController : Controller
    {
        // When I return a ViewResult object from an action method, I am instructing ASP.NET Core to render a view.
        // I create the ViewResult by calling the View method, specifying the name of the view that I want to use, which is MyView.

        // The view model in this example is a string, and it is provided to the view as the second argument to the View method.
        //  Listing updates the view so that it receives and uses the view model in the HTML it generates.
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            string viewModel = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View("MyView", viewModel);
        }
    }
}
