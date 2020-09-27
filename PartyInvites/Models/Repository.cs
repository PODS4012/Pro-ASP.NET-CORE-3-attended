using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.Models
{

     // The Repository class and its members are static, which will make it easy to store and retrieve data from different places. the application.ASP.NET Core provides a more sophisticated approach for defining common functionality, called dependency injection, which I describe in Chapter 14, but a static class is a good way to get started for a simple application like this one.
    public static class Repository
    {
        private static List<GuestResponse> responses = new List<GuestResponse>();
        public static IEnumerable<GuestResponse> Responses => responses;

        public static void AddResponse(GuestResponse response)
        {
            responses.Add(response);
        }
    }
}
