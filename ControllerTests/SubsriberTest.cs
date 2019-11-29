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
        
        [Fact]
        public async void Index_ReturnsAViewResult_WithListOfSubscribers()
        {
            // Arrange
            options = new DbContextOptionsBuilder<VitecContext>()
                .UseInMemoryDatabase(databaseName: "IndexSubsriberDatabase").Options;
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
            IActionResult result = await controller.Index();

            // Assert that it's a viewResult
            ViewResult viewResult = Assert.IsType<ViewResult>(result);
            // Assert that the model returned is a list of subscribers
            List<Subscriber> model = Assert.IsAssignableFrom<List<Subscriber>>(viewResult.ViewData.Model);
            // Asser that there's 2 subscribers
            Assert.Equal(2, model.Count);
        }

        [Fact]
        public async void Details_ReturnsRequested_Model()
        {
            // Arrange
            options = new DbContextOptionsBuilder<VitecContext>()
                .UseInMemoryDatabase(databaseName: "DetailsSubsriberDatabase").Options;
            VitecContext context = new VitecContext(options);
            context.Subscriber.Add(new Subscriber
            {
                FirstName = "Kenni",
                LastName = "Bobber",
                PhoneNumber = "88888888",
                Active = true,
                Email = "Kenni@bobber.dk",
                ID = 1
            });
            context.Subscriber.Add(new Subscriber
            {
                FirstName = "Nidolaj",
                LastName = "Molle",
                PhoneNumber = "88888888",
                Active = true,
                Email = "Nidolaj@molle.dk",
                ID = 2
            });
            context.SaveChanges();
            SubscriberController controller = new SubscriberController(context);

            // Act
            IActionResult result = await controller.Details(2);

            ViewResult viewResult = Assert.IsType<ViewResult>(result);
            // Assert that it's a subscriber as model
            Subscriber sub = Assert.IsAssignableFrom<Subscriber>(viewResult.ViewData.Model);
            // Assert that it's the correct subsriber
            Assert.Equal("Nidolaj", sub.FirstName);
        }
    }
}
