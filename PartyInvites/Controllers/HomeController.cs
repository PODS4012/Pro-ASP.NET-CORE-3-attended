using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;
using System.Linq;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        // Before the POST version of the RsvpForm method is invoked, the ASP.NET Core model binding feature extracts values from the HTML form and assigns them to the properties of the GuestResponse object.The result is used as the argument when the method is invoked to handle the HTTP request, and all I have to do to deal with the form data sent in a request is to work with the GuestResponse object that is passed to the action method—in this case, to pass it as an argument to the Repository.AddResponse method so that the response can be stored.
        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            //The Controller base class provides a property called ModelState that provides details of the outcome of the model binding process.If the ModelState.IsValid property returns true, then I know that the model binder has been able to satisfy the validation constraints I specified through the attributes on the GuestResponse class. When this happens, I render the Thanks view, just as I did previously. If the ModelState.IsValid property returns false, then I know that there are validation errors. The object returned by the ModelState property provides details of each problem that has been encountered, but I don’t need to get into that level of detail because I can rely on a useful feature that automates the process of asking the user to address any problems by calling the View method without any parameters.
            if (ModelState.IsValid)
            {
                Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }
            else
            {
                return View();
            }
            
        }

        public ViewResult ListResponses()
        {
            // Action method ListResponses,calls the View method, using the Repository.Responses property as the argument.This will cause Razor to render the default view, using the action method name as the name of the view file, and to use the data from the repository as the view model. The view model data is filtered using LINQ so that only positive responses are provided to the view.
            return View(Repository.Responses.Where(r => r.WillAttend == true));
        }
    }
}
