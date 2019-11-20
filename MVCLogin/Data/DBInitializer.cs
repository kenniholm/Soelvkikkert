using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MVCLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCLogin.Data
{
    public class DBInitializer
    {

        public static void Initialize(VitecContext context)
        {
            context.Database.EnsureCreated();

            if (context.PaymentInterval.Any())
            {
                return; // database has been seeded
            }

            var paymentIntervals = new PaymentInterval[]
            {
                new PaymentInterval{ Interval = new TimeSpan(30), Discount = 0},
                new PaymentInterval{ Interval = new TimeSpan(90), Discount = 2.5},
                new PaymentInterval{ Interval = new TimeSpan(180), Discount = 5 },
                new PaymentInterval{ Interval = new TimeSpan(360), Discount = 7.5}
            };

            foreach (PaymentInterval p in paymentIntervals)
            {
                context.PaymentInterval.Add(p);
            }

            context.SaveChanges();

            //Look for any subscribers


            var subscribers = new Subscriber[]
            {
                new Subscriber { FirstName = "Victor", LastName = "West-Larsen", Email = "Victor@hotmail.com", PhoneNumber = "12345678", Active = false },
                new Subscriber { FirstName = "Kenni", LastName = "Holm", Email = "Kenni@hotmail.com", PhoneNumber = "11223344", Active = true },
                new Subscriber { FirstName = "Nikolaj", LastName = "Lauridsen", Email = "Nikolaj@hotmail.com", PhoneNumber = "12312312", Active = true },
                new Subscriber { FirstName = "Kasper", LastName = "Hoffmann", Email = "Kasper@hotmail.com", PhoneNumber = "12341234", Active = false }
            };

            foreach (Subscriber s in subscribers)
            {
                context.Subscriber.Add(s);
            }
            context.SaveChanges();

            var employees = new Employee[]
            {
                new Employee { FirstName = "Victor", LastName = "West-Larsen", Email = "Victor@hotmail.com", PhoneNumber = "12345678", Administrator = true },
                new Employee { FirstName = "Kenni", LastName = "Holm", Email = "Kenni@hotmail.com", PhoneNumber = "11223344", Administrator = true },
                new Employee { FirstName = "Nikolaj", LastName = "Lauridsen", Email = "Nikolaj@hotmail.com", PhoneNumber = "12312312", Administrator = true },
                new Employee { FirstName = "Kasper", LastName = "Hoffmann", Email = "Kasper@hotmail.com", PhoneNumber = "12341234", Administrator = true }
            };

            foreach (Employee e in employees)
            {
                context.Employee.Add(e);
            }
            context.SaveChanges();

            var products = new Product[]
            {
                new Product { Name = "IntoWords", Description = "Digitalt værktøj der hjælper dig med at skrive og læse, på både bærbare computere, tablets og mobil telefoner", Price = 30, ImageName="IntoWords.png"},
                new Product { Name = "C-Pen", Description = "Skan ord eller sætninger ind på computeren så de kan læses op", Price = 20, ImageName="PlaceHolder.png"},
                new Product { Name = "Grammatekst", Description = "Tjekker din tekst for fejl i stavning, grammatik og kommatering", Price = 25, ImageName="PlaceHolder.png"},
                new Product { Name = "Matematikleg Flex", Description = "Hjælp til elever med matematikvanskeligheder", Price = 40, ImageName="PlaceHolder.png"},
                new Product { Name = "MiVo", Description = "Træner brugen af skrivehjælpen i CD-ORD og IntoWords  ", Price = 15, ImageName="PlaceHolder.png"},
                new Product { Name = "CD-Ord", Description="Pc-baseret læse- og skriveprogram, der hjælper usikre læsere og ordblinde.", Price=42, ImageName="PlaceHolder.png"}
            };

            foreach (Product p in products)
            {
                context.Product.Add(p);
            }
            context.SaveChanges();

            var subscriberProducts = new SubscriberProduct[]
            {
                new SubscriberProduct{ SubscriptionStart = DateTime.Now , SubscriptionEnd = Convert.ToDateTime("10,10,2020"),
                                        PaymentIntervalID = paymentIntervals.Single(p => p.Discount == 0.0).ID,
                                        ProductID = products.Single(p => p.Name == "MiVo").ID,
                                        SubscriberID = subscribers.Single(s => s.Email == "Kenni@hotmail.com").ID},

                new SubscriberProduct{ SubscriptionStart = DateTime.Now, SubscriptionEnd = Convert.ToDateTime("10,12,2022"),
                                        PaymentIntervalID = paymentIntervals.Single(p => p.Discount == 2.5).ID,
                                        ProductID = products.Single(p => p.Name == "IntoWords").ID,
                                        SubscriberID = subscribers.Single(s => s.Email == "Nikolaj@hotmail.com").ID}
            };
            foreach (SubscriberProduct s in subscriberProducts)
            {
                context.SubscriberProduct.Add(s);
            }
            context.SaveChanges();


            var productPaymentIntervals = new ProductPaymentInterval[]
           {
                new ProductPaymentInterval {
                    ProductID = products.Single(p => p.Name == "IntoWords").ID,
                    PaymentIntervalID = paymentIntervals.Single(p => p.Discount == 0).ID
                    },
                new ProductPaymentInterval {
                    ProductID = products.Single(p => p.Name == "IntoWords").ID,
                    PaymentIntervalID = paymentIntervals.Single(p => p.Discount == 2.5).ID
                    },
                new ProductPaymentInterval {
                    ProductID = products.Single(p => p.Name == "IntoWords").ID,
                    PaymentIntervalID = paymentIntervals.Single(p => p.Discount == 5.0).ID
                    },
                new ProductPaymentInterval {
                    ProductID = products.Single(p => p.Name == "IntoWords").ID,
                    PaymentIntervalID = paymentIntervals.Single(p => p.Discount == 7.5).ID
                    },
                new ProductPaymentInterval {
                    ProductID = products.Single(p => p.Name == "C-Pen").ID,
                    PaymentIntervalID = paymentIntervals.Single(p => p.Discount == 0).ID
                    },
                new ProductPaymentInterval {
                    ProductID = products.Single(p => p.Name == "C-Pen").ID,
                    PaymentIntervalID = paymentIntervals.Single(p => p.Discount == 2.5).ID
                    },
                new ProductPaymentInterval {
                    ProductID = products.Single(p => p.Name == "C-Pen").ID,
                    PaymentIntervalID = paymentIntervals.Single(p => p.Discount == 5.0).ID
                    },
                new ProductPaymentInterval {
                    ProductID = products.Single(p => p.Name == "C-Pen").ID,
                    PaymentIntervalID = paymentIntervals.Single(p => p.Discount == 7.5).ID
                    },
                new ProductPaymentInterval {
                    ProductID = products.Single(p => p.Name == "Grammateket").ID,
                    PaymentIntervalID = paymentIntervals.Single(p => p.Discount == 0).ID
                    },
                new ProductPaymentInterval {
                    ProductID = products.Single(p => p.Name == "Grammateket").ID,
                    PaymentIntervalID = paymentIntervals.Single(p => p.Discount == 2.5).ID
                    },
                new ProductPaymentInterval {
                    ProductID = products.Single(p => p.Name == "Grammateket").ID,
                    PaymentIntervalID = paymentIntervals.Single(p => p.Discount == 5.0).ID
                    },
                new ProductPaymentInterval {
                    ProductID = products.Single(p => p.Name == "Grammateket").ID,
                    PaymentIntervalID = paymentIntervals.Single(p => p.Discount == 7.5).ID
                    },
                new ProductPaymentInterval {
                    ProductID = products.Single(p => p.Name == "Matematikleg Flex").ID,
                    PaymentIntervalID = paymentIntervals.Single(p => p.Discount == 0).ID
                    },
                new ProductPaymentInterval {
                    ProductID = products.Single(p => p.Name == "Matematikleg Flex").ID,
                    PaymentIntervalID = paymentIntervals.Single(p => p.Discount == 2.5).ID
                    },
                new ProductPaymentInterval {
                    ProductID = products.Single(p => p.Name == "Matematikleg Flex").ID,
                    PaymentIntervalID = paymentIntervals.Single(p => p.Discount == 5.0).ID
                    },
                new ProductPaymentInterval {
                    ProductID = products.Single(p => p.Name == "Matematikleg Flex").ID,
                    PaymentIntervalID = paymentIntervals.Single(p => p.Discount == 7.5).ID
                    },
                new ProductPaymentInterval {
                    ProductID = products.Single(p => p.Name == "MiVo").ID,
                    PaymentIntervalID = paymentIntervals.Single(p => p.Discount == 0).ID
                    },
                new ProductPaymentInterval {
                    ProductID = products.Single(p => p.Name == "MiVo").ID,
                    PaymentIntervalID = paymentIntervals.Single(p => p.Discount == 2.5).ID
                    },
                new ProductPaymentInterval {
                    ProductID = products.Single(p => p.Name == "MiVo").ID,
                    PaymentIntervalID = paymentIntervals.Single(p => p.Discount == 5.0).ID
                    },
                new ProductPaymentInterval {
                    ProductID = products.Single(p => p.Name == "MiVo").ID,
                    PaymentIntervalID = paymentIntervals.Single(p => p.Discount == 7.5).ID
                    },
           };

            foreach (ProductPaymentInterval p in productPaymentIntervals)
            {
                context.ProductPaymentInterval.Add(p);
            }
            context.SaveChanges();

        }
    }
}
