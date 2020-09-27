using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage ="Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        public string Phone { get; set; }

        //As noted earlier, I used a nullable bool for the WillAttend property. I did this so that I could apply the Required validation attribute.If I had used a regular bool, the value I received through model binding could be only true or false, and I would not be able to tell whether the user had selected a value.A nullable bool has three possible values: true, false, and null. The browser sends a null value if the user has not selected a value, and this causes the Required attribute to report a validation error.This is a nice example of how ASP.NET Core elegantly blends C# features with HTML and HTTP.
        [Required(ErrorMessage = "Please specify whether you'll attend")]
        public bool? WillAttend { get; set; } //WillAttend property is a nullable bool, which means that it can be true, false, or null
    }
}
