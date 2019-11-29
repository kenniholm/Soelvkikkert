using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xunit;
using Moq;
using SoelvkikkertMVC.Controllers;
using SoelvkikkertMVC.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.AspNetCore.Mvc;

namespace ControllerTests
{
    public class SubsriberTest
    {
        DbContextOptions<VitecContext> options;
        public SubsriberTest()
        {
            options = new DbContextOptionsBuilder<VitecContext>()
                .UseInMemoryDatabase(databaseName: "SubsriberDatabase").Options;
        }
        
        [Fact]
        public async void Index_ReturnsAViewResult_WithListOfSubscribers()
        {
            // Arrange
            VitecContext context = new VitecContext(options);
            context.Subscriber.Add(new Subscriber
            {
                FirstName = "Kenni",
                LastName = "Bobber",
                PhoneNumber = "88888888",
                Active = true,
                Email = "Kenni@bobber.dk"
            });
            context.Subscriber.Add(new Subscriber
            {
                FirstName = "Nidolaj",
                LastName = "Molle",
                PhoneNumber = "88888888",
                Active = true,
                Email = "Nidolaj@molle.dk"
            });
            context.SaveChanges();

            SubscriberController controller = new SubscriberController(context);

            // Act
            var result = await controller.Index();

            // Assert that it's a viewResult
            var viewResult = Assert.IsType<ViewResult>(result);
            // Assert that the model returned is a list of subscribers
            List<Subscriber> model = Assert.IsAssignableFrom<List<Subscriber>>(viewResult.ViewData.Model);
            // Asser that there's 2 subscribers
            Assert.Equal(2, model.Count);
        }
    }
}
