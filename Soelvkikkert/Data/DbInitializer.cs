using Soelvkikkert.Data;
using Soelvkikkert.Models;
using System;
using System.Linq;

namespace Soelvkikkert.Data
{
    public static class DbInitializer
    {
        public static void Initialize(RazorPagesSubscriberContext context)
        {
            context.Database.EnsureCreated();

            if (context.Movie.Any())
            {
                return;
            }

            var subscribers = new Subscriber[]
            {
                new Subscriber{Email = "subscriber1@email.dk", PhoneNumber = "12345678", FirstName = "Hans", LastName = "Hansen", Active = false, Product = "Haaj", SubscribtionStart = new DateTime(2003, 01, 01), SubscribtionEnd = new DateTime(2004, 02, 04)},

            };
        }
    }
}
