using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.Infrastructure.Data.Queries;
using Microsoft.Extensions.Logging;

namespace Microsoft.eShopWeb.Infrastructure.Data
{
    public class CatalogContextSeed
    {
        public static async Task SeedAsync(CatalogContext catalogContext,
            ILogger logger,
            int retry = 0)
        {
            var retryForAvailability = retry;
            try
            {
                if (catalogContext.Database.IsSqlServer())
                {
                    catalogContext.Database.Migrate();
                }

                if (!await catalogContext.CatalogBrands.AnyAsync())
                {
                    await catalogContext.CatalogBrands.AddRangeAsync(
                        GetPreconfiguredCatalogBrands());

                    await catalogContext.SaveChangesAsync();
                }

                if (!await catalogContext.CatalogItems.AnyAsync())
                {
                    await catalogContext.CatalogItems.AddRangeAsync(
                        GetPreconfiguredItems());

                    await catalogContext.SaveChangesAsync();
                }
                
                if (!await catalogContext.Events.AnyAsync())
                {
                    await catalogContext.Events.AddRangeAsync(
                        GetPreconfiguredEvents());

                    await catalogContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability >= 10) throw;

                retryForAvailability++;
                
                logger.LogError(ex.Message);
                await SeedAsync(catalogContext, logger, retryForAvailability);
                throw;
            }
        }

        static IEnumerable<CatalogBrand> GetPreconfiguredCatalogBrands()
        {
            return new List<CatalogBrand>
                {
                    new("Azure"),
                    new(".NET"),
                    new("Visual Studio"),
                    new("SQL Server"),
                    new("Other")
                };
        }

        static IEnumerable<CatalogItem> GetPreconfiguredItems()
        {
            return new List<CatalogItem>
                {
                    new(2,2, ".NET Bot Black Sweatshirt", ".NET Bot Black Sweatshirt", 19.5M,  "http://catalogbaseurltobereplaced/images/products/1.png"),
                    new(1,2, ".NET Black & White Mug", ".NET Black & White Mug", 8.50M, "http://catalogbaseurltobereplaced/images/products/2.png"),
                    new(2,5, "Prism White T-Shirt", "Prism White T-Shirt", 12,  "http://catalogbaseurltobereplaced/images/products/3.png"),
                    new(2,2, ".NET Foundation Sweatshirt", ".NET Foundation Sweatshirt", 12, "http://catalogbaseurltobereplaced/images/products/4.png"),
                    new(3,5, "Roslyn Red Sheet", "Roslyn Red Sheet", 8.5M, "http://catalogbaseurltobereplaced/images/products/5.png"),
                    new(2,2, ".NET Blue Sweatshirt", ".NET Blue Sweatshirt", 12, "http://catalogbaseurltobereplaced/images/products/6.png"),
                    new(2,5, "Roslyn Red T-Shirt", "Roslyn Red T-Shirt",  12, "http://catalogbaseurltobereplaced/images/products/7.png"),
                    new(2,5, "Kudu Purple Sweatshirt", "Kudu Purple Sweatshirt", 8.5M, "http://catalogbaseurltobereplaced/images/products/8.png"),
                    new(1,5, "Cup<T> White Mug", "Cup<T> White Mug", 12, "http://catalogbaseurltobereplaced/images/products/9.png"),
                    new(3,2, ".NET Foundation Sheet", ".NET Foundation Sheet", 12, "http://catalogbaseurltobereplaced/images/products/10.png"),
                    new(3,2, "Cup<T> Sheet", "Cup<T> Sheet", 8.5M, "http://catalogbaseurltobereplaced/images/products/11.png"),
                    new(2,5, "Prism White TShirt", "Prism White TShirt", 12, "http://catalogbaseurltobereplaced/images/products/12.png")
                };
        }

        static IEnumerable<Event> GetPreconfiguredEvents()
        {
            var conferenceType = new EventType("Conference");
            var hackathonType = new EventType("Hackathon");
            var onlineType = new EventType("Online");
            var workshopType = new EventType("Workshop");
            var summitType = new EventType("Summit");

            var newYorkLocation = new EventLocation("New York, NY", false);
            var sanFranciscoLocation = new EventLocation("San Francisco, CA", false);
            var onlineLocation = new EventLocation("Online", false);
            var bostonLocation = new EventLocation("Boston, MA", false);
            var chicagoLocation = new EventLocation("Chicago, IL", false);

            return new List<Event>
            {
                new("AI Conference 2024", "A conference discussing the latest in AI technology and research.", 500.0m, "http://catalogbaseurltobereplaced/images/products/aiconf.png", DateTime.Now, DateTime.Now.AddDays(1), new List<EventType>{ conferenceType }, new List<EventLocation>{ newYorkLocation }),
                new("Cybersecurity Summit", "A summit on the current trends and challenges in cybersecurity.", 300.0m, "http://catalogbaseurltobereplaced/images/products/cyber.png", DateTime.Now.AddDays(2), DateTime.Now.AddDays(3), new List<EventType>{ summitType }, new List<EventLocation>{ sanFranciscoLocation }),
                new("Tech Expo 2024", "An exposition showcasing the latest in technology and gadgets.", 400.0m, "http://catalogbaseurltobereplaced/images/products/tech.jpeg", DateTime.Now.AddDays(4), DateTime.Now.AddDays(5), new List<EventType>{ conferenceType }, new List<EventLocation>{ chicagoLocation }),
                new("Startup Pitch Night", "An event where startups pitch their ideas to potential investors.", 150.0m, "http://catalogbaseurltobereplaced/images/products/startup.jpeg", DateTime.Now.AddDays(6), DateTime.Now.AddDays(7), new List<EventType>{ hackathonType }, new List<EventLocation>{ bostonLocation }),
                new("Developer Conference", "A conference for developers to learn and share knowledge.", 250.0m, "http://catalogbaseurltobereplaced/images/products/devconf.jpeg", DateTime.Now.AddDays(8), DateTime.Now.AddDays(9), new List<EventType>{ conferenceType }, new List<EventLocation>{ sanFranciscoLocation }),
                new("Blockchain Workshop", "A workshop on blockchain technology and its applications.", 350.0m, "http://catalogbaseurltobereplaced/images/products/blockchain.jpeg", DateTime.Now.AddDays(10), DateTime.Now.AddDays(11), new List<EventType>{ workshopType }, new List<EventLocation>{ newYorkLocation }),
                new("Data Science Bootcamp", "An intensive bootcamp on data science and machine learning.", 600.0m, "http://catalogbaseurltobereplaced/images/products/ml.png", DateTime.Now.AddDays(12), DateTime.Now.AddDays(13), new List<EventType>{ workshopType }, new List<EventLocation>{ onlineLocation }),
                new("Networking Event", "An event for professionals to network and build connections.", 100.0m, "http://catalogbaseurltobereplaced/images/products/networking.jpeg", DateTime.Now.AddDays(14), DateTime.Now.AddDays(15), new List<EventType>{ onlineType }, new List<EventLocation>{ onlineLocation }),
                new("Hackathon 2024", "A 48-hour hackathon for developers to create innovative solutions.", 200.0m, "http://catalogbaseurltobereplaced/images/products/hack.jpeg", DateTime.Now.AddDays(16), DateTime.Now.AddDays(17), new List<EventType>{ hackathonType }, new List<EventLocation>{ chicagoLocation }),
                new("VR/AR Conference", "A conference on the latest developments in VR and AR technologies.", 450.0m, "http://catalogbaseurltobereplaced/images/products/ar.png", DateTime.Now.AddDays(18), DateTime.Now.AddDays(19), new List<EventType>{ conferenceType }, new List<EventLocation>{ bostonLocation }),
                new("Cloud Computing Summit", "A summit discussing the future of cloud computing.", 500.0m, "http://catalogbaseurltobereplaced/images/products/cloud.jpg", DateTime.Now.AddDays(20), DateTime.Now.AddDays(21), new List<EventType>{ summitType }, new List<EventLocation>{ newYorkLocation }),
                new("Robotics Expo", "An exposition showcasing the latest in robotics technology.", 700.0m, "http://catalogbaseurltobereplaced/images/products/robotics.jpeg", DateTime.Now.AddDays(22), DateTime.Now.AddDays(23), new List<EventType>{ conferenceType }, new List<EventLocation>{ sanFranciscoLocation })
            };
        }
    }
}
