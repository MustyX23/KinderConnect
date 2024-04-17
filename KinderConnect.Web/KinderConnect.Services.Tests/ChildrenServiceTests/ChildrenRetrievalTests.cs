using KinderConnect.Data;
using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Services.Data;
using KinderConnect.Web.ViewModels.Classroom;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using KinderConnect.Data.Models;

namespace KinderConnect.Services.Tests.ChildrenServiceTests
{
    [TestFixture]
    public class ChildrenRetrievalTests
    {
        private DbContextOptions<KinderConnectDbContext> options;
        private KinderConnectDbContext dbContext;
        private IChildService childService;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<KinderConnectDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            dbContext = new KinderConnectDbContext(options);
            childService = new ChildService(dbContext);

            // Seed data
            dbContext.Children.AddRange(new[]
            {
                new Child { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), FirstName = "John", LastName = "Doe", Gender = "Male", DateOfBirth = DateTime.Parse("2019-01-01"), Age = 3, ImageUrl = "image1.jpg", IsActive = true, ParentGuardianId = Guid.Parse("22222222-2222-2222-2222-222222222222"),ParentGuardianContact="1234567899" },
                new Child { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), FirstName = "Jane", LastName = "Doe", Gender = "Female", DateOfBirth = DateTime.Parse("2018-01-01"), Age = 4, ImageUrl = "image2.jpg", IsActive = true, ParentGuardianId = Guid.Parse("22222222-2222-2222-2222-222222222222"),ParentGuardianContact="1234567899" }
            });

            dbContext.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }

        [Test]
        public async Task GetChildByIdAsync_ShouldReturnChild()
        {
            // Act
            var result = await childService.GetChildByIdAsync("11111111-1111-1111-1111-111111111111");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("John", result.FirstName);
        }

        [Test]
        public async Task GetChildByParentIdAsync_ShouldReturnChild()
        {
            // Act
            var result = await childService.GetChildByParentIdAsync("22222222-2222-2222-2222-222222222222");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("John", result.FirstName);
        }

        [Test]
        public async Task GetChildForDetailsByIdAsync_ShouldReturnChildDetails()
        {
            // Act
            var result = await childService.GetChildForDetailsByIdAsync("11111111-1111-1111-1111-111111111111");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("John", result.FirstName);
        }

        [Test]
        public async Task GetChildForEditByIdAsync_ShouldReturnChildForEdit()
        {
            // Act
            var result = await childService.GetChildForEditByIdAsync("11111111-1111-1111-1111-111111111111");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("John", result.FirstName);
        }

        [Test]
        public async Task GetChildrenByParentIdAsync_ShouldReturnChildren()
        {
            // Act
            var result = await childService.GetChildrenByParentIdAsync("22222222-2222-2222-2222-222222222222");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public async Task GetLeaveChildViewModelByIdAsync_ShouldReturnLeaveChildViewModel()
        {
            // Act
            var result = await childService.GetLeaveChildViewModelByIdAsync("11111111-1111-1111-1111-111111111111");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("John", result.FirstName);
        }

        [Test]
        public async Task IsChildAlreadyInAClassroomAsync_ShouldReturnTrue()
        {
            // Arrange
            var model = new JoinClassroomFormModel
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = DateTime.Parse("2019-01-01"),
                ParentGuardianId = "22222222-2222-2222-2222-222222222222",
                ClassroomId = "11111111-1111-1111-1111-111111111111"
            };

            // Act
            var result = await childService.IsChildAlreadyInAClassroomAsync(model, "22222222-2222-2222-2222-222222222222");

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task IsChildAlreadyInAClassroomByIdAsync_ShouldReturnFalse()
        {
            // Act
            var result = await childService.IsChildAlreadyInAClassroomByIdAsync("11111111-1111-1111-1111-111111111111");

            // Assert
            Assert.IsFalse(result);
        }
    }
}
