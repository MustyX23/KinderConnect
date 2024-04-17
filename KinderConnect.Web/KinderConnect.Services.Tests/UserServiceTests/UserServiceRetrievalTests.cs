using KinderConnect.Data.Models;
using KinderConnect.Data;
using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Services.Data;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace KinderConnect.Services.Tests.UserServiceTests
{
    public class UserServiceRetrievalTests
    {
        private DbContextOptions<KinderConnectDbContext> options;
        private KinderConnectDbContext dbContext;
        private IUserService userService;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<KinderConnectDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            dbContext = new KinderConnectDbContext(options);
            userService = new UserService(dbContext);

            // Seed data
            dbContext.Users.AddRange(new[]
            {
                new ApplicationUser { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", PhoneNumber = "1234567890", IsActive = true, Gender = "Male" },
                new ApplicationUser { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), FirstName = "Jane", LastName = "Doe", Email = "jane.doe@example.com", PhoneNumber = "0987654321", IsActive = true, Gender = "Female" }
            });

            dbContext.Teachers.Add(new Teacher { TeacherUserId = Guid.Parse("11111111-1111-1111-1111-111111111111"), ImageUrl = "default.jpg", Summary = "Default summary" });

            dbContext.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }

        [Test]
        public async Task GetFullNameByEmailAsync_ShouldReturnFullName()
        {
            // Act
            var result = await userService.GetFullNameByEmailAsync("john.doe@example.com");

            // Assert
            Assert.AreEqual("John Doe", result);
        }

        [Test]
        public async Task GetFullNameByEmailAsync_ShouldReturnEmptyStringForNonExistingEmail()
        {
            // Act
            var result = await userService.GetFullNameByEmailAsync("nonexisting@example.com");

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public async Task GetFullNameByIdAsync_ShouldReturnFullName()
        {
            // Act
            var result = await userService.GetFullNameByIdAsync("11111111-1111-1111-1111-111111111111");

            // Assert
            Assert.AreEqual("John Doe", result);
        }

        [Test]
        public async Task GetFullNameByIdAsync_ShouldReturnEmptyStringForNonExistingId()
        {
            // Act
            var result = await userService.GetFullNameByIdAsync("33333333-3333-3333-3333-333333333333");

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public async Task AllAsync_ShouldReturnAllActiveUsers()
        {
            // Act
            var result = await userService.AllAsync();

            // Assert
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.All(u => !string.IsNullOrEmpty(u.FullName)));
        }

        [Test]
        public async Task GetUserViewModelByIdAsync_ShouldReturnUserViewModel()
        {
            // Act
            var result = await userService.GetUserViewModelByIdAsync("11111111-1111-1111-1111-111111111111");

            // Assert
            Assert.AreEqual("11111111-1111-1111-1111-111111111111", result.Id);
            Assert.AreEqual("john.doe@example.com", result.Email);
            Assert.AreEqual("John Doe", result.FullName);
            Assert.AreEqual("1234567890", result.PhoneNumber);
        }

        [Test]
        public async Task GetUserViewModelByIdAsync_ShouldReturnNullForNonExistingId()
        {
            // Act
            var result = await userService.GetUserViewModelByIdAsync("33333333-3333-3333-3333-333333333333");

            // Assert
            Assert.IsNull(result);
        }
    }
}
