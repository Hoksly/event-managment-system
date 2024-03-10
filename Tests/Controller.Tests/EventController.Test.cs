using crm_minimal.Controllers;
using crm_minimal.Data;
using crm_minimal.Data.Dao;
using crm_minimal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace crm_minimal.Tests.Controller.Tests
{
    public class TestAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> _inner;

        public TestAsyncEnumerator(IEnumerator<T> inner)
        {
            _inner = inner;
        }

        public T Current => _inner.Current;

        public ValueTask DisposeAsync() => default(ValueTask);

        public ValueTask<bool> MoveNextAsync() => new ValueTask<bool>(_inner.MoveNext());
    }
    
    public class EventsController_Test
    {
        private Mock<IEventDao> _mockContext;

        [SetUp]
        public void Setup()
        {
            _mockContext = new Mock<IEventDao>();
        }

        [Test]
        public void GetEvents_ReturnsListOfEvents()
        {
            var events = new List<Event>
            {
                new Event { Id = 1, Title = "Event 1", Description = "Description 1", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1), CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsListed = true, ImageBanner = "image1.jpg", SeatsMap = "[]" },
                new Event { Id = 2, Title = "Event 2", Description = "Description 2", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1), CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsListed = true, ImageBanner = "image2.jpg", SeatsMap = "[]" },
                new Event { Id = 3, Title = "Event 3", Description = "Description 3", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1), CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsListed = true, ImageBanner = "image3.jpg", SeatsMap = "[]" }
            };
            
            _mockContext.Setup(m => m.GetAllEvents()).ReturnsAsync(events);
            var controller = new EventsController(_mockContext.Object);
            var result = controller.GetEvents().Result;
            var eventsResult = result.Result as OkObjectResult;
            var eventsList = eventsResult.Value as List<Event>;

            if (eventsList != null)
            {
                Assert.That(eventsList.Count, Is.EqualTo(events.Count));
                Assert.That(eventsList, Is.EqualTo(events));
            }
        }

        [Test]
        public void GetEvents_ReturnEmptyList()
        {
            var events = new List<Event>();
            _mockContext.Setup(m => m.GetAllEvents()).ReturnsAsync(events);
            var controller = new EventsController(_mockContext.Object);
            var result = controller.GetEvents().Result;
            var eventsResult = result.Result as OkObjectResult;
            var eventsList = eventsResult.Value as List<Event>;

            if (eventsList != null)
            {
                Assert.That(eventsList.Count, Is.EqualTo(events.Count));
                Assert.That(eventsList, Is.EqualTo(events));
            }
        } 
        [Test]
        public void GetEventById_ReturnsOneEvent()
        {
            var events = new List<Event>
            {
                new Event { Id = 1, Title = "Event 1", Description = "Description 1", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1), CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsListed = true, ImageBanner = "image1.jpg", SeatsMap = "[]" },
                new Event { Id = 2, Title = "Event 2", Description = "Description 2", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1), CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsListed = true, ImageBanner = "image2.jpg", SeatsMap = "[]" },
                new Event { Id = 3, Title = "Event 3", Description = "Description 3", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1), CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsListed = true, ImageBanner = "image3.jpg", SeatsMap = "[]" }
            };
            
            _mockContext.Setup(m => m.GetEventById(1)).ReturnsAsync(events[0]);
           
            var controller = new EventsController(_mockContext.Object);
            var result = controller.GetEventById(1).Result;
            var eventResult = result.Result as OkObjectResult;
            var eventItem = eventResult.Value as Event;

            if (eventItem != null)
            {
                Assert.That(eventItem, Is.EqualTo(events[0]));
            }
        }
        [Test]
        public void GetEventById_ReturnsEvent()
        {   
            var events = new List<Event>
            {
                new Event { Id = 1, Title = "Event 1", Description = "Description 1", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1), CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsListed = true, ImageBanner = "image1.jpg", SeatsMap = "[]" },
                new Event { Id = 2, Title = "Event 2", Description = "Description 2", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1), CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsListed = true, ImageBanner = "image2.jpg", SeatsMap = "[]" },
                new Event { Id = 3, Title = "Event 3", Description = "Description 3", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1), CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsListed = true, ImageBanner = "image3.jpg", SeatsMap = "[]" }
            };
            
            _mockContext.Setup(m => m.GetEventById(1)).ReturnsAsync(events[0]);
            var controller = new EventsController(_mockContext.Object);
            var result = controller.GetEventById(1).Result;
            var eventResult = result.Result as OkObjectResult;
            var eventItem = eventResult.Value as Event;

            if (eventItem != null)
            {
                Assert.That(eventItem, Is.EqualTo(events[0]));
            }
        }

        [Test]
        public void GetEventById_NotFound()
        {   
            var events = new List<Event>
            {
                new Event { Id = 1, Title = "Event 1", Description = "Description 1", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1), CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsListed = true, ImageBanner = "image1.jpg", SeatsMap = "[]" },
                new Event { Id = 2, Title = "Event 2", Description = "Description 2", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1), CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsListed = true, ImageBanner = "image2.jpg", SeatsMap = "[]" },
                new Event { Id = 3, Title = "Event 3", Description = "Description 3", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1), CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsListed = true, ImageBanner = "image3.jpg", SeatsMap = "[]" }
            };
            
            var controller = new EventsController(_mockContext.Object);
            var result = controller.GetEventById(1).Result;
            var eventResult = result.Result as NotFoundResult;

            Assert.That(eventResult.StatusCode, Is.EqualTo(404));
        }
    }
}
