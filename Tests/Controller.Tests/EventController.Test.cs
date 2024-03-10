using crm_minimal.Controllers;
using crm_minimal.Data;
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
        private Mock<ApplicationManagementContext>? _mockContext;

        [SetUp]
        public void Setup()
        {
            _mockContext = new Mock<ApplicationManagementContext>();
        }

        [Test]
        public void GetEvents_ReturnsListOfEvents()
        {
            // Arrange
           var data = new List<Event>
            {
                new Event { Id = 1, Title = "Event1", Description = "Description1", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsListed = true, ImageBanner = "ImageBanner1", SeatsMap = "SeatsMap1" },
                new Event { Id = 2, Title = "Event2", Description = "Description2", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsListed = true, ImageBanner = "ImageBanner2", SeatsMap = "SeatsMap2" },
                new Event { Id = 3, Title = "Event3", Description = "Description3", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsListed = true, ImageBanner = "ImageBanner3", SeatsMap = "SeatsMap3" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Event>>();
            mockSet.As<IQueryable<Event>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Event>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Event>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Event>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockSet.As<IAsyncEnumerable<Event>>().Setup(m => m.GetAsyncEnumerator(It.IsAny<CancellationToken>())).Returns(new TestAsyncEnumerator<Event>(data.GetEnumerator()));

            _mockContext.Setup(c => c.Events).Returns(mockSet.Object);
            _mockContext.Setup(c => c.Events).Returns(mockSet.Object);
            var controller = new EventsController(_mockContext.Object);

            // Act
            var result = controller.GetEvents();

            // Assert
            Assert.That(result, Is.Not.Null);
            IEnumerable<Event>? events = result.Result.Value;
            
            Assert.That(events, Is.EqualTo(data));
            
        }

        [Test]
        public void GetEvents_ReturnEmptyList()
        {
            // Arrange
            var data = new List<Event>().AsQueryable();

            var mockSet = new Mock<DbSet<Event>>();
            mockSet.As<IQueryable<Event>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Event>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Event>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Event>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockSet.As<IAsyncEnumerable<Event>>().Setup(m => m.GetAsyncEnumerator(It.IsAny<CancellationToken>())).Returns(new TestAsyncEnumerator<Event>(data.GetEnumerator()));

            _mockContext.Setup(c => c.Events).Returns(mockSet.Object);
            var controller = new EventsController(_mockContext.Object);

            // Act
            var result = controller.GetEvents();

            // Assert
            Assert.That(result, Is.Not.Null);
            IEnumerable<Event>? events = result.Result.Value;
            
            Assert.That(events, Is.EqualTo(data));
        } 
        [Test]
public void GetEventById_ReturnsOneEvent()
{
    // Arrange
    var expectedEventId = 1;
    var expectedEvent = new Event { Id = expectedEventId, Title = "Event1", Description = "Description1", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsListed = true, ImageBanner = "ImageBanner1", SeatsMap = "SeatsMap1" };

    var data = new List<Event> { expectedEvent }.AsQueryable();

    var mockSet = new Mock<DbSet<Event>>();
    mockSet.As<IQueryable<Event>>().Setup(m => m.Provider).Returns(data.Provider);
    mockSet.As<IQueryable<Event>>().Setup(m => m.Expression).Returns(data.Expression);
    mockSet.As<IQueryable<Event>>().Setup(m => m.ElementType).Returns(data.ElementType);
    mockSet.As<IQueryable<Event>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

    mockSet.As<IAsyncEnumerable<Event>>().Setup(d => d.GetAsyncEnumerator(new CancellationToken()))
        .Returns(new TestAsyncEnumerator<Event>(data.GetEnumerator()));

    mockSet.Setup(d => d.Find(It.IsAny<object[]>())).Returns<object[]>(ids => data.FirstOrDefault(d => d.Id == (int)ids[0]));

    _mockContext.Setup(c => c.Events).Returns(mockSet.Object);
    var controller = new EventsController(_mockContext.Object);

    // Act
    var result = controller.GetEventById(expectedEventId);

    // Assert
    Assert.That(result, Is.Not.Null);
    Event? events = result.Result.Value;

    Assert.That(events, Is.Not.Null);
    Assert.That(events, Is.EqualTo(expectedEvent));
}
        [Test]
        public void GetEventById_ReturnsEvent()
        {
            // Arrange
            var data = new List<Event>
            {
                new Event { Id = 1, Title = "Event1", Description = "Description1", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsListed = true, ImageBanner = "ImageBanner1", SeatsMap = "SeatsMap1" },
                new Event { Id = 2, Title = "Event2", Description = "Description2", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsListed = true, ImageBanner = "ImageBanner2", SeatsMap = "SeatsMap2" },
                new Event { Id = 3, Title = "Event3", Description = "Description3", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsListed = true, ImageBanner = "ImageBanner3", SeatsMap = "SeatsMap3" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Event>>();
            
            mockSet.As<IQueryable<Event>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Event>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Event>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Event>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockSet.As<IAsyncEnumerable<Event>>().Setup(m => m.GetAsyncEnumerator(It.IsAny<CancellationToken>())).Returns(new TestAsyncEnumerator<Event>(data.GetEnumerator()));
            mockSet.As<IAsyncEnumerable<Event>>().Setup(d => d.GetAsyncEnumerator(new CancellationToken()))
                .Returns(new TestAsyncEnumerator<Event>(data.GetEnumerator()));
            
            _mockContext.Setup(c => c.Events).Returns(mockSet.Object);
            var controller = new EventsController(_mockContext.Object);
        
            // Act
            var result = controller.GetEventById(1);
            mockSet.Verify(m => m.FindAsync(1), Times.Once());
            
             // Assert
            Assert.That(result, Is.Not.Null);
            Event? events = result.Result.Value;
            
            Assert.That(events, Is.Not.Null);
        }

        [Test]
        public void GetEventById_NotFound()
        {
            // Arrange
            var data = new List<Event>
            {
                new Event { Id = 1, Title = "Event1", Description = "Description1", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsListed = true, ImageBanner = "ImageBanner1", SeatsMap = "SeatsMap1" },
                new Event { Id = 2, Title = "Event2", Description = "Description2", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsListed = true, ImageBanner = "ImageBanner2", SeatsMap = "SeatsMap2" },
                new Event { Id = 3, Title = "Event3", Description = "Description3", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsListed = true, ImageBanner = "ImageBanner3", SeatsMap = "SeatsMap3" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Event>>();
            mockSet.As<IQueryable<Event>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Event>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Event>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Event>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockSet.As<IAsyncEnumerable<Event>>().Setup(m => m.GetAsyncEnumerator(It.IsAny<CancellationToken>())).Returns(new TestAsyncEnumerator<Event>(data.GetEnumerator()));
            mockSet.As<IAsyncEnumerable<Event>>().Setup(d => d.GetAsyncEnumerator(new CancellationToken()))
                .Returns(new TestAsyncEnumerator<Event>(data.GetEnumerator()));
            _mockContext.Setup(c => c.Events).Returns(mockSet.Object);
            
            var controller = new EventsController(_mockContext.Object);

            // Act
            var result = controller.GetEventById(1);

            // Assert
            Assert.That(result, Is.Not.Null);
            Event? events = result.Result.Value;
            
            Assert.That(events, Is.EqualTo(null));
        }
    }
}
